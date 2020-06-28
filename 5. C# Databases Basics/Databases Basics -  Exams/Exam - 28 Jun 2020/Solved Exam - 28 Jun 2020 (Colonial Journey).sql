 ----------------------------- Section 1. DDL ----------------------------------------------

 CREATE DATABASE ColonialJourney
 GO 
 USE ColonialJourney 

 -- 1. Database Design ---------------------------------------------------------------------

 CREATE TABLE Planets(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(30) NOT NULL
 )

 CREATE TABLE Spaceports(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 PlanetId INT REFERENCES Planets(Id)
 )

 CREATE TABLE Spaceships(
 Id INT PRIMARY KEY IDENTITY,
 [Name]  VARCHAR(50) NOT NULL,
 Manufacturer VARCHAR(30) NOT NULL,
 LightSpeedRate INT DEFAULT 0
 )

 CREATE TABLE Colonists(
 Id INT PRIMARY KEY IDENTITY,
 FirstName VARCHAR(20) NOT NULL,
 LastName VARCHAR(20) NOT NULL,
 Ucn VARCHAR(10) UNIQUE NOT NULL,
 BirthDate DATE NOT NULL
 )

 CREATE TABLE Journeys(
 Id INT PRIMARY KEY IDENTITY,
 JourneyStart DATE NOT NULL,
 JourneyEnd DATE NOT NULL,
 Purpose VARCHAR(11) CHECK(Purpose = 'Medical' OR Purpose = 'Technical' OR Purpose = 'Educational' OR Purpose = 'Military') NOT NULL,
 DestinationSpaceportId INT REFERENCES Spaceports (Id) NOT NULL,
 SpaceshipId INT REFERENCES Spaceships(Id) NOT NULL
 )

 CREATE TABLE TravelCards(
 Id  INT PRIMARY KEY IDENTITY,
 CardNumber CHAR(10) UNIQUE NOT NULL,
 JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney = 'Pilot' OR JobDuringJourney = 'Engineer' OR JobDuringJourney = 'Trooper' OR JobDuringJourney = 'Cleaner' OR JobDuringJourney = 'Cook') NOT NULL,
 ColonistId INT REFERENCES Colonists (Id) NOT NULL, 
 JourneyId INT REFERENCES Journeys(Id) NOT NULL
 )

 ----------------------------- Section 2. DML ----------------------------------------------
 
 -- 2. Insert ------------------------------------------------------------------------------

 INSERT INTO Planets([Name])
 VALUES
 ('Mars'),
 ('Earth'),
 ('Jupiter'),
 ('Saturn')

 INSERT INTO Spaceships ([Name], Manufacturer,  LightSpeedRate)
 VALUES
 ('Golf', 'VW', 3),
 ('WakaWaka', 'Wakanda', 4),
 ('Falcon9', 'SpaceX', 1),
 ('Bed', 'Vidolov', 6)

 -- 3. Update ------------------------------------------------------------------------------

UPDATE Spaceships
SET  LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

-- 4. Delete -------------------------------------------------------------------------------

DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

-- 5. Select all military journeys ---------------------------------------------------------

SELECT 
	Id, 
	FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart, 
	FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd 
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

-- 6. Select all pilots --------------------------------------------------------------------

SELECT
	c.Id,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName
FROM TravelCards AS tc
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

-- 7. Count colonists ----------------------------------------------------------------------

SELECT COUNT(*) AS [Count] FROM TravelCards AS tc
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE Purpose = 'Technical'

-- 8. Select spaceships with pilots younger than 30 years ----------------------------------

SELECT 
	s.Name,
	s.Manufacturer
FROM TravelCards AS tc
JOIN Colonists AS c ON c.Id = tc.ColonistId
JOIN Journeys AS j ON j.Id = tc.JourneyId
JOIN Spaceships AS s ON s.Id = j.SpaceshipId 
WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30
ORDER BY s.Name

-- 9. Select all planets and their journey count -------------------------------------------

SELECT p.Name AS PlanetName, COUNT(*) AS JourneysCount FROM Journeys AS j
JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
JOIN Planets AS p ON p.Id = s.PlanetId
GROUP BY p.Name
ORDER BY COUNT(*) DESC, p.Name

-- 10. Select Second Oldest Important Colonist --------------------------------------------

SELECT * FROM (SELECT 
					JobDuringJourney, 
					CONCAT(c.FirstName,' ', c.LastName) AS FullName , 
					DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) AS JobRank 
				FROM  Journeys AS j
				JOIN TravelCards AS tc ON tc.JourneyId = j.Id
				JOIN Colonists AS c ON c.Id = tc.ColonistId) AS t
WHERE JobRank = 2

-- 11. Get Colonists Count ----------------------------------------------------------------
GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
 RETURNS INT AS
BEGIN
   
  DECLARE @countColonist INT = (SELECT 
									COUNT(*) AS CountColonists
								FROM Journeys AS j
								JOIN TravelCards AS tc ON tc.JourneyId = j.Id
								JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
								JOIN Planets AS p ON p.Id = s.PlanetId
								WHERE p.Name = @PlanetName)
    RETURN @countColonist
END

-- 12. Change Journey Purpose -------------------------------------------------------------
GO

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
BEGIN

		DECLARE @checkId INT = (SELECT TOP(1) Id FROM Journeys WHERE Id = @JourneyId) 

		IF @checkId IS NULL
			THROW 50001, 'The journey does not exist!', 1;

			
		DECLARE @checkPurpose INT = (SELECT TOP(1) Id FROM Journeys WHERE Id = @JourneyId AND Purpose = @NewPurpose)
		
		IF  @checkPurpose IS NOT NULL
			THROW 50002, 'You cannot change the purpose!', 1

		UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id =  @JourneyId

END
