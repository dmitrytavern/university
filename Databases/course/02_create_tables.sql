USE insurance_company
GO

CREATE TABLE events (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  price MONEY NOT NULL,
  name VARCHAR(128) NOT NULL,
  description VARCHAR(1024),
);

CREATE TABLE clients (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(20) NOT NULL,
  surname VARCHAR(24) NOT NULL,
  email VARCHAR(320) NOT NULL,
  phone VARCHAR(15) NOT NULL,
  sex VARCHAR(6) NOT NULL,
  birthday DATE NOT NULL,
  password VARCHAR(64) NOT NULL,
  passport_expiry DATE NOT NULL,
  passport_record_no VARCHAR(14) NOT NULL,
  passport_document_no VARCHAR(9) NOT NULL,
);

CREATE TABLE insurances (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  event_id INT FOREIGN KEY REFERENCES events(id),
  client_id INT NOT NULL FOREIGN KEY REFERENCES clients(id),
  sum MONEY NOT NULL,
  price MONEY NOT NULL,
  payment MONEY,
  start_date DATE NOT NULL,
  end_date DATE NOT NULL,
);

CREATE TABLE insurances_events (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  event_id INT NOT NULL FOREIGN KEY REFERENCES events(id),
  insurance_id INT NOT NULL FOREIGN KEY REFERENCES insurances(id),
);

CREATE TABLE admins (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(64) NOT NULL,
  login VARCHAR(64) NOT NULL UNIQUE,
  password VARCHAR(64) NOT NULL,
);
