from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate
from flask_jwt_extended import (JWTManager, jwt_required, create_access_token, get_jwt_identity, get_jwt)
from werkzeug.security import generate_password_hash, check_password_hash
from datetime import timedelta
from functools import wraps

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///app.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
app.config['JWT_SECRET_KEY'] = 'super-secret-key'
app.config['JWT_ACCESS_TOKEN_EXPIRES'] = timedelta(hours=24)

db = SQLAlchemy(app)
jwt = JWTManager(app)
migrate = Migrate(app, db)

class User(db.Model):
  __tablename__ = 'users'

  id = db.Column(db.Integer, primary_key=True)
  username = db.Column(db.String(80), unique=True, nullable=False)
  password_hash = db.Column(db.String(128), nullable=False)
  role = db.Column(db.String(20), default='user')
  created_at = db.Column(db.DateTime, default=db.func.now())

  def set_password(self, password):
    self.password_hash = generate_password_hash(password)

  def check_password(self, password):
    return check_password_hash(self.password_hash, password)

  def __repr__(self):
    return f'<User {self.username}>'

@app.route('/register', methods=['POST'])
def register():
  data = request.get_json()
  if User.query.filter_by(username=data['username']).first():
    return jsonify({'message': 'Username already exists'}), 400
  user = User(username=data['username'])
  user.set_password(data['password'])
  user.role = data.get('role', 'user')
  db.session.add(user)
  db.session.commit()
  return jsonify({'message': 'User registered, successfully'}), 201

@app.route('/login', methods=['POST'])
def login():
  data = request.get_json()
  user = User.query.filter_by(username=data['username']).first()

  if not user or not user.check_password(data['password']):
    return jsonify({'message': 'Invalid credentials'}), 401

  access_token = create_access_token(
    identity=user.username,
    additional_claims={'role': user.role}
  )

  return jsonify(access_token=access_token), 200

@app.route('/protected', methods=['GET'])
@jwt_required()
def protected():
  current_user = get_jwt_identity()
  return jsonify(logged_in_as=current_user), 200

def admin_required(fn):
  @wraps(fn)
  def wrapper(*args, **kwargs):
    claims = get_jwt()
    if claims['role'] != 'admin':
      return jsonify({'message': 'Admins only!'}), 403
    return fn(*args, **kwargs)
  return wrapper

@app.route('/admin', methods=['GET'])
@jwt_required()
@admin_required
def admin_only():
  return jsonify({'message': 'Welcome admin!'}), 200

if __name__ == '__main__':
  app.run(debug=True, port=5002)
