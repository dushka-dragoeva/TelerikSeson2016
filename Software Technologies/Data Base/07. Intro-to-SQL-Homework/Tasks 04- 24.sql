--04. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
USE TelerikAcademy
SELECT * FROM Departments;
-------------------------------------------------------------------------------------------------------
--05. Write a SQL query to find all department names.
USE TelerikAcademy
SELECT Name 
FROM Departments;	
-------------------------------------------------------------------------------------------------------
--06. Write a SQL query to find the salary of each employee.
USE TelerikAcademy
SELECT FirstName, LastName, Salary 
FROM Employees ;
------------------------------------------------------------------------------------------------------
--07. Write a SQL to find the full name of each employee.
USE TelerikAcademy
SELECT FirstName + ' ' + LastName as [Full Name]
FROM Employees ;
------------------------------------------------------------------------------------------------------
/*08. Write a SQL query to find the email addresses of each employee (by his first and last name). 
Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
The produced column should be named "Full Email Addresses".*/
USE TelerikAcademy
SELECT FirstName + '.' + LastName+'@telerik.com' as [Full Email Addresses]
FROM Employees ;
------------------------------------------------------------------------------------------------------
--09. Write a SQL query to find all different employee salaries.
USE TelerikAcademy
SELECT DISTINCT Salary
FROM Employees ;
------------------------------------------------------------------------------------------------------
--10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
USE TelerikAcademy
SELECT *
FROM Employees
WHERE JobTitle='Sales Representative';
------------------------------------------------------------------------------------------------------
--11. Write a SQL query to find the names of all employees whose first name starts with "SA".
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName Like 'Sa%'
------------------------------------------------------------------------------------------------------
--12. Write a SQL query to find the names of all employees whose last name contains "ei".
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LastName Like '%ei%'
------------------------------------------------------------------------------------------------------
--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000; 
------------------------------------------------------------------------------------------------------
--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary  IN (25000, 14000, 12500, 23600); 
------------------------------------------------------------------------------------------------------
--15. Write a SQL query to find all employees that do not have manager.
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name],ManagerID
FROM Employees
WHERE ManagerID IS NULL; 
------------------------------------------------------------------------------------------------------
/*16. Write a SQL query to find all employees that have salary more than 50000. 
Order them in decreasing order by salary.*/
USE TelerikAcademy
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary >5000
ORDER BY Salary;
------------------------------------------------------------------------------------------------------
--17. Write a SQL query to find the top 5 best paid employees.
USE TelerikAcademy
SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
ORDER BY Salary DESC;
------------------------------------------------------------------------------------------------------
--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Full Name], A.AddressText AS Address
FROM Employees E
INNER JOIN Addresses A
ON E.AddressID=A.AddressID;
------------------------------------------------------------------------------------------------------
--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Full Name], A.AddressText AS Address
FROM Employees E, Addresses A
WHERE E.AddressID=A.AddressID;
------------------------------------------------------------------------------------------------------
--20. Write a SQL query to find all employees along with their manager.
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Employee Name], M.FirstName + ' ' + M.LastName AS [Manager Name]
FROM Employees E, Employees M
WHERE E.ManagerID=M.EmployeeID;
------------------------------------------------------------------------------------------------------
/*21. Write a SQL query to find all employees, along with their manager and their address. 
Join the 3 tables: Employees e, Employees m and Addresses a.*/
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Employee Name], 
	   M.FirstName + ' ' + M.LastName AS [Manager Name],
	   A.AddressText AS Address
FROM Employees E
JOIN Employees M
ON  E.ManagerID=M.EmployeeID
JOIN Addresses A
ON E.AddressID=A.AddressID;
------------------------------------------------------------------------------------------------------
--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name AS [Deparments and Towns] 
FROM Departments D
UNION 
SELECT Name AS [Deparments and Towns] 
FROM  Towns;
------------------------------------------------------------------------------------------------------
/*23. Write a SQL query to find all the employees and the manager for each of them along with the employees 
that do not have manager. Use right outer join. Rewrite the query to use left outer join.*/
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Employee Name], 
	   M.FirstName + ' ' + M.LastName AS [Manager Name]
FROM Employees E
RIGHT OUTER JOIN Employees M
ON E.ManagerID=M.EmployeeID
--------------------------------------------------------------------------------
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Employee Name], 
	   M.FirstName + ' ' + M.LastName AS [Manager Name]
FROM Employees E
LEFT OUTER JOIN Employees M
ON E.ManagerID=M.EmployeeID
------------------------------------------------------------------------------------------------------
/*24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
whose hire year is between 1995 and 2005*/
USE TelerikAcademy
SELECT E.FirstName + ' ' + E.LastName AS [Employee Name], D.Name, YEAR(e.HireDate) AS [Hire Year]
FROM Employees E
JOIN Departments D
ON E.DepartmentID=D.DepartmentID
WHERE  D.Name IN ('Sales', 'Finance')
AND YEAR(E.HireDate) BETWEEN 1995 AND 2005
------------------------------------------------------------------------------------------------------
