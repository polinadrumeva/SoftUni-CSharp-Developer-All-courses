CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @State VARCHAR(10)
	IF @Salary < 30000
		SET @State = 'Low'
	ELSE IF @Salary <= 50000
		SET @State = 'Average'
	ELSE 
		SET @State = 'High'
	RETURN @State
END
	