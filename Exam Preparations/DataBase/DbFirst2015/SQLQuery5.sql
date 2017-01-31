USE PetStore
GO

CREATE PROCEDURE usp_seed_initial_colors 
AS
	DECLARE @ColorCount AS 	INT
	SET @ColorCount =( SELECT COUNT (*) fROM Colors)
	IF @ColorCount=0
	BEGIN
		INSERT INTO Colors(Value)
		VALUES('Black'),('White'),('Red'),('Mixed')
	END
GO

EXEC dbo.usp_seed_initial_colors
GO