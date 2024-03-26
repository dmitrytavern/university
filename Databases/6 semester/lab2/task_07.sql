USE lab2

-- выбрать всех учителей
-- присоеденить к ним их ведомости
-- присоеденить к ведомостям дистциплину
-- присоеденить к ведомостям оценки студентов
-- сгрупировать по учителю и дисциплине
-- выбрать только те записи, где средняя значение оценок студентов выше или равно 60
-- вывести имя учителя и дисциплины

SELECT
  Teachers.name AS teacher_name,
  Disciplines.name AS discipline_name
FROM Teachers
INNER JOIN Reports ON Teachers.id = Reports.teacher_id
INNER JOIN Disciplines ON Disciplines.id = Reports.discipline_id
INNER JOIN StudentsReports ON Reports.id = StudentsReports.report_id
GROUP BY
	Teachers.id,
	Teachers.name,
	Disciplines.id,
	Disciplines.name
HAVING AVG(StudentsReports.ects_grade) >= 60;

-- выбрать всех учителей
-- присоеденить к ним их ведомости
-- присоеденить к ведомостям дистциплину
-- присоеденить к ведомостям оценки студентов
-- сгрупировать по учителю и дисциплине
-- выбрать только те записи, где средняя значение оценок студентов ниже 60
-- вывести имя учителя и дисциплины

SELECT
  Teachers.name AS teacher_name,
  Disciplines.name AS discipline_name
FROM Teachers
INNER JOIN Reports ON Teachers.id = Reports.teacher_id
INNER JOIN Disciplines ON Disciplines.id = Reports.discipline_id
INNER JOIN StudentsReports ON Reports.id = StudentsReports.report_id
GROUP BY
	Teachers.id,
	Teachers.name,
	Disciplines.id,
	Disciplines.name
HAVING AVG(StudentsReports.ects_grade) < 60;