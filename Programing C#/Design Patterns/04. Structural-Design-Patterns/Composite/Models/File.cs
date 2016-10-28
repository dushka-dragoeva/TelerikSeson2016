using System;

namespace Composite.Models
{
    public class File : FileSystemEntity
    {
        public File(string name) : base(name)
        {
        }

        public override void Print(int padding)
        {
            Console.WriteLine(new string(' ', padding) + $"- {this.Name}");
        }
    }
}