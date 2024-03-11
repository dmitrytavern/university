USE db_books;

CREATE TABLE books (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  title VARCHAR(255),
  author VARCHAR(124),
  price MONEY,
  published_date DATE
);

INSERT INTO books (title, author, price, published_date)
VALUES
  ('The Great Gatsby', 'F. Scott Fitzgerald', 10.99, '1925-04-10'),
  ('To Kill a Mockingbird', 'Harper Lee', 12.49, '1960-07-11'),
  ('1984', 'George Orwell', 9.99, '1949-06-08'),
  ('Pride and Prejudice', 'Jane Austen', 8.99, '1813-01-28'),
  ('The Catcher in the Rye', 'J.D. Salinger', 11.99, '1951-07-16'),
  ('Animal Farm', 'George Orwell', 9.49, '1945-08-17'),
  ('Brave New World', 'Aldous Huxley', 11.99, '1932-10-27'),
  ('The Lord of the Rings', 'J.R.R. Tolkien', 15.99, '1954-07-29'),
  ('The Hobbit', 'J.R.R. Tolkien', 12.99, '1937-09-21'),
  ('Harry Potter and the Philosopher''s Stone', 'J.K. Rowling', 14.99, '1997-06-26');