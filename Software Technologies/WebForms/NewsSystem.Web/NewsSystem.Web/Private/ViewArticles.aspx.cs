using Microsoft.AspNet.Identity;
using NewsSystem.Data.Models;
using NewsSystem.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Web.Private
{
    public partial class ViewArticles : System.Web.UI.Page
    {
        [Inject]
        public IArticleDataProvider ArticleServeces { get; set; }

        [Inject]
        public ICategoryDataProvider CategoryServeces { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Article> ArtivlesLV_GetData([QueryString] string orderBy)
        {
            var result = this.ArticleServeces.GetAll();
            // TODO validate order by or create distionary
            result = string.IsNullOrEmpty(orderBy) ? result.OrderBy(x => x.Id) : result.OrderBy(orderBy + " Ascending");
            return result;
        }

        public IQueryable<Category> CategoriesDD_GetData()
        {
            return this.CategoryServeces.GetAll().OrderBy(x => x.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ArtivlesLV_DeleteItem(int id)
        {
            this.ArticleServeces.Delete(id);
        }

        public void ArtivlesLV_InsertItem()
        {
            var articleToInsert = new Article();
            TryUpdateModel(articleToInsert);
            articleToInsert.AuthorId = Page.User.Identity.GetUserId();
            articleToInsert.DateCreated = DateTime.UtcNow;
            this.ArticleServeces.Create(articleToInsert);
            this.Response.Redirect("~/Private/ViewArticles.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ArtivlesLV_UpdateItem(int id)
        {
            Article articleToUpdate = new Article();
            TryUpdateModel(articleToUpdate);
            this.ArticleServeces.Update(id, articleToUpdate);
            this.Response.Redirect("~/Private/ViewArticles.aspx");

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            this.ArtivlesLV.InsertItemPosition = InsertItemPosition.LastItem;
        }

         protected void btnCancelCreate_Click (object sender, EventArgs e)
        {
            this.Response.Redirect("~/Private/ViewArticles.aspx");
        }
    }
}