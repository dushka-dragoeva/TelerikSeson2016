using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.DataBindingHomework
{
    public partial class XmlTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.BookstoreTree.DataSourceID = "Bookstore";
            this.BookstoreTree.DataBind();
        }
    }
}