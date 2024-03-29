USE lab5
GO

DROP TRIGGER IF EXISTS PreventRegionDeletion ON DATABASE
GO

CREATE OR ALTER TRIGGER PreventRegionDeletion
ON Regions
INSTEAD OF DELETE
AS
BEGIN
  SET NOCOUNT ON;

  IF EXISTS (
    SELECT 1
    FROM deleted d
    JOIN DeparturePoints dp ON d.id = dp.region_id
  )
  BEGIN
    RAISERROR('Cannot delete region because it is referenced by one or more departure points.', 16, 1);
  END
  ELSE
  BEGIN
    DELETE FROM Regions WHERE id IN (SELECT id FROM deleted);
  END;
END;
