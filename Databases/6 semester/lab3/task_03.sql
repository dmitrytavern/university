USE lab3;

-- повысить цену на 20% для книг, выпущенных до 1950 года

UPDATE books
SET price = price * 1.20
WHERE id IN (
	SELECT id
	FROM books
	WHERE published_date < '1950-01-01'
);

SELECT * FROM books
