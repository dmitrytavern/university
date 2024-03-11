USE lab4;

CREATE TABLE Regions (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255)
);

CREATE TABLE DeparturePoints (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  region_id INT FOREIGN KEY REFERENCES Regions(id),
  name VARCHAR(255)
);

CREATE TABLE CarriageTypes (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255)
);

CREATE TABLE TrainCompositionAct (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  departure_point_id INT FOREIGN KEY REFERENCES DeparturePoints(id),
  departure_date DATE,
  act_number INT,
  train_number INT
);

CREATE TABLE AppendixAct (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  carriage_type_id INT FOREIGN KEY REFERENCES CarriageTypes(id),
  composition_train_id INT FOREIGN KEY REFERENCES TrainCompositionAct(id),
);
