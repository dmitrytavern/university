USE lab6
GO

-- выбрали все требования между двумя датами,
-- присоеденили таблицу со сырьем,
-- подсчитали количество уникальный требований
-- сумировать количество сырья

DROP VIEW IF EXISTS count_of_using_materials_by_warehouses;
GO

CREATE VIEW count_of_using_materials_by_warehouses
AS
SELECT 
	Warehouses.name AS warehouse_name,
	COUNT(DISTINCT Requirements.id) AS number_of_requirements,
	SUM(RequirementsMaterials.quantity) AS number_of_materials
FROM Requirements
INNER JOIN Warehouses ON Warehouses.id = Requirements.warehouses_id
INNER JOIN RequirementsMaterials ON Requirements.id = RequirementsMaterials.requirements_id
GROUP BY Warehouses.id, Warehouses.name;
GO

SELECT * FROM count_of_using_materials_by_warehouses;
GO
