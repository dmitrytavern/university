USE lab2;

-- выбираем все отчеты
-- присоеденяем к отчету дисциплину и оценки студента
-- выбираем только те записи, где оценка студента меньше 60 и указан год
-- групируем по названию дисциплины

SELECT
	Disciplines.name AS discipline_name
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
INNER JOIN StudentsReports ON Reports.id = StudentsReports.report_id
WHERE
	StudentsReports.ects_grade < 60 AND
	YEAR(Reports.date) = '2022'
GROUP BY Disciplines.name;