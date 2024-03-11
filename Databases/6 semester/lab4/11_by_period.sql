USE lab4
GO

DROP PROCEDURE GetTrainCompositionCountByPeriod
GO

CREATE PROCEDURE GetTrainCompositionCountByPeriod
  @start_date DATE,
  @end_date DATE
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
    WHERE 
      TrainCompositionAct.departure_date BETWEEN @start_date AND @end_date
    GROUP BY 
      TrainCompositionAct.id
  ) AS CompositionSummary
GO

EXEC GetTrainCompositionCountByPeriod '2023-01-01', '2025-01-01'
