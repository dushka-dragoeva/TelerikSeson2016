using System;
using System.Collections.Generic;

namespace StackWithResizableArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new ResizableStack<int>();
            new List<int> { 1, 2, 3, 4, 5 }.ForEach(x => stack.Push(x));

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
