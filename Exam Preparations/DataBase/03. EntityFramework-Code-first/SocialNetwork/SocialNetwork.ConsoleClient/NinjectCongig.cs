using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;
using SocialNetwork.ConsoleClient.Searcher;
using System.Data.Entity;
using SocialNetwork.Data;
using SocialNetwork.Data.Common;

namespace SocialNetwork.ConsoleClient
{
    public class NinjectCongig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<SocialNetworkDbContext>().InSingletonScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EFGenericRepozitory<>));
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
            this.Bind<ISocialNetworkService>().To<SocialNetworkService>();
            this.Bind<DataSearcher>().To<DataSearcher>();
            //  this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
        }
    }
}
