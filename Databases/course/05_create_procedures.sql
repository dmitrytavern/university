USE insurance_company
GO

CREATE OR ALTER PROCEDURE GetInsuranceCountBetweenDates
  @startDate DATE,
  @endDate DATE
AS
BEGIN
  SELECT COUNT(*) AS InsuranceCount
  FROM insurances
  WHERE start_date >= @startDate AND start_date <= @endDate;
END;
GO

CREATE OR ALTER PROCEDURE GetPaidInsuranceCountBetweenDates
  @startDate DATE,
  @endDate DATE
AS
BEGIN
    SELECT COUNT(*) AS PaidInsuranceCount
    FROM insurances
    WHERE payment IS NOT NULL AND start_date >= @startDate AND start_date <= @endDate;
END;
GO

CREATE OR ALTER PROCEDURE GetInsurancesByEvents
AS
BEGIN
    SELECT events.name AS EventName, COUNT(*) AS InsuranceCount
    FROM insurances
    INNER JOIN events ON insurances.event_id = events.id
    WHERE insurances.event_id IS NOT NULL
    GROUP BY events.name;
END;
GO

CREATE OR ALTER PROCEDURE GetInsuranceCountByUsersBetweenDates
AS
BEGIN
  SELECT clients.name, clients.surname, COUNT(*) AS InsuranceCount
  FROM insurances
  INNER JOIN clients ON insurances.client_id = clients.id
  GROUP BY clients.name, clients.surname;
END;
GO