USE lab6
GO

-- выбрали все требования между двумя датами
-- присоеденили таблицы с цехом и требованиями по сырью
-- сгрупировали требования по id цеха
-- подсчитали количество сырья на каждый цех и сырье
-- вывели id цеха, id материала и сколько было использовано этого материала в этом цеху

DROP VIEW IF EXISTS count_of_using_materials;
GO

CREATE VIEW count_of_using_materials
AS
SELECT 
	Warehouses.id AS warehouse_id,
	RequirementsMaterials.materials_id AS material_id,
	SUM(RequirementsMaterials.quantity) AS material_total
FROM Requirements
INNER JOIN Warehouses ON Warehouses.id = Requirements.warehouses_id
INNER JOIN RequirementsMaterials ON Requirements.id = RequirementsMaterials.requirements_id
WHERE
	Requirements.date BETWEEN '2023-01-01' AND '2024-01-01'
GROUP BY
	Warehouses.id,
	RequirementsMaterials.materials_id
GO

-- 

DROP VIEW IF EXISTS count_of_using_materials_max;
GO

-- выбираем все записи из приведущего запроса
-- к каждой записи присоеденяем запись о максимальном использовании материала в определенном цеху
-- выбираем только те записи, где material_total равны
-- присоеденям остальные таблицы для вывода названий цех и материала

CREATE VIEW count_of_using_materials_max
AS
SELECT
	Warehouses.name as warehouses_name,
	Materials.name as material_name,
	count_of_using_materials.material_total
FROM count_of_using_materials
INNER JOIN (
	SELECT 
		warehouse_id,
		MAX(material_total) as material_total
	FROM count_of_using_materials
	GROUP BY
		warehouse_id
) AS axi ON axi.warehouse_id = count_of_using_materials.warehouse_id
INNER JOIN Materials ON Materials.id = count_of_using_materials.material_id
INNER JOIN Warehouses ON Warehouses.id = count_of_using_materials.warehouse_id
WHERE count_of_using_materials.material_total = axi.material_total;
GO

SELECT * FROM count_of_using_materials_max;
GO
