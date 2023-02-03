CREATE PROC usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE (SELECT dbo.ufn_GetSalaryLevel(Salary)) = @Level
GO

EXEC usp_EmployeesBySalaryLevel 'High'