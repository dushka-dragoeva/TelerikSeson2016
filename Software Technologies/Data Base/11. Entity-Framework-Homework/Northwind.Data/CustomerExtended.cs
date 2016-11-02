using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.Tasks.ViewModels;

namespace Northwind.Data
{
    public partial class Customer
    {
        public CustomerView ToViewCustomer()
        {
            var customer = new CustomerView();

            customer.CustomerID = this.CustomerID;
            customer.CompanyName = this.CompanyName;
            customer.ContactName = this.ContactName;
            customer.ContactTitle = this.ContactTitle;
            customer.Address = this.Address;
            customer.City = this.City;
            customer.Region = this.Region;
            customer.PostalCode = this.PostalCode;
            customer.Country = this.Country;
            customer.Phone = this.Phone;
            customer.Fax = this.Fax;

            return customer;
        }
    }
}
