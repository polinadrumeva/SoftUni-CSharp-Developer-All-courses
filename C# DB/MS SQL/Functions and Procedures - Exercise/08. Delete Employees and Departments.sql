CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
	DECLARE @employeesToDelete TABLE (Id INT)
	INSERT @employeesToDelete 
		SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @DepartmentId

	DELETE 
		FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT * FROM @employeesToDelete)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
		SET ManagerID = NULL
		WHERE ManagerID IN (SELECT * FROM @employeesToDelete)

	UPDATE Employees
		SET ManagerID = NULL
		WHERE ManagerID IN (SELECT * FROM @employeesToDelete)
	
	DELETE 
		FROM Employees
		WHERE DepartmentID = @DepartmentId

	DELETE 
		FROM Departments
		WHERE DepartmentID = @DepartmentId

	SELECT COUNT(*)
		FROM Employees
		WHERE DepartmentID = @DepartmentId
GO

EXEC usp_DeleteEmployeesFromDepartment 1