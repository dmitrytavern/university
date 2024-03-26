USE lab2;

-- выбрали все отчеты между двумя датами,
-- присоеденили таблицу с оценками,
-- подсчитали количество уникальный отчетов и студентов

SELECT 
	COUNT(DISTINCT Reports.id) AS number_of_reports,
	COUNT(StudentsReports.student_id) AS number_of_students
FROM Reports
INNER JOIN StudentsReports ON Reports.id = StudentsReports.report_id
WHERE Reports.date BETWEEN '2023-12-31' AND '2023-12-31';