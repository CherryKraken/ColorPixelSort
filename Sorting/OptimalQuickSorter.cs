using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class OptimalQuickSorter<T> : QuickSorter<T> where T : IComparable<T>
    {
        public OptimalQuickSorter(T[] array) : base(array)
        {
        }

        protected override int FindPivot(int first, int last)
        {
            int mid = (first + last) / 2;

            if (this[first].CompareTo(this[mid]) > 0)
            {
                Swap(first, mid);
            }

            if (this[first].CompareTo(this[last]) > 0)
            {
                Swap(first, last);
            }

            if (this[mid].CompareTo(this[last]) > 0)
            {
                Swap(mid, last);
            }

            return mid;
        }
    }
}
