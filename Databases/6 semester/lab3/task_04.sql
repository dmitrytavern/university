USE lab3;

-- удалить книги, выпущенные до 1950 года

DELETE FROM books
WHERE id IN (
	SELECT id
	FROM books
	WHERE published_date < '1950-01-01'
);

SELECT * FROM books
