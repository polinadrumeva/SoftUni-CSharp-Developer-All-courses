SELECT TOP(1) (SELECT AVG(Salary)
			FROM Employees
			WHERE DepartmentID  = d.DepartmentID) AS AvgSalary
	FROM Departments d
	ORDER BY AvgSalary