USE lab2;

-- Disciplines

CREATE TABLE Disciplines (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255)
);

INSERT INTO Disciplines (name)
VALUES
    ('Mathematics'),
    ('Physics'),
    ('Chemistry'),
    ('Biology');

-- Students

CREATE TABLE Students (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    middle_name VARCHAR(255)
);

INSERT INTO Students (first_name, last_name, middle_name)
VALUES
    ('John', 'Doe', 'Smith'),
    ('Alice', 'Johnson', 'Marie'),
    ('Michael', 'Brown', 'Anthony'),
    ('Emma', 'Davis', 'Elizabeth'),
    ('Hello', 'World', 'Student');

-- Teachers

CREATE TABLE Teachers (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    middle_name VARCHAR(255)
);

INSERT INTO Teachers  (first_name, last_name, middle_name)
VALUES
    ('Professor', 'Johnson', 'Andrew'),
    ('Dr.', 'Miller', 'Jessica'),
    ('Professor', 'Williams', 'David'),
    ('Dr.', 'Martinez', 'Maria');

-- Reports

CREATE TABLE Reports (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  teacher_id INT FOREIGN KEY REFERENCES Teachers(id),
  discipline_id INT FOREIGN KEY REFERENCES Disciplines(id),
  number INT,
  date DATE
);

INSERT INTO Reports (teacher_id, discipline_id, number, date)
VALUES
  (1, 1, 1001, '2024-03-10'),
  (2, 2, 1002, '2024-03-11'),
  (3, 3, 1003, '2024-03-12'),
  (4, 4, 1004, '2024-03-13');

-- StudentsReport

CREATE TABLE StudentsReport (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    report_id INT FOREIGN KEY REFERENCES Reports(id),
    student_id INT FOREIGN KEY REFERENCES Students(id),
    national_grade VARCHAR(10),
    ECTS_grade VARCHAR(10),
    score INT
);

INSERT INTO StudentsReport (report_id, student_id, national_grade, ECTS_grade, score)
VALUES
  (1, 1, 'A', 'A', 95),
  (1, 2, 'B', 'B', 85),
  (1, 3, 'C', 'C', 75),
  (1, 4, 'B', 'B', 85),
  (2, 1, 'B', 'B', 85),
  (2, 2, 'A', 'A', 95),
  (2, 3, 'A', 'A', 95),
  (2, 4, 'C', 'C', 75),
  (3, 1, 'C', 'C', 75),
  (3, 2, 'B', 'B', 85),
  (3, 3, 'B', 'B', 85),
  (3, 4, 'A', 'A', 95),
  (4, 1, 'A', 'A', 95),
  (4, 2, 'A', 'A', 95),
  (4, 3, 'B', 'B', 85),
  (4, 4, 'C', 'C', 75),
  (1, 5, 'D', 'D', 55),
  (2, 5, 'D', 'D', 55),
  (3, 5, 'F', 'F', 45),
  (4, 5, 'D', 'D', 55);
