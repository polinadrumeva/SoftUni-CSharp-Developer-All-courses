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
