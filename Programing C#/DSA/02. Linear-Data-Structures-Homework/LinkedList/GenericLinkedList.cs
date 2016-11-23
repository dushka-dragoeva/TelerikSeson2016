using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class GenericLinkedList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        public GenericLinkedList()
        {
            this.Count = 0;
            this.First = null;
            this.Last = null;
        }

        public Node<T> First { get; set; }

        public Node<T> Last { get; set; }

        public int Count { get; set; }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);

            if (First == null)
            {
                this.First = node;
                this.Last = node;
                this.Count = 1;
            }
            else
            {
                node.Next = this.First;
                this.First = node;
                this.Count++;
            }
        }
        public void AddLast(T value)
        {
            var node = new Node<T>(value);

            if (First == null)
            {
                this.First = node;
                this.Last = node;
                this.Count = 1;
            }
            else
            {
                this.Last.Next = node;
                this.Last = node;
                this.Count++;
            }
        }

        public void RemoveFirst()
        {
            var oldFirst = this.First;
            this.First = oldFirst.Next;
            this.Count--;
        }

        public void RemoveLast()
        {
            var oldLast = this.Last;
            var current = this.First;
            while (current.Next != null)
            {
                if (current.Next == oldLast)
                {
                    this.Last = current;
                    current.Next = current.Next.Next;
                    this.Count--;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.First;

            while (currentItem != null)
            {
                yield return currentItem.Value;

                currentItem = currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
