USE lab4
GO

-- Create

CREATE PROCEDURE AddTrainCompositionAct
    @departure_point_id INT,
    @departure_date DATE,
    @act_number INT,
    @train_number INT
AS
  INSERT INTO TrainCompositionAct (departure_point_id, departure_date, act_number, train_number) 
  VALUES (@departure_point_id, @departure_date, @act_number, @train_number)
GO

-- Delete

CREATE PROCEDURE DeleteTrainCompositionAct
  @act_id INT
AS
  DELETE FROM TrainCompositionAct WHERE id = @act_id
GO

-- Update

CREATE PROCEDURE UpdateTrainCompositionAct
  @act_id INT,
  @new_departure_point_id INT,
  @new_departure_date DATE,
  @new_act_number INT,
  @new_train_number INT
AS
  UPDATE TrainCompositionAct SET 
  departure_point_id = @new_departure_point_id, 
  departure_date = @new_departure_date, 
  act_number = @new_act_number, 
  train_number = @new_train_number
  WHERE id = @act_id
GO
