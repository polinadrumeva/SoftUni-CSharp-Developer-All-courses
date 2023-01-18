CREATE TABLE Persons 
(
	Id INT NOT NULL, 
	FirstName NVARCHAR(20), 
	Salary DECIMAL(7,2),
	PassportID INT UNIQUE
)

INSERT INTO Persons 
	VALUES 
	(1, 'Roberto', 43300.00, 102),
	(2, 'Tom', 56100.00, 103),
	(3, 'Yana', 60200.00, 101)

CREATE TABLE Passports 
(
	PassportID INT NOT NULL UNIQUE,
	PassportNumber VARCHAR(8)
)

INSERT INTO Passports 
	VALUES 
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

ALTER TABLE Persons 
ADD PRIMARY KEY (Id)

ALTER TABLE Passports 
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPassports
FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)