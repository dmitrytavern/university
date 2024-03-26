USE lab2;

-- выбрать всех студентов
-- присоеденить к ним их баллы с каждой ведомости
-- присоеденить к ним данные ведомости
-- выбрать только те записи, где оценка ниже трех и год равее определенному году
-- сгрупировать по id и имени
-- вывести имя и среднюю оценку

SELECT 
  Students.name as student_name,
  AVG(StudentsReports.national_grade) AS average_score
FROM Students
INNER JOIN StudentsReports ON Students.id = StudentsReports.student_id
INNER JOIN Reports ON Reports.id = StudentsReports.report_id
WHERE
	StudentsReports.national_grade < 3 AND
	YEAR(Reports.date) = '2022'
GROUP BY
	Students.id,
	Students.name;

-- выбрать всех студентов
-- присоеденить к ним их баллы с каждой ведомости
-- присоеденить к ним данные ведомости
-- выбрать только те записи год равен определенному году
-- сгрупировать по id и имени
-- выбрать только те записи, которые имеют среднюю оценку 4.5 и выше
-- вывести имя и среднюю оценку

SELECT 
  Students.name as student_name,
  AVG(StudentsReports.national_grade) AS average_score
FROM Students
INNER JOIN StudentsReports ON Students.id = StudentsReports.student_id
INNER JOIN Reports ON Reports.id = StudentsReports.report_id
WHERE
	YEAR(Reports.date) = '2023'
GROUP BY
	Students.id,
	Students.name
HAVING AVG(StudentsReports.national_grade) >= 4.5;