
-- Problem 1. One-To-One Relationship ----------------------------------------------------------------

CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(8,2) NOT NULL,
PassportID INT NOT NULL UNIQUE
)

CREATE TABLE Passports(
PassportID INT NOT NULL,
PassportNumber CHAR(8) NOT NULL
)

INSERT INTO Persons(PersonID, FirstName, Salary,PassportID)
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

INSERT INTO Passports( PassportID, PassportNumber)
VALUES
( 101, 'N34FG21B'),
( 102, 'K65LO4R7'),
( 103, 'ZE657QP2') 

ALTER TABLE Persons
ADD CONSTRAINT PK_Person PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_Passport PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Passport FOREIGN KEY (PassportID) REFERENCES Passports (PassportID)

-- Problem 2. One-To-Many Relationship ------------------------------------------------------------------

CREATE TABLE Models(
ModelID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers(
ManufacturerID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)

INSERT INTO Models(ModelID, [Name], ManufacturerID)
VALUES
( 101, 'X1', 1),
( 102, 'i6', 1),
( 103, 'Model S', 2),
( 104, 'Model x', 2),
( 105, 'Model 3', 2),
( 106, 'Nova', 3)

INSERT INTO Manufacturers(ManufacturerID, [Name], EstablishedOn)
VALUES
( 1, 'BMW', '1916-03-07'),
( 2, 'Tesla', '2003-01-01'),
( 3, 'Lada', '1966-05-01')

ALTER TABLE Models
ADD CONSTRAINT PK_Model PRIMARY KEY (ModelID)

ALTER TABLE Manufacturers
ADD CONSTRAINT PK_Manifacturer PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
ADD CONSTRAINT FK_Manifacturer FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

-- Problem 3. Many-To-Many Relationship -----------------------------------------------------------------

CREATE TABLE Students(
StudentID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL,
)

INSERT INTO Students(StudentID, [Name])
VALUES
( 1, 'Mila'),
( 2, 'Toni'),
( 3, 'Ron')

INSERT INTO Exams(ExamID, [Name])
VALUES
( 101, 'SpringMVC'),
( 102, 'Neo4j'),
( 103, 'Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
( 1, 101),
( 1, 102),
( 2, 101),
( 3, 103),
( 2, 102),
( 2, 103)

ALTER TABLE Students
ADD CONSTRAINT PK_Sudent PRIMARY KEY (StudentID)

ALTER TABLE Exams
ADD CONSTRAINT PK_Exam PRIMARY KEY (ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Exam FOREIGN KEY (ExamID) REFERENCES Exams (ExamID)

-- Problem 4. Self-Referencing --------------------------------------------------------------------------

CREATE TABLE Teachers(
TeacherID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManagerID INT
) 

INSERT INTO Teachers( TeacherID, [Name], ManagerID)
VALUES
(101 , 'John', NULL),
(102 , 'Maya', 106),
(103 , 'Silvia', 106),
(104 , 'Ted', 105),
(105 , 'Mark', 101),
(106 , 'Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT PK_Teacher PRIMARY KEY (TeacherID)

ALTER TABLE Teachers
ADD CONSTRAINT FK_Manager FOREIGN KEY(ManagerId) REFERENCES Teachers (TeacherID)

-- Problem 5. Online Store Database ---------------------------------------------------------------------

--CREATE DATABASE OnlineStore
--GO
--USE OnlineStore

CREATE TABLE Cities(
CityID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) 
)

CREATE TABLE ItemTypes(
ItemTypesID INT PRIMARY KEY IDENTITY(1, 1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY IDENTITY(1, 1),
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes (ItemTypesID) NOT NULL
)

CREATE TABLE OrderItems(
OrderID INT NOT NULL,
ItemID INT NOT NULL,
CONSTRAINT PK_OrderItem PRIMARY KEY (OrderID, ItemID),
CONSTRAINT FK_Order FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
CONSTRAINT FK_Item FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
)

-- Problem 6. University Database -----------------------------------------------------------------------

--CREATE DATABASE UniversityDatabase
--GO
--USE UniversityDatabase 

CREATE TABLE Majors(
MajorID INT PRIMARY KEY IDENTITY(1, 1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY(1, 1),
StudentNumber INT NOT NULL,
StudentName VARCHAR(50) NOT NULL,
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY(1, 1),
PaymentDate DATE NOT NULL,
PaymentAmount DECIMAL(8,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY IDENTITY(1,1),
SubjrectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL,
CONSTRAINT PK_StudentSubject PRIMARY KEY (StudentID, SubjectID),
CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Subject FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

-- Problem 9. *Peaks in Rila ----------------------------------------------------------------------------

SELECT m.MountainRange, p.PeakName, p.Elevation FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
