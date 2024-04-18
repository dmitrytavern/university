USE insurance_company
GO

CREATE OR ALTER TRIGGER CheckUserAge
ON clients
AFTER INSERT, UPDATE
AS
BEGIN
  DECLARE @minAge INT
  SET @minAge = 18

  IF EXISTS (
    SELECT 1
    FROM inserted
    WHERE DATEDIFF(YEAR, birthday, GETDATE()) < @minAge
  )
  BEGIN
    RAISERROR ('Client`s age must be at least 18 years old.', 16, 1)
    ROLLBACK TRANSACTION
  END
END
GO

CREATE OR ALTER TRIGGER CheckUserPassportExpiry
ON clients
AFTER INSERT, UPDATE
AS
BEGIN
  IF EXISTS (
    SELECT 1
    FROM inserted
    WHERE passport_expiry < GETDATE()
  )
  BEGIN
    RAISERROR ('Passport expiry date must be greater than the current date.', 16, 1)
    ROLLBACK TRANSACTION
  END
END
GO

CREATE OR ALTER TRIGGER CheckUserSexValue
ON clients
AFTER INSERT, UPDATE
AS
BEGIN
  IF EXISTS (
    SELECT 1
    FROM inserted
    WHERE sex NOT IN ('male', 'female')
  )
  BEGIN
    RAISERROR ('Sex value must be either "male" or "female".', 16, 1)
    ROLLBACK TRANSACTION
  END
END
GO

CREATE OR ALTER TRIGGER PreventEditEventsForClientUser
ON events
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
  IF EXISTS (
    SELECT 1
    FROM (
        SELECT SUSER_NAME() AS username
        UNION ALL
        SELECT SUSER_NAME() AS username
        ) AS usercheck
    WHERE username = 'client_user'
  )
  BEGIN
    PRINT 'You cannot perform this action as a client user!'
    ROLLBACK TRANSACTION
  END
END
GO

CREATE OR ALTER TRIGGER PreventEditAdminsForClientUser
ON admins
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
  IF EXISTS (
    SELECT 1
    FROM (
        SELECT SUSER_NAME() AS username
        UNION ALL
        SELECT SUSER_NAME() AS username
        ) AS usercheck
    WHERE username = 'client_user'
  )
  BEGIN
    PRINT 'You cannot perform this action as a client user!'
    ROLLBACK TRANSACTION
  END
END
GO
