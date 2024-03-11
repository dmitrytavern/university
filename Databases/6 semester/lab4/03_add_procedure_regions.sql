USE lab4
GO

-- Create

CREATE PROCEDURE AddRegion
  @name VARCHAR(255)
AS
INSERT INTO Regions (name) VALUES (@name)
GO

-- Delete

CREATE PROCEDURE DeleteRegion
  @region_id INT
AS
DELETE FROM Regions WHERE id = @region_id
GO

-- Update

CREATE PROCEDURE UpdateRegion
  @region_id INT,
  @new_name VARCHAR(255)
AS
UPDATE Regions SET name = @new_name WHERE id = @region_id
GO
