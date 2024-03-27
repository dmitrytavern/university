CREATE DATABASE lab2;
GO

USE lab2;
GO

-- Disciplines

CREATE TABLE Disciplines (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255)
);

INSERT INTO Disciplines (name)
VALUES
    ('Discipline 1'),
    ('Discipline 2'),
    ('Discipline 3'),
    ('Discipline 4');

-- Teachers

CREATE TABLE Teachers (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
);

INSERT INTO Teachers (name)
VALUES
    ('Teacher 1'),
    ('Teacher 2'),
    ('Teacher 3');

-- Students

CREATE TABLE Students (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
);

INSERT INTO Students (name)
VALUES
    ('Student 1'),
    ('Student 2'),
    ('Student 3'),
    ('Student 4'),
    ('Student 5'),
    ('Student 6'),
    ('Student 7'),
    ('Student 8'),
    ('Student 9'),
    ('Student 10');

-- Reports

CREATE TABLE Reports (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  teacher_id INT FOREIGN KEY REFERENCES Teachers(id),
  discipline_id INT FOREIGN KEY REFERENCES Disciplines(id),
  number INT,
  date DATE
);

INSERT INTO Reports (teacher_id, discipline_id, number, date) VALUES
    (1, 1, 1000, '2022-12-31'),
    (2, 2, 1001, '2022-12-31'),
    (3, 3, 1002, '2022-12-31'),
    (3, 4, 1003, '2022-12-31'),

    (1, 1, 1004, '2023-12-31'),
    (2, 2, 1005, '2023-12-31'),
    (3, 3, 1006, '2023-12-31'),
    (3, 4, 1008, '2023-12-31');

-- StudentsReport

CREATE TABLE StudentsReports (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    report_id INT FOREIGN KEY REFERENCES Reports(id),
    student_id INT FOREIGN KEY REFERENCES Students(id),
    national_grade INT, -- 0-5
	total_grade INT, -- 1-100
    ects_grade VARCHAR(2), -- A, B, C, D, E, FX, F
);

INSERT INTO StudentsReports (report_id, student_id, national_grade, total_grade, ects_grade)
VALUES
    (1, 1, 2, 45, 'Fx'),
    (1, 2, 5, 90, 'A'),
    (1, 3, 5, 95, 'A'),
    (1, 4, 3, 75, 'C'),

    (2, 2, 5, 95, 'A'),
    (2, 3, 5, 90, 'A'),
    (2, 4, 3, 65, 'E'),
    (2, 5, 4, 85, 'B'),

    (3, 6, 3, 70, 'D'),
    (3, 7, 4, 85, 'B'),
    (3, 8, 5, 95, 'A'),

    (4, 9, 5, 95, 'A'),
    (4, 3, 4, 80, 'B'),
    (4, 4, 3, 70, 'D'),
    (4, 5, 4, 90, 'A'),

    -- Next

    (5, 2, 2, 45, 'Fx'),
    (5, 3, 5, 90, 'A'),
    (5, 4, 5, 95, 'A'),
    (5, 5, 3, 75, 'C'),

    (6, 3, 5, 95, 'A'),
    (6, 4, 5, 90, 'A'),
    (6, 5, 3, 65, 'E'),
    (6, 6, 4, 85, 'B'),

    (7, 7, 3, 70, 'D'),
    (7, 8, 4, 85, 'B'),
    (7, 9, 5, 95, 'A'),

    (8, 10, 5, 95, 'A'),
    (8, 4, 4, 80, 'B'),
    (8, 5, 3, 70, 'D'),
    (8, 6, 4, 90, 'A');