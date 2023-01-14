CREATE DATABASE Movies

-- 	Directors (Id, DirectorName, Notes)
CREATE TABLE Directors 
(
	Id INT IDENTITY PRIMARY KEY,
	DirectorName NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)
INSERT INTO Directors 
	VALUES ('Alexandra', 'best directors ever') , 
	('WB', 'ok') , 
	('Paccino', 'godfather') , 
	('Valencia', 'new fin company') , 
	('They', 'new') 

-- Genres (Id, GenreName, Notes)
CREATE TABLE Genres 
(
	Id INT IDENTITY PRIMARY KEY,
	GenreName NVARCHAR(40) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres (GenreName)
	VALUES ('Horor') , 
	('Comedy') , 
	('Drama') , 
	('Romantic') , 
	('Criminal') 

--	Categories (Id, CategoryName, Notes)
CREATE TABLE Categories 
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName)
	VALUES ('Horor') , 
	('Comedy') , 
	('Drama') , 
	('Romantic') , 
	('Criminal') 

-- Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
CREATE TABLE Movies 
(
	Id INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL, 
	CopyrightYear INT, 
	[Length] TIME,
	GenreId INT NOT NULL, 
	CategoryId INT NOT NULL,
	Rating INT, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies
	VALUES ('Titanic', 2, 1992, '3:00:00', 3, 3, 10, 'best movie') , 
	('Notebook', 1, 1999, '1:50:00', 4, 4, 9, 'very good') , 
	('Be mine', 3, 2002, '2:00:00', 4, 4, 6, 'not') , 
	('Cops', 5, 2018, '1:40:32', 5, 5, 7, 'prefer') , 
	('Scary movie', 4, 1992, '1:34:23', 2, 2, 10, 'funny movie') 
