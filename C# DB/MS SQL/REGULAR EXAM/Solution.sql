--01. DDL
CREATE DATABASE Boardgames

USE Boardgames

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40) UNIQUE NOT NULL,
	Phone NVARCHAR(20) NOT NULL
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(16,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL,
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL,
	PRIMARY KEY(CreatorId, BoardgameId)
)

--02. Insert
INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
	VALUES
	('Deep Blue', 2019, 5.67, 1, 15, 7),
	('Paris', 2016, 9.78, 7, 1, 5),
	('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
	('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
	('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers(Name, AddressId, Website, Phone)
	VALUES
	('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
	('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
	('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


--03. Update
SELECT * 
	FROM PlayersRanges

UPDATE PlayersRanges
	SET PlayersMax +=1
	WHERE PlayersMin = 2 AND PlayersMax = 2

SELECT * 
	FROM Boardgames

UPDATE Boardgames
	SET Name = CONCAT(Name, 'V2')
	WHERE YearPublished >= 2020

--04. Delete
DELETE 
	FROM CreatorsBoardgames
	WHERE BoardgameId IN (SELECT Id 
							FROM Boardgames
							WHERE PublisherId IN (SELECT Id 
													FROM Publishers
													WHERE AddressId = 5))

DELETE 
	FROM Boardgames
	WHERE PublisherId IN (SELECT Id 
							FROM Publishers
							WHERE AddressId = 5)

DELETE 
	FROM Publishers
	WHERE AddressId = (SELECT Id 
						FROM Addresses 
						WHERE Town LIKE 'L%')

DELETE 
	FROM Addresses
	WHERE Town LIKE 'L%'

--05. Boardgames by Year of Publication
SELECT Name, Rating 
	FROM Boardgames
	ORDER BY YearPublished, Name DESC

--06. Boardgames by Category
SELECT b.Id, b.Name, b.YearPublished, c.Name AS CategoryName
	FROM Boardgames b
	JOIN Categories c ON b.CategoryId = c.Id
	WHERE c.Name = 'Strategy Games' OR c.Name = 'Wargames'
	ORDER BY b.YearPublished DESC

--07. Creators without Boardgames
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, c.Email
	FROM Creators c
	LEFT JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
	WHERE cb.BoardgameId IS NULL
	ORDER BY CreatorName

--08. First 5 Boardgames
SELECT TOP(5) b.Name, b.Rating, c.Name AS CategoryName
	FROM Boardgames b
	JOIN PlayersRanges pr ON b.PlayersRangeId = pr.Id
	JOIN Categories c ON b.CategoryId = c.Id
	WHERE (b.Rating > 7.00 AND b.Name LIKE '%a%') OR (b.Rating > 7.50 AND (pr.PlayersMin = 2) AND (pr.PlayersMax = 5))
	ORDER BY b.Name, b.Rating DESC

--09. Creators with Emails
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, c.Email, MAX(b.Rating) AS Rating 
	FROM Creators c
	JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
	JOIN Boardgames b ON cb.BoardgameId = b.Id
	WHERE Email LIKE '%.com'
	GROUP BY c.FirstName, c.LastName, c.Email
	ORDER BY FullName

--10. Creators by Rating
SELECT c.LastName, CEILING(Subquery.AverageRating) AS AverageRating, p.Name AS PublisherName
	FROM (SELECT c.LastName, AVG(b.Rating) AS AverageRating
			FROM Creators c
			JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
			JOIN Boardgames b ON cb.BoardgameId = b.Id
			JOIN Publishers p ON b.PublisherId = p.Id
			WHERE cb.BoardgameId IS NOT NULL AND p.Name = 'Stonemaier Games'
			GROUP BY c.LastName) AS Subquery
	JOIN Creators c ON Subquery.LastName = c.LastName
	JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
	JOIN Boardgames b ON cb.BoardgameId = b.Id
	JOIN Publishers p ON b.PublisherId = p.Id
	WHERE p.Name = 'Stonemaier Games'
	ORDER BY Subquery.AverageRating DESC

SELECT c.Id, c.LastName, AVG(b.Rating), COUNT(b.Id)
	FROM Creators c
	LEFT JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
	LEFT JOIN Boardgames b ON cb.BoardgameId = b.Id
	JOIN Publishers p ON b.PublisherId = p.Id
	WHERE cb.BoardgameId IS NOT NULL AND p.Name = 'Stonemaier Games'
	GROUP BY c.Id, c.LastName


--11. Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
	BEGIN
		RETURN (SELECT COUNT(c.Id) 
					FROM Creators c
					JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
					JOIN Boardgames b ON cb.BoardgameId = b.Id
					WHERE c.FirstName = @name)
	END
GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

--12. Search for Boardgame with Specific Category
CREATE PROC usp_SearchByCategory(@category VARCHAR(50)) 
AS
	SELECT b.Name, b.YearPublished, b.Rating, c.Name AS CategoryName, p.Name AS PublisherName, CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
			CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
		FROM Boardgames b
		JOIN Categories c ON b.CategoryId = c.Id
		JOIN Publishers p ON b.PublisherId = p.Id
		JOIN PlayersRanges pr ON b.PlayersRangeId = pr.Id
		WHERE c.Name = @category
		ORDER BY PublisherName, b.YearPublished DESC
GO

EXEC usp_SearchByCategory 'Wargames'