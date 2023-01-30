SELECT * INTO TableMoreThan30000
	FROM Employees
	WHERE Salary > 30000

DELETE FROM TableMoreThan30000 
	WHERE ManagerID = 42

UPDATE TableMoreThan30000	
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary 
	FROM TableMoreThan30000
	GROUP BY DepartmentID