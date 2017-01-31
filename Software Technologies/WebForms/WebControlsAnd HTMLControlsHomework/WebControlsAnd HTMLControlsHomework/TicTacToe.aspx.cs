using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        private const string PlayerOneSymbol = "X";
        private const string ComputerSymbol = "O";
        private const string EmptySpace = " ";
        private const string PlayerWinsMessage = "Player wins :)";
        private const string ComputerWinsMessage = "Computer wins :(";

        private IList<Button> buttons = new List<Button>();
        private Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttons.Add(Button0);
            this.buttons.Add(Button1);
            this.buttons.Add(Button2);
            this.buttons.Add(Button3);
            this.buttons.Add(Button4);
            this.buttons.Add(Button5);
            this.buttons.Add(Button6);
            this.buttons.Add(Button7);
            this.buttons.Add(Button8);
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            var senderIndex = int.Parse(button.ID.Substring(button.ID.Length - 1));

            var clickedbutton = this.buttons[senderIndex];

            clickedbutton.Text = PlayerOneSymbol;
            clickedbutton.Enabled = false;

            if (!this.CheckForWinner())
            {
                this.ComputerPlays();
                this.CheckForWinner();
            }
            else
            {
                foreach (var b in this.buttons)
                {
                    if (b.Enabled)
                    {
                        b.Enabled = false;
                    }
                }
            }
        }

        private void ComputerPlays()
        {
            int emptyCount = this.buttons.Where(b => b.Text == EmptySpace).Count();

            if (emptyCount > 1)
            {
                while (true)
                {
                    var randomBtn = random.Next(0, 8 + 1);
                    if (this.buttons[randomBtn].Text != PlayerOneSymbol && this.buttons[randomBtn].Text != ComputerSymbol)
                    {
                        this.buttons[randomBtn].Text = ComputerSymbol;
                        this.buttons[randomBtn].Enabled = false;
                        break;
                    }
                }
            }
        }

        private bool CheckForWinner()
        {
            int playerScore = 0;
            int computerScore = 0;

            // check horizontal
            for (int i = 0; i < 9; i++)
            {
                if (i == 3 || i == 6)
                {
                    playerScore = 0;
                    computerScore = 0;
                }

                if (buttons[i].Text == PlayerOneSymbol)
                {
                    playerScore++;
                }
                else if (buttons[i].Text == ComputerSymbol)
                {
                    computerScore++;
                }

                if (playerScore == 3)
                {
                    this.winner.InnerHtml = PlayerWinsMessage;
                    return true;
                }
                else if (computerScore == 3)
                {
                    this.winner.InnerHtml = ComputerWinsMessage;
                    return true;
                }

            }

            // vertical
            for (int i = 0; i < 3; i++)
            {
                playerScore = 0;
                computerScore = 0;

                for (int j = i; j < i + 7; j += 3)
                {
                    if (buttons[j].Text == PlayerOneSymbol)
                    {
                        playerScore++;
                    }
                    else if (buttons[j].Text == ComputerSymbol)
                    {
                        computerScore++;
                    }

                    if (playerScore == 3)
                    {
                        this.winner.InnerHtml = PlayerWinsMessage;
                        return true;
                    }
                    else if (computerScore == 3)
                    {
                        this.winner.InnerHtml = ComputerWinsMessage;
                        return true;
                    }
                }
            }

            if (CheckRightDiagonal(PlayerOneSymbol) || CheckleftDiagonal(PlayerOneSymbol))
            {
                this.winner.InnerHtml = PlayerWinsMessage;
                return true;
            }
            else if (CheckRightDiagonal(ComputerSymbol) || CheckleftDiagonal(ComputerSymbol))
            {
                this.winner.InnerHtml = ComputerWinsMessage;
                return true;
            }

            return false;
        }

        private bool CheckRightDiagonal(string symbol)
        {
            return this.buttons[0].Text == symbol
                && this.buttons[4].Text == symbol
                && this.buttons[8].Text == symbol;
        }

        private bool CheckleftDiagonal(string symbol)
        {
            return this.buttons[2].Text == symbol
                && this.buttons[4].Text == symbol
                && this.buttons[6].Text == symbol;
        }
    }
}