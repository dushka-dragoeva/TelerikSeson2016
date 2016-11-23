using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
  public  class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }

    }

}

