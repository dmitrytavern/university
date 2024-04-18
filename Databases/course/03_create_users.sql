USE insurance_company
GO

CREATE LOGIN admin WITH PASSWORD = 'password';  
GO
CREATE LOGIN client_user WITH PASSWORD = 'password';
GO

CREATE USER admin FOR LOGIN admin;  
GO
CREATE USER client_user FOR LOGIN client_user;  
GO

GRANT SELECT, INSERT, UPDATE, DELETE TO admin;
GO
GRANT SELECT, INSERT, UPDATE TO client_user;
GO

DENY DELETE TO client_user;
GO
