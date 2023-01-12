CREATE TABLE Users
(
	Id BIGINT IDENTITY PRIMARY KEY, 
	Username VARCHAR(30) NOT NULL, 
	[Password] VARCHAR(26) NOT NULL, 
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2, 
	IsDeleted BIT
)

INSERT INTO Users
	VALUES
	('Peter', '233423', null, '2022-02-02', 0),
	('Ivan', '349847', null, '2022-02-03', 1),
	('Maria', '2931741', null, '2022-03-02', 0),
	('Polina', '392757', null, '2023-02-02', 1),
	('Moni', '9284923', null, '2021-02-02', 1)