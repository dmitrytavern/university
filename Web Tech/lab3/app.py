from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///app.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db = SQLAlchemy(app)
migrate = Migrate(app, db)

class Task(db.Model):
  id = db.Column(db.Integer, primary_key=True)
  title = db.Column(db.String(100), nullable=False)
  description = db.Column(db.Text)
  status = db.Column(db.String(20), default='new')
  created_at = db.Column(db.DateTime, default=db.func.now())
  updated_at = db.Column(db.DateTime, default=db.func.now(), onupdate=db.func.now())

  def __repr__(self):
    return f'<Task {self.title}>'

# Create
@app.route('/tasks', methods=['POST'])
def create_task():
  data = request.get_json()
  new_task = Task(
    title=data['title'],
    description=data.get('description', ''),
    status=data.get('status', 'new')
  )
  db.session.add(new_task)
  db.session.commit()
  return jsonify({'message': 'Task created', 'id': new_task.id}), 201

# Read (all)
@app.route('/tasks', methods=['GET'])
def get_tasks():
  tasks = Task.query.all()
  return jsonify([{
  'id': task.id,
  'title': task.title,
  'status': task.status
  } for task in tasks])

# Read (single)
@app.route('/tasks/<int:task_id>', methods=['GET'])
def get_task(task_id):
  task = Task.query.get_or_404(task_id)
  return jsonify({
    'id': task.id,
    'title': task.title,
    'description': task.description,
    'status': task.status,
    'created_at': task.created_at.isoformat()
  })

# Update
@app.route('/tasks/<int:task_id>', methods=['PUT'])
def update_task(task_id):
  task = Task.query.get_or_404(task_id)
  data = request.get_json()
  task.title = data.get('title', task.title)
  task.description = data.get('description', task.description)
  task.status = data.get('status', task.status)
  db.session.commit()
  return jsonify({'message': 'Task updated'})

# Delete
@app.route('/tasks/<int:task_id>', methods=['DELETE'])
def delete_task(task_id):
  task = Task.query.get_or_404(task_id)
  db.session.delete(task)
  db.session.commit()
  return jsonify({'message': 'Task deleted'})

if __name__ == '__main__':
  app.run(debug=True, port=5002)
