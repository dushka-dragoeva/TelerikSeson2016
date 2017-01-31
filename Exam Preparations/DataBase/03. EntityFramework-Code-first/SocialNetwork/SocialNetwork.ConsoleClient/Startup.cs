using System;
using System.Data.Entity;
using System.Linq;
using SocialNetwork.ConsoleClient.Searcher;
using SocialNetwork.Data;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Models;
using Ninject;
using System.Reflection;
using SocialNetwork.Data.Common;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
           // var sns = kernal.Get<SocialNetworkService>();
           // DataSearcher.Search(sns);

            var ds = kernal.Get<DataSearcher>();
            ds.Search();
            

            //var context = new SocialNetworkDbContext();
            //var users = new EFGenericRepozitory<User>(context);
            //var images = new EFGenericRepozitory<Image>(context);
            //var snService = new SocialNetworkService(users, images);


            //DataSearcher.Search(snService);

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());
            // Database.SetInitializer(new DropCreateDatabaseAlways<SocialNetworkDbContext>());
            //    var context = new SocialNetworkDbContext();

            // Importer.Create(Console.Out).Import();

            //  var queries = new SocialNetworkService();
            //  DataSearcher.Search(queries);
        }
    }
}
