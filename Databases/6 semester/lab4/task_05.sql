USE lab4
GO

DROP PROCEDURE IF EXISTS GetTrainCompositionAndCarsCountByDeparturePoint;
GO

CREATE PROCEDURE GetTrainCompositionAndCarsCountByDeparturePoint
  @departure_point_id INT
AS
  SELECT 
    COUNT(DISTINCT TrainActs.id) AS trains_count,
    COUNT(TrainActs_CarriageTypes.id) AS total_carriages_count
  FROM TrainActs
  INNER JOIN TrainActs_CarriageTypes ON TrainActs.id = TrainActs_CarriageTypes.train_act_id
  INNER JOIN DeparturePoints ON TrainActs.departure_point_id = DeparturePoints.id
  WHERE 
	DeparturePoints.id = @departure_point_id
GO

EXEC GetTrainCompositionAndCarsCountByDeparturePoint 2
GO
