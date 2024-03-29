USE lab6
GO

-- выбрали все требования между двумя датами,
-- присоеденили таблицу со сырьем,
-- подсчитали количество уникальный требований
-- сумировать количество сырья

DROP VIEW IF EXISTS count_of_requirements_between_2023_and_2024;
GO

CREATE VIEW count_of_requirements_between_2023_and_2024
AS
SELECT 
	COUNT(DISTINCT Requirements.id) AS number_of_requirements,
	SUM(RequirementsMaterials.quantity) AS number_of_materials
FROM Requirements
INNER JOIN RequirementsMaterials ON Requirements.id = RequirementsMaterials.requirements_id
WHERE Requirements.date BETWEEN '2023-01-01' AND '2024-01-01';
GO

SELECT * FROM count_of_requirements_between_2023_and_2024;
GO
