USE lab4
GO

-- Create

CREATE PROCEDURE AddAppendixAct
  @carriage_type_id INT,
  @composition_train_id INT
AS
  INSERT INTO AppendixAct (carriage_type_id, composition_train_id) VALUES (@carriage_type_id, @composition_train_id)
GO

-- Delete

CREATE PROCEDURE DeleteAppendixActById
    @appendix_id INT
AS
  DELETE FROM AppendixAct WHERE id = @appendix_id
GO

-- Delete by train id

CREATE PROCEDURE DeleteAppendixActByTrainId
    @composition_train_id INT
AS
  DELETE FROM AppendixAct WHERE composition_train_id = @composition_train_id
GO

-- Update

CREATE PROCEDURE UpdateAppendixAct
  @appendix_act_id INT,
  @new_carriage_type_id VARCHAR(255)
AS
  UPDATE AppendixAct SET carriage_type_id = @new_carriage_type_id WHERE id = @appendix_act_id
GO
