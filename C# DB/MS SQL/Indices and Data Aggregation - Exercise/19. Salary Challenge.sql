SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
	FROM Employees e
	JOIN (
		SELECT DepartmentID, AVG (Salary) AS AverageSalary
		FROM Employees
		GROUP BY DepartmentID) av ON e.DepartmentID = av.DepartmentID
	WHERE e.Salary > av.AverageSalary
	ORDER BY e.DepartmentID
