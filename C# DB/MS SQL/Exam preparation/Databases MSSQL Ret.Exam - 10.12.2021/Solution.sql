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
SELECT TOP(20) fd.Id, fd.Start, p.FullName, a.AirportName, fd.TicketPrice
	FROM FlightDestinations fd
	LEFT JOIN Airports a ON fd.AirportId = a.Id
	LEFT JOIN Passengers p ON fd.PassengerId = p.Id
	WHERE DATEPART(day, Start) % 2 = 0
	ORDER BY fd.TicketPrice DESC, a.AirportName 

--08. Number of Flights for Each Aircraft
SELECT fd.AircraftId, a.Manufacturer, a.FlightHours, fd.FlightDestinationsCount, fd.AvgPrice
	FROM(SELECT fd.AircraftId, COUNT(*) AS FlightDestinationsCount, ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
			FROM FlightDestinations fd
			GROUP BY AircraftId 
			HAVING COUNT(*)>1) AS fd
	JOIN Aircraft a ON fd.AircraftId = a.Id
	ORDER BY fd.FlightDestinationsCount DESC, fd.AircraftId;

--09.Regular Passengers
SELECT p.FullName, COUNT(fd.PassengerId) AS CountOfAircraft, SUM(fd.TicketPrice) AS TotalPayed
	FROM Passengers p
	LEFT JOIN FlightDestinations fd ON p.Id = fd.PassengerId
	WHERE FullName LIKE '_a%'
	GROUP BY p.FullName
	HAVING COUNT(*) > 1
	ORDER BY p.FullName


--10. Full Info for Flight Destinations
SELECT a.AirportName, fd.Start AS DayTime, fd.TicketPrice,p.FullName, ac.Manufacturer, ac.Model
	FROM FlightDestinations fd
	LEFT JOIN Airports a ON fd.AirportId = a.Id
	LEFT JOIN Aircraft ac ON fd.AircraftId = ac.Id
	LEFT JOIN Passengers p ON fd.PassengerId = p.Id
	WHERE (DATEPART(hour, Start) BETWEEN 6 AND 20) AND TicketPrice > 2500
	ORDER BY ac.Model

--11.Find all Destinations by Email Address
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
	BEGIN
		RETURN (SELECT COUNT(p.Id)
			FROM Passengers p
			JOIN FlightDestinations fd ON p.Id = fd.PassengerId
			WHERE Email = @email)
	END
GO

SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

--12.Full Info for Airports
CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
	SELECT a.AirportName, p.FullName, 
		(CASE 
			WHEN fd.TicketPrice <= 400 THEN 'Low'
			WHEN (fd.TicketPrice > 400 AND fd.TicketPrice <=  1500) THEN 'Medium'
			ELSE 'High'
		END) AS LevelOfTickerPrice, ac.Manufacturer, ac.Condition, at.TypeName
		FROM Airports a
		LEFT JOIN FlightDestinations fd ON a.Id = fd.AirportId
		LEFT JOIN Passengers p ON fd.PassengerId = p.Id
		LEFT JOIN Aircraft ac ON fd.AircraftId = ac.Id
		LEFT JOIN AircraftTypes at ON ac.TypeId = at.Id
		WHERE a.AirportName = @airportName
		ORDER BY ac.Manufacturer, p.FullName
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'