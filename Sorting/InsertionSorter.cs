using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public InsertionSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            for (int i = 1; i < Length; i++)
            {
                InsertInOrder(i);
                //Console.WriteLine(this);
            }
            //Console.WriteLine();
        }

        private void InsertInOrder(int index)
        {
            // Shift previous elements up until current value is at correct position
            T element = this[index];
            for (int i = index - 1; i >= 0 && element.CompareTo(this[i]) < 0; i--)
            {
                this[index--] = this[i];
            }
            this[index] = element;


            // Insert each "current" element to correct position (always worst case)

            //for (int i = 0; i < index; i++)
            //{
            //    if (array[index].CompareTo(array[i]) < 0)
            //    {
            //        Swap(index, i);
            //    }
            //}
        }
    }
}
