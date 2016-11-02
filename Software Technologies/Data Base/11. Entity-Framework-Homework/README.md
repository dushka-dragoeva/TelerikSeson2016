<!-- section start -->

<!-- attr: {id: 'title', class: 'slide-title', hasScriptWrapper: true} -->

# Entity Framework
##  ORM Concepts, Entity Framework (EF), DbContext
<div class="signature">
    <p class="signature-course">Databases</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>

<!-- section start -->
<!-- attr: {id: 'table-of-contents' } -->
# Table of Contents
*   [ORM Technologies – Basic Concepts](#orm-technologies)
*   [Entity Framework – Overview](#overview-of-ef)
*   [Reading Data with EF](#the-dbcontext-class)
*   [Create, Update, Delete using Entity Framework](#creating-new-data)
*   [Extending Entity Classes](#extending-entity-classes)
*   [Executing Native SQL Queries](#executing-native-sql-queries)
*   [Joining and Grouping Tables](#joining-tables-in-ef)
*   [Attaching and Detaching Objects](#attaching-and-detaching-objects)

<!-- section start -->
<!-- attr: {id: 'orm-technologies', class: 'slide-section', showInPresentation:true} -->
<!-- # Introduction to ORM
## Object-Relational Mapping (ORM) Technologies -->

<!-- attr: { style:'font-size:0.95em' } -->
# ORM Technologies
*   `Object-Relational Mapping` (`ORM`) is a programming technique for automatic mapping and converting data
    *   Between relational database tables and object-oriented classes and objects
*   `ORM` creates a "`virtual object database`" 
    *   Which can be used from within the programming language, e.g. C# or Java
*   `ORM frameworks` automate the ORM process
    *   A.k.a. `object-relational persistence frameworks`

# ORM Frameworks
*   `ORM frameworks` typically provide the following functionality:
    *   Creating object model by database schema
    *   Creating database schema by object model
    *   Querying data by object-oriented API
    *   Data manipulation operations
        *   `CRUD` – create, retrieve, update, delete
*   `ORM frameworks` automatically generate SQL to perform the requested data operations

<!-- attr: { hasScriptWrapper:true } -->
# ORM Mapping Example
*   Database and Entities mapping diagrams for a subset of the `Northwind` database
<img class="slide-image" src="imgs/orm-mapping.png" style="height:60%; left:5%; top:30%;" />

# ORM Advantages
*   Object-relational mapping advantages
    *   Developer productivity
        *   Writing less code
    *   Abstract from differences between object and relational world
        *   Complexity hidden within ORM
    *   Manageability of the CRUD operations for complex relationships
    *   Easier maintainability

# ORM Frameworks in .NET
*   Built-in ORM tools in .NET Framework and VS
    *   Entity Framework (`LINQ-to-Entities`)
    *   `LINQ-to-SQL`
    *   Both combine entity class mappings and code generation, SQL is generated at runtime
*   Third party ORM tools
    *   NHibernate – the old daddy of ORM
    *   Telerik OpenAccess ORM

<!-- section start -->
<!-- attr: {id: 'overview-of-ef', class: 'slide-section', showInPresentation:true} -->
<!-- # Entity Framework Overview
## Object Relation Persistence Framework -->

# Overview of EF
*   `Entity Framework` (`EF`) is a standard ORM framework, part of .NET
    *   Provides a run-time infrastructure for managing SQL-based database data as .NET objects
*   The relational database schema is mapped to an object model (classes and associations)
    *   Visual Studio has built-in tools for generating `Entity Framework` SQL data mappings
        *   Data mappings consist of C# classes and XML
    *   A standard data manipulation API is provided

# Entity Framework Features
*   Maps tables, views, stored procedures and functions as .NET objects
*   Provides LINQ-based data queries
    *   Executed as `SQL SELECT` on the database server (parameterized queries)
*   Built-in CRUD operations
    *   `Create` / `Read` / `Update` / `Delete`
*   Creating or deleting the database schema
*   Tracks changes to in-memory objects

# Entity Framework Features
*   Works with any relational database with valid Entity Framework provider
*   Work with a visual model, database or with your own classes
*   Has very good default behaviour
    *   Very flexible for more granular control
*   Open source – independent release cycle
    *   [entityframework.codeplex.com](http://entityframework.codeplex.com)
    *   [github.com/aspnet/EntityFramework](http://github.com/aspnet/EntityFramework)

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.8em' } -->
# Basic Workflow

<ol>
    <li style="width:30%; position:absolute; left:2%">Define model
        <ul>
            <li>Database</li>
            <li>Visual designer</li>
            <li>Code</li>
        </ul>
    </li>
    <li style="width:28%; position:absolute; left:35%">Express & execute query over `IQueryable`</li>
    <li style="width:30%; position:absolute; left: 70%">EF determines & executes SQL query</li>
</ol>
<img class="slide-image" src="imgs/basic-workflow.png" style="left:0%; top:40%" />

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.8em', showInPresentation:true } -->
<!-- # Basic Workflow -->

<ol start="4">
    <li style="width:30%; position:absolute; left:2%">EF transforms selected results into .NET objects</li>
    <li style="width:28%; position:absolute; left:35%">Modify data and call “save changes”</li>
    <li style="width:30%; position:absolute; left: 70%">EF determines & executes SQL query</li>
</ol>
<img class="slide-image" src="imgs/basic-workflow2.png" style="left:0%; top:40%" />

# EF Components
*   The `DbContext` class
    *   `DbContext` holds the database connection and the entity classes
    *   Provides LINQ-based data access
    *   Implements identity tracking, change tracking, and API for CRUD operations
*   `Entity classes`
    *   Each database table is typically mapped to a single entity class (C# class)

# EF Components
*   `Associations` (`Relationship Management`)
    *   An association is a primary key / foreign key based relationship between two entity classes
    *   Allows navigation from one entity to another, e.g. Student.Courses
*   `Concurrency control`
    *   `Entity Framework` uses optimistic concurrency control (no locking by default)
    *   Provides automatic concurrency conflict detection and means for conflicts resolution

<!-- attr: { hasScriptWrapper:true } -->
# EF Runtime Metadata
<img class="slide-image" src="imgs/ef-metadata.png" style="height:75%; left:10%" />

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # The Entity Framework Designer in Visual Studio -->
## [Demo]()

<!-- section start -->
<!-- attr: {id: 'the-dbcontext-class', class: 'slide-section'} -->
# Reading Data with Entity Framework

# The DbContext Class
*   The `DbContext` class is generated by the Visual Studio designer
*   `DbContext` provides:
    *   Methods for accessing entities (object sets) and creating new entities (`Add()` methods)
    *   Ability to manipulate database data though entity classes (read, modify, delete, insert)
    *   Easily navigate through the table relationships
    *   Executing LINQ queries as native SQL queries
    *   Create the DB schema in the database server

# Using DbContext Class
*   First create instance of the DbContext:

```cs
NorthwindEntities northwind = new NorthwindEntities();
```
*   In the constructor you can pass a database connection string and mapping source
*   `DbContext` properties
    *   `Connection` – the `SqlConnection` to be used
    *   `CommandTimeout` – timeout for database SQL commands execution
    *   All entity classes (tables) are listed as properties
        *   e.g. `IDbSet&lt;Order> Orders { get; }`

<!-- attr: { hasScriptWrapper:true } -->
# Reading Data with LINQ Query
*   Executing LINQ-to-Entities query over `EF` entity:

```cs
using (var context = new NorthwindEntities())
{
  var customers = 
    from c in context.Customers
    where c.City == "London"
    select c;
}
```
The query will be executes as SQL command in the database <!-- .element; class="fragment balloon" style="left:60%; top:30%" -->

*   `Customers` property in the `DbContext`:

```cs
public partial class NorthwindEntities : DbContext
{
  public ObjectSet<Customer> Customers { get { … } }
}
```

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.9em' } -->
# Reading Data with LINQ Query
*   We can also use extension methods (fluent API) for constructing the query

```cs
using (var context = new NorthwindEntities())
{
  var customerPhoness = context.Customers
                          .Select(c => c.Phone)
                          .Where(c => c.City == "London")
                          .ToList();
}
```
<div class="fragment">
    <div class="balloon" style="left:70%; top:35%">This is called projection</div>
    <div class="balloon" style="width:200px; left:15%; top:45%">ToList() method executes the query</div>
</div>

*   Find element by id

```cs
using (var context = new NorthwindEntities())
{
  var customer = context.Customers.Find(2);
  Console.WriteLine(customer.ContactTitle);
}
```

# Logging the Native SQL Queries
*   To print the native database SQL commands executed on the server use the following:

```cs
var query = context.Countries;
Console.WriteLine(query.ToString());
```
*   This will print the SQL native query executed at the database server to select the `Countries`
    *   Can be printed to file using `StreamWriter` class instead of `Console` class

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Retrieving Data with LINQ to Entities -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/08.%20Entity%20Framework/Demo/ReadingWithLINQToEntities/ReadingWithLINQToEntities.cs)

<!-- section start -->
<!-- attr: {id: 'creating-new-data', class: 'slide-section', showInPresentation:true} -->
<!-- # Create, Update, Delete using Entity Framework -->

<!-- attr: { style:'font-size:0.95em' } -->
# Creating New Data
*   To create a new database row use the method `Add(…)` of the corresponding collection:

```cs
// Create new order object
Order order = new Order()
{
  OrderDate = DateTime.Now, ShipName = "Titanic",
  ShippedDate = new DateTime(1912, 4, 15),
  ShipCity = "Bottom Of The Ocean"
};
// Mark the object for inserting
context.Orders.Add(order);
context.SaveChanges();
```
*   `SaveChanges()` method call is required to post the SQL commands to the database

<!-- attr: { style:'font-size:0.95em' } -->
# Cascading Inserts
*   We can also add cascading entities to the database:

```cs
Country spain = new Country();
spain.Name = "Spain";
spain.Population = "47 770 100";
spain.Cities.Add( new City { Name = "Barcelona" } );
spain.Cities.Add( new City { Name = "Madrid" } );
countryEntities.Countries.Add(spain);
countryEntities.SaveChanges();
```
*   This way we don't have to add each `City` individually
    *   They will be added when the `Country` entity (`Spain`) is inserted to the database

<!-- attr: { hasScriptWrapper:true } -->
# Deleting Existing Data
*   Delete is done by `Remove()` on the specified entity collection
*   `SaveChanges()` method performs the delete action in the database

```cs
Order order = northwindEntities.Orders.First();
// Mark the entity for deleting on the next save
northwindEntities.Orders.Remove(order);
northwindEntities.SaveChanges();
```
*   This will execute an SQL DELETE command <!-- .element; class="fragment balloon" style="width:20% ;left:70%; top:65%" -->

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # CRUD Operations with Entity Framework -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/08.%20Entity%20Framework/Demo/UpdatingDeletingInsertingData/UpdatingDeletingInsertingData.cs)

<!-- section start -->
<!-- attr: {id: 'extending-entity-classes', class: 'slide-section', showInPresentation:true} -->
<!-- # Extending Entity Classes
## Add methods like ToString(), Equals(), etc… -->

<!-- attr: { style:'font-size:0.95em' } -->
# Extending Entity Classes
*   When using “database first” or “model first” entity classes are separate `.cs` files that are generated by T4 tempalte `XXXModel.tt`
    *   And each time we update the `EntitiesModel` from the `database` all files are generated anew
    *   If we add methods like `ToString()`, they will be overridden and lost
    *   That is why all the entity classes are "`partial`"
        *   We can extend them in another file with the `same partial class`
*   When using “code first” this is not a problem

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Extending Entity Classes -->
## [Demo]()

<!-- section start -->
<!-- attr: {id: 'executing-native-sql-queries', class: 'slide-section', showInPresentation:true} -->
<!-- # Executing Native SQL Queries -->

# Executing Native SQL Queries
*   Executing a native SQL query in Entity Framework directly in its database store:

```cs
ctx.Database.SqlQuery<return-type>(native-SQL-query);
```
*   Example:

```cs
string query = "SELECT count(*) FROM dbo.Customers";
var queryResult = ctx.Database.SqlQuery<int>(query);
int customersCount = queryResult.FirstOrDefault();
```
*   Examples are shown in SQL Server but the same can be done for any other database


<!-- attr: { showInPresentation:true } -->
<!-- # Executing Native SQL Queries -->
*   Native SQL queries can also be parameterized:

```cs
NorthwindEntities context = new NorthwindEntities();
string nativeSQLQuery =
  "SELECT FirstName + ' ' + LastName " +
  "FROM dbo.Employees " +
  "WHERE Country = {0} AND City = {1}";
object[] parameters = { country, city };
var employees = context.Database.SqlQuery<string>(
  string.Format(nativeSQLQuery, parameters));
foreach (var emp in employees)
{
  Console.WriteLine(emp);
}
```

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Executing Native SQL Queries -->
## [Demo]()

<!-- section start -->
<!-- attr: {id: 'joining-tables-in-ef', class: 'slide-section', showInPresentation:true} -->
<!-- # Joining and Grouping Tables
## Join and Group Using LINQ -->

<!-- attr: { style:'font-size:0.9em' } -->
# Joining Tables in EF
*   In `EF` we can join tables in `LINQ` or by using extension methods on `IEnumerable&lt;T>`
    *   The same way like when joining collections
    
```cs
var custSuppl = 
 from customer in northwindEntities.Customers
 join supplier in northwindEntities.Suppliers
 on customer.Country equals supplier.Country
 select new {  CustomerName = customer.CompanyName, 
               Supplier = supplier.CompanyName, 
               Country = customer.Country };
```
```cs
northwindEntities.Customers.Join(northwindEntities.Suppliers,
  (c=>c.Country), (s=>s.Country), (c,s) => new {
    Customer = c.CompanyName,
    Supplier = s.CompanyName,
    Country = c.Country });
```

# Grouping Tables in EF
*   Grouping also can be done by `LINQ`
    *   The same ways as with collections in `LINQ`
*   Grouping with `LINQ`:

```cs
var groupedCustomers = 
  from customer in northwindEntities.Customers
  group customer by Customer.Country;
```
*   Grouping with extension methods:

```cs
var groupedCustomers = 
  northwindEntities.Customers.GroupBy(
    customer => customer.Country);
```

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Joining and Grouping Tables -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/08.%20Entity%20Framework/Demo/JoinAndGroupDemo/JoinAndGroupExample.cs)

<!-- section start -->
<!-- attr: {id: 'attaching-and-detaching-objects', class: 'slide-section', showInPresentation:true} -->
<!-- # Attaching and Detaching Objects -->

# Attaching and Detaching Objects
*   In Entity Framework, objects can be attached to or detached from an object context
*   `Attached` objects are tracked and managed by the DbContext
    *   `SaveChanges()` persists all changes in DB
*   `Detached` objects are not referenced by the `DbContext`
    *   Behave like a normal objects, like all others, which are not related to EF

# Attaching Detached Objects
*   When a query is executed inside an `DbContext`, the returned objects are automatically attached to it
*   When a context is destroyed, all objects in it are automatically detached
    *   E.g. in Web applications between the requests
*   You might later on attach to a new context objects that have been previously detached

<!-- attr: { hasScriptWrapper:true } -->
# Detaching Objects
*   When an object is detached?
    *   When we obtain the object from an DbContext and then Dispose it
    *   Manually: by set the entry state to Detached

```cs
Product GetProduct(int id)
{
   using (NorthwindEntities northwindEntities = 
      new NorthwindEntities())
   {
      return northwindEntities.Products.First(
         p => p.ProductID == id);
   }
}
```
*   Now the returned product is detached <!-- .element; class="fragment balloon" style="left:10%; top:85%" -->

# Attaching Objects
*   When we want to update a detached object we need to reattach it and then update it
    *   Done by the `Attached` state of the entry

```cs
void UpdatePrice(Product product, decimal newPrice)
{
   using (NorthwindEntities northwindEntities = 
      new NorthwindEntities())
   {
      var entry = northwindEntities.Entry(product);
      entry.State = EntityState.Attached;   
      product.UnitPrice = newPrice;
      northwindEntities.SaveChanges();
   }
}
```

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Attaching and Detaching Objects -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/08.%20Entity%20Framework/Demo/AttachDetachEntities/AttachDetachEntities.cs)

<!-- section start -->
<!-- attr: {id: 'questions', class: 'slide-section'} -->
# Questions
## Databases
[go to Telerik Academy forum](http://telerikacademy.com/Forum/Tag/entity-framework)
