USE lab4
GO

CREATE PROCEDURE GetTrainCompositionAndCarsByPeriodAndDeparturePoint
  @start_date DATE,
  @end_date DATE,
  @departure_point_id INT
AS
  SELECT 
    TCA.*,
    AA.*
  FROM 
    TrainCompositionAct TCA
  INNER JOIN 
    AppendixAct AA ON TCA.id = AA.composition_train_id
  INNER JOIN 
    DeparturePoints DP ON TCA.departure_point_id = DP.id
  WHERE 
    TCA.departure_date BETWEEN @start_date AND @end_date
    AND DP.id = @departure_point_id
GO

EXEC GetTrainCompositionAndCarsByPeriodAndDeparturePoint '2023-01-01', '2025-01-01', 2
GO