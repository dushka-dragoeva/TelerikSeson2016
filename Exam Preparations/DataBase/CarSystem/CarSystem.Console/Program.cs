using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarSystem.Models;
using CarSystem.Data;
using CarSystem.Data.Migrations;

namespace CarSystem.Console
{
    public class Program
    {
        static void Main()
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarSystemDbContext, Configuration>());
          //  Database.SetInitializer( new DropCreateDatabaseAlways<CarSystemDbContext>());
             var db = new CarSystemDbContext();
          //  System.Console.WriteLine(db.Dealers);
           JsonImporter.Import (db);
          //  Searcher.Search(db);

        }
    }
}
