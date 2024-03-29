USE lab4
GO

DROP PROCEDURE IF EXISTS GetTrainCompositionAndCarsByPeriodAndDeparturePoint;
GO

CREATE PROCEDURE GetTrainCompositionAndCarsByPeriodAndDeparturePoint
  @start_date DATE,
  @end_date DATE,
  @departure_point_id INT
AS
  SELECT 
    TrainActs.*,
    TrainActs_CarriageTypes.*
  FROM TrainActs
  INNER JOIN TrainActs_CarriageTypes ON TrainActs.id = TrainActs_CarriageTypes.train_act_id
  INNER JOIN DeparturePoints ON DeparturePoints.id = TrainActs.departure_point_id
  WHERE 
	DeparturePoints.id = @departure_point_id AND
    TrainActs.departure_date BETWEEN @start_date AND @end_date
GO

EXEC GetTrainCompositionAndCarsByPeriodAndDeparturePoint '2023-01-01', '2024-05-01', 2
GO
