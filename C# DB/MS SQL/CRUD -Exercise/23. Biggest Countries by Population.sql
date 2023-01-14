
SELECT TOP(30) CountryName, Population From Countries
	WHERE ContinentCode = 'EU'
	ORDER BY Population DESC,
	CountryName