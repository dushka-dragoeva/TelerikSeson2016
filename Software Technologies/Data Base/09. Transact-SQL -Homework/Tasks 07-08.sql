/*07. Define a function in the database TelerikAcademy that returns all Employee's names
 (first or middle or last name) and all town's names that are comprised of given set of letters.
Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.*/
USE TelerikAcademy
GO

CREATE FUNCTION ufn_CheckString(
@stringToCheck NVARCHAR(50), @pattern NVARCHAR(50))
RETURNS INT
AS
	BEGIN
		DECLARE @i INT =1
		DECLARE @currentChar NVARCHAR(1)
		IF (@stringToCheck IS NULL) 
				BEGIN  
					RETURN 0
				END
		WHILE(@i <=LEN(@stringToCheck))
			BEGIN
				SET @currentChar = SUBSTRING(@stringToCheck,@i, 1)
					IF (CHARINDEX(LOWER(@currentChar),LOWER(@pattern)) <= 0) 
						BEGIN  
							RETURN 0
						END
				SET @i = @i + 1	
			END
		RETURN 1
	END
GO

USE TelerikAcademy
GO

CREATE FUNCTION dbo.ufn_AllEmploeeysAndTownByStringPattern(@pattern NVARCHAR(50))
RETURNS @table TABLE
	([Name] NVARCHAR(50) NOT NULL)
AS
BEGIN
	INSERT @table
	SELECT DataToCheck.LastName FROM
		(SELECT LastName FROM Employees
		UNION
		SELECT FirstName FROM Employees
		UNION
		SELECT MiddleName FROM Employees
		UNION
		SELECT Name FROM Towns) AS DataToCheck
		WHERE dbo.ufn_CheckString(DataToCheck.LastName, @pattern) > 0
	 RETURN
END
GO

SELECT * FROM ufn_AllEmploeeysAndTownByStringPattern('oistmiahf')
------------------------------------------------------------------------------------------------------
/*08. Using database cursor write a T-SQL script that scans all employees and their addresses 
and prints all pairs of employees that live in the same town.*/

DECLARE employeeCoursor CURSOR READ_ONLY FOR
  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
  JOIN Addresses a
  ON e.AddressID = a.AddressID
  JOIN Towns t
  ON a.TownID = t.TownID

OPEN employeeCoursor
DECLARE @firstName nvarchar(50), @lastName nvarchar(50), @town nvarchar(50)
FETCH NEXT FROM employeeCoursor INTO @firstName, @lastName, @town

WHILE @@FETCH_STATUS = 0
  BEGIN
  			  DECLARE employeeCoursor1 CURSOR READ_ONLY FOR
			  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			  JOIN Addresses a
			  ON e.AddressID = a.AddressID
			  JOIN Towns t
			  ON a.TownID = t.TownID

			OPEN employeeCoursor1
			DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town1 nvarchar(50)
			FETCH NEXT FROM employeeCoursor1 INTO @firstName1, @lastName1, @town1

			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1 AND @firstName != @firstName1 AND @lastName != @lastName1)
				  BEGIN
					PRINT @town+':'+ @firstName + ' ' + @lastName + ':' + @firstName1 + ' ' + @lastName1 
				  END
				FETCH NEXT FROM employeeCoursor1 INTO @firstName1, @lastName1, @town1
			  END

			CLOSE employeeCoursor1
			DEALLOCATE employeeCoursor1

    FETCH NEXT FROM employeeCoursor  INTO @firstName, @lastName, @town
  END

CLOSE employeeCoursor
DEALLOCATE employeeCoursor
------------------------------------------------------------------------------------------------------
