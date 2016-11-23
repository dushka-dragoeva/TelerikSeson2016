using System;

namespace QueueAsDinamikLinkedList
{
    public class Program
    {
      public  static void Main(string[] args)
        {
            var a = new DinamicQueue<int>();
            a.Enque(16);
            a.Enque(216);
            a.Enque(136);
            a.Enque(6);
            a.Enque(17);
            a.Enque(-98);
            a.Dequeue();
            Console.WriteLine(a.Peek()) ;

            Console.WriteLine(string.Join(", ", a));

        }
    }
}
