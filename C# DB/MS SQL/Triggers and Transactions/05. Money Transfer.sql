CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
	BEGIN TRANSACTION
	IF (@Amount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Amount must be positive sum', 1
	END

	IF NOT EXISTS (SELECT * FROM Accounts WHERE Id = @SenderId)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Sender not found', 1
	END

	IF NOT EXISTS (SELECT * FROM Accounts WHERE Id = @ReceiverId)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Receiver not found', 1
	END

	UPDATE Accounts
	SET Balance -= @Amount
	WHERE Id = @SenderId

	UPDATE Accounts
	SET Balance += @Amount
	WHERE Id = @ReceiverId

COMMIT
GO

EXEC usp_TransferMoney 5, 1, 5000

SELECT * 
	FROM Accounts
	WHERE Id = 5 OR Id = 1
