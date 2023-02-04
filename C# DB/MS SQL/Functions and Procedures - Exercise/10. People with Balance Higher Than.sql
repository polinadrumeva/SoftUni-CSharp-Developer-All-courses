CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(18,4))
AS
	SELECT FirstName, LastName
		FROM AccountHolders h
		JOIN Accounts a ON h.Id = a.AccountHolderId
		GROUP BY FirstName, LastName
		HAVING SUM(a.Balance) > @Number
		ORDER BY FirstName, LastName
GO

EXEC usp_GetHoldersWithBalanceHigherThan 90000