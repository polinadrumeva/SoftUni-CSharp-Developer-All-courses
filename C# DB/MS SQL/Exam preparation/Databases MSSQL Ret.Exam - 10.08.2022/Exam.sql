--01. DDL

CREATE DATABASE NationalTouristSitesOfBulgaria

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL
) 

CREATE TABLE Locations (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL, 
	Municipality VARCHAR(50), 
	Province VARCHAR(50)
) 

CREATE TABLE Sites (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(100) NOT NULL, 
	LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id), 
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Establishment VARCHAR(15)
) 

CREATE TABLE Tourists (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL, 
	Age INT NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
) 

CREATE TABLE SitesTourists (
	TouristId INT, 
	SiteId INT, 
	CONSTRAINT PK_SitesTourists 
	PRIMARY KEY(TouristId, SiteId),
	CONSTRAINT PK_SitesTourists_TouristId FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
	CONSTRAINT PK_SitesTourists_SiteId FOREIGN KEY (SiteId) REFERENCES Sites(Id)
) 

CREATE TABLE BonusPrizes (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL
) 

CREATE TABLE TouristsBonusPrizes (
	TouristId INT, 
	BonusPrizeId INT, 
	CONSTRAINT PK_TouristsBonusPrizes 
	PRIMARY KEY(TouristId, BonusPrizeId),
	CONSTRAINT PK_TouristsBonusPrizes_TouristId FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
	CONSTRAINT PK_TouristsBonusPrizes_Bonus FOREIGN KEY (BonusPrizeId) REFERENCES BonusPrizes(Id)
) 

--02. Insert
INSERT INTO Tourists(Name, Age, PhoneNumber, Nationality, Reward) VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites(Name, LocationId, CategoryId, Establishment) VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--03. Update
UPDATE Sites	
	SET Establishment = '(not defined)'
	WHERE Establishment IS NULL

--04. Delete
DELETE
	FROM TouristsBonusPrizes
	WHERE BonusPrizeId = 5

DELETE
	FROM BonusPrizes
	WHERE Name = 'Sleeping bag'
	
--05. Tourists
SELECT Name, Age, PhoneNumber, Nationality 
	FROM Tourists
	ORDER BY Nationality, Age DESC, Name 

--06. Sites with Their Location and Category
SELECT s.Name, l.Name, s.Establishment, c.Name 
	FROM Sites s
	JOIN Locations l ON s.LocationId = l.Id
	JOIN Categories c ON s.CategoryId = c.Id
	ORDER BY c.Name DESC, l.Name, s.Name

--07. Count of Sites in Sofia Province
SELECT DISTINCT l.Province, l.Municipality, l.Name,(SELECT COUNT(Id) FROM Sites GROUP BY LocationId HAVING LocationId = l.Id) AS CountOfSites
	FROM Locations l
	JOIN Sites s ON l.Id = s.LocationId
	WHERE Province = 'Sofia'
	ORDER BY CountOfSites DESC, l.Name

--08. Tourist Sites established BC
SELECT s.Name, l.Name AS Location, l.Municipality, l.Province, s.Establishment 
	FROM Sites s
	JOIN Locations l ON s.LocationId = l.Id
	WHERE (l.Name NOT LIKE 'B%' AND l.Name NOT LIKE 'M%' AND l.Name NOT LIKE 'D%') AND Establishment LIKE '%BC%'
	ORDER BY s.Name

--09. Tourists with their Bonus Prizes
SELECT t.Name, t.Age, t.PhoneNumber, t.Nationality, 
	CASE
		WHEN b.Name IS NULL THEN '(no bonus prize)'
		ELSE b.Name
	END AS Rewards
	FROM Tourists t
	LEFT JOIN TouristsBonusPrizes tb ON t.Id = tb.TouristId
	LEFT JOIN BonusPrizes b ON tb.BonusPrizeId = b.Id
	ORDER BY t.Name

--10. Tourists visiting History & Archaeology sites
SELECT DISTINCT (SELECT SUBSTRING(t.Name, (SELECT CHARINDEX(' ',t.Name)), LEN(t.Name))) AS LastName, t.Nationality,t.Age, t.PhoneNumber 
	FROM Tourists t
	LEFT JOIN SitesTourists st ON t.Id = st.TouristId
	LEFT JOIN Sites s ON st.SiteId = s.Id
	LEFT JOIN Categories c ON s.CategoryId = c.Id
	WHERE c.Name = 'History and archaeology'
	ORDER BY LastName

--11. Tourists Count on a Tourist Site
CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
	BEGIN 
		RETURN (SELECT COUNT(s.Id)
					FROM Sites s
					LEFT JOIN SitesTourists st ON s.Id = st.SiteId
					WHERE s.Name = @Site)
	END
GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')


--12. Annual Reward Lottery
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
	SELECT * 
		FROM Tourists t
		LEFT JOIN SitesTourists st ON t.Id = st.TouristId
		LEFT JOIN Sites s ON s.Id = st.SiteId
		WHERE t.Name = 'Mariya Petrova'
GO
