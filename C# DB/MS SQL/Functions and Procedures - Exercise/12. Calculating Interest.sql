CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@Account INT, @Rate FLOAT)
AS
	SELECT h.Id AS [Account Id],
			h.FirstName, h.LastName, a.Balance AS [Current Balance], 
			(SELECT dbo.ufn_CalculateFutureValue (a.Balance, @Rate, 5)) AS [Balance in 5 years]
		FROM AccountHolders h
		JOIN Accounts a ON h.Id = a.AccountHolderId
		WHERE a.Id = @Account
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1