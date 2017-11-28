using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class ASorter<T> where T : IComparable<T>
    {
        protected T[] array;
        public int Length { get => array.Length; }
        public T this[int index] { get => array[index]; set => array[index] = value; }

        protected ASorter(T[] array)
        {
            this.array = array;
        }

        public abstract void Sort();

        protected void Swap(int a, int b)
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", array)}]";
        }
    }
}
