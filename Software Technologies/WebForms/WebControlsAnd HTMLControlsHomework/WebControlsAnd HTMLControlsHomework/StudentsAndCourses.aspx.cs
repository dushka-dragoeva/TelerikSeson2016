using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class StudentsAndCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnSubmit(object sender, EventArgs e)
        {
            this.RegisteredName.Text = $"Registered Student:\n\r { this.FirstName.Text + " " + this.LastName.Text}";
            this.RegisteredUniversity.Text = this.University.SelectedItem.Text;
            this.RegisteredSpecialty.Text = this.Specialty.SelectedItem.Text;
            var courses = new List<string>();

            foreach (ListItem item in this.CheckBoxList.Items)
            {
                if (item.Selected)
                {
                    courses.Add(item.Text);
                }
            }

            this.RegisteredCourses.Text = $"Courses: {string.Join(", ", courses)}";
        }


    }
}