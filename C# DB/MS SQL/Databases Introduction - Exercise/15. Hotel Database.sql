CREATE DATABASE Hotel

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees 
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	Title NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
	VALUES 
	('Polina', 'Drumeva', 'Manager', 'some notes'),
	('Maria', 'Ivanova', 'Hostesa', 'some notes'),
	('Ivan', 'Devev', 'Pikolo', 'some notes')

--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers 
(
	AccountNumber INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	PhoneNumber VARCHAR(10),
	EmergencyName NVARCHAR(50),
	EmergencyNumber VARCHAR(10),
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
	VALUES 
	('Iva', 'Nikolova', '0887526652', 'Valq Moarinova', '02458655', 'some notes'),
	('Dew', 'Wes', '0565565223', 'Vasa Asw', '2546223', 'some notes'),
	('Sara', 'Napol', '0889956652', 'Joro Marinov', '03778375', 'some notes')

--•	RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus 
(
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
	VALUES 
	(0, 'some notes'),
	(1, 'some notes'),
	(0, 'some notes')

--•	RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(20),
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
	VALUES 
	('apartment', 'some notes'),
	('studio', 'some notes'),
	('double room', 'some notes')

--•	BedTypes (BedType, Notes)
CREATE TABLE BedTypes 
(
	BedType VARCHAR(20),
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
	VALUES 
	('single', 'some notes'),
	('double', 'some notes'),
	('triple', 'some notes')


--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms 
(
	RoomNumber INT IDENTITY PRIMARY KEY,
	RoomType VARCHAR(20),
	BedType VARCHAR(20),
	Rate INT,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
	VALUES 
	('apartment', 'double', 10, 0, 'some notes'),
	('studio', 'double', 9, 0, 'some notes'),
	('single room', 'single', 8, 0, 'some notes')


--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments 
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT,
	PaymentDate DATE,
	AccountNumber INT,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL(5,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments
	VALUES 
	(3, '2020-03-01', 234, '2021-05-04', '2021-05-10', 6, 100.20, 5.00, 20.00, 120.20, 'some notes'),
	(1, '2021-03-01', 2334, '2021-06-01', '2021-06-10', 9, 200.20, 5.00, 20.00, 220.20, 'some notes'),
	(2, '2022-03-01', 238734, '2021-04-04', '2021-05-10', 25, 100.20, 5.00, 200.00, 120.20, 'some notes')



--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)

CREATE TABLE Occupancies 
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT,
	DateOccupied DATE,
	AccountNumber INT,
	RoomNumber INT,
	RateApplied BIT,
	PhoneCharge BIT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
	VALUES 
	(3, '2020-03-01', 234, 2, 0, 1, 'some notes'),
	(4, '2021-03-15', 868, 4, 0, 1, 'some notes'),
	(2, '2023-01-01', 563, 12, 1, 0, 'some notes')

