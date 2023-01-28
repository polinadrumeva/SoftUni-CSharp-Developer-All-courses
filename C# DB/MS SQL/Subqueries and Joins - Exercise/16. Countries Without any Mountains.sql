
SELECT COUNT(*) AS Count
	FROM (
		SELECT mc.MountainId m
			FROM MountainsCountries mc
	  RIGHT JOIN Countries c ON c.CountryCode = mc.CountryCode
		WHERE mc.MountainId IS NULL
		) AS Query