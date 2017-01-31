using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class WebCalculator : System.Web.UI.Page
    {
        private const string Sign = "operation";
        private const string CurrentNumber = "currentNumber";
        private const string Result = "result";

            protected void Page_Load(object sender, EventArgs e)
        {
            this.Field.Enabled = false;
        }

        protected void Number_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var value = btn.Text;

            this.Field.Text += value;

            if (this.ViewState[CurrentNumber] == null)
            {
                this.ViewState[CurrentNumber] = this.Field.Text;
            }
            else
            {
                this.ViewState[CurrentNumber] = this.Field.Text;
            }

        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.Field.Text = string.Empty;
            this.ViewState[Result] = null;
            this.ViewState[CurrentNumber] = null;
            this.ViewState[Sign] = null;

        }

        protected void Operation(object sender, EventArgs e)
        {
            var operationBtn = sender as Button;

            var operation = operationBtn.Text;

            if (operation != "=")
            {
                this.ViewState[Sign] = operation;
            }

            if (this.ViewState[Result] == null)
            {
                this.ViewState[Result] = this.ViewState[CurrentNumber];
                this.Field.Text = string.Empty;

                this.ViewState[CurrentNumber] = null;
                this.Field.Text = string.Empty;
            }
            else
            {
                double currentResult = double.Parse(this.ViewState[Result].ToString());
                double currentNum = double.Parse(this.ViewState[CurrentNumber].ToString());
                string equals = null;

                if (operation == "=")
                {
                    operation = this.ViewState[Sign].ToString();
                    equals = "=";
                }

                switch (operation)
                {
                    case "+":
                        currentResult += currentNum;
                        break;
                    case "-":
                        currentResult -= currentNum;
                        break;
                    case "*":
                        currentResult *= currentNum;
                        break;
                    case "/":
                        currentResult /= currentNum;
                        break;
                    case "SQRT":
                        currentResult = Math.Sqrt(currentNum);
                        break;
                    default: break;
                }

                this.ViewState[Result] = currentResult.ToString();

                if (equals != null)
                {
                    this.ViewState[CurrentNumber] = currentResult.ToString();
                    this.ViewState[Result] = null;
                }

                this.Field.Text = currentResult.ToString();
            }
        }
    }
}