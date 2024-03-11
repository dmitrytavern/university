USE lab4
GO

CREATE PROCEDURE GetUsedCarsByPeriodWithCount
  @start_date DATE,
  @end_date DATE
AS
  SELECT 
    AA.carriage_type_id,
    COUNT(*) AS carriages_count
  FROM 
    TrainCompositionAct TCA
  INNER JOIN 
    AppendixAct AA ON TCA.id = AA.composition_train_id
  WHERE 
    TCA.departure_date BETWEEN @start_date AND @end_date
  GROUP BY 
    AA.carriage_type_id
GO

EXEC GetUsedCarsByPeriodWithCount '2023-01-01', '2025-01-01'
GO