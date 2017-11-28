using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Sorting;

namespace ImagePixelSorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bitmap img = new Bitmap(@"G:\image.bmp", true);

            Pixel[,] pixels = new Pixel[img.Height, img.Width];
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    pixels[y, x] = new Pixel();
                    pixels[y, x].Color = img.GetPixel(x, y);
                }
            }

            Bitmap result = new Bitmap(img.Width, img.Height);

            Console.WriteLine(pixels.GetLength(0));
            Console.WriteLine(pixels.GetLength(1));

            for (int i = 0; i < pixels.GetLength(1); i++)
            {
                InsertionSorter<Pixel> line = new InsertionSorter<Pixel>(GetRow(pixels, i));
                line.Sort();
                
                for (int j = 0; j < line.Length; j++)
                {
                    result.SetPixel(i, j, line[j].Color);
                }
            }

            result.Save(@"G:\image-sorted-reverse.bmp");
        }


        public static T[] GetRow<T>(T[,] input2DArray, int row)
        {
            var width = input2DArray.GetLength(0);
            var height = input2DArray.GetLength(1);

            if (row >= height)
                throw new IndexOutOfRangeException("Row Index Out of Range");
            // Ensures the row requested is within the range of the 2-d array

            var returnRow = new T[width];
            for (var i = 0; i < width; i++)
                returnRow[i] = input2DArray[i, row];

            return returnRow;
        }
    }


    public class Pixel : IComparable<Pixel>
    {
        public Color Color { get; set; }

        public int CompareTo(Pixel obj)
        {
            Color other = obj.Color;
            return  (other.R + other.G + other.B) - (Color.R + Color.G + Color.B);
        }
    }
}
