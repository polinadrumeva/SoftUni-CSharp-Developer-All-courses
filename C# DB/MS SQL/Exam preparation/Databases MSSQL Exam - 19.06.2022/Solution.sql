--01. DDL
CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50) 
)

CREATE TABLE AnimalTypes (
	Id INT PRIMARY KEY IDENTITY, 
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages (
	Id INT PRIMARY KEY IDENTITY, 
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages (
	CageId INT NOT NULL,
	AnimalId INT NOT NULL, 
	CONSTRAINT PK_AnimalsCages PRIMARY KEY (CageId, AnimalId),
	CONSTRAINT FK_AnimalsCages_CageId FOREIGN KEY(CageId) REFERENCES Cages(Id),
	CONSTRAINT FK_AnimalsCages_AnimalId FOREIGN KEY(AnimalId) REFERENCES Animals(Id)
)

CREATE TABLE VolunteersDepartments (
	Id INT PRIMARY KEY IDENTITY, 
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers (
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id),
)

--02. Insert
INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId) 
	VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId) 
	VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)

--03. Update
UPDATE Animals	
	SET OwnerId = 4
	WHERE OwnerId IS NULL


--04. Delete
DELETE 
	FROM Volunteers
	WHERE DepartmentId = 2

DELETE 
	FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'


--05. Volunteers
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
	FROM Volunteers
	ORDER BY Name, AnimalId, DepartmentId

--06. Animals data
SELECT a.Name, at.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy')  
	FROM Animals a
	JOIN AnimalTypes at ON a.AnimalTypeId = at.Id
	ORDER BY a.Name

--07. Owners and Their Animals
SELECT TOP(5) o.Name AS Owner, COUNT(a.Id) AS CountOfAnimals
	FROM Animals a
	JOIN Owners o ON a.OwnerId = o.Id
	GROUP BY o.Name
	ORDER BY CountOfAnimals DESC, Owner

--08. Owners, Animals and Cages
SELECT CONCAT(o.Name, '-', a.Name) AS OwnersAnimals, o.PhoneNumber, c.Id 
	FROM Animals a
	JOIN AnimalTypes at ON a.AnimalTypeId = at.Id
	JOIN Owners o ON a.OwnerId = o.Id
	JOIN AnimalsCages ac ON a.Id = ac.AnimalId
	JOIN Cages c ON ac.CageId = c.Id
	WHERE at.AnimalType = 'Mammals'
	ORDER BY o.Name, a.Name DESC

--09. Volunteers in Sofia
SELECT v.Name, v.PhoneNumber, SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 2, LEN(v.Address))
	FROM Volunteers v
	JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
	WHERE vd.DepartmentName = 'Education program assistant' AND v.Address LIKE '%Sofia%'
	ORDER BY v.Name

--10. Animals for Adoption
SELECT a.Name, YEAR(a.BirthDate) AS BirthYear, at.AnimalType 
	FROM Animals a
	JOIN AnimalTypes at ON a.AnimalTypeId = at.Id
	WHERE OwnerId IS NULL AND at.AnimalType != 'Birds' AND BirthDate > '2018-01-01'
	ORDER BY a.Name

--11. All Volunteers in a Department
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
	BEGIN
		RETURN (SELECT COUNT(v.Id) 
			FROM Volunteers v
			JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
			WHERE vd.DepartmentName = @VolunteersDepartment)

	END
GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')


--12. Animals with Owner or Not
CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
AS
	SELECT a.Name, 
		(CASE 
			WHEN a.OwnerId IS NULL THEN 'For adoption'
			ELSE o.Name
		END) AS OwnersName
		FROM Animals a
		LEFT JOIN Owners o ON a.OwnerId = o.Id
		WHERE a.Name = @AnimalName
GO

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'

