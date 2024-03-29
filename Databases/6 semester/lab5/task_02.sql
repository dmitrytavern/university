USE lab5
GO

DROP TRIGGER IF EXISTS PreventPastDepartures_Insert ON DATABASE
GO

DROP TRIGGER IF EXISTS PreventPastDepartures_Update ON DATABASE
GO

CREATE TRIGGER PreventPastDepartures_Insert
ON TrainActs
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE departure_date < GETDATE()
    )
    BEGIN
        RAISERROR('Cannot insert past departure dates.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

CREATE TRIGGER PreventPastDepartures_Update
ON TrainActs
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE departure_date < GETDATE()
    )
    BEGIN
        RAISERROR('Cannot update to past departure dates.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO