USE lab4
GO

CREATE PROCEDURE GetTrainCompositionAndCarsCountByDeparturePoint
  @departure_point_id INT
AS
  SELECT 
    COUNT(*) AS trains_count,
    SUM(CarriageCount) AS total_carriages_count
  FROM (
    SELECT
      TrainCompositionAct.id,
      COUNT(*) AS CarriageCount
    FROM 
      TrainCompositionAct
    INNER JOIN 
      AppendixAct ON TrainCompositionAct.id = AppendixAct.composition_train_id
    INNER JOIN 
      DeparturePoints ON TrainCompositionAct.departure_point_id = DeparturePoints.id
    WHERE 
      DeparturePoints.id = @departure_point_id
    GROUP BY 
      TrainCompositionAct.id
  ) AS CompositionSummary
GO

EXEC GetTrainCompositionAndCarsCountByDeparturePoint 1
GO