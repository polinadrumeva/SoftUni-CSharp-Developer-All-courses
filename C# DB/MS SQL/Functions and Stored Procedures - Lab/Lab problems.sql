-- Problem: Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF @Salary IS NULL
	RETURN NULL
	IF @Salary < 30000 
	RETURN 'Low'
	ELSE IF @Salary <= 50000 
	RETURN 'Average'
	ELSE 
	RETURN 'High'

	RETURN NULL
END

SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
	FROM Employees

-- Problem: Employees with three projects 

CREATE PROC	AddEmployee(@EmployeeID INT, @ProjectID INT)
AS
	DECLARE @EmployeeProjectCount INT = 
		(SELECT COUNT(*) FROM EmployeesProjects
		WHERE @EmployeeID = EmployeeID)

	IF @EmployeeProjectCount >= 3
		THROW 50001, 'The employee has 3 projects.', 1

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES (@EmployeeID, @ProjectID)

GO

EXEC AddEmployee 2, 3
EXEC AddEmployee 2, 4
EXEC AddEmployee 2, 5
EXEC AddEmployee 2, 6