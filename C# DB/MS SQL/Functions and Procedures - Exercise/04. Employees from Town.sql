CREATE OR ALTER PROC usp_GetEmployeesFromTown (@Town VARCHAR(50))
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Towns t
		JOIN Addresses a ON t.TownID = a.TownID
		JOIN Employees e ON a.AddressID = e.AddressID
		WHERE t.Name = @Town
		
GO

EXEC usp_GetEmployeesFromTown Sofia
