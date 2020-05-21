
-- Problem 1. Create Database -----------------------------------------------------------------------

CREATE DATABASE Minions

-- Problem 2. Create Tables -------------------------------------------------------------------------

CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Age INT 
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

-- Problem 3. Alter Minions Table -------------------------------------------------------------------

ALTER TABLE Minions 
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- Problem 4. Insert Records in Both Tables --------------------------------------------------------

INSERT INTO Towns (Id, [Name])
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3) ,
(3, 'Steward', NULL, 2) 

-- Problem 5.	Truncate Table Minions --------------------------------------------------------------
 
 TRUNCATE TABLE Minions

 -- Problem 6. Drop All Tables ----------------------------------------------------------------------

 DROP TABLE Towns

 DROP TABLE Minions

 -- Problem 7. Create Table People ------------------------------------------------------------------

 CREATE TABLE People(
 Id INT PRIMARY KEY IDENTITY,
 [Name] NVARCHAR(200) NOT NULL,
 Picture VARBINARY(2000),
 Height DECIMAL(8, 2),
 [Weight] DECIMAL(8, 2),
 Gender CHAR(1) NOT NULL,
 Birthdate DATE NOT NULL,
 Biography NVARCHAR(MAX)  
 )

 INSERT INTO People( [Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
 VALUES
 ('Pesho', NULL, 100.20, 50.30, 'f', '1-12-1974', NULL),
 ('Gosho', NULL, 130.50, 34.60, 'm', '2-14-1984', NULL),
 ('Tosho', NULL, 170.70, 87.30, 'f', '3-16-1994', NULL),
 ('Atanas', NULL, 120.20, 45.10, 'm', '4-18-2004', NULL),
 ('As', NULL, 150.90, 80.20, 'f', '5-22-2014', NULL) 

 -- Problem 8. Create Table Users -------------------------------------------------------------------
 
 CREATE TABLE Users(
  Id INT PRIMARY KEY IDENTITY,
  Username VARCHAR(30) NOT NULL,
  [Password] VARCHAR(26)  NOT NULL,
  ProfilePicture VARBINARY(900),
  LastLoginTime DATETIME,
  IsDeleted BIT
 ) 

 INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
 VALUES
 ('abv', 'vba123', NULL, '1-12-1974', 1),
 ('bvg', 'gvb123', NULL, '1-12-1984', 1),
 ('vgd', 'dgv123', NULL, '1-12-1994', 0),
 ('gdi', 'idg123', NULL, '1-12-2004', 1),
 ('dik', 'kid123', NULL, '1-12-2014', 0)

 -- Problem 9. Change Primary Key --------------------------------------------------------------------

 ALTER TABLE Users
 DROP CONSTRAINT [PK__Users__3214EC07AC712A5F]
  
 ALTER TABLE Users
 ADD CONSTRAINT PK_Id_Username PRIMARY KEY ( Id, Username)

 -- Problem 10.	Add Check Constraint ----------------------------------------------------------------

 ALTER TABLE Users
 ADD CHECK(LEN([Password]) >= 5)  

 -- Problem 11.	Set Default Value of a Field --------------------------------------------------------

  ALTER TABLE Users
  ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

  -- Problem 12. Set Unique Field -------------------------------------------------------------------

  ALTER TABLE Users
  DROP CONSTRAINT PK_Id_Username

  ALTER TABLE Users
  ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

  ALTER TABLE Users
  ADD UNIQUE (Username)

  ALTER TABLE Users
  ADD CHECK (LEN(Username) >=3)

  -- Problem 13. Movies Database --------------------------------------------------------------------

  CREATE DATABASE Movies
  GO
  USE Movies

  CREATE TABLE Directors(
  Id INT PRIMARY KEY IDENTITY(1, 1),
  DirectorName NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Genres(
  Id INT PRIMARY KEY IDENTITY(1,1),
  GenreName NVARCHAR(50) NOT NULL,  
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Categories(
   Id INT PRIMARY KEY IDENTITY(1,1),
  CategoryName NVARCHAR(50) NOT NULL,  
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Movies(
  Id INT PRIMARY KEY IDENTITY(1, 1),
  Title NVARCHAR(50) NOT NULL,
  DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
  CopyrightYear DATE NOT NULL,
  [Length] DECIMAL(8,2) NOT NULL,
  GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
  Rating DECIMAL(8,2),
  Notes NVARCHAR(MAX)
  )

  INSERT INTO Directors (DirectorName, Notes)
 VALUES
 ('TO', null), 
 ('YO', null), 
 ('PO', null), 
 ('SO', null), 
 ('FO', null)

  INSERT INTO Genres (GenreName, Notes)
 VALUES
 ('Action', null), 
 ('Drama', null), 
 ('Comedy', null), 
 ('Crime', null), 
 ('Fantasy', null)

 INSERT INTO Categories (CategoryName, Notes)
 VALUES
 ('Romantic', null),
 ('Legal', null),
 ('Military', null),
 ('Teen', null),
 ('Dark', null)

 INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
 VALUES
 ('Amadeus', 2, '1984-01-01', 112.34, 1, 3, 76.34, null),
 ('Titanic', 1, '2000-01-01', 112.34, 4, 2, 98.34, null),
 ('Ball of Fire', 5, '2007-01-01', 112.34, 2, 3, 76.34, null),
 ('The Lion King', 3, '1993-01-01', 112.34, 5, 4, 76.34, null),
 ('Being There', 4, '2017-01-01', 112.34, 3, 5, 76.34, null)

 -- Problem 14.	Car Rental Database -----------------------------------------------------------------

 CREATE DATABASE CarRental
 GO
 USE CarRental

 CREATE TABLE Categories(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 CategoryName NVARCHAR(50) NOT NULL, 
 DailyRate DECIMAL(8, 2) NOT NULL, 
 WeeklyRate DECIMAL(8, 2) NOT NULL, 
 MonthlyRate DECIMAL(8, 2) NOT NULL, 
 WeekendRate DECIMAL(8, 2) NOT NULL
 )

 CREATE TABLE Cars(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 PlateNumber VARCHAR(12) NOT NULL, 
 Manufacturer VARCHAR(50) NOT NULL, 
 Model VARCHAR(50) NOT NULL, 
 CarYear DATE, 
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
 Doors INT NOT NULL, 
 Picture VARBINARY(2000), 
 Condition VARCHAR(100) NOT NULL, 
 Available VARCHAR(MAX) NOT NULL
 )

 CREATE TABLE Employees(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 Title VARCHAR(50) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Customers(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 DriverLicenceNumber INT NOT NULL, 
 FullName NVARCHAR(100) NOT NULL, 
 [Address] NVARCHAR(200) NOT NULL, 
 City NVARCHAR(50) NOT NULL, 
 ZIPCode INT NOT NULL , 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RentalOrders(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
 CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
 CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
 TankLevel DECIMAL(5, 2) NOT NULL, 
 KilometrageStart DECIMAL(8,2) NOT NULL, 
 KilometrageEnd DECIMAL(8,2) NOT NULL, 
 TotalKilometrage  DECIMAL(8,2) NOT NULL, 
 StartDate DATE NOT NULL, 
 EndDate DATE NOT NULL, 
 TotalDays INT NOT NULL, 
 RateApplied DECIMAL(8,2) NOT NULL, 
 TaxRate DECIMAL(8,2) NOT NULL, 
 OrderStatus BIT NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 INSERT INTO Categories( CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) 
 VALUES
 ('Tir', 12.4, 34.5, 21.6, 34.4),
 ('Car', 12.4, 34.5, 21.6, 34.4),
 ('Bus', 12.4, 34.5, 21.6, 34.4)

 INSERT INTO Cars( PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
 VALUES
 (1234, 'Opel', 'Astra', '2007', 2, 4, null, 'Perfect', 'Many'),
 (5678, 'Ford', 'Ka', '1996', 2, 4, null, 'Perfect', 'Many'),
 (9876, 'MB', 'AMG', '2015', 2, 4, null, 'Perfect', 'Many')


 INSERT INTO Employees (FirstName, LastName, Title, Notes)
 VALUES
 ('Go', 'Goev', 'Boss', null),
 ('To', 'Toev', 'Boss', null),
 ('Po', 'Poev', 'Boss', null)

 INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) 
 VALUES
 (1234, 'KoTo', 'gk.Lulin', 'Sofia', 1330, null),
 (5432, 'KoTo', 'gk.Lulin', 'Sofia', 1330, null),
 (7856, 'KoTo', 'gk.Lulin', 'Sofia', 1330, null)

 INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
  TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
 VALUES
 (2,3,1, 56.5, 100.5, 200.5, 300.67, '2010-01-23', '2010-03-23', 60, 45.7, 123.56, 1, null),
 (1,2,3, 56.5, 200.5, 300.5, 500.67, '2010-01-23', '2010-03-23', 60, 45.7, 123.56, 0, null),
 (3,2,1, 56.5, 300.5, 400.5, 800.67, '2010-01-23', '2010-03-23', 60, 45.7, 123.56, 1, null)


 -- Problem 15.	Hotel Database ----------------------------------------------------------------------

 CREATE DATABASE Hotel
 GO
 USE Hotel
 
 CREATE TABLE Employees(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 Title NVARCHAR(50) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Customers(
 AccountNumber  INT PRIMARY KEY NOT NULL, 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 PhoneNumber INT NOT NULL, 
 EmergencyName NVARCHAR(50) NOT NULL, 
 EmergencyNumber INT NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomStatus(
 RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomTypes(
 RoomType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE BedTypes(
 BedType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Rooms(
 RoomNumber INT PRIMARY KEY NOT NULL, 
 RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
 BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL, 
 Rate DECIMAL(5, 2) NOT NULL, 
 RoomStatus VARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Payments(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  PaymentDate DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  FirstDateOccupied DATE NOT NULL, 
  LastDateOccupied DATE NOT NULL, 
  TotalDays INT NOT NULL, 
  AmountCharged DECIMAL(10,2) NOT NULL, 
  TaxRate DECIMAL(10,2) NOT NULL, 
  TaxAmount DECIMAL(10,2) NOT NULL, 
  PaymentTotal DECIMAL(10,2) NOT NULL, 
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Occupancies(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  DateOccupied DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
  RateApplied DECIMAL(8,2) NOT NULL, 
  PhoneCharge DECIMAL(8,2), 
  Notes NVARCHAR(MAX)
  )

  INSERT INTO Employees (FirstName, LastName, Title, Notes)
	 VALUES
	 ('Toto', 'Totev', 'Boss', null),
	 ('Moto', 'Motev', 'Slave', null),
	 ('Roto', 'Rotev', 'Slave', null)

	 INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	 VALUES
	 (11, 'Toto', 'Totev', 12345, 'Toto', 911, null),
	 (22, 'Moto', 'Motev', 12345, 'Toto', 911, null),
	 (33, 'Roto', 'Rotev', 12345, 'Toto', 911, null)

	 INSERT INTO RoomStatus(RoomStatus, Notes)
	 VALUES
	  ('C', null),
	  ('O', null),
	  ('CO', null)

	 INSERT INTO RoomTypes (RoomType, Notes)
	 VALUES
	  ('Big', null),
	  ('Medium', null),
	  ('Small', null)

	 INSERT INTO BedTypes (BedType, Notes)
	 VALUES
	 ('Big', null),
	 ('Medium', null),
	 ('Small', null)

	 INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
	 VALUES
	 (1, 'Big', 'Small', 25, 'C', null),
	 (2, 'Small', 'Big', 35, 'O', null),
	 (3, 'Small', 'Small', 5, 'CO', null)

	 INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
	 VALUES
	 (1, '2020-01-23', 11, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (2, '2020-01-23', 22, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (3, '2020-01-23', 33, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null)

	 INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	 VALUES
	 (1, '2020-01-23', 11, 1, 23, 43, null),
	 (2, '2020-01-23', 22, 2, 23, 43, null),
	 (3, '2020-01-23', 33, 3, 23, 43, null)


	 -- Problem 16.	Create SoftUni Database ---------------------------------------------------------

	 CREATE DATABASE SoftUni
	 GO
	 USE Softuni

	 CREATE TABLE Towns(
	 Id INT PRIMARY KEY IDENTITY(1, 1),
	 [Name] NVARCHAR(50) NOT NULL
	 )

	 CREATE TABLE Addresses(
	 Id INT PRIMARY KEY IDENTITY(1, 1),
	 AddressText NVARCHAR(100) NOT NULL, 
	 TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
	 )

	 CREATE TABLE Departments(
	  Id INT PRIMARY KEY IDENTITY(1, 1),
	 [Name] NVARCHAR(50) NOT NULL
	 )

	 CREATE TABLE Employees(
	 Id INT PRIMARY KEY IDENTITY(1, 1), 
	 FirstName  NVARCHAR(50) NOT NULL, 
	 MiddleName  NVARCHAR(50), 
	 LastName  NVARCHAR(50) NOT NULL, 
	 JobTitle  NVARCHAR(50) NOT NULL, 
	 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
	 HireDate DATE NOT NULL, 
	 Salary DECIMAL (8, 2) NOT NULL, 
	 AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
	 )

	 -- Problem 18.	Basic Insert --------------------------------------------------------------------

	 INSERT INTO Towns ([Name])
	 VALUES
	 ('Sofia'), 
	 ('Plovdiv'), 
	 ('Varna'), 
	 ('Burgas')

	 INSERT INTO Departments([Name])
	 VALUES
	 ('Engineering'), 
	 ('Sales'), 
	 ('Marketing'), 
	 ('Software Development'), 
	 ('Quality Assurance')

	 INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	 VALUES
	 ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	 ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	 ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	 ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	 ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88) 

	 -- Problem 19.	Basic Select All Fields ---------------------------------------------------------

	 SELECT * FROM Towns

	 SELECT * FROM Departments

	 SELECT * FROM Employees

	 -- Problem 20.	Basic Select All Fields and Order Them ------------------------------------------

	 SELECT * FROM Towns
	 ORDER BY [Name]

	 SELECT * FROM Departments
	 ORDER BY [Name]

	 SELECT * FROM Employees
	 ORDER BY Salary DESC

	 -- Problem 21.	Basic Select Some Fields --------------------------------------------------------
	  
	 SELECT [Name] FROM Towns
	 ORDER BY [Name]

	 SELECT [Name] FROM Departments
	 ORDER BY [Name]

	 SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	 ORDER BY Salary DESC

	 -- Problem 22.	Increase Employees Salary -------------------------------------------------------

	 UPDATE Employees
	 SET Salary = Salary * 1.1
	 SELECT Salary FROM Employees

	 -- Problem 23.	Decrease Tax Rate ---------------------------------------------------------------

	 USE Hotel

	 UPDATE Payments
	 SET TaxRate = TaxRate * 0.97
	 SELECT TaxRate FROM Payments
	 
	 -- Problem 24.	Delete All Records --------------------------------------------------------------
	 
	 TRUNCATE TABLE Occupancies 
