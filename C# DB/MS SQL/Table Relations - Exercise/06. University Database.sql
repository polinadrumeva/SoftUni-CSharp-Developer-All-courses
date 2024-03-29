CREATE DATABASE University 

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY , 
	[Name] NVARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY, 
	StudentNumber VARCHAR(10) UNIQUE,
	StudentName NVARCHAR(40), 
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID VARCHAR(10) PRIMARY KEY,
	PaymentDate DATE, 
	PaymentAmount DECIMAL(6,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY, 
	SubjectName NVARCHAR(30)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID), 
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)