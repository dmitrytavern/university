USE lab3;

-- выбрать все записи, где цена равняется максимальной цене

SELECT *
FROM Books
WHERE price = (
  SELECT MAX(price) FROM Books
);

-- подсчитать количество книг, которые дороже среднего значения

SELECT
	COUNT(*) as expensive_books_count
FROM Books
WHERE price > (
	SELECT AVG(price) FROM Books
);
