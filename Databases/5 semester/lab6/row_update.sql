Use autobusiness

UPDATE clients
SET first_name = 'Dmitry New',
    last_name = 'Tavern New',
    middle_name = 'Middle New',
    address = 'USA',
    phone = '+10937764812'
WHERE id = 1;

UPDATE cars
SET mark = 'New mark name',
    type = 'New type name',
    price = 100500,
    lease_price = 1050
WHERE id = 1;

UPDATE issued_cars
SET issue_date = '2023-11-01',
    return_date = '2023-11-10'
WHERE id = 1;
