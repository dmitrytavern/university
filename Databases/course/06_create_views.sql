USE insurance_company
GO

CREATE OR ALTER VIEW ActiveInsurances AS
SELECT *
FROM insurances
WHERE end_date > GETDATE() AND event_id IS NULL;
GO

CREATE OR ALTER VIEW InactiveInsurances AS
SELECT *
FROM insurances
WHERE end_date < GETDATE() AND event_id IS NULL;
GO

CREATE OR ALTER VIEW RealizedInsurances AS
SELECT *
FROM insurances
WHERE event_id IS NOT NULL;
GO

CREATE OR ALTER VIEW TotalInsurancePrice AS
SELECT SUM(price) AS total_price
FROM insurances;
GO

CREATE OR ALTER VIEW TotalPayments AS
SELECT SUM(payment) AS total_payments
FROM insurances
WHERE payment IS NOT NULL;
GO

CREATE OR ALTER VIEW Income AS
SELECT
	(SELECT SUM(price) FROM insurances) - 
	(SELECT SUM(payment) FROM insurances WHERE payment IS NOT NULL) AS total_income;
GO
