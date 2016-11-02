<!-- section start -->

<!-- attr: {id: 'title', class: 'slide-title', hasScriptWrapper: true} -->

# Entity Framework Code First
<div class="signature">
    <p class="signature-course">Databases</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>

<!-- section start -->
<!-- attr: {id: 'table-of-contents'} -->
# Table of Contents
*   [Modeling Workflow](#modeling-workflow)
*   [Code First Main Parts](#domain-classes---models)
    *   [Domain Classes - Models](#domain-classes---models)
    *   [DbContext and DbSets](#dbcontext-class)
    *   [Database connection](#where-is-my-data)
*   [Using Code First Migrations](#code-first-migrations)
*   [Configure Mappings](#configure-mappings)
*   [LINQPad](#linqpad)

<!-- section start -->
<!-- attr: {id: 'modeling-workflow', class: 'slide-section', showInPresentation:true} -->
<!-- # Modeling Workflow -->

# Modeling Workflow
*   Entity Framework supports three types of modeling workflow:
    *   Database first
        *   Create models as database tables
        *   Use Management Studio or native SQL queries
    *   Model first
        *   Create models using visual EF designer in VS
    *   Code first
        *   Write models and combine them in DbContext

<!-- attr: { hasScriptWrapper:true } -->
# Database First Modeling Workflow
*   Create models as database tables and then generate code (models) from them
<img class="slide-image" src="imgs/db-first-workflow.png" style="height:55%; left:10%; top:40%" />

<!-- attr: { hasScriptWrapper:true } -->
# Model First Modeling Workflow
<img class="slide-image" src="imgs/model-first-workflow.png" style="height:75%; left:10%; top:15%" />

<!-- attr: { hasScriptWrapper:true } -->
# Code First Modeling Workflow
Domain classes
<img class="slide-image" src="imgs/code-first-workflow.png" style="height:75%; left:0%; top:15%" />

# Why Use Code First?
*   Write code without having to define mappings in XML or create database models
*   Define objects in POCO
    *   Reuse these models and their attributes
*   No base classes required
*   Enables database persistence with no configuration
    *   Can use automatic migrations
*   Can use Data Annotations (`Key`, `Required`, etc.)

<!-- section start -->
<!-- attr: {id: 'domain-classes---models', class: 'slide-section', showInPresentation:true} -->
<!-- # Code First Main Parts
## Domain classes, DbContext and DbSets -->

<!-- attr: { hasScriptWrapper:true } -->
# Domain Classes - Models
*   Bunch of normal C# classes (POCO)
    *   May contain navigation properties

```cs
public class PostAnswer
{
    public int PostAnswerId { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
}
```
<div class="fragment">
    <div class="balloon" style="left:25%; top:38%">Primary key</div>
    <div class="balloon" style="left:55%; top:50%">Foreign key</div>
    <div class="balloon" style="left:10%; top:60%">Virtual for lazy loading</div>
    <div class="balloon" style="left:45%; top:60%">Navigation property</div>
</div>

*   Recommended to be in a separate class library

<!-- attr: { hasScriptWrapper:true, showInPresentation:true } -->
<!-- # Domain Classes -->
*   Another example of domain class (model)

```cs
public class Post
{
    private ICollection<PostAnswer> answers;
    public Post()
    {
        this.answers = new HashSet<PostAnswer>();
    }
    // ...
    public virtual ICollection<PostAnswer> Answers
    {
        get { return this.answers; }
        set { this.answers = value; }
    }
    public PostType Type { get; set; }
}
```
<div class="fragment">
    <div class="balloon" style="left:60%; top:40%">Prevents null reference exception</div>
    <div class="balloon" style="left:70%; top:65%">Navigation property</div>
    <div class="balloon" style="left:25%; top:87%">Enumeration</div>
</div>

<!-- attr: { class:'slide-section', hasScriptWrapper:true, showInPresentation:true  } -->
<!-- # Creating domain classes (models)
<img class="slide-image" src="imgs/demo-models.png" style="left:-20%; top:45%" title="POCO Objects: Plain and simple objects with less stuff on them as possible" /> -->
## [Demo](https://github.com/TelerikAcademy/Databases/tree/master/09.%20Entity%20Framework%20Code%20First/Demo/CodeFirst.Models)
*   hover me <!-- .element; class="balloon" style="left:25%; top:80%" /> -->

<!-- attr: { id:'dbcontext-class' } -->
# DbContext Class
*   A class that inherits from `DbContext`
    *   Manages model classes using `DbSet` type
    *   Implements identity tracking, change tracking, and API for CRUD operations
    *   Provides `LINQ-based` data access
*   Recommended to be in a separate class library
    *   Don't forget to reference the Entity Framework library (using NuGet package manager)
*   If you have a lot of models it is recommended to use more than one `DbContext`

<!-- attr: { hasScriptWrapper:true } -->
# DbSet Type
*   Collection of single entity type
*   Set operations: `Add`, `Attach`, `Remove`, `Find`
*   Use with `DbContext` to query database
<img class="slide-image" src="imgs/dbset.png" style="position:initial" />

```cs
public DbSet<Post> Posts { get; set; }
```

# DbContext Example

```cs
using System.Data.Entity;

using CodeFirst.Models;

public class ForumContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<PostAnswer> PostAnswers { get; set; }

    public DbSet<Tag> Tags { get; set; }
}
```

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Creating DbContext -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/09.%20Entity%20Framework%20Code%20First/Demo/CodeFirst.Data/ForumContext.cs)

# How to Interact With the Data?
*   In the same way as when we use database first or model first approach

```cs
var db = new ForumContext();
var category = new Category {
    Parent = null, Name = "Database course" };
db.Categories.Add(category);

var post = new Post();
post.Title = "Срока на домашните";
post.Content = "Моля удължете срока на домашните";
post.Type = PostType.Normal;
post.Category = category;
post.Tags.Add(new Tag { Text = "домашни" });
post.Tags.Add(new Tag { Text = "срок" });
db.Posts.Add(post);
db.SaveChanges();
```

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Using The Data -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/09.%20Entity%20Framework%20Code%20First/Demo/CodeFirst.Client/Program.cs)

<!-- attr: { id:'where-is-my-data', style:'font-size:0.9em' } -->
# Where is My Data
* By default `app.config` file contains link to default connection factory that creates local db

```xml
&lt;entityFramework>
  &lt;defaultConnectionFactory 
type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory,
EntityFramework">
    &lt;parameters>
      &lt;parameter value="v11.0" />
    &lt;/parameters>
  &lt;/defaultConnectionFactory>
&lt;/entityFramework>
```
* Server name by default: `(localdb)\v11.0` or `.\SQLEXPRESS.[full-class-name]`
  * We can use VS server explorer to view database

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.85em' } -->
# How to Connect to SQL Server?
* First, create context constructor that calls base constructor with appropriate connection name

```cs
public class ForumContext : DbContext
{
    public ForumContext()
        : base("ForumDb")
    { }
    // ...
}
```
* Then add the connection string in app.config 

```xml
<connectionStrings>
  <add name="ForumDb" connectionString="Data Source=.;Initial 
    Catalog=ForumDb;Integrated Security=True"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```
* Server address might be .\SQLEXPRESS <!-- .element; class="fragment balloon" style="left:48%; top:68%" -->

<!-- attr: { hasScriptWrapper:true } -->
# Database Connection Workflow
<img class="slide-image" src="imgs/db-connection-workflow.png" style="position:initial" />

<!-- attr: { class:"slide-section", showInPresentation:true } -->
<!-- # Change Database Connection -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/09.%20Entity%20Framework%20Code%20First/Demo/CodeFirst.Client/App.config)

<!-- section start -->
<!-- attr: {id: 'code-first-migrations', class: 'slide-section', showInPresentation:true} -->
<!-- # Using Code First Migrations -->

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.85em' } -->
# Changes in Domain Classes
* What happens when we change our models?
  * Entity Framework compares our model with the model in `__MigrationHistory` table
<img class="slide-image" src="imgs/exception.png" style="position:initial; margin-bottom:0" />

* By default Entity Framework only creates the database and don't do any changes after that
* Using Code First Migrations we can manage differences between models and database

# Code First Migrations
* Enable Code First Migrations
  * Open Package Manager Console
  * Run `Enable-Migrations` command
    * This will create some initial jumpstart code
    * `-EnableAutomaticMigrations` for auto migrations
* Two types of migrations
  * Automatic migrations
    * Set `AutomaticMigrationsEnabled = true`;
  * Code-based (providing full control)
    * Separate C# code file for every migration

# Database Migration Strategies
* `CreateDatabaseIfNotExists` (default)
* `DropCreateDatabaseIfModelChanges`
  * We loose all the data when change the model
* `DropCreateDatabaseAlways`
  * Great for automated integration testing
* `MigrateDatabaseToLatestVersion`
  * This option uses our migrations
* We can implement `IDatabaseInitializer` if we want custom migration strategy

<!-- attr: { hasScriptWrapper:true } -->
# Use Code First Migrations
* First, enable code first migrations
* Second, we need to tell to Entity Framework to use our migrations with code (or app.config)

```cs
Database.SetInitializer(
  new MigrateDatabaseToLatestVersion
    <ForumContext, Configuration>());
```
* We can configure automatic migration

```cs
public Configuration()
{
    this.AutomaticMigrationsEnabled = true;
    this.AutomaticMigrationDataLossAllowed = true;
}
```
* This will allow us to delete or change properties <!-- .element; class="balloon" style="width:300px; left:50%; top:70%" -->

# Seeding the Database
* During a migration we can seed the database with some data using the `Seed` method

```cs
protected override void Seed(ForumContext context)
{
    /* This method will be called after migrating to
       the latest version. You can use the
       DbSet<T>.AddOrUpdate() helper extension method 
       to avoid creating duplicate seed data. E.g. */

    context.Tags.AddOrUpdate(new Tag { Text = "срок" });
    context.Tags.AddOrUpdate(new Tag { Text = "форум" });
}
```
* This method will be run every time (since EF 5)

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Code First Migrations -->
## [Demo](https://github.com/TelerikAcademy/Databases/blob/master/09.%20Entity%20Framework%20Code%20First/Demo/CodeFirst.Data/Migrations/Configuration.cs)

<!-- section start -->
<!-- attr: {id: 'configure-mappings', class: 'slide-section', showInPresentation:true} -->
<!-- # Configure Mappings
## Using Data Annotations and Fluent API -->

# Configure Mappings
* Entity Framework respects mapping details from two sources
  * Data annotation attributes in the models
    * Can be reused for validation purposes
  * Fluent API code mapping configuration
    * By overriding `OnModelCreating` method
    * By using custom configuration classes
* Use one approach or the other

<!-- attr: { showInPresentation:true } -->
<!-- # Configure Mappings -->
* There is a bunch of data annotation attributes in `System.ComponentModel.DataAnnotations`
  * `[Key]` – specifies the primary key of the table
  * For validation: [StringLength], [MaxLength], [MinLength], [Required]
  * Schema: `[Column]`, `[Table]`, `[ComplexType]`, `[ConcurrencyCheck]`, `[Timestamp]`, `[ComplexType]`, `[InverseProperty]`, `[ForeignKey]`, `[DatabaseGenerated]`, `[NotMapped]`, `[Index]`
* In EF 6 we will be able to add custom attributes by using custom conventions


# Fluent API for Mappings
* By overriding `OnModelCreating` method in `DbContext` class we can specify mapping configurations

```cs
protected override void OnModelCreating(
  DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
    modelBuilder.Entity<Tag>().Property(x => x.Text)
      .IsUnicode(true);
    modelBuilder.Entity<Tag>().Property(x => x.Text)
      .HasMaxLength(255);
    // modelBuilder.Entity<Tag>().Property(x => x.Text)
    //  .IsFixedLength();
    base.OnModelCreating(modelBuilder);
}
```

<!-- attr: { showInPresentation:true } -->
<!-- # Fluent API Configurations -->
* `.Entity()`
  * Map: Table Name, Schema
  * Inheritance Hierarchies, Complex Types
  * Entity -> Multiple Tables
  * Table -> Multiple Entities
  * Specify Key (including Composite Keys)
* `.Property()`
  * Attributes (and Validation)
  * Map: Column Name, Type, Order
  * Relationships
  * Concurrency

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Configure Mappings -->
## [Demo]()

<!-- section start -->
<!-- attr: {id: 'linqpad', class: 'slide-section', showInPresentation:true} -->
<!-- # LINQpad -->

# LINQpad
* Download from: http://www.linqpad.net/ 
* Supports native C# 5.0
* Translates it to SQL, XML, Objects
* Understands LINQ
* Free and paid version

<!-- attr: { class:'slide-section table-of-contents',showInPresentation:true } -->
<!-- # LINQpad -->
## [Demo]()

<!-- section start -->
<!-- attr: {id: 'questions', class: 'slide-section'} -->
# Questions
## Databases
