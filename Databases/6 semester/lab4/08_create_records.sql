USE lab4

EXEC AddRegion 'Kyiv Oblast'
EXEC AddRegion 'Lviv Oblast'
EXEC AddRegion 'Kharkiv Oblast'

EXEC AddDeparturePoint 1, 'Kyiv'
EXEC AddDeparturePoint 1, 'Bila Tserkva'
EXEC AddDeparturePoint 2, 'Lviv'
EXEC AddDeparturePoint 2, 'Uzhhorod'
EXEC AddDeparturePoint 3, 'Kharkiv'
EXEC AddDeparturePoint 3, 'Poltava'

EXEC AddCarriageType 'Food'
EXEC AddCarriageType 'Military'
EXEC AddCarriageType 'Cargo'

EXEC AddTrainCompositionAct 1, '2024-03-11', 12345, 101
EXEC AddTrainCompositionAct 2, '2024-03-12', 12346, 102
EXEC AddTrainCompositionAct 3, '2024-03-13', 12347, 103

EXEC AddAppendixAct 1, 1
EXEC AddAppendixAct 2, 1
EXEC AddAppendixAct 3, 2
