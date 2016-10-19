using System;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public abstract class Cpu : MotherboardComponent, ICpu
    {
        private const int MinValue = 0;

        private const string NumberTooLow = "Number too low.";
        private const string NumberTooHigh = "Number too high.";

        private static readonly Random Random = new Random();

        public Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; private set; }

        public virtual void SquareNumber()
        {
            var data = Motherboard.LoadRamValue();
            if (MinValue > data)
            {
                Motherboard.DrawOnVideoCard(NumberTooLow);
            }
            else if (data > this.GetMaxNumber())
            {
                Motherboard.DrawOnVideoCard(NumberTooHigh);
            }
            else
            {
                var result = data * data;
                Motherboard.DrawOnVideoCard($"Square of {data} is {result}.");
            }
        }

        public virtual void GenerateRandomNumber(int min, int max)
        {
            var randomNumber = Random.Next(min, max);

            Motherboard.SaveRamValue(randomNumber);
        }

        public abstract int GetMaxNumber();
    }
}