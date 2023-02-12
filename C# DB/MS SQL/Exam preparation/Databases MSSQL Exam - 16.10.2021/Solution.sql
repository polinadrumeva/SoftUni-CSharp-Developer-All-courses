--01. DDL

CREATE DATABASE CigarShop

USE CigarShop

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	Length INT NOT NULL,
	RingRange DECIMAL(4,2) NOT NULL
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL, 
	TasteStrength VARCHAR(15) NOT NULL, 
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL, 
	PriceForSingleCigar DECIMAL(18,4) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT FOREIGN KEY REFERENCES Clients(id),
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)


--02. Insert
INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) 
	VALUES
	('COHIBA ROBUSTO', 9, 1, 5,	15.50, 'cohiba-robusto-stick_18.jpg'),
	('COHIBA SIGLO I', 9, 1, 10, 410.00,'cohiba-siglo-i-stick_12.jpg'),
	('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50,'hoyo-du-maire-stick_17.jpg'),
	('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00,'hoyo-de-san-juan-stick_20.jpg'),
	('TRINIDAD COLONIALES', 2, 3, 8, 85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP) 
	VALUES
	('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
	('Athens','Greece','4342 McDonald Avenue','10435'),
	('Zagreb','Croatia','4333 Lauren Drive','10000')

--03. Update
UPDATE Cigars
	SET PriceForSingleCigar = PriceForSingleCigar * 1.2
	WHERE TastId = (SELECT Id 
						FROM Tastes
						WHERE TasteType = 'Spicy')

UPDATE Brands
	SET BrandDescription = 'New description'
	WHERE BrandDescription IS NULL

--04. Delete
DELETE 
	FROM Clients
	WHERE AddressId IN (SELECT Id 
						FROM Addresses
						WHERE Country LIKE 'C%')

DELETE 
	FROM Addresses
	WHERE Country LIKE 'C%'

--05. Cigars by Price
SELECT CigarName, PriceForSingleCigar, ImageURL
	FROM Cigars
	ORDER BY PriceForSingleCigar, CigarName DESC


--06. Cigars by Taste
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength 
	FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
	ORDER BY c.PriceForSingleCigar DESC

--07. Clients without Cigars
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email
	FROM Clients c
	LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
	WHERE cc.ClientId IS NULL
	ORDER BY ClientName

--08. First 5 Cigars
SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
	FROM Cigars c
	JOIN Sizes s ON c.SizeId = s.Id
	WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
	ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--09. Clients with ZIP Codes
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, a.Country, a.ZIP, CONCAT('$', p.Price) AS CigarPrice
	FROM (SELECT cc.ClientId, MAX(ci.PriceForSingleCigar) AS Price
			FROM ClientsCigars cc
			JOIN Cigars ci ON cc.CigarId = ci.Id
			GROUP BY cc.ClientId) AS p
			JOIN Clients c ON p.ClientId = c.Id
			JOIN Addresses a ON c.Id = a.Id
			WHERE a.ZIP NOT LIKE '%[^0-9]%'
			ORDER BY FullName;

--10. Cigars by Size
SELECT c.LastName, AVG (s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients c
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cg ON cc.CigarId = cg.Id
	JOIN Sizes s ON cg.SizeId = s.Id
	GROUP BY c.LastName
	ORDER BY CiagrLength DESC

--11. Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
	BEGIN
	RETURN (SELECT COUNT(cc.CigarId)
				FROM Clients c
				JOIN ClientsCigars cc ON c.Id = cc.ClientId
				WHERE c.FirstName = @name)
	END
GO

SELECT dbo.udf_ClientWithCigars('Betty')

--12. Search for Cigar with Specific Taste
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName, CONCAT('$', c.PriceForSingleCigar) AS Price,
			t.TasteType, b.BrandName, CONCAT(s.Length, ' cm') AS CigarLength, 
			CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars c
		JOIN Tastes t ON c.TastId = t.Id
		JOIN Sizes s ON c.SizeId = s.Id
		JOIN Brands b ON c.BrandId = b.Id
		WHERE t.TasteType = @taste
		ORDER BY CigarLength, CigarRingRange DESC
GO

EXEC usp_SearchByTaste 'Woody'