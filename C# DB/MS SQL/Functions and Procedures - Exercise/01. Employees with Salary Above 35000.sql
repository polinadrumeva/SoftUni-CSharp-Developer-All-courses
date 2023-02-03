CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees
		WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000