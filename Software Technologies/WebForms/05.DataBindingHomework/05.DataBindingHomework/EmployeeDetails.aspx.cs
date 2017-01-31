using DataBindingHomework.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.DataBindingHomework
{
    public partial class EmployeeDetails : Page
    {
        private readonly EmployeeRepository data = new EmployeeRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Request.Params["id"];

            if (id != null)
            {
                int requestedId = int.Parse(id);
                this.DetailsTitle.Visible = true;
                var requestedEmployee= this.data.GetEmployeeById(requestedId);
                this.DetailsTitle.InnerText = requestedEmployee.First().Fullname+ this.DetailsTitle.InnerText;
                this.EmployeeDetils.DataSource = requestedEmployee;
                this.EmployeeDetils.DataBind();
            }
        }
    }
}