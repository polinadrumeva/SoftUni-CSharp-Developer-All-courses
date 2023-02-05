CREATE OR ALTER PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY) 
AS
	BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Amount must be positive sum', 1
	END

	UPDATE Accounts
	SET Balance = Balance + @MoneyAmount
	WHERE AccountHolderId = @AccountId

COMMIT

GO

EXEC usp_DepositMoney 1, 10

SELECT * FROM Accounts