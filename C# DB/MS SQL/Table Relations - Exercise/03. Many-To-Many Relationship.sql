CREATE TABLE Students 
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(20)
)

INSERT INTO Students 
	VALUES 
	('Mila'),
	('Toni'),
	('Ron')


CREATE TABLE Exams 
(
	ExamID INT PRIMARY KEY,
	[Name] VARCHAR(20)
)

INSERT INTO Exams 
	VALUES 
	(101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

CREATE TABLE StudentsExams 
(
	StudentID INT,
	ExamID INT,
	CONSTRAINT PK_StudentExam
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_StudentID
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_ExamID
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams 
	VALUES 
	(1, 101),
	(1, 102), 
	(2, 101), 
	(3, 103), 
	(2, 102), 
	(2, 103)