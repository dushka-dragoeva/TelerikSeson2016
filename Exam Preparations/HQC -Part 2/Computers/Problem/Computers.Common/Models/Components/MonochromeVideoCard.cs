using System;

using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class MonochromeVideoCard : MotherboardComponent, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
