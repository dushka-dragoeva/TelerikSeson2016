namespace _05_07_GenericList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> : IEnumerable<T>
        where T : IComparable
    {
        private const int InitialCount = 0;
        private int capacity;
        private T[] arr;
        private int count;

        public GenericList(int initialCapacity)
        {
            this.Capacity = initialCapacity;
            this.Count = InitialCount;
            this.arr = new T[this.capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value > 0 || value <= int.MaxValue)
                {
                    this.capacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Capacity", "Rows must be between 1 and  2,147,483,647!");
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException($"Index should be between 0 and {this.Count - 1}.");
                }
                else
                {
                    return this.arr[index];
                }
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException($"Index should be between 0 and {this.Count - 1}.");
                }
                else
                {
                    this.arr[index] = value;
                }
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.capacity)
            {
                this.Capacity *= 2;
                var oldArr = this.arr;
                this.arr = new T[this.Capacity];
                Array.Copy(oldArr, this.arr, this.Count);
            }

            this.arr[this.Count] = item;
            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException($"Index should be between 0 and {this.Count - 1}.");
            }
            else
            {
                var oldArr = this.arr;

                this.Count = 0;
                this.arr = new T[this.Capacity];

                for (int i = 0; i < index; i++)
                {
                    this.Add(oldArr[i]);
                }

                for (int i = index; i < oldArr.Length - index; i++)
                {
                    this.Add(oldArr[i + 1]);
                }
            }
        }

        public void Insirt(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException($"Index should be between 0 and {this.Count - 1}.");
            }
            else
            {
                var oldArr = this.arr;
                this.Count = 0;
                this.arr = new T[this.Capacity];

                for (int i = 0; i < index; i++)
                {
                    this.Add(oldArr[i]);
                }

                this.Add(item);

                for (int i = index + 1; i < oldArr.Length - index - 1; i++)
                {
                    this.Add(oldArr[i - 1]);
                }
            }
        }

        public void Clear()
        {
            this.Count = InitialCount;
            this.arr = new T[this.Capacity];
        }

        public int IndexOf(T item)
        {
            var index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.arr[i].CompareTo(item) == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                builder.Append(this.arr[i] + ", ");
            }

            return builder.ToString().Trim(new[] { ',', ' ' });
        }

        public T[] Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (this.arr[j].CompareTo(this.arr[i]) < 0)
                    {
                        var temp = this.arr[j];
                        this.arr[j] = this.arr[i];
                        this.arr[i] = temp;
                    }
                }
            }

            return this.arr;
        }

        public T Min()
        {
            var minElement = default(T);

            if (this.count > 0)
            {
                this.arr = this.Sort();
                minElement = this.arr[0];
            }

            return minElement;
        }

        public T Max()
        {
            var maxElement = default(T);

            if (this.count > 0)
            {
                this.arr = this.Sort();
                maxElement = this.arr[this.Count - 1];
            }

            return maxElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var item = this.arr[i];
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
