CREATE VIEW v_HighestPeak AS

SELECT TOP (1) Id, PeakName, Elevation, MountainId
	FROM Peaks
	ORDER BY Elevation DESC

	