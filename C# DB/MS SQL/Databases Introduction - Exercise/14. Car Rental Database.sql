CREATE DATABASE CarRental

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories 
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(30),
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories
	VALUES 
	('Motor car', 3, 4, 5, 9),
	('Jeep', 8, 1, 3, 9),
	('Bus', 3, 7, 9, 9)

--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars 
(
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber VARCHAR(8),
	Manufacturer NVARCHAR(20),
	Model NVARCHAR(20),
	CarYear INT,
	CategoryId INT,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX),
	Available BIT
)

INSERT INTO Cars
	VALUES 
	('DE3728WE', 'Ferrari', '300', 2021, 1, 2, NULL, 'some condition', 0),
	('WEK353EK', 'Renault', '300', 2020, 1, 4, NULL, 'some condition', 1),
	('DW3847OP', 'Honda', 'CRV', 2000, 1, 5, NULL, 'some condition', 2)

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees 
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20),
	LastName NVARCHAR(20),
	Title NVARCHAR(40),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
	VALUES 
	('Tino', 'Molinova', 'Manager', 'some notes'),
	('Jack', 'Prino', 'Driver', 'some notes'),
	('Huan', 'Devi', 'Driver', 'some notes')

--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers 
(
	Id INT IDENTITY PRIMARY KEY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50),
	[Address] NVARCHAR(50),
	City NVARCHAR(30),
	ZIPCode INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
	VALUES 
	(38962676, 'Ivan Petrov', 'Gotshe Delchev', 'Sofia', 1404, 'some notes'),
	(29856265, 'Maria Petrova', 'Lozenec', 'Sofia', 1400, 'some notes'),
	(2918287, 'Ivalina Georgieva', 'Vasil Levski', 'Veliko Turnovo', 5000, 'some notes')

--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
--TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE RentalOrders 
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT,
	CustomerId INT,
	CarId INT,
	TankLevel INT,
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied BIT, 
	TaxRate INT, 
	OrderStatus BIT,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders
	VALUES 
	(12, 34, 3,4, 22332, 454333, 23, '2020-02-09', '2020-03-02', 10, 0, 10, 1, 'some notes'),
	(1, 4, 34, 4, 222, 433, 3, '2021-02-09', '2021-02-02', 2, 0, 10, 1, 'some notes'),
	(7, 39, 6 ,7, 234545, 45877833, 5460, '2022-01-09', '2022-03-02', 6, 0, 10, 1, 'some notes')