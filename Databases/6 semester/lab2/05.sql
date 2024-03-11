USE lab2;

SELECT
  Disciplines.name AS discipline_name,
  AVG(StudentsReport.score) AS average_score
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
INNER JOIN StudentsReport ON Reports.id = StudentsReport.report_id
WHERE MONTH(Reports.date) = MONTH('2024-03-01') AND YEAR(Reports.date) = YEAR('2024-03-01')
GROUP BY Disciplines.name;
