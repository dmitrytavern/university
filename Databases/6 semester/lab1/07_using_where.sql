USE db_books;

SELECT * FROM books WHERE author = 'George Orwell' AND price < 10.00;

SELECT * FROM books WHERE NOT author = 'George Orwell';

SELECT * FROM books WHERE author = 'George Orwell' AND NOT price > 10.00;
