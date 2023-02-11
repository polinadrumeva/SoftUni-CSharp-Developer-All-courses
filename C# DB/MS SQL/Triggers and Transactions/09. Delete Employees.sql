CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(150) NOT NULL,
	DepartmentId INT REFERENCES Departments(DepartmentID),
	Salary MONEY NOT NULL
)

GO
CREATE TRIGGER tr_LogDeletedEmployees
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted
GO