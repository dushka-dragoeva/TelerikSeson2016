using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitsOfWork.TestGenerator
{
    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public static Unit Parse(IList<string> unitParts)
        {
            return new Unit
            {
                Name = unitParts[0],
                Type = unitParts[1],
                Attack = int.Parse(unitParts[2])
            };
        }

        public int CompareTo(Unit other)
        {
            var result = this.Attack.CompareTo(other.Attack) * -1;
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }

    public class Command
    {
        public string Name { get; set; }

        public IList<string> Arguments { get; set; }

        public static Command Parse(string commandAsString)
        {
            var commandParts = commandAsString.Split(' ');

            var name = commandParts[0];

            var newListOfStrings = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                newListOfStrings.Add(commandParts[i]);
            }

            return new Command
            {
                Name = name,
                Arguments = newListOfStrings
            };
        }
    }

    public class Game
    {
        private IDictionary<string, Unit> unitsByName;
        private IDictionary<string, SortedSet<Unit>> unitsByType;
        private ISet<Unit> unitsByAttack;

        public Game()
        {
            this.unitsByName = new Dictionary<string, Unit>();
            this.unitsByType = new Dictionary<string, SortedSet<Unit>>();
            this.unitsByAttack = new SortedSet<Unit>();
        }

        public bool Add(Unit unit)
        {
            if (this.unitsByName.ContainsKey(unit.Name))
            {
                return false;
            }

            this.unitsByName[unit.Name] = unit;

            if (!this.unitsByType.ContainsKey(unit.Type))
            {
                this.unitsByType[unit.Type] = new SortedSet<Unit>();
            }

            this.unitsByType[unit.Type].Add(unit);

            this.unitsByAttack.Add(unit);

            return true;
        }

        public IEnumerable<Unit> FindByType(string type)
        {
            if (!this.unitsByType.ContainsKey(type))
            {
                return Enumerable.Empty<Unit>();
            }

            return this.unitsByType[type].Take(10);
        }

        public IEnumerable<Unit> MostPowerful(int numberOfUnits)
        {
            return this.unitsByAttack.Take(numberOfUnits);
        }

        public bool Remove(string name)
        {
            if (!this.unitsByName.ContainsKey(name))
            {
                return false;
            }

            var unitByName = this.unitsByName[name];

            this.unitsByName.Remove(name);

            var unitsWithSameType = this.unitsByType[unitByName.Type];

            unitsWithSameType.Remove(unitByName);

            this.unitsByAttack.Remove(unitByName);

            return true;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var numberOfUnits = 40000;
            var numberOfTypes = 400;
            var numberOfQueries = 400;
            var random = new Random();

            var types = new List<string>();
            for (int i = 0; i < numberOfTypes; i++)
            {
                types.Add(i.ToString());
            }

            // generate tests without remove
            for (int i = 3; i < 11; i++)
            {
                var inputName = string.Format("test.{0:D3}.in.txt", i);
                var output = string.Format("test.{0:D3}.out.txt", i);

                var listOfLines = new List<string>();

                using (var writer = new StreamWriter(inputName))
                {
                    // add units
                    for (int j = 0; j < numberOfUnits; j++)
                    {
                        var line = string.Format("add {0} {1} {2}", j.ToString(), types[random.Next(0, types.Count)], random.Next(100, 1000));

                        writer.WriteLine(line);
                        listOfLines.Add(line);

                        // add the same unit to test the exists error
                        if (j % 10 == 0)
                        {
                            writer.WriteLine(line);
                            listOfLines.Add(line);
                        }
                    }

                    // find units
                    for (int j = 0; j < numberOfQueries; j++)
                    {
                        var line = string.Format("find {0}", types[random.Next(0, types.Count)]);
                        writer.WriteLine(line);
                        listOfLines.Add(line);
                    }

                    // powerful units
                    for (int j = 0; j < numberOfQueries; j++)
                    {
                        var line = string.Format("power {0}", random.Next(1, 100));
                        writer.WriteLine(line);
                        listOfLines.Add(line);
                    }

                    // add remove testing
                    if (i >= 7)
                    {
                        for (int j = 0; j < numberOfQueries; j++)
                        {
                            var line = string.Format("remove {0}", random.Next(0, numberOfUnits));
                            writer.WriteLine(line);
                            listOfLines.Add(line);
                        }

                        // and run again finds

                        // find units
                        for (int j = 0; j < numberOfQueries; j++)
                        {
                            var line = string.Format("find {0}", types[random.Next(0, types.Count)]);
                            writer.WriteLine(line);
                            listOfLines.Add(line);
                        }

                        // powerful units
                        for (int j = 0; j < numberOfQueries; j++)
                        {
                            var line = string.Format("power {0}", random.Next(1, 100));
                            writer.WriteLine(line);
                            listOfLines.Add(line);
                        }
                    }

                    writer.WriteLine("end");
                    listOfLines.Add("end");
                }

                var result = Solve(listOfLines);

                using (var writer = new StreamWriter(output))
                {
                    writer.WriteLine(result);
                }
            }
        }

        public static string Solve(List<string> lines)
        {
            var game = new Game();
            var finalResult = new StringBuilder();

            var counter = 0;
            var line = lines[counter];
            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var unit = Unit.Parse(command.Arguments);
                        var added = game.Add(unit);
                        if (added)
                        {
                            finalResult.AppendLine(string.Format("SUCCESS: {0} added!", unit.Name));
                        }
                        else
                        {
                            finalResult.AppendLine(string.Format("FAIL: {0} already exists!", unit.Name));
                        }

                        break;

                    case "remove":
                        var name = command.Arguments[0];
                        var removed = game.Remove(name);
                        if (removed)
                        {
                            finalResult.AppendLine(string.Format("SUCCESS: {0} removed!", name));
                        }
                        else
                        {
                            finalResult.AppendLine(string.Format("FAIL: {0} could not be found!", name));
                        }

                        break;

                    case "find":
                        var type = command.Arguments[0];
                        var found = game.FindByType(type);
                        finalResult.AppendLine(string.Format("RESULT: {0}", string.Join(", ", found)));

                        break;

                    case "power":
                        var mostPowerful = game.MostPowerful(int.Parse(command.Arguments[0]));
                        finalResult.AppendLine(string.Format("RESULT: {0}", string.Join(", ", mostPowerful)));

                        break;
                    default:
                        throw new InvalidOperationException();
                }

                counter++;
                line = lines[counter];
            }

            return finalResult.ToString();
        }
    }
}
