using System;
using System.Web.UI;

namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class Escaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnEscapeButton_Click(object sender, EventArgs e)
        {
            string textToEscape = TextToEscape.Text;
            TextBoxEscapedText.Text = Server.HtmlEncode(textToEscape);
            LableEscapedText.Text = Server.HtmlEncode(textToEscape);
        }
    }
}