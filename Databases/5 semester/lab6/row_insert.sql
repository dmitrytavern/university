Use autobusiness

INSERT INTO clients (first_name, last_name, middle_name, address, phone)
VALUES
	('Dmitry', 'Tavern', 'Middle', 'Ukraine', '+380654788230'),
  ('John', 'Doe', 'Smith', 'USA', '+12025551234'),
  ('Alice', 'Johnson', 'M', 'Canada', '+14185559999'),
  ('Maria', 'Garcia', 'Lopez', 'Spain', '+34987123456'),
  ('Robert', 'Smith', 'E', 'UK', '+441632987654'),
  ('Anna', 'Kowalski', 'M', 'Poland', '+482211223344'),
  ('Luis', 'Fernandez', 'Gomez', 'Mexico', '+5215566778899'),
  ('Elena', 'Ivanova', 'Petrovna', 'Russia', '+74991234567'),
  ('Ahmed', 'Ali', 'Hassan', 'Egypt', '+201234567890'),
  ('Yuki', 'Suzuki', 'Takahashi', 'Japan', '+81345678901');

INSERT INTO cars (mark, type, price, lease_price)
VALUES
  ('Toyota', 'Sedan', 25000, 350),
  ('Honda', 'SUV', 30000, 400),
  ('Ford', 'Truck', 35000, 500),
  ('Chevrolet', 'Convertible', 45000, 600),
  ('Nissan', 'Hatchback', 20000, 300),
  ('Volkswagen', 'Sedan', 28000, 380),
  ('BMW', 'Luxury', 55000, 700),
  ('Mercedes-Benz', 'SUV', 60000, 750),
  ('Audi', 'Sedan', 50000, 650),
  ('Hyundai', 'Hatchback', 22000, 320),
  ('Kia', 'SUV', 27000, 370),
  ('Mazda', 'Sedan', 23000, 330),
  ('Subaru', 'SUV', 32000, 420),
  ('Lexus', 'Luxury', 58000, 720),
  ('Jeep', 'SUV', 38000, 480),
  ('Tesla', 'Electric', 60000, 750),
  ('Volvo', 'SUV', 45000, 600),
  ('Fiat', 'Compact', 18000, 280),
  ('Mitsubishi', 'SUV', 26000, 350),
  ('Porsche', 'Sports', 80000, 1000);

INSERT INTO issued_cars(car_id, client_id, issue_date, return_date)
VALUES
  (1, 1, '2023-10-01', '2023-10-10'),
  (2, 2, '2023-10-02', '2023-10-11'),
  (3, 3, '2023-10-03', '2023-10-12'),
  (4, 4, '2023-10-04', '2023-10-13'),
  (5, 5, '2023-10-05', '2023-10-14'),
  (6, 6, '2023-10-06', '2023-10-15'),
  (7, 7, '2023-10-07', '2023-10-16'),
  (8, 8, '2023-10-08', '2023-10-17'),
  (9, 9, '2023-10-09', '2023-10-18'),
  (10, 10, '2023-10-10', '2023-10-19'),
  (11, 1, '2023-10-11', '2023-10-20'),
  (12, 2, '2023-10-12', '2023-10-21'),
  (13, 3, '2023-10-13', '2023-10-22'),
  (14, 4, '2023-10-14', '2023-10-23'),
  (15, 5, '2023-10-15', '2023-10-24'),
  (16, 6, '2023-10-16', '2023-10-25'),
  (17, 7, '2023-10-17', '2023-10-26'),
  (18, 8, '2023-10-18', '2023-10-27'),
  (19, 9, '2023-10-19', '2023-10-28'),
  (20, 10, '2023-10-20', '2023-10-29');
