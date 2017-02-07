using NewsSystem.Data;
using System.Data.Entity;
using NewsSystem.Data.Migrations;

namespace NewsSystem.Web.App_Start
{
    public class DbConfig
    {
        public static void Initilize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSystemDbContext, Configuration>());
            NewsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}