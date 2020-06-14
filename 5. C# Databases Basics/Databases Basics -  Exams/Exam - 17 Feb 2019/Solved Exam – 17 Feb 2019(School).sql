
------------------------------------- Section 1. DDL -----------------------------------------------

-- 1. Database Design -----------------------------------------------------------------------------

--CREATE DATABASE School
--GO
--USE School

CREATE TABLE Students(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CHECK (Age >= 5 AND Age <=100),
[Address] NVARCHAR(50),
Phone CHAR(10)
)

CREATE TABLE Subjects(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT IDENTITY PRIMARY KEY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK(Grade >= 2 AND Grade <= 6) 
)

CREATE TABLE Exams(
	Id INT IDENTITY PRIMARY KEY,
	Date DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	ExamId INT FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(3,2) CHECK(Grade >= 2 AND Grade <= 6),
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId,ExamId)
)

CREATE TABLE Teachers(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id),
	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)

------------------------------------- Section 2. DML -----------------------------------------------

-- 2. Insert ---------------------------------------------------------------------------------------

INSERT INTO Teachers ( FirstName,LastName,[Address], Phone,	SubjectId)
VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
	('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons)
VALUES
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9)

-- 3. Update ---------------------------------------------------------------------------------------

UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN(1, 2) AND Grade >= 5.50

-- 4. Delete

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers
                    WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

----------------------------------- Section 3. Querying --------------------------------------------

-- 5. Teen Students --------------------------------------------------------------------------------

SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

-- 6. Cool Addresses -------------------------------------------------------------------------------

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name], [Address] FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

-- 7. 42 Phones ------------------------------------------------------------------------------------

SELECT FirstName, [Address],Phone  FROM Students
WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
ORDER BY FirstName

-- 8. Students Teachers ----------------------------------------------------------------------------

SELECT FirstName, LastName, COUNT(TeacherId) AS TeachersCount FROM Students AS s
LEFT JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY FirstName, LastName

-- 9. Subjects with Students -----------------------------------------------------------------------

SELECT FullName, Subjects, COUNT(StudentId) FROM (SELECT 
				   FirstName + ' ' + LastName AS FullName,
				   CONCAT(s.Name,'-',s.Lessons) AS Subjects,
				   st.StudentId
			   FROM Teachers AS t
			   JOIN Subjects AS s ON t.SubjectId = s.Id
			   JOIN StudentsTeachers AS st ON t.Id = st.TeacherId) AS t
GROUP BY FullName, Subjects
ORDER BY COUNT(StudentId) DESC, FullName, Subjects

-- 10. Students to Go ------------------------------------------------------------------------------

SELECT s.FirstName + ' ' + s.LastName AS [Full Name] FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE se.Grade IS NULL
ORDER BY [Full Name]

-- 11. Busiest Teachers

SELECT TOP(10) 
	t.FirstName, 
	t.LastName, 
	COUNT(st.StudentId) AS StudentsCount 
FROM Teachers AS t
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName

-- 12. Top Students --------------------------------------------------------------------------------
SELECT TOP(10) FirstName, LastName, FORMAT(AVG(Grade), 'N2') AS Grade 
FROM Students AS s
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY FirstName, LastName
ORDER BY AVG(Grade) DESC, FirstName, LastName 

-- 13. Second Highest Grade ------------------------------------------------------------------------

SELECT FirstName, LastName,Grade 
FROM ( SELECT FirstName, LastName,Grade, 
       ROW_NUMBER() OVER(PARTITION BY FirstName ORDER BY Grade DESC) AS [Rank] 
       FROM Students AS s
	   JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId) AS t
WHERE [Rank] = 2
ORDER BY  FirstName, LastName

-- 14. Not So In The Studying ----------------------------------------------------------------------

SELECT 
	CASE
	WHEN MiddleName IS NULL THEN CONCAT(s.FirstName, ' ', s.LastName)
	ELSE CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName) 
	END AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

-- 15. Top Student per Teacher ---------------------------------------------------------------------

SELECT 
	[Subject Name], 
	[Teacher Full Name], 
	[Student Full Name], 
	FORMAT(AVG(Grade), 'N2') AS Grade,
	ROW_NUMBER() OVER (PARTITION BY [Teacher Full Name] ORDER BY AVG(Grade) DESC) AS [Rank] 
INTO #TempTable
FROM
	(SELECT	CONCAT(t.FirstName,' ', t.LastName) AS [Teacher Full Name],
			sub.[Name] AS [Subject Name],
			CONCAT(s.FirstName, ' ', s.LastName) AS [Student Full Name],
			ss.Grade
	 FROM Teachers AS t
	    JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
		JOIN Students AS s ON st.StudentId = s.Id
		JOIN Subjects AS sub ON sub.Id = t.SubjectId
		JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId AND sub.Id = ss.SubjectId) AS t
GROUP BY [Subject Name], [Teacher Full Name], [Student Full Name]

	
SELECT [Teacher Full Name], [Subject Name], [Student Full Name], Grade FROM #TempTable
WHERE [Rank] = 1
ORDER BY [Subject Name], [Teacher Full Name], Grade DESC

-- 16. Average Grade per Subject -------------------------------------------------------------------

SELECT s.Name, AVG(Grade) FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY s.[Name],ss.SubjectId
ORDER BY ss.SubjectId 

-- 17. Exams Information ---------------------------------------------------------------------------

SELECT 
	CASE
		WHEN DATEPART (quarter , e.[Date]) IS NULL THEN 'TBA'
		ELSE 'Q' + CAST(DATEPART (quarter , e.[Date]) AS VARCHAR)
	END AS [Quarter],
	s.Name AS SubjectName,
	COUNT(*) AS StudentsCount 
FROM Subjects AS s
JOIN Exams AS e ON  e.SubjectId = s.Id
JOIN StudentsExams AS se ON se.ExamId = e.Id
JOIN Students AS st ON st.Id = se.StudentId
WHERE se.Grade >= 4 
GROUP BY s.Name, DATEPART (quarter , e.[Date]) 
ORDER BY [Quarter] 
	
------------------------- Section 4. Programmability ----------------------------------------------

-- 18. Exam Grades --------------------------------------------------------------------------------

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL (3,2))
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @Count INT = 0;
	DECLARE @Name VARCHAR(50);
	 
		SELECT @Count = COUNT(*), @Name = s.FirstName FROM StudentsExams AS se
		JOIN Students AS s ON se.StudentId = s.Id
		WHERE se.StudentId = @studentId AND Grade BETWEEN @grade AND @grade + 0.5
		GROUP BY s.FirstName

	IF @grade > 6.00
		RETURN 'Grade cannot be above 6.00!'
	ELSE IF @Count = 0
		RETURN 'The student with provided id does not exist in the school!'
	ELSE
		RETURN 'You have to update '+ CONVERT(VARCHAR, @Count ) + ' grades for the student ' + @Name
	RETURN''
END

-- 19. Exclude from school -------------------------------------------------------------------------

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @CurrentStudentId INT = 0

	SELECT @CurrentStudentId = Id FROM Students
	WHERE Id = @StudentId

	IF @CurrentStudentId = 0
		THROW  50001 , 'This school has no student with the provided id!' , 1 

	DELETE FROM StudentsExams
	WHERE StudentId = @CurrentStudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @CurrentStudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @CurrentStudentId

	DELETE FROM Students
	WHERE Id = @CurrentStudentId
GO

-- 20. Deleted Student -----------------------------------------------------------------------------

CREATE TABLE ExcludedStudents(
StudentId INT, 
StudentName VARCHAR(50)
)

CREATE TRIGGER tr_DeleteStudent ON Students
INSTEAD OF DELETE
AS
	INSERT INTO ExcludedStudents (StudentId, StudentName )
	SELECT Id, FirstName + ' '+ LastName FROM deleted