USE lab6
GO

DROP VIEW IF EXISTS count_of_using_materials_by_first_warehouses_betweewn_2023_2024;
GO

CREATE VIEW count_of_using_materials_by_first_warehouses_betweewn_2023_2024
AS
SELECT 
	TOP 100 PERCENT
	YEAR(Requirements.date) as Year,
	MONTH(Requirements.date) as Month, 
	SUM(RequirementsMaterials.quantity) AS quantity
FROM Requirements
INNER JOIN RequirementsMaterials ON Requirements.id = RequirementsMaterials.requirements_id
INNER JOIN Materials ON Materials.id = RequirementsMaterials.materials_id
GROUP BY
	YEAR(Requirements.date),
	MONTH(Requirements.date)
ORDER BY Year, Month;
GO

SELECT * FROM count_of_using_materials_by_first_warehouses_betweewn_2023_2024;
GO
