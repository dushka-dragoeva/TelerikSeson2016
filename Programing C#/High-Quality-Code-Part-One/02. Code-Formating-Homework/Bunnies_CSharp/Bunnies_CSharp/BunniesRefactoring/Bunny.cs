namespace BunniesRefactoring
{
    using Contracts;
    using System;
    using System.Text;

    [Serializable]
    public class Bunny
    {
        public Bunny(string name, int age, FurType furType)
        {
            this.Name = name;
            this.Age = age;
            this.FurType = furType;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine($"{this.Name} - \"I am {this.Age} years old!\"");
            writer.WriteLine($"{this.Name} - \"And I am {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}\"");
        }

        public override string ToString()
        {
            var builderSize = 200;
            var builder = new StringBuilder(builderSize);

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}");

            return builder.ToString();
        }
    }
}