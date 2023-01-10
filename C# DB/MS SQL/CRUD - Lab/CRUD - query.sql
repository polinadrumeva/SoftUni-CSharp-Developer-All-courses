SELECT Id 
	FROM Mountains

SELECT * 
	FROM Countries

SELECT * 
	FROM Countries 
	WHERE CountryCode = 'AD'

SELECT Capital, CountryName, Population 
	FROM Countries

SELECT Capital AS C, CountryName, Population
	FROM Countries

SELECT TOP(10) Capital AS C, CountryName, Population 
	FROM Countries

SELECT CountryName, Population
	FROM Countries 
	WHERE Population > 900000 AND 
	Capital > 'D'

SELECT CountryName, Population
	FROM Countries 
	WHERE Population > 900000 AND 
	Capital > 'D'
	ORDER BY CountryName DESC

--INSERT INTO Peaks(PeakName, Elevation, MountainId)
	--VALUES ('Botev', 2312, 17)

DELETE FROM Peaks WHERE Id=50

SELECT * 
	FROM Peaks


