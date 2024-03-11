USE lab2

SELECT
  Teachers.first_name + ' ' + Teachers.last_name AS full_name,
  Disciplines.name AS disciplin_name
FROM Teachers
INNER JOIN Reports ON Teachers.id = Reports.teacher_id
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
INNER JOIN StudentsReport ON Reports.id = StudentsReport.report_id
GROUP BY Teachers.id, Teachers.first_name, Teachers.last_name, Disciplines.id, Disciplines.name
HAVING AVG(StudentsReport.score) >= 60;
