/*01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
		*Insert few records for testing.
	    *Write a stored procedure that selects the full names of all persons.*/

USE [master]
GO

CREATE DATABASE TelerikCreditBank
GO

USE TelerikCreditBank
CREATE TABLE Persons (
Id INT IDENTITY PRIMARY KEY NOT NULL ,
FirstName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
SSN VARCHAR(10) NOT NULL
)
GO

USE TelerikCreditBank
CREATE TABLE Accounts (
Id INT IDENTITY PRIMARY KEY NOT NULL ,
PersonId INT NOT NULL,
Balance MONEY NOT NULL
CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId)
REFERENCES Persons(Id)
)
GO

USE TelerikCreditBank
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES
('Gosho', 'Goshev', 6912063456),
('Ivan', 'Ivanov', 7003022313),
('Hristo', 'Hristov', 7301016789),
('Peter', 'Petrov', 8904056789)

INSERT INTO Accounts(PersonId, Balance)
VALUES
(1, 2500.45),
(2, 1456.25),
(3, 1234.78),
(4, 4678.40)
GO

CREATE PROCEDURE dbo.usp_PersonsFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO


EXEC usp_PersonsFullName
------------------------------------------------------------------------------------------------------

--02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more 
--money in their accounts than the supplied number.

CREATE PROCEDURE
dbo.usp_PersonsWithMoreMoneyInBallanceThan(
@number money)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name]
	FROM Persons p
	JOIN Accounts a
	ON a.PersonId=p.Id
	WHERE a.Balance>@number
GO

EXEC usp_PersonsWithMoreMoneyInBallanceThan 1500
------------------------------------------------------------------------------------------------------
--03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.

CREATE FUNCTION dbo.ufn_CalculateInterest(
@sum money, @interestRate float, @months int)
RETURNS money
AS
	BEGIN
		RETURN @sum +@sum*(@interestRate/12/100)*@months
	END
GO

SELECT Balance, dbo.ufn_CalculateInterest(Balance, 3.2,5)
AS [Current Ballance]
FROM Accounts
 ------------------------------------------------------------------------------------------------------
 /*04. Create a stored procedure that uses the function from the previous example to give an interest to a person's 
 account for one month. It should take the AccountId and the interest rate as parameters.*/
  CREATE PROCEDURE dbo.usp_InterestPerMonth(
 @accountId int, @interest float)
 AS
	DECLARE @balance money =
	(SELECT Balance FROM Accounts WHERE Id = @accountId)
	 SELECT dbo.ufn_CalculateInterest(@balance,@interest ,1) -@balance	AS [Monthly Interest]
 GO

 EXEC usp_InterestPerMonth 2,3.4
 ------------------------------------------------------------------------------------------------------
 /*05. Add two more stored procedures WithdrawMoney(AccountId, money) 
 and DepositMoney(AccountId, money) that operate in transactions.*/
 CREATE PROCEDURE dbo.usp_WithdrawMoney(
 @accountId int, @money money)
 AS
	BEGIN
		UPDATE Accounts
		SET Balance	-=@money
		WHERE Id=@accountId
	END
 GO

 EXEC  usp_WithdrawMoney 2, 200

 CREATE PROCEDURE dbo.usp_DepositMoney(
 @accountId int, @money money)
 AS
	BEGIN
		UPDATE Accounts
		SET Balance	+=@money
		WHERE Id=@accountId
	END
 GO

 EXEC  usp_DepositMoney 2, 500
------------------------------------------------------------------------------------------------------
/*06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.*/
USE TelerikCreditBank
CREATE TABLE Logs (
	Id INT IDENTITY PRIMARY KEY NOT NULL ,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NweSum MONEY NOT NULL
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId)
	REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NweSum)
	SELECT 	i.Id, d.Balance, i.Balance
	FROM inserted i, deleted d
GO

EXEC  usp_DepositMoney 1, 500
EXEC  usp_DepositMoney 2, 500
EXEC  usp_DepositMoney 3, 500
EXEC  usp_DepositMoney 2, 500
EXEC  usp_WithdrawMoney 3, 200
EXEC  usp_WithdrawMoney 2, 200
EXEC  usp_WithdrawMoney 1, 1000
------------------------------------------------------------------------------------------------------