CREATE TABLE dvo_Minions (
	Id int NOT NULL, 
	Name nvarchar(20) NOT NULL,
	Age int NOT NULL
	CONSTRAINT Minions PRIMARY KEY(Id)
	)

CREATE TABLE dvo_Towns (
	Id int NOT NULL, 
	Name nvarchar(20) NOT NULL
	CONSTRAINT Towns PRIMARY KEY(Id)
	)