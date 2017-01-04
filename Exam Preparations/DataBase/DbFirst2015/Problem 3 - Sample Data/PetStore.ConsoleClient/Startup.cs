namespace PetStore.ConsoleClient
{
    using Ninject;
    using Ninject.Modules;
    using System;
    using System.Reflection;

    using PetStore.Importer;
    using PetStore.Importer.Importers;

    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjectCongig());
         //   kernel.Load(Assembly.GetExecutingAssembly());
            var importer = kernel.Get<DataImporter>();

            importer.ImportData();


            //  IWebServerConsole webServer = kernel.Get<IWebServerConsole>();
            //  webServer.Start();
        }
    }
}
