namespace BunniesRefactoring
{
    using System.Collections.Generic;
    using System.IO;

    public class Bunnies
    {
        public static void Main()
        {
            var bunnies = new List<Bunny>
            {
                new Bunny("Leonid", 1, FurType.NotFluffy),
                new Bunny("Rasputin", 2, FurType.ALittleFluffy),
                new Bunny("Tiberii", 3, FurType.ALittleFluffy),
                new Bunny("Neron", 1, FurType.ALittleFluffy),
                new Bunny("Klavdii", 3, FurType.Fluffy),
                new Bunny("Vespasian", 3, FurType.Fluffy),
                new Bunny("Domician", 4, FurType.FluffyToTheLimit),
                new Bunny("Tit", 2, FurType.FluffyToTheLimit)
            };

            var consoleWriter = new ConsoleWriter();

            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var bunniesFilePath = @"..\..\bunnies.txt";
            var fileStream = File.Create(bunniesFilePath);
            fileStream.Close();

            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}