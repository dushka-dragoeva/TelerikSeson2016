using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ninject;

using NewsSystem.Data.Models;
using NewsSystem.Data.Services.Contracts;

namespace NewsSystem.Web
{
    public partial class _Default : Page
    {
        private const int TopArticlesCount = 3;

        [Inject]
        public IArticleDataProvider ArticleServeces { get; set; }

        [Inject]
        public ICategoryDataProvider CategoryServeces { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          //  if(this.CategoryServeces.GetAll().Select(x=>x.Articles.Count==0))
        }

        public IEnumerable<Article> MostPopulerArticles_GetDatail()
        {
            return this.ArticleServeces.GetTop(TopArticlesCount);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NewsSystem.Data.Models.Category> Categories_GetData()
        {
            return this.CategoryServeces.GetAll();
        }
    }
}