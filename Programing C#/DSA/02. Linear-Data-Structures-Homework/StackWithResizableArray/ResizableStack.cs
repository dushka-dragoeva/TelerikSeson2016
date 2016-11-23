using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackWithResizableArray
{
   public class ResizableStack<T>
    {
        private const int InitialSize = 5;

        private T[] internalArray;
        private int size;
        private int pointer;

        public ResizableStack()
            : this(InitialSize)
        {
        }

        public ResizableStack(int size)
        {
            this.internalArray = new T[size];
            this.pointer = -1;
            this.size = size;
        }

        public int Count
        {
            get
            {
                return this.pointer + 1;
            }
        }

        public void Push(T element)
        {
            ++this.pointer;

            if (this.pointer == this.size)
            {
                this.DoubleSize();
            }

            this.internalArray[this.pointer] = element;
        }

        public T Peek()
        {
            if (this.pointer < 0)
            {
                throw new NullReferenceException("The stack does not contain any elements.");
            }

            return this.internalArray[this.pointer];
        }

        public T Pop()
        {
            if (this.pointer < 0)
            {
                throw new NullReferenceException("The stack does not contain any elements.");
            }
            else
            {
                this.pointer--;
                return this.internalArray[this.pointer + 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int ind = 0; ind < this.pointer; ind++)
            {
                yield return this.internalArray[ind];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleSize()
        {
            var tmp = new T[this.size * 2];
            Array.Copy(this.internalArray, tmp, this.internalArray.Length);
            this.internalArray = tmp;
            this.size = this.internalArray.Length;
        }
    }
}
