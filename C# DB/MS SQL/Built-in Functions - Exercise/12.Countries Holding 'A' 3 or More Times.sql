SELECT CountryName AS [Country name], IsoCode AS [ISO Code]
	FROM Countries
	WHERE LOWER(CountryName) LIKE '%a%a%a%'
	ORDER BY IsoCode