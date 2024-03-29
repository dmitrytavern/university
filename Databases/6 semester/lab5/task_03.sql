USE lab5
GO

DROP TRIGGER IF EXISTS CheckDuplicateRegion_Insert ON DATABASE
GO

DROP TRIGGER IF EXISTS CheckDuplicateRegion_Update ON DATABASE
GO

CREATE TRIGGER CheckDuplicateRegion_Insert
ON Regions
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Regions r1
        INNER JOIN inserted i ON r1.name = i.name
        WHERE r1.id <> i.id
    )
    BEGIN
        RAISERROR('Region name already exists.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

CREATE TRIGGER CheckDuplicateRegion_Update
ON Regions
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Regions r1
        INNER JOIN inserted i ON r1.name = i.name
        WHERE r1.id <> i.id
    )
    BEGIN
        RAISERROR('Region name already exists.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO