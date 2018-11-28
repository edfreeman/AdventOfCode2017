using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Day03
{
    public static class Spiral3
    {        
        public static Dictionary<int,(int X,int Y)> GenerateSpiral(int spiralLength)
        {
            var dictionary = new Dictionary<int, (int X, int Y)>() { { 1, (0, 0) } };

            int right = 1;
            int up = 1;
            int left = 2;
            int down = 2;

            for (int i = 2; i <= spiralLength; i++)
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
                    dictionary.Add(i, (dictionary[i - 1].X + 1, dictionary[i - 1].Y));
                    right--;
                    continue;
                }
                if (up != 0)
                {
                    dictionary.Add(i, (dictionary[i - 1].X, dictionary[i - 1].Y + 1));
                    up--;
                    continue;
                }
                if (left != 0)
                {
                    dictionary.Add(i, (dictionary[i - 1].X - 1, dictionary[i - 1].Y));
                    left--;
                    continue;
                }
                if (down != 0)
                {
                    dictionary.Add(i, (dictionary[i - 1].X, dictionary[i - 1].Y - 1));
                    down--;
                    continue;
                }                
            }

            return dictionary;
        }
        
        public static int ManhattanDistance(int number)
        {
            var fullSpiral = GenerateSpiral(number);
            var coordinatesOfNumber = fullSpiral[number];

            return Math.Abs(coordinatesOfNumber.X) + Math.Abs(coordinatesOfNumber.Y);
        }
    }
}
