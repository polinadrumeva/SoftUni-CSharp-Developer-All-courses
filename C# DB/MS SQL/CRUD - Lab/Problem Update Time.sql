UPDATE Projects
	SET EndDate = GETDATE()
	WHERE EndDate IS NULL


SELECT * 
	FROM Projects
