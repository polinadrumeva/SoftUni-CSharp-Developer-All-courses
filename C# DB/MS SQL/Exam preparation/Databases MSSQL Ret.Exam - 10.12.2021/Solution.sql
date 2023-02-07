--01. DDL
CREATE DATABASE Airport

USE Airport

CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) NOT NULL, 
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Pilots (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL, 
	LastName VARCHAR(30) NOT NULL, 
	Age TINYINT NOT NULL,
	Rating FLOAT
)

CREATE TABLE AircraftTypes (
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) NOT NULL
)

CREATE TABLE Aircraft (
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL, 
	Model VARCHAR(30) NOT NULL, 
	Year INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft (
	AircraftId INT,
	PilotId INT,
	CONSTRAINT PK_PilotsAircraft PRIMARY KEY(AircraftId,PilotId),
	CONSTRAINT FK_PilotsAircraft_AircraftId FOREIGN KEY(AircraftId) REFERENCES Aircraft(Id),
	CONSTRAINT FK_PilotsAircraft_PilotId FOREIGN KEY(PilotId) REFERENCES Pilots(Id),
)

CREATE TABLE Airports (
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) NOT NULL UNIQUE, 
	Country VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE FlightDestinations (
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id), 
	Start DATETIME NOT NULL,
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	TicketPrice DECIMAL (18,2) NOT NULL
)

--02. Insert
INSERT INTO Passengers(FullName, Email) 
	VALUES 
	('Krystal Cuckson', 'KrystalCuckson@gmail.com'),
	('Susy Borrel', 'SusyBorrel@gmail.com'),
	('Saxon Veldman', 'SaxonVeldman@gmail.com'),
	('Lenore Romera', 'LenoreRomera@gmail.com'),
	('Enrichetta Jeremiah', 'EnrichettaJeremiah@gmail.com'),	
	('Delaney Stove', 'DelaneyStove@gmail.com'),
	('Ilaire Tomaszewicz', 'IlaireTomaszewicz@gmail.com'),
	('Genna Jaquet', 'GennaJaquet@gmail.com'),
	('Carlotta Dykas', 'CarlottaDykas@gmail.com'),
	('Viki Oneal', 'VikiOneal@gmail.com'),
	('Anthe Larne', 'AntheLarne@gmail.com')

--03. Update
UPDATE Aircraft
	SET Condition = 'A'
	WHERE (Condition = 'C' OR Condition = 'B') AND (FlightHours IS NULL OR FlightHours <= 100) AND Year >= 2013

--04. Delete
DELETE
	FROM Passengers
	WHERE LEN(FullName) <= 10

--05. Aircraft
SELECT Manufacturer, Model, FlightHours, Condition 
	FROM Aircraft
	ORDER BY FlightHours DESC

--06. Pilots and Aircraft
SELECT p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours 
	FROM Pilots p 
	JOIN PilotsAircraft pa ON p.Id = pa.PilotId
	JOIN Aircraft a ON pa.AircraftId = a.Id
	WHERE (a.FlightHours IS NULL) OR (a.FlightHours < 304)
	ORDER BY a.FlightHours DESC, p.FirstName

--07. Top 20 Flight Destinations
