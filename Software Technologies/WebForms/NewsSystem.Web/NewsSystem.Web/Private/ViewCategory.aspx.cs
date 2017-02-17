using NewsSystem.Data.Models;
using NewsSystem.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Web.Private
{
    public partial class ViewCategory : System.Web.UI.Page
    {

        [Inject]
        public ICategoryDataProvider CategoryServeces { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NewsSystem.Data.Models.Category> GridViewCategories_GetData()
        {
            return this.CategoryServeces.GetAll().OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int id)
        {
            var editTitleBox = this.GridViewCategories.Rows[this.GridViewCategories.EditIndex].Controls[0].Controls[0] as TextBox;
            var name = editTitleBox.Text;
            // To do Validate Null
            //if (this.CategoryServeces.GetByName(name)==null || string.IsNullOrWhiteSpace(name))
            //{

            //}

            this.CategoryServeces.UpdateName(id, editTitleBox.Text);

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int id)
        {
            this.CategoryServeces.Delete(id);
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            var createTitleBox = this.CategoryCreate.Text;

            this.CategoryServeces.Create(createTitleBox);
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.CategoryCreate.Text = string.Empty;
        }
    }
}