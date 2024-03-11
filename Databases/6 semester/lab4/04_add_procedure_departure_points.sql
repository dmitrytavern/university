USE lab4
GO

-- Create

CREATE PROCEDURE AddDeparturePoint
  @region_id INT,
  @name VARCHAR(255)
AS
  INSERT INTO DeparturePoints (region_id, name) VALUES (@region_id, @name)
GO

-- Delete

CREATE PROCEDURE DeleteDeparturePoint
  @departure_point_id INT
AS
  DELETE FROM DeparturePoints WHERE id = @departure_point_id
GO

-- Update

CREATE PROCEDURE UpdateDeparturePoint
  @departure_point_id INT,
  @new_region_id INT,
  @new_name VARCHAR(255)
AS
  UPDATE DeparturePoints SET region_id = @new_region_id, name = @new_name WHERE id = @departure_point_id
GO