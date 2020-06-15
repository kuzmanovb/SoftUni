
--------------------------------- Section 1. DDL --------------------------------------------------

CREATE DATABASE Airport
GO
USE Airport

-- 1. Database Design -----------------------------------------------------------------------------

CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME2,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL, 
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(10, 2)
)

--------------------------------- Section 2. DML ---------------------------------------------------

-- 2. Insert ---------------------------------------------------------------------------------------

INSERT INTO Planes([Name], Seats, [Range])
VALUES
('Airbus 336',	112,	5132),
('Airbus 330',	432, 	5325),
('Boeing 369',	231,	2355),
('Stelt 297',	254,	2143),
('Boeing 338', 	165,	5111),
('Airbus 558', 	387,	1342),
('Boeing 128', 	345,	5541)


INSERT INTO LuggageTypes ([Type])
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

-- 3. Update --------------------------------------------------------------------------------------

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = 41

-- 4. Delete --------------------------------------------------------------------------------------

DELETE FROM Tickets
WHERE FlightId = 30 

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim' 

------------------------------- Section 3. Querying -----------------------------------------------

-- 5. Trips ---------------------------------------------------------------------------------------

SELECT Origin, Destination FROM Flights
ORDER BY Origin, Destination

-- 6. The "Tr" Planes -----------------------------------------------------------------------------

SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

-- 7. Flight Profits ------------------------------------------------------------------------------

SELECT FlightId, SUM(Price) AS Price FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC, FlightId

-- 8. Passengers and Prices -----------------------------------------------------------------------

SELECT TOP(10) p.FirstName, p.LastName, t.Price FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.FirstName, p.LastName 

-- 9. Most Used Luggage's -------------------------------------------------------------------------

 SELECT lt.Type, COUNT(*) FROM Passengers AS p
 JOIN Luggages AS l ON p.Id = l.PassengerId
 JOIN LuggageTypes As lt ON l.LuggageTypeId = lt.Id 
 GROUP BY lt.Type
 ORDER BY COUNT(*) DESC, lt.Type

 -- 10.	Passenger Trips ---------------------------------------------------------------------------
 
 SELECT 
	p.FirstName + ' ' + p.LastName AS [Full Name],
	f.Origin,
	f.Destination
 FROM Passengers AS p
 JOIN Tickets AS t ON p.Id = t.PassengerId
 JOIN Flights AS f ON f.Id = t.FlightId
 ORDER BY [Full Name],f.Origin, f.Destination

 -- 11.	Non Adventures People ---------------------------------------------------------------------

 SELECT p.FirstName, p.LastName, p.Age  FROM Passengers AS p
 LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
 WHERE t.Id IS NULL
 ORDER BY p.Age DESC, p.FirstName, p.LastName

 -- 12.	Lost Luggage's -----------------------------------------------------------------------------

 SELECT PassportId, [Address] FROM Passengers AS p
 LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
 WHERE l.PassengerId IS NULL
 ORDER BY PassportId, [Address]

 -- 13.	Count of Trips -----------------------------------------------------------------------------

 SELECT 
	 p.FirstName AS [First Name], 
	 p.LastName AS [Last Name], 
	 COUNT(t.Id) AS [Total Trips] FROM Passengers AS p
 LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
 GROUP BY p.FirstName, p.LastName
 ORDER BY [Total Trips] DESC, p.FirstName, p.LastName

 -- 14.	Full Info ----------------------------------------------------------------------------------

 SELECT 
	p.FirstName + ' ' + LastName AS [Full Name],
	pl.[Name] AS [Plane Name],
	f.Origin + ' - ' + f.Destination AS Trip,
	lt.[Type] AS [Luggage Type] 
 FROM Passengers AS p
 JOIN Tickets AS t ON t.PassengerId = p.Id
 JOIN Flights AS f ON t.FlightId = f.Id
 JOIN Luggages AS l ON t.LuggageId = l.Id
 JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
 JOIN Planes AS pl ON pl.Id = f.PlaneId
 ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]  

 -- 15.	Most Expensive Trips -----------------------------------------------------------------------
 
 SELECT FirstName, LastName, Destination, Price
 FROM
	 (SELECT 
		 p.FirstName, 
		 p.LastName, 
		 f.Destination, 
		 t.Price , 
		 DENSE_RANK() OVER (PARTITION BY p.FirstName ORDER BY t.Price DESC) AS num 
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON t.FlightId = f.Id) AS t
WHERE num = 1
ORDER BY Price DESC, FirstName, LastName, Destination

-- 16. Destinations Info --------------------------------------------------------------------------

SELECT f.Destination, COUNT(t.Id) AS FilesCount FROM Flights AS f
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY f.Destination
ORDER BY FilesCount DESC, f.Destination

-- 17. PSP ----------------------------------------------------------------------------------------

SELECT p.Name, p.Seats, COUNT(t.PassengerId) AS [Passengers Count] FROM Planes AS p
LEFT JOIN Flights AS f ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY p.Name, p.Seats
ORDER BY [Passengers Count] DESC,  p.Name, p.Seats

-------------------------- Section 4. Programmability ----------------------------------------------

-- 18. Vacation ------------------------------------------------------------------------------------

CREATE FUNCTION udf_CalculateTickets (@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(100) 
AS
BEGIN
	IF @peopleCount <= 0
		RETURN 'Invalid people count!'
	
	DECLARE @FlightID INT = 0;
		SELECT @FlightID = Id FROM Flights
		WHERE Origin = @origin AND Destination = @destination

	IF @FlightID = 0
		RETURN  'Invalid flight!'

	DECLARE @Price DECIMAL(15,2) 
	SELECT @Price = Price FROM Tickets 
	WHERE FlightId = @FlightID
	
	DECLARE @TotalPrice DECIMAL(15,2)  = @Price * @peopleCount;

	RETURN 'Total price ' + CAST(@TotalPrice AS VARCHAR)
END

-- 19. Wrong Data ---------------------------------------------------------------------------------

CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE Flights
	SET DepartureTime = NULL , ArrivalTime = NULL
	WHERE DepartureTime < ArrivalTime
GO

-- 20. Deleted Planes -----------------------------------------------------------------------------

CREATE TABLE DeletedPlanes(
Id INT PRIMARY KEY,
[Name] VARCHAR(30),
Seats INT, 
[Range] INT
)

CREATE TRIGGER tr_DeletedPlanes ON Planes
FOR DELETE AS

	INSERT INTO DeletedPlanes(Id,[Name], Seats, [Range])
	SELECT d.Id, d.Name, d.Seats, d.Range FROM deleted AS d

GO