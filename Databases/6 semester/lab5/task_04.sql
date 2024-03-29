USE lab5
GO

DROP TRIGGER IF EXISTS PreventCurrentYearDeletion ON DATABASE
GO

CREATE OR ALTER TRIGGER PreventCurrentYearDeletion
ON TrainActs
AFTER DELETE
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @CurrentYear INT;
  SELECT @CurrentYear = YEAR(GETDATE());

  IF EXISTS (
      SELECT 1
      FROM deleted
      WHERE YEAR(departure_date) = @CurrentYear
  )
  BEGIN
      RAISERROR('Cannot delete records with departure date in the current year.', 16, 1);
      ROLLBACK TRANSACTION;
  END
END
