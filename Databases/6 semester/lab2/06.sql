USE lab2;

SELECT DISTINCT Disciplines.name AS discipline_name
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
INNER JOIN StudentsReport ON Reports.id = StudentsReport.report_id
WHERE StudentsReport.score < 60 AND YEAR(Reports.date) = YEAR('2024-03-01');