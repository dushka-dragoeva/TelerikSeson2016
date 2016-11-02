using Northwind.Tasks.ViewModels;
using System.Collections.Generic;

namespace Northwind.Tasks.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerView> GetAllCustomers();

        CustomerView GetCustomerViewById(string id);

        void InsirtCustomer(CustomerView newCustomer);

        void ModifyCustomer(CustomerView modifiedCustomer);

        void DeleteCustomer(string id);
    }
}
