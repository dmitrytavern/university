from flask import Flask, request, jsonify
from werkzeug.security import generate_password_hash, check_password_hash
import uuid
from functools import wraps

app = Flask(__name__)

# Application State

users = {
    "admin": {
        'id': 1,
        'password_hash': generate_password_hash("adminpass"),
        'name': 'Адміністратор',
        'email': 'admin@example.com',
        'is_admin': True
    },
    "testuser": {
        'id': 2,
        'password_hash': generate_password_hash("testpass"),
        'name': 'Тестовий Користувач',
        'email': 'test@example.com',
        'is_admin': False
    }
}
sessions = {}
user_id_counter = 3

# Application helpers

def generate_session_token():
    return str(uuid.uuid4())

def get_current_user_username():
    auth_header = request.headers.get('Authorization')
    if auth_header and auth_header.startswith('Bearer '):
        token = auth_header.split(' ')[1]
        return sessions.get(token)
    return None

# New Api decorators

def login_required(f):
    @wraps(f)
    def decorated_function(*args, **kwargs):
        token_header = request.headers.get('Authorization')
        if not token_header or not token_header.startswith('Bearer '):
            return jsonify({"message": "Заголовок авторизації відсутній або недійсний"}), 401
        
        token = token_header.split(' ')[1]
        username = sessions.get(token)

        if not username or username not in users:
            if token in sessions:
                del sessions[token]
            return jsonify({"message": "Недійсний або прострочений токен сесії, або користувач більше не існує"}), 401
        
        request.current_user_username = username
        return f(*args, **kwargs)
    return decorated_function

def admin_required(f):
    @wraps(f)
    @login_required
    def decorated_function(*args, **kwargs):
        username = request.current_user_username
        if not users[username].get('is_admin', False):
            return jsonify({"message": "Потрібен доступ адміністратора"}), 403
        return f(*args, **kwargs)
    return decorated_function

# Application routes

@app.route('/register', methods=['POST'])
def register():
    global user_id_counter
    data = request.get_json()
    if not data or not all(k in data for k in ('username', 'password', 'name', 'email')):
        return jsonify({"message": "Відсутнє ім'я користувача, пароль, ім'я або електронна пошта"}), 400

    username = data['username']
    password = data['password']
    name = data['name']
    email = data['email']

    if not username or not password or not name or not email:
        return jsonify({"message": "Ім'я користувача, пароль, ім'я та електронна пошта не можуть бути порожніми"}), 400
    
    if len(password) < 6:
        return jsonify({"message": "Пароль повинен містити щонайменше 6 символів"}), 400

    if username in users:
        return jsonify({"message": "Ім'я користувача вже існує"}), 409

    hashed_password = generate_password_hash(password)
    
    is_admin = data.get('is_admin', False)

    users[username] = {
        'id': user_id_counter,
        'password_hash': hashed_password,
        'name': name,
        'email': email,
        'is_admin': is_admin
    }
    user_id_counter += 1
    
    user_info_for_response = users[username].copy()
    del user_info_for_response['password_hash']

    return jsonify({"message": "Користувача успішно зареєстровано", "user": user_info_for_response}), 201

@app.route('/login', methods=['POST'])
def login():
    data = request.get_json()
    if not data or not all(k in data for k in ('username', 'password')):
        return jsonify({"message": "Відсутнє ім'я користувача або пароль"}), 400

    username = data['username']
    password = data['password']

    user = users.get(username)
    if not user or not check_password_hash(user['password_hash'], password):
        return jsonify({"message": "Невірне ім'я користувача або пароль"}), 401

    session_token = generate_session_token()
    sessions[session_token] = username
    return jsonify({"message": "Вхід успішний", "session_token": session_token, "is_admin": user.get('is_admin', False)}), 200

@app.route('/logout', methods=['POST'])
@login_required
def logout():
    token = request.headers.get('Authorization').split(' ')[1]
    if token in sessions:
        del sessions[token]
    return jsonify({"message": "Вихід успішний"}), 200

@app.route('/profile', methods=['GET'])
@login_required
def get_profile():
    username = request.current_user_username
    user_data = users.get(username)
    
    profile_info = {
        "id": user_data.get("id"),
        "username": username,
        "name": user_data.get("name"),
        "email": user_data.get("email"),
        "is_admin": user_data.get("is_admin", False)
    }
    return jsonify(profile_info), 200

@app.route('/profile', methods=['PUT'])
@login_required
def update_profile():
    username = request.current_user_username
    data = request.get_json()
    if not data:
        return jsonify({"message": "Дані для оновлення не надано"}), 400

    user_data = users.get(username)

    if 'name' in data:
        if not data['name'].strip():
            return jsonify({"message": "Ім'я не може бути порожнім"}), 400
        user_data['name'] = data['name']
    if 'email' in data:
        if not data['email'].strip():
            return jsonify({"message": "Електронна пошта не може бути порожньою"}), 400
        user_data['email'] = data['email']
    
    users[username] = user_data
    
    updated_profile = {
        "username": username,
        "name": user_data.get("name"),
        "email": user_data.get("email")
    }
    return jsonify({"message": "Профіль успішно оновлено", "profile": updated_profile}), 200

@app.route('/change-password', methods=['POST'])
@login_required
def change_password():
    username = request.current_user_username
    data = request.get_json()

    if not data or not all(k in data for k in ('old_password', 'new_password')):
        return jsonify({"message": "Відсутній старий або новий пароль"}), 400

    old_password = data['old_password']
    new_password = data['new_password']

    if not new_password or len(new_password) < 6:
        return jsonify({"message": "Новий пароль не може бути порожнім і повинен містити щонайменше 6 символів"}), 400

    user_data = users.get(username)
    if not check_password_hash(user_data['password_hash'], old_password):
        return jsonify({"message": "Невірний старий пароль"}), 401

    user_data['password_hash'] = generate_password_hash(new_password)
    users[username] = user_data
    return jsonify({"message": "Пароль успішно змінено"}), 200

@app.route('/users', methods=['GET'])
@admin_required
def get_all_users():
    user_list = []
    for username, data in users.items():
        user_list.append({
            "id": data.get("id"),
            "username": username,
            "name": data.get("name"),
            "email": data.get("email"),
            "is_admin": data.get("is_admin", False)
        })
    return jsonify(user_list), 200

@app.route('/user/<int:user_id_to_delete>', methods=['DELETE'])
@admin_required
def delete_user(user_id_to_delete):
    username_to_delete = None
    user_obj_to_delete = None

    for uname, udata in users.items():
        if udata.get('id') == user_id_to_delete:
            username_to_delete = uname
            user_obj_to_delete = udata
            break
            
    if not username_to_delete:
        return jsonify({"message": f"Користувача з ID {user_id_to_delete} не знайдено"}), 404

    current_admin_username = request.current_user_username
    if users[current_admin_username].get('id') == user_id_to_delete :
        return jsonify({"message": "Адміністратор не може видалити сам себе"}), 403

    del users[username_to_delete]

    tokens_to_remove = [token for token, user_session_username in sessions.items() if user_session_username == username_to_delete]
    for token in tokens_to_remove:
        del sessions[token]

    return jsonify({"message": f"Користувача '{username_to_delete}' (ID: {user_id_to_delete}) успішно видалено"}), 200

@app.route('/', methods=['GET'])
def health_check():
    return jsonify({"status": "API is running", "users_loaded": len(users)}), 200

if __name__ == '__main__':
    print("Starting Flask app...")
    print("Data is stored in memory and will be lost when the server stops.")
    print("Endpoints:")
    print("  GET    /")
    print("  POST   /register         {'username', 'password', 'name', 'email'}")
    print("  POST   /login            {'username', 'password'}")
    print("  POST   /logout           (Requires Auth)")
    print("  GET    /profile          (Requires Auth)")
    print("  PUT    /profile          (Requires Auth) {'name'?, 'email'?}")
    print("  POST   /change-password  (Requires Auth) {'old_password', 'new_password'}")
    print("  GET    /users            (Requires Admin Auth)")
    print("  DELETE /user/<id>        (Requires Admin Auth)")
    app.run(debug=True, port=5002)
