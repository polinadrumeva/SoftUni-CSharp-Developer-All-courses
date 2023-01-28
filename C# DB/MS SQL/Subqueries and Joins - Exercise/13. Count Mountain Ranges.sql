SELECT mc.CountryCode,
		COUNT(m.MountainRange)
	FROM Mountains m
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	WHERE mc.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY mc.CountryCode