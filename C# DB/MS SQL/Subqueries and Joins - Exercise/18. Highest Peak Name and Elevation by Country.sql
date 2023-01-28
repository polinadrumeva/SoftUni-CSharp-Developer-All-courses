SELECT TOP (5) CountryName AS Country, 
	CASE WHEN PeakName IS NULL THEN '(no highest peak)'
	ELSE PeakName
	END AS [Highest Peak Name],
	CASE 
	WHEN Elevation IS NULL THEN 0
	ELSE Elevation
	END  AS [Highest Peak Elevation], 
	MountainRange AS [Mountain]
	FROM (
	SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange,
		DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM Countries c
	 LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	 LEFT JOIN Mountains m ON mc.MountainId = m.Id
	 LEFT JOIN Peaks p ON p.MountainId = m.Id
	) AS PeakRanikingSubquery
	WHERE PeakRank = 1
	ORDER BY Country, [Highest Peak Elevation]

