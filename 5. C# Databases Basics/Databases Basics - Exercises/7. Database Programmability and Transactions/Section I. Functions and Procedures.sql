

---------------------------- Part 1. Queries for SoftUni Database ---------------------------------------

-- Problem 1. Employees with Salary Above 35000 ---------------------------------------------------------

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000
GO

-- Problem 2. Employees with Salary Above Number --------------------------------------------------------

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Salary DECIMAL(18,4)
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @Salary 
GO

-- Problem 3. Town Names Starting With ------------------------------------------------------------------

CREATE PROCEDURE usp_GetTownsStartingWith @Param NVARCHAR(50)
AS
	SELECT [Name] AS Town FROM Towns
	WHERE Name LIKE @Param + '%'
GO

-- Problem 4. Employees from Town -----------------------------------------------------------------------

CREATE PROCEDURE usp_GetEmployeesFromTown @Name NVARCHAR(50)
AS
	SELECT FirstName, LastName FROM Employees AS e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @Name
GO

-- Problem 5. Salary Level Function ---------------------------------------------------------------------

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	 IF @salary < 30000 RETURN 'Low'
	 ELSE IF @salary BETWEEN 30000 AND 50000 RETURN 'Average'
	 ELSE RETURN 'High'
	 RETURN ''
END

-- Problem 6. Employees by Salary Level -----------------------------------------------------------------

CREATE PROCEDURE usp_EmployeesBySalaryLevel @Level VARCHAR(10)
AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
GO

-- Problem 7. Define Function ---------------------------------------------------------------------------

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(100), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @CountWord INT = LEN(@word);
	DECLARE @Count INT = 1;

	WHILE(@CountWord >=  @Count)
			BEGIN
				DECLARE @CurentChar VARCHAR(1)= SUBSTRING(@word,@Count ,1)
				DECLARE @Result INT =  CHARINDEX(@CurentChar,@setOfLetters)

				SET @Count += 1

				IF @Result = 0 
				   RETURN 0
			END
	RETURN 1
END 

-- Problem 8. Delete Employees and Departments ----------------------------------------------------------

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN ( (SELECT EmployeeID FROM Employees
	                       WHERE DepartmentID = @departmentId))

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees
                        WHERE DepartmentID = @departmentId);

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId
	
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
GO

-------------------------- Part 2. Queries for Bank Database --------------------------------------------

-- Problem 9. Find Full Name ----------------------------------------------------------------------------

CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT CONCAT(FirstName,' ',LastName) AS [Fuul Name] FROM AccountHolders
GO

-- Problem 10. People with Balance Higher Than ----------------------------------------------------------

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Money MONEY) 
AS
	SELECT AccountHolderId, SUM(Balance) AS SumBalance
	INTO #GroupAccount
    FROM Accounts 
	GROUP BY  AccountHolderId
	
	
	SELECT ah.FirstName, ah.LastName FROM AccountHolders AS ah
	JOIN #GroupAccount AS a ON ah.Id = a.AccountHolderId
	WHERE SumBalance > @Money 
	ORDER BY ah.FirstName, ah.LastName
GO

-- Problem 11. Future Value Function --------------------------------------------------------------------

CREATE FUNCTION ufn_CalculateFutureValue 
               (@sum DECIMAL (20, 4), @yearlyInterestRate FLOAT, @numberOfYears int)
RETURNS DECIMAL(20,4)
AS
BEGIN
	DECLARE @Result DECIMAL(20,4);

	SET @Result = @sum * POWER((1 + @yearlyInterestRate), @numberOfYears); 

	RETURN @Result;
END;

-- Problem 12. Calculating Interest ---------------------------------------------------------------------

CREATE PROCEDURE usp_CalculateFutureValueForAccount (@Id INT, @InterestRate FLOAT) 
AS
	SELECT 
		ah.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue (a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.Id = ah.Id
	WHERE ah.Id = @Id
GO

----------------------- Part 3. Queries for Diablo Database ---------------------------------------------

-- Problem 13. Scalar Function: Cash in User Games Odd Rows ---------------------------------------------

CREATE FUNCTION ufn_CashInUsersGames( @GameName VARCHAR(50))
RETURNS TABLE
AS
RETURN
( 
SELECT SUM(t.Cash) AS SumCash FROM
	(SELECT *, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
	FROM UsersGames
	WHERE GameId = ( SELECT Id FROM Games
					 WHERE [Name] = @GameName)) AS t
WHERE t.RowNumber % 2 != 0
)