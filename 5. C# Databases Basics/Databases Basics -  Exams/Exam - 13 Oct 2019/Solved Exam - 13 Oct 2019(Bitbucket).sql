
--------------------------------- Section 1. DDL --------------------------------------------------

CREATE DATABASE Bitbucket
GO
USE Bitbucket

-- 1. Database Design -----------------------------------------------------------------------------

CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL,
)

CREATE TABLE Repositories(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
ContributorId INT REFERENCES Users(Id) NOT NULL,
CONSTRAINT pk_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
Id INT IDENTITY PRIMARY KEY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT REFERENCES Issues(Id),
RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(30, 2) NOT NULL,
ParentId INT REFERENCES Files(Id),
CommitId INT REFERENCES Commits(Id)
)


---------------------------------- Section 2. DML -------------------------------------------------

-- 2. Insert --------------------------------------------------------------------------------------

INSERT INTO Files([Name], Size,	ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8

-- 3. Update ---------------------------------------------------------------------------------------
 
 UPDATE Issues
 SET IssueStatus = 'closed' 
 WHERE AssigneeId = 6

 -- 4. Delete --------------------------------------------------------------------------------------

 DELETE FROM RepositoriesContributors
 WHERE RepositoryId = 3

 DELETE FROM Issues
 WHERE RepositoryId = 3

 ---------------------------- Section 3. Querying -------------------------------------------------
 
 -- 5. Commits ------------------------------------------------------------------------------------

 SELECT Id , [Message], RepositoryId, ContributorId FROM Commits
 ORDER BY Id , [Message], RepositoryId, ContributorId

 -- 6. Heavy HTML --------------------------------------------------------------------------------
 
 SELECT Id, [Name], Size FROM Files
 WHERE Size > 1000 AND [Name] LIKE '%html%'
 ORDER BY Size DESC, Id, [Name]
 
 -- 7. Issues and Users ---------------------------------------------------------------------------

 SELECT i.Id, u.Username + ' : ' + i.Title AS IssueAssignee FROM Issues AS i
 JOIN Users AS u ON u.Id = i.AssigneeId
 ORDER BY i.Id DESC, i.AssigneeId

 -- 8. Non-Directory Files ------------------------------------------------------------------------

 SELECT f.Id, f.[Name] , CONVERT(VARCHAR(50),f.Size) + 'KB' AS Size FROM Files AS f
 LEFT JOIN Files AS ft ON f.Id = ft.ParentId
 WHERE ft.ParentId IS NULL
 ORDER BY f.Id, f.[Name], f.Size DESC

 -- 9. Most Contributed Repositories --------------------------------------------------------------
 ---- INCORRECT CONDITION--------------------------------------------------------------------------

SELECT TOP(5) r.Id, r.Name, COUNT(*) AS Commits FROM Commits AS c
JOIN Repositories AS r ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY COUNT(*) DESC, r.Id, r.Name

-- 10. User and Files ------------------------------------------------------------------------------

SELECT u.Username, AVG(f.Size) AS  Size FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username

------------------------------- Section 4. Programmability -----------------------------------------

-- 11. User Total Commits --------------------------------------------------------------------------

CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50))
RETURNS  INT AS
BEGIN
	DECLARE @CountCommits INT;
	SELECT @CountCommits = COUNT(*) FROM Commits AS c
	JOIN Users AS u ON c.ContributorId = u.Id
	WHERE u.Username = @username 
	RETURN @CountCommits
END

-- 12. Find by Extensions -------------------------------------------------------------------------

CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(20))
AS
	SELECT Id, [Name], CONVERT(VARCHAR(20),Size) + 'KB' AS Size FROM Files
	WHERE [Name] LIKE '%' + @extension
	ORDER BY Id, [Name], Size
GO

