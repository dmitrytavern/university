# Web Tech Lab 5

For this lab, you will be creating a backend and frontend on React.js.

## Setup

Run the following commands in your terminal to get started:

```bash
python3 -m venv venv
source venv/bin/activate
pip install Flask flask-sqlalchemy flask-migrate
```

- `python3 -m venv venv` creates a virtual environment for your project.
- `source venv/bin/activate` activates the virtual environment.
- `pip install Flask flask-sqlalchemy flask-migrate flask-jwt-extended passlib flask-cors` installs the Flask framework with the Flask extensions for working with SQLite databases.

Next:

```bash
flask shell
>>> from app import db
>>> db.create_all()
>>> exit()
```

- `flask shell` opens a Python shell with the Flask application context.
- `from app import db` imports the database object from the Flask application.
- `db.create_all()` creates the database tables.
- `exit()` exits the Python shell.

Next:

```bash
flask db init
flask db migrate -m "Initial migration"
flask db upgrade
```

- `flask db init` initializes the database migrations.
- `flask db migrate -m "Initial migration"` creates a migration file.
- `flask db upgrade` applies the migration to the database.


Next:

```bash
cd client
npm install
npm run start
```

- `cd client` changes the current working directory to the client directory.
- `npm install` installs the dependencies for the client.
- `npm run start` starts the client.
