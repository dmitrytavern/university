USE lab6
GO

-- выбрали все требования между двумя датами
-- присоеденили таблицу с цехом, где выбрали только один цех
-- присоеденили таблицы со требованиями по сырью и сырье
-- сгрупировали сырье по id и имени
-- подсчитали количество на каждое сырье
-- вывели имя сырья и сколько его было использовано

DROP VIEW IF EXISTS count_of_using_materials_by_first_warehouses_betweewn_2023_2024;
GO

CREATE VIEW count_of_using_materials_by_first_warehouses_betweewn_2023_2024
AS
SELECT 
	Materials.name AS material,
	SUM(RequirementsMaterials.quantity) AS quantity
FROM Requirements
INNER JOIN Warehouses ON Warehouses.id = Requirements.warehouses_id
INNER JOIN RequirementsMaterials ON Requirements.id = RequirementsMaterials.requirements_id
INNER JOIN Materials ON Materials.id = RequirementsMaterials.materials_id
WHERE
	Warehouses.id = 1 AND
	Requirements.date BETWEEN '2023-01-01' AND '2024-01-01'
GROUP BY Materials.id, Materials.name;
GO

SELECT * FROM count_of_using_materials_by_first_warehouses_betweewn_2023_2024;
GO
