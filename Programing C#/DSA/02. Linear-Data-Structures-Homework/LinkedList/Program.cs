using System;

namespace LinkedList
{
    public class Program
    {
        public static void Main()
        {
            var a = new GenericLinkedList<int>();
            a.AddFirst(5);
            a.AddLast(7);
            a.AddFirst(3);
            a.AddLast(15);
            a.AddLast(6);
            a.RemoveFirst();

            Console.WriteLine(a.Last);
            a.RemoveLast();
            Console.WriteLine(a.Last);

            Console.WriteLine(string.Join(", ", a));
        }
    }
}
