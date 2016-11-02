using Ninject.Modules;

using Northwind.Data;
using Northwind.Tasks.Daos;
using Northwind.Tasks.Repositories;

namespace Northwind.ConsoleApp
{
    public class NinjectConfiguration : NinjectModule
    {

        public override void Load()
        {
            this.Bind<ICustomerRepository>().To<SqlCustomersRepository>();
            this.Bind<CustomersDao>().To<CustomersDao>();
        }
    }
}
