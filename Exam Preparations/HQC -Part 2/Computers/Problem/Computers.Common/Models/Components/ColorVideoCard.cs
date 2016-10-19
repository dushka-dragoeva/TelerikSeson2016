using System;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class ColorVideoCard : MotherboardComponent, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
