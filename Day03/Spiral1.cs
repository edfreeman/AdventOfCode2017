using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Day03
{
    public class Spiral1
    {
        public Spiral1(int length)
        {
            if(length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                SpiralLength = length;
            }            
        }

        public int SpiralLength { get; }
        
        public Dictionary<int,Point> GenerateSpiral()
        {
            var dictionary = new Dictionary<int, Point>() { { 1, new Point(0, 0) } };
            int up = 1;
            int down = 2;
            int left = 2;
            int right = 1;

            for (int i = 2; i <= SpiralLength; i++)
            {
                if(down == 0) //if we've reached the "end" of a sub-spiral, re initialize variables
                {
                    right = (2 * -dictionary[i - 1].X) + 1;
                    up = (2 * -dictionary[i - 1].Y) + 1;
                    left = (2 * (-dictionary[i - 1].X + 1));
                    down = (2 * (-dictionary[i - 1].Y + 1));
                }
                if(right != 0)
                {
                    dictionary.Add(i, dictionary[i - 1] + new Size(1, 0));
                    right--;
                    continue;
                }
                if (up != 0)
                {
                    dictionary.Add(i, dictionary[i - 1] + new Size(0, 1));
                    up--;
                    continue;
                }
                if (left != 0)
                {
                    dictionary.Add(i, dictionary[i - 1] + new Size(-1, 0));
                    left--;
                    continue;
                }
                if (down != 0)
                {
                    dictionary.Add(i, dictionary[i - 1] + new Size(0, -1));
                    down--;
                    continue;
                }                
            }

            return dictionary;
        }
        
        public int ManhattanDistance()
        {
            var fullSpiral = GenerateSpiral();
            var coordinatesOfNumber = fullSpiral[SpiralLength];

            return Math.Abs(coordinatesOfNumber.X) + Math.Abs(coordinatesOfNumber.Y);
        }
    }
}
