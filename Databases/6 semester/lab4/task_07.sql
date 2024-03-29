USE lab4
GO

DROP PROCEDURE IF EXISTS GetUsedCarsByPeriodWithCount
GO

CREATE PROCEDURE GetUsedCarsByPeriodWithCount
  @start_date DATE,
  @end_date DATE
AS
  SELECT 
    COUNT(*) AS carriages_count
  FROM TrainActs
  INNER JOIN TrainActs_CarriageTypes ON TrainActs.id = TrainActs_CarriageTypes.train_act_id
  WHERE
    TrainActs.departure_date BETWEEN @start_date AND @end_date
GO

EXEC GetUsedCarsByPeriodWithCount '2023-01-01', '2024-05-01'
GO
