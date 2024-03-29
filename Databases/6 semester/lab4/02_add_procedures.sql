USE lab4
GO
 
-- CUD (Create, Update, Delete)

-- CUD Regions

DROP PROCEDURE IF EXISTS AddRegion;
GO

CREATE PROCEDURE AddRegion
  @name VARCHAR(255)
AS
  INSERT INTO Regions (name)
  VALUES (@name)
GO

DROP PROCEDURE IF EXISTS DeleteRegion;
GO

CREATE PROCEDURE DeleteRegion
  @region_id INT
AS
  DELETE FROM Regions
  WHERE id = @region_id
GO

DROP PROCEDURE IF EXISTS UpdateRegion;
GO

CREATE PROCEDURE UpdateRegion
  @region_id INT,
  @new_name VARCHAR(255)
AS
  UPDATE Regions
  SET name = @new_name
  WHERE id = @region_id
GO

-- CUD Departure points

DROP PROCEDURE IF EXISTS AddDeparturePoint;
GO

CREATE PROCEDURE AddDeparturePoint
  @region_id INT,
  @name VARCHAR(255)
AS
  INSERT INTO DeparturePoints (region_id, name)
  VALUES (@region_id, @name)
GO

DROP PROCEDURE IF EXISTS DeleteDeparturePoint;
GO

CREATE PROCEDURE DeleteDeparturePoint
  @departure_point_id INT
AS
  DELETE FROM DeparturePoints
  WHERE id = @departure_point_id
GO

DROP PROCEDURE IF EXISTS UpdateDeparturePoint;
GO

CREATE PROCEDURE UpdateDeparturePoint
  @departure_point_id INT,
  @new_region_id INT,
  @new_name VARCHAR(255)
AS
  UPDATE DeparturePoints
  SET
    region_id = @new_region_id,
    name = @new_name
  WHERE id = @departure_point_id
GO

-- CUR CarriageType

DROP PROCEDURE IF EXISTS AddCarriageType;
GO

CREATE PROCEDURE AddCarriageType
  @name VARCHAR(255)
AS
  INSERT INTO CarriageTypes (name)
  VALUES (@name)
GO

DROP PROCEDURE IF EXISTS DeleteCarriageType;
GO

CREATE PROCEDURE DeleteCarriageType
  @carriage_type_id INT
AS
  DELETE FROM CarriageTypes
  WHERE id = @carriage_type_id
GO

DROP PROCEDURE IF EXISTS UpdateCarriageType;
GO

CREATE PROCEDURE UpdateCarriageType
  @carriage_type_id INT,
  @new_name VARCHAR(255)
AS
  UPDATE CarriageTypes
  SET name = @new_name
  WHERE id = @carriage_type_id
GO

-- CUR TrainAct

DROP PROCEDURE IF EXISTS AddTrainAct;
GO

CREATE PROCEDURE AddTrainAct
    @departure_point_id INT,
    @departure_date DATE,
    @train_number INT,
    @act_number INT
AS
  INSERT INTO TrainActs (
    departure_point_id,
    departure_date,
    train_number,
    act_number
  )
  VALUES (
    @departure_point_id,
    @departure_date,
    @train_number,
    @act_number
  )
GO

DROP PROCEDURE IF EXISTS DeleteTrainAct;
GO

CREATE PROCEDURE DeleteTrainAct
  @act_id INT
AS
  DELETE FROM TrainActs
  WHERE id = @act_id
GO

DROP PROCEDURE IF EXISTS UpdateTrainAct;
GO

CREATE PROCEDURE UpdateTrainAct
  @act_id INT,
  @new_departure_point_id INT,
  @new_departure_date DATE,
  @new_train_number INT,
  @new_act_number INT
AS
  UPDATE TrainActs SET 
    departure_point_id = @new_departure_point_id, 
    departure_date = @new_departure_date, 
    train_number = @new_train_number,
    act_number = @new_act_number
  WHERE id = @act_id
GO

-- CUR TrainActs_CarriageTypes

DROP PROCEDURE IF EXISTS AddTrainActs_CarriageTypes;
GO

CREATE PROCEDURE AddTrainActs_CarriageTypes
  @train_act_id INT,
  @carriage_type_id INT
AS
  INSERT INTO TrainActs_CarriageTypes (
    train_act_id,
    carriage_type_id
  )
  VALUES (
    @train_act_id,
    @carriage_type_id
  )
GO

DROP PROCEDURE IF EXISTS DeleteTrainActs_CarriageTypes;
GO

CREATE PROCEDURE DeleteTrainActs_CarriageTypes
    @appendix_id INT
AS
  DELETE FROM TrainActs_CarriageTypes
  WHERE id = @appendix_id
GO

DROP PROCEDURE IF EXISTS DeleteTrainActs_CarriageTypesByTrainId;
GO

CREATE PROCEDURE DeleteTrainActs_CarriageTypesByTrainId
    @train_act_id INT
AS
  DELETE FROM TrainActs_CarriageTypes
  WHERE train_act_id = @train_act_id
GO

DROP PROCEDURE IF EXISTS UpdateTrainActs_CarriageTypes;
GO

CREATE PROCEDURE UpdateTrainActs_CarriageTypes
  @appendix_act_id INT,
  @new_carriage_type_id VARCHAR(255)
AS
  UPDATE TrainActs_CarriageTypes
  SET carriage_type_id = @new_carriage_type_id
  WHERE id = @appendix_act_id
GO
