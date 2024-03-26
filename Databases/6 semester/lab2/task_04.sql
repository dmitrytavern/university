USE lab2;

-- выбираем все отчеты в определенном году
-- присоеденяем к отчету дисциплину и оценки студента
-- выводим название дисциплины и среднюю оценку
-- групируем по дисциплине

SELECT
  Disciplines.name AS discipline_name,
  AVG(StudentsReports.national_grade) AS average_score
FROM Reports
INNER JOIN Disciplines ON Reports.discipline_id = Disciplines.id
INNER JOIN StudentsReports ON StudentsReports.report_id = Reports.id
WHERE YEAR(Reports.date) = '2023'
GROUP BY Disciplines.name;
