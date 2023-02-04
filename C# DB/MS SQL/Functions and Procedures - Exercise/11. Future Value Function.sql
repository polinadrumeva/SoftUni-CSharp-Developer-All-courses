CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,4), @Rate FLOAT, @NumOfYears INT)
RETURNS DECIMAL(18,4)
AS 
BEGIN
	DECLARE @Total DECIMAL(18,4) = @Sum * (POWER(1 + @Rate, @NumOfYears))
	RETURN @Total
END

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)