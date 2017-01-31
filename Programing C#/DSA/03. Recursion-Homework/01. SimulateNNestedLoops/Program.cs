using System;

namespace SimulateNNestedLoops
{
    public class RecursiveNestedLoops
    {
        public static void Main()
        {
            Console.Write("N = ");
            var numberOfLoops = int.Parse(Console.ReadLine());
            var loops = new int[numberOfLoops];
            NestedLoops(0, numberOfLoops, loops);
        }

        static void NestedLoops(int currentLoop, int numberOfLoops, int[] loops)
        {
            if (currentLoop == numberOfLoops)
            {
                Console.WriteLine(string.Join(" ", loops));
                return;
            }
            for (int counter = 1; counter <= numberOfLoops; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoops(currentLoop + 1, numberOfLoops, loops);
            }
        }
    }
}
