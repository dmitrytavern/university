SELECT 
  Students.first_name + ' ' + Students.last_name AS full_name,
  AVG(StudentsReport.score) AS average_score
FROM Students
INNER JOIN StudentsReport ON Students.id = StudentsReport.student_id
INNER JOIN Reports ON StudentsReport.report_id = Reports.id
WHERE StudentsReport.score < 60 AND YEAR(Reports.date) = YEAR('2024-03-01')
GROUP BY Students.id, Students.first_name, Students.last_name;

SELECT
  Students.first_name + ' ' + Students.last_name AS full_name,
  AVG(StudentsReport.score) AS average_score
FROM Students
INNER JOIN StudentsReport ON Students.id = StudentsReport.student_id
INNER JOIN Reports ON StudentsReport.report_id = Reports.id
WHERE YEAR(Reports.date) = YEAR('2024-03-01')
GROUP BY Students.id, Students.first_name, Students.last_name
HAVING AVG(StudentsReport.score) >= 4.5;