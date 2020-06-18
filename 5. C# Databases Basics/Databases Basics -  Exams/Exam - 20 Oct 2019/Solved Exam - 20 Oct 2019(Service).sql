
------------------------------------ Section 1. DDL ------------------------------------------------

CREATE DATABASE [Service]
GO
USE [Service]

-- 1. Table design ---------------------------------------------------------------------------------

CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME2,
Age INT CHECK (Age >= 14 AND Age <= 110),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME2,
Age INT CHECK (Age >= 18 AND Age <= 110),
DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT REFERENCES  Departments(Id) NOT  NULL
)

CREATE TABLE [Status](
Id INT IDENTITY PRIMARY KEY,
Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT IDENTITY PRIMARY KEY,
CategoryId INT REFERENCES Categories(Id), 
StatusId INT REFERENCES [Status](Id),
OpenDate DATETIME2 NOT NULL,
CloseDate DATETIME2,
[Description] VARCHAR(200) NOT NULL,
UserId INT REFERENCES Users(Id) NOT NULL,
EmployeeId INT REFERENCES Employees(Id)
)

------------------------------ Section 2. DML ----------------------------------------------

-- 2. Insert -------------------------------------------------------------------------------

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133',	6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

-- 3. Update -------------------------------------------------------------------------------

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- 4. Delete -------------------------------------------------------------------------------

DELETE FROM Reports
WHERE StatusId = 4

----------------------- Section 3. Querying ------------------------------------------------

-- 5. Unassigned Reports -------------------------------------------------------------------

SELECT [Description], CONVERT(varchar,OpenDate,105) AS OpenDate FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

-- 6. Reports & Categories -----------------------------------------------------------------

SELECT r.[Description], c.Name AS CategoryName FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description], c.Name 

-- 7. Most Reported Category ---------------------------------------------------------------

SELECT TOP(5) c.Name AS CategoryName, COUNT(*) AS ReportsNumber FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY  COUNT(*) DESC, c.Name

-- 8. Birthday Report ----------------------------------------------------------------------

SELECT u.Username , c.[Name] AS CategoryName FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE FORMAT(u.Birthdate, 'dd/MM') = FORMAT(r.OpenDate, 'dd/MM') 
ORDER BY u.Username, c.[Name]

-- 9. Users per Employee -------------------------------------------------------------------

 SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName ,
	COUNT(r.Id) AS UsersCount
 FROM Employees AS e
 LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
 GROUP BY e.FirstName, LastName
 ORDER BY UsersCount DESC ,FullName

 -- 10.	Full Info --------------------------------------------------------------------------

SELECT 
	 CASE
		 WHEN e.FirstName IS NULL THEN 'None'
		 ELSE CONCAT(e.FirstName, ' ', e.LastName)
	 END AS Employee,
	 ISNULL(d.Name, 'None') AS Department,
	 cat.Name AS Category,
	 r.[Description],
	 FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate, 
	 s.Label AS [Status],
	 u.[Name] AS [User]
 FROM Reports AS r
 LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
 LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
 LEFT JOIN Categories AS cat ON cat.Id = r.CategoryId
 LEFT JOIN Users AS u On r.UserId = u.Id
 LEFT JOIN [Status] AS s ON r.StatusId = s.Id
 ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.[Description],OpenDate, [Status] , [User] 

 -------------------------- Section 4. Programmability ------------------------------------

 -- 11.	Hours to Complete -----------------------------------------------------------------

CREATE OR ALTER  FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT 
AS
BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
		RETURN 0
	
		RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

-- 12. Assign Employee ---------------------------------------------------------------------

CREATE PROCEDURE usp_AssignEmployeeToReport (@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @DepartReport INT = 0 
	  SELECT @DepartReport = c.DepartmentId FROM Reports AS r
	  LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	  WHERE r.Id = @ReportId

	DECLARE @DepartEmployee INT = 0
	  SELECT @DepartEmployee = DepartmentId FROM Employees WHERE Id = @EmployeeId
	
	IF @DepartReport = @DepartEmployee
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
		RETURN
	END
	--PRINT  'Employee doesn''t belong to the appropriate department!'
    SELECT  'Employee doesn''t belong to the appropriate department!'
END
