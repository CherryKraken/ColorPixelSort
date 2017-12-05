using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public QuickSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            Sort(0, Length - 1);
        }

        private void Sort(int first, int last)
        {
            if (last > first)
            {
                // Find the pivot
                int pivot = FindPivot(first, last);
                Swap(pivot, last);

                // Partition relative to the pivot value
                int partition = Partition(first - 1, last, this[last]);
                Swap(partition, last);

                // Recurse left
                Sort(first, partition - 1);
                // Recurse right
                Sort(partition + 1, last);
            }
        }

        protected int Partition(int left, int right, T pivotValue)
        {
            do
            {
                // Move the left pointer until a value greater than the pivot value is found
                while (this[++left].CompareTo(pivotValue) < 0) ;
                // Move the right pointer until a value less than the pivot value is found, or it meets the left pointer
                while (right > left && this[--right].CompareTo(pivotValue) > 0) ;

                Swap(left, right);
            } while (left < right); // Continue until the left pointer meets or crosses the right pointer

            return left;
        }

        protected virtual int FindPivot(int first, int last)
        {
            return last; // for random sets, this is fine
        }
    }
}
