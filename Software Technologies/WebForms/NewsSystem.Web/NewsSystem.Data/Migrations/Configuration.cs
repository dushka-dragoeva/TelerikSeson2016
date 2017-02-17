using NewsSystem.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NewsSystem.Data.Migrations
{
   

    public sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Data.NewsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystem.Data.NewsSystemDbContext context)
        {
            if (context.Articles.Any())
            {
                return;
            }

            var user = new User()
            {
                UserName = "Kolkoto"
            };

            var seed = new SeedData(user);
            context.Users.Add(user);
            context.SaveChanges();
            seed.Categories.ForEach(x => context.Categories.Add(x));
            seed.Articles.ForEach(x => context.Articles.Add(x));
            context.SaveChanges();

        }
    }
}
