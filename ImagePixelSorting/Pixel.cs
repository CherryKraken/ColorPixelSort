using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePixelSorting
{
    public class Pixel : IComparable<Pixel>
    {
        public Color Color { get; set; }

        public int CompareTo(Pixel obj)
        {
            return obj.GetHashCode() - GetHashCode();
        }

        public override int GetHashCode()
        {
            return Color.R + Color.G + Color.B;
        }
    }
}
