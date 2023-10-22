Use autobusiness

CREATE TABLE cars(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	mark CHAR(255),
	price MONEY,
	lease_price MONEY,
	type CHAR(30),
)

CREATE TABLE clients(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	first_name CHAR(255),
	last_name CHAR(255),
	middle_name CHAR(255),
	address_name CHAR(100),
	phone_name CHAR(10),
)

CREATE TABLE issued_cars(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	car_id INT FOREIGN KEY REFERENCES cars(id),
	client_id INT FOREIGN KEY REFERENCES clients(id),
	issue_date DATE,
	return_date DATE,
)
