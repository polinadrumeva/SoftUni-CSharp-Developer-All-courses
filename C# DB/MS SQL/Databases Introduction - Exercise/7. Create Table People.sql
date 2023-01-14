CREATE TABLE People 
(
	Id BIGINT IDENTITY PRIMARY KEY, 
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2), 
	[Weight] DECIMAL(5,2),
	Gender BIT NOT NULL,
	Birthdate DATETIME2 NOT NULL, 
	Biography NVARCHAR(MAX)
)


INSERT INTO People 
	VALUES
	('Ivan', NULL, 2.01, 98.00, 0, '1991-02-01', 'i akjdskdksaj'),
	('Maria', NULL, 1.91, 114.00, 1,'2020-02-01', 'i akjdskddejfhjsdhkjshdjksaj'),
	('Polina', NULL, 1.61, 58.00, 0, '1992-02-04', 'i akjddskjrnlwloi4nr.vwiorimccw,rinow3v5vcufeiscjdkxzskdksaj'),
	('Marin', NULL, 2.31, 108.00, 0, '1990-02-01', 'qwi4buV39;QCUIJNRLM3QWKJASkdksaj'),
	('Stefania', NULL, 1.71, 48.00, 0, '1993-03-01', 'dskruacw;3 jk3lckrewkjdskdksaj')