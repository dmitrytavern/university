USE lab2;

-- выбрать отчеты определенного преподавателя в определенный период
-- присоеденить дисциплину к отчету
-- выбрать только дату, номер отчета и название дисциплины

SELECT
	Reports.date as report_date,
	Reports.number as report_number,
	Disciplines.name AS discipline_name
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
WHERE
	Reports.teacher_id = 3 AND
	Reports.date BETWEEN '2022-12-31' AND '2023-12-31';