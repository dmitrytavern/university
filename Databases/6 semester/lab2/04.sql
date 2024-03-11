USE lab2;

SELECT Reports.number, Reports.date, Disciplines.name AS discipline_name
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
WHERE Reports.teacher_id = 1 AND Reports.date BETWEEN '2024-01-01' AND '2024-12-31';