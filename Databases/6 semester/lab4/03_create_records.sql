USE lab4

EXEC AddRegion 'Region 1'
EXEC AddRegion 'Region 2'
EXEC AddRegion 'Region 3'

EXEC AddDeparturePoint 1, 'Point 1'
EXEC AddDeparturePoint 1, 'Point 2'
EXEC AddDeparturePoint 2, 'Point 3'
EXEC AddDeparturePoint 3, 'Point 4'

EXEC AddCarriageType 'Carriage type 1'
EXEC AddCarriageType 'Carriage type 2'
EXEC AddCarriageType 'Carriage type 3'

EXEC AddTrainAct 1, '2023-03-11', 1000, 101
EXEC AddTrainAct 1, '2023-04-11', 1010, 111
EXEC AddTrainAct 2, '2024-04-12', 1001, 102
EXEC AddTrainAct 3, '2024-05-13', 1002, 103
EXEC AddTrainAct 4, '2024-06-13', 1003, 104

EXEC AddTrainActs_CarriageTypes 1, 1
EXEC AddTrainActs_CarriageTypes 2, 1
EXEC AddTrainActs_CarriageTypes 3, 2
EXEC AddTrainActs_CarriageTypes 4, 3
EXEC AddTrainActs_CarriageTypes 5, 2
EXEC AddTrainActs_CarriageTypes 3, 1
