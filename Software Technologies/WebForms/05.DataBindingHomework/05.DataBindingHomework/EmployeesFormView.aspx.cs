using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

using DataBindingHomework.Employees;
using System.Data.Common;
using System;

namespace _05.DataBindingHomework
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        private readonly EmployeeRepository data = new EmployeeRepository();
        
        
        protected void Page_Load(object sender, EventArgs e)

        {
            this.EmployeeForm.DataSource = data.GetAllEmployees();
            this.EmployeeForm.DataBind();
        }


        private void Page_PreRender(object sender, EventArgs e)
        {
          
        }

        protected void EmployeeForm_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
    }
}