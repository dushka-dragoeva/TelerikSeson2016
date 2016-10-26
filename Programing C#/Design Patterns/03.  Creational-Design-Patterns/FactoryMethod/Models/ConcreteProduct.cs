using FactoryMethod.Contracts;
using System;

namespace FactoryMethod.Models
{
    public class ConcreteProduct : IProduct
    {
        public void DoSomething()
        {
            /// doing something in ConcreteProduct way;
        }
    }
}
