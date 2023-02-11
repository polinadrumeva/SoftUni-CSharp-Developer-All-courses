CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
	DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)
	
	DECLARE @countProjects INT = (SELECT COUNT(*)FROM EmployeesProjects 
								  WHERE EmployeeID = @emloyeeId)

	IF (@employee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid employee or project', 2
	END
	IF (@countProjects) >= 3
	BEGIN
		ROLLBACK;
		THROW 50002, 'The employee has too many projects!', 1
	END
	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
	(@emloyeeId, @projectID)
COMMIT
GO