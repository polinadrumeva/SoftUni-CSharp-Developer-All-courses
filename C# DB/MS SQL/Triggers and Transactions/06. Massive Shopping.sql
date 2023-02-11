DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
DECLARE @cash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @itemsPrice MONEY = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END


SET @cash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.Name
	FROM Users AS u
	JOIN UsersGames AS ug
	  ON ug.UserId = u.Id
	JOIN Games AS g
	  ON g.Id = ug.GameId	   
	JOIN UserGameItems AS ugi
	  ON ugi.UserGameId = ug.Id
	JOIN Items AS i
	  ON i.Id = ugi.ItemId
	WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
	ORDER BY i.Name