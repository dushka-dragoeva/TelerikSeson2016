using ChainOfResponsibility.Contracts;
using ChainOfResponsibility.Models;
using System;

namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main()
        {
            IHandler h1 = new ConcreteHandler1();
            IHandler h2 = new ConcreteHandler2();
            IHandler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }
}
