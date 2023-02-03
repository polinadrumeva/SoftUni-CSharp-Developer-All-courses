CREATE OR ALTER PROC usp_GetTownsStartingWith (@StartLetter VARCHAR(2))
AS
	SELECT Name AS Town
		FROM Towns
		WHERE CHARINDEX(@StartLetter, Name) = 1
GO

EXEC usp_GetTownsStartingWith b