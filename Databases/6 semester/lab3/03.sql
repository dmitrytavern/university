USE lab3;

SELECT * FROM Books WHERE price = (SELECT MAX(price) FROM Books);
