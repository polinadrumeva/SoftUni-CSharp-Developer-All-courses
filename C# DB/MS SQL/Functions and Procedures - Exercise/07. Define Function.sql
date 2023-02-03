CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(50), @Word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @WordIndex INT = 1
	WHILE (@WordIndex <= LEN(@Word))
		BEGIN
			DECLARE @CurrentChar CHAR = SUBSTRING(@Word, @WordIndex, 1)
			IF CHARINDEX(@CurrentChar, @SetOfLetters) = 0
				BEGIN
					RETURN 0
				END
			SET @WordIndex += 1
		END

	RETURN 1
END

SELECT dbo.ufn_IsWordComprised 'sdsafds', 'Sofia'