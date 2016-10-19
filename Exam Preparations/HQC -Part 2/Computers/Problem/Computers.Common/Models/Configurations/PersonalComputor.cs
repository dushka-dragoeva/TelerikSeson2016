using System.Collections.Generic;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Configurations
{
    public class PersonalComputor : Computer
    {
        private const int MinNumber = 1;
        private const int MAxNumber = 10;

        private const string YouDidNotGuess = "You didn't guess the number ";
        private const string YouWin = "You win!";

        public PersonalComputor(ICpu cpu, IRam ram, IEnumerable<IHardDriver> driver, IVideoCard videoCard)
            : base(cpu, ram, driver, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.Motherboard.DrawOnVideoCard(YouDidNotGuess + $"{number}.");
            }
            else
            {
                this.Motherboard.DrawOnVideoCard(YouWin);
            }
        }
    }
}