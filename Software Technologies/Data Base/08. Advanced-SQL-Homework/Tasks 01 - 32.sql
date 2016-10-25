--1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary 
--in the company. Use a nested SELECT statement.
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees);
------------------------------------------------------------------------------------------------------
--2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to
-- 10% higher than the minimal salary for the company
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary <=
	(SELECT MIN(Salary) FROM Employees)*1.1;
	------------------------------------------------------------------------------------------------------
--3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal 
-- salary in their department.	Use a nested SELECT statement.
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Full Name], E.Salary, D.Name
FROM Employees E, Departments D
WHERE Salary = 	(SELECT MIN(Salary) FROM Employees S
	WHERE S.DepartmentID =d.DepartmentID)
ORDER BY D.DepartmentID;
------------------------------------------------------------------------------------------------------
--4.	Write a SQL query to find the average salary in the department #1.
USE TelerikAcademy
SELECT AVG(Salary) AS [Average Salary]
FROM Employees 
WHERE DepartmentID =1;
------------------------------------------------------------------------------------------------------
--5.	Write a SQL query to find the average salary in the "Sales" department.
USE TelerikAcademy
SELECT AVG(E.Salary) AS [Average Salary]
FROM Employees E
JOIN Departments D
ON E.DepartmentID=D.DepartmentID
WHERE D.Name ='Sales';
------------------------------------------------------------------------------------------------------
--6.	Write a SQL query to find the number of employees in the "Sales" department.
USE TelerikAcademy
SELECT COUNT (E.FirstName) AS [Number of Employees in Sales Departament]
FROM Employees E
JOIN Departments D
ON E.DepartmentID=D.DepartmentID
WHERE D.Name ='Sales';
------------------------------------------------------------------------------------------------------
--7.	Write a SQL query to find the number of all employees that have manager.
USE TelerikAcademy
SELECT COUNT (FirstName) AS [Employees with Manager]
FROM Employees 
WHERE ManagerID IS NOT NULL
------------------------------------------------------------------------------------------------------
--8.	Write a SQL query to find the number of all employees that have no manager.
USE TelerikAcademy
SELECT COUNT (FirstName) AS [Employees without Manager]
FROM Employees 
WHERE ManagerID IS NULL
------------------------------------------------------------------------------------------------------
--9.	Write a SQL query to find all departments and the average salary for each of them.
USE TelerikAcademy
SELECT D.Name AS [Dpartment ], ROUND(AVG(E.Salary), 2) AS [Average Salary]
FROM  Departments D, Employees E
WHERE D.DepartmentID= E.DepartmentID
GROUP BY D.Name
ORDER BY [Average Salary] DESC
------------------------------------------------------------------------------------------------------
--10.	Write a SQL query to find the count of all employees in each department and for each town.
USE TelerikAcademy
SELECT T.Name as [Town], D.Name AS [Dpartment ], COUNT(E.FirstName) AS [Employees Count]
FROM  Departments D, Towns T, Employees E, Addresses A
WHERE E.AddressID=A.AddressID
AND A.TownID =T.TownID
AND D.DepartmentID= E.DepartmentID
GROUP BY  D.Name, T.Name
------------------------------------------------------------------------------------------------------
--11.	Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
USE TelerikAcademy
SELECT M.FirstName + ' ' + M.LastName AS [Manager Name], COUNT (E.ManagerID) AS [Count]
FROM Employees E, Employees M
WHERE E.ManagerID = M.ManagerID
GROUP BY M.FirstName, M.LastName
HAVING COUNT (E.ManagerID) =5
------------------------------------------------------------------------------------------------------
--12.	Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
USE TelerikAcademy
SELECT( E.FirstName + ' ' + E.LastName) AS [Employee], ISNULL(M.FirstName + ' ' + M.LastName, '(no manager)') AS [Manager]
FROM Employees E
LEFT OUTER JOIN Employees M
ON E.ManagerID = M.EmployeeID
------------------------------------------------------------------------------------------------------
--13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
USE TelerikAcademy
SELECT E.FirstName, E.LastName
FROM Employees E
WHERE LEN(E.LastName)=5
------------------------------------------------------------------------------------------------------
--14.	Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
--o	Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) AS [Current date]
------------------------------------------------------------------------------------------------------
--15.	Write a SQL statement to create a table Users.
-- Users should have username, password, full name and last login time.
--o	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--o	Define the primary key column as identity to facilitate inserting records.
--o	Define unique constraint to avoid repeating usernames.
--o	Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
Id INT NOT NULL IDENTITY PRIMARY KEY,
Username nvarchar(100)NOT NULL UNIQUE ,
Password nvarchar(50), 
FullName  nvarchar(150) NOT NULL,
LastLogin SMALLDATETIME,
CONSTRAINT [Password] CHECK (LEN(Password)>=5)
)
GO
------------------------------------------------------------------------------------------------------
--16.	Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--o	Test if the view works correctly.

CREATE VIEW [V_Visitors_Today] AS
SELECT Username
FROM Users
WHERE CONVERT(varchar, LastLogin,104) = CONVERT(varchar, GETDATE(),104);
GO
------------------------------------------------------------------------------------------------------
--17.	Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--o	Define primary key and identity column.

CREATE TABLE Groups(
Id INT NOT NULL IDENTITY PRIMARY KEY,
Name nvarchar(100)NOT NULL UNIQUE ,
)
GO
------------------------------------------------------------------------------------------------------
--18.	Write a SQL statement to add a column GroupID to the table Users.
--o	Fill some data in this new column and as well in the `Groups table.
--o	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
USE TelerikAcademy
ALTER TABLE Users
ADD GroupId INT
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Group
FOREIGN KEY (GroupId)
REFERENCES Groups(Id)
Go
------------------------------------------------------------------------------------------------------
--19.	Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups
VALUES
('First_Group'),
('Second_Group'),
('Third_Group')
GO
 
 INSERT INTO Users
 VALUES
 ('JohnD', 'johny_bravo', 'John Doe', GetDate(), 1),
('JaneD', 'janeIsInsane', 'Jane Doe', GetDate(), 2),
('JimmyD', 'hendrix4Life', 'Jimmy Doe', GetDate(), 3),
('VoggD', 'johny_bravo', 'John Doe', GetDate(), 1),
('Jane5D', 'janeIsInsane', 'Jane Doe', GetDate(), 2),
('Jimmy6D', 'hendrix4Life', 'Jimmy Doe', GetDate(), 3)
GO

------------------------------------------------------------------------------------------------------
--20.	Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET[Password]='ASDFGHJK'
WHERE Username ='JaneD'
GO

UPDATE Groups
SET[Name]='ASDFGHJK'
WHERE Id =2
GO
------------------------------------------------------------------------------------------------------
--21.	Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE Users
WHERE Username ='JaneD'
GO
------------------------------------------------------------------------------------------------------
--22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--o	Combine the first and last names as a full name.
--o	For username use the first letter of the first name + the last name (in lowercase).
--o	Use the same for the password, and NULL for last login time.
 INSERT INTO Users
 ([FullName], [Username], [Password], [LastLogin])
 SELECT E.FirstName +E.LastName,
	LOWER(SUBSTRING(E.FirstName, 1,3))+ LOWER( SUBSTRING(E.LastName, 1,3))+CONVERT(varchar,E.HireDate),
	LOWER(SUBSTRING(E.FirstName, 1,1))+ LOWER( SUBSTRING(E.LastName, 1,1))+'555555',
	NULL
FROM Employees E
GO
------------------------------------------------------------------------------------------------------
--23.	Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET [Password] = NULL
WHERE DATEDIFF(DAY, LastLogin, '03.10.2010 00:00:00:000') > 0
GO
------------------------------------------------------------------------------------------------------
--24.	Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE [Password] IS NULL
GO
------------------------------------------------------------------------------------------------------
--25.	Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) AS AverageSalary, d.Name AS Department, e.JobTitle
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name, e.JobTitle
------------------------------------------------------------------------------------------------------
--26.	Write a SQL query to display the minimal employee salary by department and job title along
-- with the name of some of the employees that take it.
SELECT e.FirstName, e.LastName, MIN(e.Salary) AS MinimalSalary, d.Name AS Department, e.JobTitle
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName
ORDER BY d.Name, e.JobTitle
------------------------------------------------------------------------------------------------------
--27.	Write a SQL query to display the town where maximal number of employees work.
USE TelerikAcademy
SELECT TOP 1 T.Name as [Town],  COUNT(M.FirstName) AS [Managers Count]
FROM  Towns T, Employees M, Addresses A
WHERE M.AddressID=A.AddressID
AND A.TownID =T.TownID
AND M.AddressID= A.AddressID
GROUP BY  T.Name
ORDER BY [Managers Count] Desc
------------------------------------------------------------------------------------------------------
--28.	Write a SQL query to display the number of managers from each town.
USE TelerikAcademy
SELECT T.Name as [Town],  COUNT(M.FirstName) AS [Managers Count]
FROM  Towns T, Employees M, Addresses A
WHERE M.AddressID=A.AddressID
AND A.TownID =T.TownID
AND M.AddressID= A.AddressID
GROUP BY  T.Name
------------------------------------------------------------------------------------------------------
--29.	Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--o	Don't forget to define identity, primary key and appropriate foreign key.
--o	Issue few SQL statements to insert, update and delete of some data in the table.
--o	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--	For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(250),
	CONSTRAINT FK_WorkHours_Employees 
		FOREIGN KEY (EmployeeId) 
		REFERENCES Employees(EmployeeID)
)
GO

INSERT INTO WorkHours
VALUES (1, GETDATE(), 'Task1', 10, NULL),
	   (2, GETDATE(), 'Task2', 9, NULL),
	   (3, GETDATE(), 'Task3', 8, 'TODO')
GO

UPDATE WorkHours
SET [Comments] = 'Did bad work'
WHERE [EmployeeId] = 1
GO

DELETE FROM WorkHours
WHERE [Hours] = 9
GO

CREATE TABLE ReportsLogs(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(250),
	[For] VARCHAR(50)
)
GO

CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
FOR INSERT 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'INSERT'
    FROM INSERTED
GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
FOR DELETE 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'DELETE'
    FROM DELETED
GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours
FOR UPDATE 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'UPDATE'
    FROM INSERTED
GO

INSERT INTO WorkHours
VALUES(2, GETDATE(), 'Task2', 9, NULL)
GO

DELETE FROM  WorkHours 
WHERE [Hours] = 9
GO

UPDATE WorkHours
SET Comments = 'Done'
WHERE Comments = 'TODO'
------------------------------------------------------------------------------------------------------
--30.	Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--o	At the end rollback the transaction.
BEGIN TRAN
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE WorkHours
	DROP CONSTRAINT FK_WorkHours_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN
------------------------------------------------------------------------------------------------------
--31.	Start a database transaction and drop the table EmployeesProjects.
--o	Now how you could restore back the lost table data?
USE TelerikAcademy
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN
------------------------------------------------------------------------------------------------------
--32.	Find how to use temporary tables in SQL Server.
--o	Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
USE TelerikAcademy
BEGIN TRAN
SELECT *  INTO  #TempEmployeesProjects
FROM EmployeesProjects
DROP TABLE EmployeesProjects
SELECT * INTO EmployeesPRojects
FROM #TempEmployeesProjects
ROLLBACK TRAN

