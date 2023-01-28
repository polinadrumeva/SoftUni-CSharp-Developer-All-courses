-- Problem: Address with towns

--SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText 
--	FROM Employees e
--	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
--	LEFT JOIN Towns t ON a.TownID = t.TownID
--	ORDER BY e.FirstName, e.LastName


-- Problem: Sales Employees

--SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
--	FROM Employees e
--	JOIN Departments d ON e.DepartmentID = d.DepartmentID
--	WHERE d.Name = 'Sales'
--	ORDER BY e.EmployeeID


-- Problem: Employyes hired after

--SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
--	FROM Employees e
--	JOIN Departments d ON e.DepartmentID = d.DepartmentID
--	WHERE e.HireDate > '1999-01-01' AND (d.Name = 'Sales' OR d.Name = 'Finance')
--	ORDER BY e.HireDate

-- Problem: Employee Summary

SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName, d.Name AS DepartmentName
	FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

