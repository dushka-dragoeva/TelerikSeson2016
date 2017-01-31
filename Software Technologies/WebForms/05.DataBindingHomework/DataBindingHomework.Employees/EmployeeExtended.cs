using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingHomework.Employees
{
    public partial class Employee
    {
        public string Fullname
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}
