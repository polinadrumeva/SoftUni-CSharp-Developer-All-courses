CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES [Accounts](Id),
	[Subject] NVARCHAR (MAX) NOT NULL, 
	Body NVARCHAR (MAX) NOT NULL
)


GO
CREATE TRIGGER tr_OnNewLogAddEmailNotification
ON [Logs] FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP(1) [AccountId] FROM inserted);
	DECLARE @OldSum MONEY = (Select TOP(1) [OldSum] FROM inserted);
	DECLARE @NewSum MONEY = (Select TOP(1) [NewSum] FROM inserted);

	INSERT INTO [NotificationEmails](Recipient, Subject, Body) 
	VALUES
	(
		@AccountId,
		'Balance change for account: ' + CAST(@AccountId AS NVARCHAR(50)),
		CONCAT('On',' ', GETDATE(), ' your balance was changed from ', CAST(@OldSum AS NVARCHAR(50)), ' to ', CAST(@NewSum AS NVARCHAR(50)), ' .')
	)
GO