using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class IntegerRadixSorter : ASorter<int>
    {
        private readonly int _base;

        public IntegerRadixSorter(int[] array) : base(array)
        {
            _base = 10;
        }

        public override void Sort()
        {
            for (int place = 1; place <= 1000000000; place *= _base)
            {
                int[] output = new int[Length];
                int[] count = new int[_base];

                for (int i = 0; i < Length; i++)
                {
                    int digit = GetDigit(this[i].GetHashCode(), place);
                    count[digit] += 1;
                }

                for (int i = 1; i < count.Length; i++)
                {
                    count[i] += count[i - 1];
                }

                for (int i = Length - 1; i >= 0; i--)
                {
                    int digit = GetDigit(this[i].GetHashCode(), place);
                    output[count[digit] - 1] = this[i];
                    count[digit]--;
                }

                array = output;
            }
        }

        private int GetDigit(int v, int place)
        {
            return (v / place) % _base;
        }

        private int GetMaxValue()
        {
            int max_index = 0;

            for (var i = 0; i < Length; i++)
            {
                if (this[i].CompareTo(this[max_index]) > 0)
                {
                    max_index = i;
                }
            }

            return max_index;
        }
    }
}
