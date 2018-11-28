using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Day03
{
    public static class ComplexSpiral
    {
        public static uint? CalculateFirstValueGreaterThanInput(uint input)
        {
            var dictionary = new Dictionary<(int X, int Y), int>() { { (0, 0), 1 } };

            var previousCoordinate = dictionary.Keys.Last();
            int? firstValueGreaterThanInput = null;

            if (input == 0)
            {
                firstValueGreaterThanInput = 1;
                return (uint?)firstValueGreaterThanInput;
            }

            int right = 1;
            int up = 1;
            int left = 2;
            int down = 2;

            bool greaterThanInput = false;

            while (!greaterThanInput)
            {
                if (down == 0) //if we've reached the "end" of a sub-spiral, re initialize variables
                {
                    right = (2 * -previousCoordinate.X) + 1;
                    up = (2 * -previousCoordinate.Y) + 1;
                    left = (2 * (-previousCoordinate.X + 1));
                    down = (2 * (-previousCoordinate.Y + 1));
                }

                if (right != 0)
                {
                    List<int> adjacentValues = new List<int>();

                    var currentCoordinate = (X: previousCoordinate.X + 1, Y: previousCoordinate.Y);
                    var currentXCoordinate = currentCoordinate.X;
                    var currentYCoordinate = currentCoordinate.Y;

                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate + 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate, currentYCoordinate + 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate + 1)]);
                    }

                    dictionary.Add(currentCoordinate, adjacentValues.Sum());
                    
                    if (dictionary[currentCoordinate] > input)
                    {
                        firstValueGreaterThanInput = dictionary[currentCoordinate];
                        greaterThanInput = true;
                        break;
                    }
                    else
                    {
                        previousCoordinate = dictionary.Keys.Last();
                        right--;
                        continue;
                    }
                }

                if (up != 0)
                {
                    List<int> adjacentValues = new List<int>();

                    var currentCoordinate = (X: previousCoordinate.X, Y: previousCoordinate.Y + 1);
                    var currentXCoordinate = currentCoordinate.X;
                    var currentYCoordinate = currentCoordinate.Y;

                    if (dictionary.ContainsKey((currentXCoordinate, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate, currentYCoordinate - 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate - 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate + 1)]);
                    }

                    dictionary.Add(currentCoordinate, adjacentValues.Sum());

                    if (dictionary[currentCoordinate] > input)
                    {
                        firstValueGreaterThanInput = dictionary[currentCoordinate];
                        greaterThanInput = true;
                        break;
                    }
                    else
                    {
                        previousCoordinate = dictionary.Keys.Last();
                        up--;
                        continue;
                    }
                }

                if (left != 0)
                {
                    List<int> adjacentValues = new List<int>();

                    var currentCoordinate = (X: previousCoordinate.X - 1, Y: previousCoordinate.Y);
                    var currentXCoordinate = currentCoordinate.X;
                    var currentYCoordinate = currentCoordinate.Y;

                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate - 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate, currentYCoordinate - 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate - 1, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate - 1, currentYCoordinate - 1)]);
                    }

                    dictionary.Add(currentCoordinate, adjacentValues.Sum());

                    if (dictionary[currentCoordinate] > input)
                    {
                        firstValueGreaterThanInput = dictionary[currentCoordinate];
                        greaterThanInput = true;
                        break;
                    }
                    else
                    {
                        previousCoordinate = dictionary.Keys.Last();
                        left--;
                        continue;
                    }
                }

                if (down != 0)
                {
                    List<int> adjacentValues = new List<int>();

                    var currentCoordinate = (X: previousCoordinate.X, Y: previousCoordinate.Y - 1);
                    var currentXCoordinate = currentCoordinate.X;
                    var currentYCoordinate = currentCoordinate.Y;

                    if (dictionary.ContainsKey((currentXCoordinate, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate, currentYCoordinate + 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate + 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate + 1)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate)]);
                    }
                    if (dictionary.ContainsKey((currentXCoordinate + 1, currentYCoordinate - 1)))
                    {
                        adjacentValues.Add(dictionary[(currentXCoordinate + 1, currentYCoordinate - 1)]);
                    }

                    dictionary.Add(currentCoordinate, adjacentValues.Sum());

                    if (dictionary[currentCoordinate] > input)
                    {
                        firstValueGreaterThanInput = dictionary[currentCoordinate];
                        greaterThanInput = true;
                        break;
                    }
                    else
                    {
                        previousCoordinate = dictionary.Keys.Last();
                        down--;
                        continue;
                    }
                }
            }

            return (uint?)firstValueGreaterThanInput;
        }            
    }
}
