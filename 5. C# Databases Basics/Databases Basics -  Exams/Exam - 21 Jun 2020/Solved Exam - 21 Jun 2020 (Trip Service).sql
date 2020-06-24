
----------------------------------- Section 1. DDL ----------------------------------------

CREATE DATABASE TripService
GO
USE TripService

-- 1. Database design ---------------------------------------------------------------------

CREATE TABLE Cities(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(20, 2)
)

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(15,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT REFERENCES Hotels (Id) NOT NULL
)

CREATE TABLE Trips(
Id  INT PRIMARY KEY IDENTITY,
RoomId INT REFERENCES Rooms(Id) NOT NULL, 
BookDate DATE NOT NULL,
ArrivalDate DATE NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE
)

ALTER TABLE Trips
ADD CHECK(BookDate < ArrivalDate)

ALTER TABLE Trips
ADD CHECK(ArrivalDate < ReturnDate)

CREATE TABLE Accounts(
Id  INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT REFERENCES Cities (Id) NOT NULL,
BirthDate DATE NOT NULL,
Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
AccountId INT REFERENCES Accounts(Id) NOT NULL,
TripId INT REFERENCES Trips(Id) NOT NULL,
Luggage INT CHECK(Luggage >= 0)
CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId,TripId)
)

----------------------------------- Section 2. DML -----------------------------------------

-- 2. Insert -------------------------------------------------------------------------------

INSERT INTO Accounts(FirstName,	MiddleName,	LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, 	'1975-07-21', 'j_smith@gmail.com' ),
('Gosho', NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan', 'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

-- 3. Update ------------------------------------------------------------------------------

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

-- 4. Delete ------------------------------------------------------------------------------

DELETE AccountsTrips
WHERE AccountId = 47

--------------------------------- Section 3. Querying -------------------------------------

-- 5. EEE-Mails ---------------------------------------------------------------------------

SELECT 
	a.FirstName,
	a.LastName,
	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS  BirthDate,
	c.[Name] AS Hometown,
	a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId 
WHERE Email LIKE 'e%'
ORDER BY c.Name

-- 6. City Statistics ----------------------------------------------------------------------

SELECT c.Name AS City, COUNT(*) AS Hotels FROM Hotels As h
JOIN Cities AS c ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY COUNT(*) DESC, c.Name

-- 7. Longest and Shortest Trips -----------------------------------------------------------

SELECT DISTINCT * 
INTO #ShortTable
FROM (SELECT 
			a.Id AS AccountId,
			CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
			DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS TripDiff,
			DENSE_RANK() OVER(PARTITION BY a.FirstName   ORDER BY DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS Short
		FROM Accounts AS a
		JOIN AccountsTrips AS atr ON a.Id = atr.AccountId
		JOIN Trips AS t ON atr.TripId = t.Id
		WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL) AS t
WHERE Short = 1
		
SELECT DISTINCT * 
INTO #LongTable
FROM (SELECT 
			a.Id AS AccountId,
			CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
			DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS TripDiff,
			DENSE_RANK() OVER(PARTITION BY a.FirstName   ORDER BY DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) DESC) AS Long
		FROM Accounts AS a
		JOIN AccountsTrips AS atr ON a.Id = atr.AccountId
		JOIN Trips AS t ON atr.TripId = t.Id
		WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL) AS t
WHERE Long = 1

SELECT st.AccountId, st.FullName,lt.TripDiff AS LongestTrip, st.TripDiff AS ShortestTrip  FROM #ShortTable AS st
JOIN #LongTable AS lt ON st.AccountId = lt.AccountId
ORDER BY LongestTrip DESC, ShortestTrip

-- 8. Metropolis ---------------------------------------------------------------------------

SELECT TOP (10) 
	c.Id, c.Name AS City, 
	c.CountryCode AS Country, 
	COUNT(*) AS Accounts 
FROM Cities AS c
JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

-- 9. Romantic Getaways --------------------------------------------------------------------

SELECT a.Id, a.Email, c.Name,  COUNT(*) AS Trips FROM Accounts AS a
JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
JOIN Trips AS t ON atr.TripId = t.Id
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id


-- 10. GDPR Violation ----------------------------------------------------------------------

SELECT 
	t.Id,
	CASE
	 WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
	 ELSE CONCAT (a.FirstName,' ', a.MiddleName,' ', LastName)
	END AS [Full Name],
	c.[Name] AS [To],
	CASE 
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate),' days')
	END AS Duration,
	a.CityId
INTO #TempTableGDPR
FROM Accounts AS a
JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
JOIN Trips AS t ON atr.TripId = t.Id
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON h.CityId = c.Id

SELECT 
	tt.Id,
	tt.[Full Name],
	c.[Name] AS [From],
	tt.[To],
	tt.Duration
FROM #TempTableGDPR AS tt
JOIN Cities c ON tt.CityId = c.Id
ORDER BY [Full Name], tt.Id

------------------------------ Section 4. Programmability ---------------------------------- 

-- 11. Available Room ----------------------------------------------------------------------
GO

CREATE OR ALTER  FUNCTION udf_GetAvailableRoom (@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

 DECLARE @RoomId INT = (SELECT TOP(1) r.Id FROM Trips AS t
						JOIN Rooms AS r ON t.RoomId = r.Id
						JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE h.Id = @HotelId 
						  AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate 
						  AND t.CancelDate IS NULL
						  AND r.Beds >= @People
						  AND YEAR(@Date) = YEAR(t.ArrivalDate)
						  ORDER BY r.Price DESC)

  IF @RoomId IS NULL
	RETURN 'No rooms available'

  DECLARE @RoomPrice DECIMAL(15,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)

  DECLARE @RoomType VARCHAR (50)  = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)

  DECLARE @RoomBeds INT  = (SELECT Beds FROM Rooms WHERE Id = @RoomId)

  DECLARE  @HotelBaseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = 112)
  
  DECLARE @TotalPrice DECIMAL(15, 2) =  (@HotelBaseRate + @RoomPrice) * @People

RETURN CONCAT('Room ',@RoomId,': ', @RoomType,' (',@RoomBeds,' beds',') - $',@TotalPrice)

END

-- 12. Switch Room -------------------------------------------------------------------------
GO

CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @Count INT =  (SELECT COUNT(*) FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN AccountsTrips AS a ON a.TripId = t.Id
							WHERE t.Id = 10) 

	DECLARE @HotelId INT =  (SELECT TOP(1) r.HotelId FROM Trips AS t
							JOIN Rooms AS r ON t.RoomId = r.Id
							JOIN AccountsTrips AS a ON a.TripId = t.Id
							WHERE t.Id = 10) 

	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE HotelId = @HotelId AND Id = @TargetRoomId)

	IF @TargetRoomBeds IS NULL
	 THROW 500001,  'Target room is in another hotel!', 1
	ELSE IF @TargetRoomBeds < @Count
	 THROW 500002,  'Not enough beds in target room!' , 1

	UPDATE Trips
	SET  RoomId = @TargetRoomId
	WHERE Id = @TripId
END




