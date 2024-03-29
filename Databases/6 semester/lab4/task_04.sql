USE lab4
GO

DROP PROCEDURE IF EXISTS GetTrainCompositionCountByPeriod
GO

CREATE PROCEDURE GetTrainCompositionCountByPeriod
  @start_date DATE,
  @end_date DATE
AS
  SELECT 
    COUNT(DISTINCT TrainActs.id) AS trains_count,
    COUNT(TrainActs_CarriageTypes.id) AS total_carriages_count
  FROM TrainActs
  INNER JOIN TrainActs_CarriageTypes ON TrainActs.id = TrainActs_CarriageTypes.train_act_id
  WHERE 
	TrainActs.departure_date BETWEEN @start_date AND @end_date
GO

EXEC GetTrainCompositionCountByPeriod '2023-01-01', '2024-04-13'
