USE lab2;

SELECT 
	COUNT(DISTINCT Reports.id) AS number_of_reports,
	COUNT(StudentsReport.student_id) AS number_of_students
FROM Reports
INNER JOIN StudentsReport ON Reports.id = StudentsReport.report_id
WHERE Reports.date BETWEEN '2024-03-10' AND '2024-03-11';