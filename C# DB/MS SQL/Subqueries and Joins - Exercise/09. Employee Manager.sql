SELECT m.EmployeeID, m.FirstName, m.ManagerID, e.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees m ON e.EmployeeID = m.ManagerID
	WHERE m.ManagerID = 3 OR m.ManagerID = 7
	ORDER BY m.EmployeeID