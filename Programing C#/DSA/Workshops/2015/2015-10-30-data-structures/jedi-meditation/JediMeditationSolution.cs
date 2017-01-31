namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JediMeditationSolution
    {
        public static void Main(string[] args)
        {
            var jedi = ReadInput();
            string keys = "mkp";
            var jediOrdered = Solve(jedi, keys);
            PrintOutput(jediOrdered, keys);
        }

        private static IEnumerable<string> ReadInput()
        {
            Console.ReadLine();
            return Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static IDictionary<char, Queue<string>> Solve(IEnumerable<string> jedi, string keys)
        {
            var jediOrdered = new Dictionary<char, Queue<string>>();
            foreach (var key in keys)
            {
                jediOrdered[key] = new Queue<string>();
            }

            var jediInitial = jedi.ToList();
            jediInitial.ForEach(j => jediOrdered[j[0]].Enqueue(j));
            return jediOrdered;
        }

        private static void PrintOutput(IDictionary<char, Queue<string>> orders, string keys)
        {
            var builder = new StringBuilder();
            foreach (var key in keys)
            {
                var queue = orders[key];
                while (queue.Count > 0)
                {
                    builder.AppendFormat("{0} ", queue.Dequeue());
                }
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
