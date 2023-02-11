CREATE TABLE [Logs]
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES [Accounts](Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO
CREATE TRIGGER tr_OnAccountBalanceAddLog
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
		SELECT [i].[Id], [d].[Balance], [i].[Balance] 
			FROM inserted AS i
			JOIN deleted AS d
			  ON d.Id = i.Id
			WHERE [i].Balance != [d].[Balance]
GO