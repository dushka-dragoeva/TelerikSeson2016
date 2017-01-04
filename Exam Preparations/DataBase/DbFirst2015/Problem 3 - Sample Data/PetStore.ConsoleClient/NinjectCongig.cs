using Ninject;
using Ninject.Modules;
using PetStore.Data;
using PetStore.Data.Common;
using PetStore.Importer;
using PetStore.Importer.Importers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.ConsoleClient
{
    public class NinjectCongig : NinjectModule
    {
        private const string CountryImporterName = "CountryImporter";
        private const string SpiceImporterName = "SpiceImporter";
        private const string PetImporterName = " PetImporter";
        private const string CategoryImporterName = "CategoryImporter";
        private const string ProductImporterName = " ProductImporter";



        public override void Load()
        {
            this.Bind<DbContext>().To<PetStoreEntities2>().InSingletonScope();
            this.Bind<TextWriter>().ToConstant(Console.Out);
            this.Bind(typeof(IRepository<>)).To(typeof(EFGenericRepozitory<>));
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
           // this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<DataImporter>().To<DataImporter>();

            Bind<IImporter>().To<CountryImporter>().Named(CountryImporterName);
            Bind<IImporter>().To<SpiceImporter>().Named(SpiceImporterName);
            Bind<IImporter>().To<PetImporter>().Named(PetImporterName);
            Bind<IImporter>().To<CategoryImporter>().Named(CategoryImporterName);
            Bind<IImporter>().To<ProductImporter>().Named(ProductImporterName);

            Bind<IImporter>().ToMethod(context =>
            {
                IImporter countryImporter = context.Kernel.Get<IImporter>(CountryImporterName);
                IImporter spiceImporter = context.Kernel.Get<IImporter>(SpiceImporterName);
                IImporter petImporter = context.Kernel.Get<IImporter>(PetImporterName);
                IImporter categoryImporter = context.Kernel.Get<IImporter>(CategoryImporterName);
                IImporter productImporter = context.Kernel.Get<IImporter>(ProductImporterName);

                countryImporter.Import();
                spiceImporter.Import();
                petImporter.Import();
                categoryImporter.Import();
                productImporter.Import();

                //headHandler.SetSuccessor(optionsHandler);
                //optionsHandler.SetSuccessor(fileHandler);
                //fileHandler.SetSuccessor(controllerHandler);

                return countryImporter;
            }).WhenInjectedInto<DataImporter>();

        }
    }
}
