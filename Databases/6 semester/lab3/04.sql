USE lab3;

SELECT COUNT(*) as expensive_books_count FROM Books WHERE price > (SELECT AVG(price) FROM Books);