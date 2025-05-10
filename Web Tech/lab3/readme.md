# Web Tech Lab 3

For this lab, you will be creating a CRUD application using the Flask framework and a SQLite database.

## Setup

Run the following commands in your terminal to get started:

```bash
python3 -m venv venv
source venv/bin/activate
pip install Flask flask-sqlalchemy flask-migrate
```

- `python3 -m venv venv` creates a virtual environment for your project.
- `source venv/bin/activate` activates the virtual environment.
- `pip install Flask flask-sqlalchemy flask-migrate` installs the Flask framework with the Flask extensions for working with SQLite databases.

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
