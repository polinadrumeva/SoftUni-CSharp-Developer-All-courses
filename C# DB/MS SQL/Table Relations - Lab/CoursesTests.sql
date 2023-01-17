CREATE DATABASE CoursesTests

CREATE TABLE Students_3
(
	Id INT IDENTITY PRIMARY KEY, 
	FirstName NVARCHAR(10) NOT NULL, 
	LastName NVARCHAR(10) NOT NULL, 
	FacultyNumber CHAR(6) NOT NULL UNIQUE,
	Photo VARBINARY(MAX), 
	[Date] DATE
)

CREATE TABLE Towns 
(
	Id INT IDENTITY PRIMARY KEY, 
	Name NVARCHAR(20)
)

INSERT INTO Towns (Name)
	VALUES ('Sofia'), 
	('Plovdiv'), 
	('Stara Zagora'), 
	('Veliko Turnovo')

CREATE TABLE Course
(
	Id INT IDENTITY PRIMARY KEY, 
	Name NVARCHAR(50) NOT NULL, 
	TownId INT REFERENCES Towns(Id) 
)

INSERT INTO Course (Name, TownId)
	VALUES ('C#', 1), 
	('Python', 2), 
	('HTML', 1), 
	('PHP', 3)

CREATE TABLE StudentsCourses
(	
	StudentId INT REFERENCES Students_3(Id),
	CourseId INT REFERENCES Course(Id),
	Mark DECIMAL(3,2), 
	CONSTRAINT PK_StudentsCourses
		PRIMARY KEY(StudentId, CourseId)
)

SELECT * 
	FROM Course
	JOIN Towns ON Course.TownId = Towns.Id

SELECT sc.FirstName, sc.LastName, sc.FacultyNumber, c.Id, c.Name, s.Mark, t.Name 
	FROM Course c
	JOIN Towns t ON c.TownId = t.Id
	JOIN StudentsCourses s ON s.CourseId = c.Id
	JOIN Students_3 sc ON sc.Id = s.StudentId

