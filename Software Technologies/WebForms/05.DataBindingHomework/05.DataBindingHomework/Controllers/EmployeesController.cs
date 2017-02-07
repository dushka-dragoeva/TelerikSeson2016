using DataBindingHomework.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _05.DataBindingHomework.Controllers
{
    public class EmployeesController :ApiController
    {
        private  EmployeeRepository data = new EmployeeRepository();

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = data.GetEmployeeById(id).FirstOrDefault();

            if (employee != null)
            {
                var response = new
                {
                    Photo = employee.Photo,
                    Phone = employee.HomePhone,
                    Email = employee.Fullname.ToLower()+"@nortwind.com",
                    Address=employee.Address,
                    Notes=employee.Notes
                  
                };

                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}