using NewsSystem.Data.Models;
using NewsSystem.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Web
{
    public partial class ViewArticle : System.Web.UI.Page
    {
        [Inject]
        public IArticleServices ArticleServeces { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article DetailsViewGetItem([QueryString] string id)
        {

          //TODO VAlidation
                return this.ArticleServeces.GetById(int.Parse(id));

        }
    }
}