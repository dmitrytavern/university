CREATE DATABASE lab6;
GO

USE lab6;
GO

-- Workshop (склад)

CREATE TABLE Workshops (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255),
);

INSERT INTO Workshops (name)
VALUES
  ('Workshop 1'),
  ('Workshop 2'),
  ('Workshop 3');

-- Warehouse (цех)

CREATE TABLE Warehouses (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255),
);

INSERT INTO Warehouses (name)
VALUES
  ('Warehouse 1'),
  ('Warehouse 2');

-- Materials (метариал/сырье)

CREATE TABLE Materials (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255),
);

INSERT INTO Materials (name)
VALUES
  ('Material 1'),
  ('Material 2'),
  ('Material 3'),
  ('Material 4'),
  ('Material 5'),
  ('Material 6'),
  ('Material 7'),
  ('Material 8'),
  ('Material 9');

-- Requirement (требование по изготовлению)

CREATE TABLE Requirements (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  workshops_id INT FOREIGN KEY REFERENCES Workshops(id),
  warehouses_id INT FOREIGN KEY REFERENCES Warehouses(id),
  number INT,
  date DATE
);

INSERT INTO Requirements (workshops_id, warehouses_id, number, date)
VALUES
  (1, 1, 1000, '2023-05-01'),
  (1, 2, 1001, '2023-06-01'),
  (2, 1, 1002, '2024-01-01'),
  (2, 2, 1003, '2024-02-01'),
  (3, 2, 1004, '2024-03-01');

-- RequirementsMaterials (какое сырье нужно и в каком количестве)

CREATE TABLE RequirementsMaterials (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  materials_id INT FOREIGN KEY REFERENCES Materials(id),
  requirements_id INT FOREIGN KEY REFERENCES Requirements(id),
  quantity INT
);

INSERT INTO RequirementsMaterials (materials_id, requirements_id, quantity)
VALUES
  (1, 1, 1),
  (2, 1, 2),
  (3, 1, 3),
  (4, 1, 4),
  (5, 1, 5),
  (6, 2, 1),
  (7, 2, 2),
  (8, 2, 3),
  (9, 2, 4),
  (1, 3, 1),
  (2, 3, 2),
  (3, 3, 3),
  (4, 3, 4),
  (5, 3, 5),
  (6, 4, 1),
  (7, 4, 2),
  (8, 4, 3),
  (9, 4, 4),
  (1, 5, 1),
  (2, 5, 2),
  (3, 5, 3),
  (4, 5, 4),
  (5, 5, 5);
