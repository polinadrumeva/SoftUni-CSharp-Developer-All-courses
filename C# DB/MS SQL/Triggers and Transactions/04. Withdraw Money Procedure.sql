CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
	BEGIN TRANSACTION

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Amount must be positive sum', 1
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

COMMIT

GO

EXEC usp_WithdrawMoney 5, 25

SELECT * FROM Accounts
	WHERE Id = 5