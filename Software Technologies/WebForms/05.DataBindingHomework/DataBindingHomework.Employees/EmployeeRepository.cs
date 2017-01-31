using System.Collections.Generic;
using System.Linq;

namespace DataBindingHomework.Employees
{
    public class EmployeeRepository
    {
        private readonly NorthwindEntities dbContext;

        public EmployeeRepository()
        {
            this.dbContext = new NorthwindEntities();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.dbContext.Employees.ToList();
        }

        public IEnumerable<Employee> GetEmployeeById(int Id)
        {
            return this.dbContext.Employees.Where(e => e.EmployeeID == Id).ToList();
        }
    }
}
