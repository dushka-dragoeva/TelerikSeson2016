using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class RandomGenerator : Page
    {
        //protected int num1;
        //protected int num2;
        //protected int firstNum;
        //protected int secondNum;
        private const string InvalidInteger = "Value must be a whole number.";

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.HtmlResult.InnerText = string.Empty;
this.Error1.InnerText = string.Empty;
            this.Error2.InnerText = string.Empty;
        }

        protected void OnHtmlRandomButton_Click(object sender, EventArgs e)
                    {
            //  this.HtmlResult.InnerText = string.Empty;
            int num1;
            bool IsNumber = int.TryParse(this.Num1.Value, out num1);

            if (!IsNumber)
            {
                this.Error1.InnerText = InvalidInteger;
                return;
            }

            int num2;
            IsNumber = int.TryParse(this.Num2.Value, out num2);

            if (!IsNumber)
            {
                this.Error2.InnerText = InvalidInteger;
                return;
            }

            if (num1 < num2)
            {
                int result = RandomNumber(num1, num2);
                this.HtmlResult.InnerText = $"Your Lucky Number Is: {result}";
            }
            else
            {
                this.Error2.InnerText = "Value must be a bigger whole number than first one.";
            }
        }

        protected void OnWebRandomButton_Click(object sender, EventArgs e)
        {
            int firstNum = int.Parse(this.FirstNum.Text);
            DataBind();
            int secondNum = int.Parse(this.SecondNum.Text);

            int result = this.RandomNumber(firstNum, secondNum);

            this.WebResult.Text = $"Your Lucky Number Is: {result}";
        }

        private int RandomNumber(int min, int max)
        {

            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}