# EntityFramework Database-first Workshop
_Exam from September 2014_

##  Task 1: Design the database

Implement a database layer, storing information about employees:

- Each **employee** has first and last name (both between 5 and 20 letters, inclusive), year salary, manager and department.
- Each **department** has unique name between 10 and 50 letters, inclusive.
- Each **employee** works on many projects.
- Each **project** has name between 5 and 50 letters, inclusive, and employees working on it.
- Each **employee** also has starting and ending date for each of his/her projects.
- Every single piece of information is mandatory, except manager – some employees do not have one.
- Additionally, every employee has to report every day when he/she got to work.
- Each report has time of reporting.

Design a database schema "Company" in SQL Server to keep the information about employees, departments, projects and reports. Ensure data integrity is fulfilled.

##  Task 2: Fill the Database with simple data

- Use C# to implement an application for generating random sample data in the Company database.

- Create at least:
    - `100` departments
    - `5 000` employees – each employee has department, `~95%` of them have managers and their salary is between `$50 000` and `$200 000`, inclusive.
      - There must be no cycles in the management tree
        - _Example_ for a cycle is Pesho’s manager is Gosho, Gosho’s manager is Ivan and Ivan’s manager is Pesho.
    - `1 000` projects – on each project there are working between `2` and `20` employees, inclusive – average of `5`. Ending date is always after starting date and ending date may be in the future.
    - `250 000` reports – add average of `50` reports per employee.
    - All text can be random string with valid length depending on the field.

**Use EntityFramework Database-first approach**

Adding a lot of data may be slow, depending on your implementation, so be patient. Consider turning off the automatic change tracking in Entity Framework.

##  Task 3: Export XML queries

- Use C# to implement an application for exporting information about the Company database.

- Implement the following interface and think of how to represent the data (employees and departments) in XML.

```cs
public interface ICompanyQueries {
  //  Get the full name (first name + " " + last name) of every employee and its salary,
  //  for each employee with salary between $100 000 and $150 000, inclusive
  //  Implement paging, i.e. return only a part of all employees, based on the given page
  XElement GetEmployeesWithSalaryBetween(decimal from, decimal to);
  XElement GetEmployeesWithSalaryBetween(decimal from, decimal to, int page);

  //  Get all departments and how many employees there are in each one.
  //  Sort the result by the number of employees in descending order.
  //  Implement paging, i.e. return only a part of all employees, based on the given page
  XElement GetDepartments();
  XElement GetDepartments(int page);

  //  Get each employee’s full name (first name + " " + last name), project’s name, department’s name,
  //  starting and ending date for each employee in project.
  //  Additionally get the number of all reports, which time of reporting is between the start and end date.
  //  Sort the results first by the employee id, then by the project id.
  //  Implement paging, i.e. return only a part of all employees, based on the given page
  XElement GetEmployeesFullInfo();
  XElement GetEmployeesFullInfo(int page);
}
```
- Handle all possible errors and act appropriately
  - i.e. the provided page is bigger than the last possible, or is negative
