USE lab4
GO

-- Create

CREATE PROCEDURE AddCarriageType
  @name VARCHAR(255)
AS
  INSERT INTO CarriageTypes (name) VALUES (@name)
GO

-- Delete

CREATE PROCEDURE DeleteCarriageType
  @carriage_type_id INT
AS
  DELETE FROM CarriageTypes WHERE id = @carriage_type_id
GO

-- Update

CREATE PROCEDURE UpdateCarriageType
  @carriage_type_id INT,
  @new_name VARCHAR(255)
AS
  UPDATE CarriageTypes SET name = @new_name WHERE id = @carriage_type_id
GO