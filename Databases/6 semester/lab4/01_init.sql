CREATE DATABASE lab4;
GO

USE lab4;

DROP TABLE IF EXISTS TrainActs_CarriageTypes
DROP TABLE IF EXISTS TrainActs
DROP TABLE IF EXISTS DeparturePoints
DROP TABLE IF EXISTS CarriageTypes
DROP TABLE IF EXISTS Regions

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

CREATE TABLE TrainActs (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  departure_point_id INT FOREIGN KEY REFERENCES DeparturePoints(id),
  departure_date DATE,
  train_number INT,
  act_number INT
);

CREATE TABLE TrainActs_CarriageTypes (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  train_act_id INT FOREIGN KEY REFERENCES TrainActs(id),
  carriage_type_id INT FOREIGN KEY REFERENCES CarriageTypes(id),
);
