Use autobusiness
SELECT
    issued_cars.issue_date,
    issued_cars.return_date,
    cars.mark AS car_name,
    clients.first_name AS client_first_name,
	clients.last_name AS client_last_name
FROM
    issued_cars
INNER JOIN cars ON issued_cars.car_id = cars.id
INNER JOIN clients ON issued_cars.client_id = clients.id;