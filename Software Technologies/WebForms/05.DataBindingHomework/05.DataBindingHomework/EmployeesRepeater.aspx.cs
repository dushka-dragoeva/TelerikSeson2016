using DataBindingHomework.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.DataBindingHomework
{
    public partial class EmployeesRepeater : System.Web.UI.Page
    {
        private readonly EmployeeRepository data = new EmployeeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EmpReapeter.DataSource = data.GetAllEmployees();
            this.EmpReapeter.DataBind();
        }
    }
}