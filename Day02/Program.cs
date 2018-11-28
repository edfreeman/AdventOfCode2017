using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            string exampleInputPath = @"C:\Users\EdFreeman\Documents\endjin\Training\AdventOfCode\Day2ExampleInput.txt";
            Debug.Assert(SolveChecksumDay2Part1(exampleInputPath, ' ') == 18);

            string actualInputPath = @"C:\Users\EdFreeman\Documents\endjin\Training\AdventOfCode\Day2ActualInput.txt"; //answer is 44670
            Console.WriteLine(SolveChecksumDay2Part1(actualInputPath));


            //Part 2 
            
            string exampleInputPath2 = @"C:\Users\EdFreeman\Documents\endjin\Training\AdventOfCode\Day2Part2ExampleInput.txt";
            Debug.Assert(SolveChecksumDay2Part2(exampleInputPath2, ' ') == 9);

            Console.WriteLine(SolveChecksumDay2Part2(actualInputPath));

        }

        static int SolveChecksumDay2Part1(string path, char delimiter = '\t')
        {
            var processedInput = ParseAsJaggedArray(path, delimiter);
            //var processedInput = ParseAsListOfLists(path, delimiter);

            return CalculateChecksum(processedInput);
        }

        static int SolveChecksumDay2Part2(string path, char delimiter = '\t')
        {
            //var processedInput = ParseAsJaggedArray(path, delimiter);
            var processedInput = ParseAsListOfLists(path, delimiter);

            return CalculateEvenlyDivisible(processedInput);
        }

        static int CalculateEvenlyDivisible(int[][] jaggedArray)
        {
            int sum = 0;            

            foreach (var subArray in jaggedArray)
            {
                int subArrayLength = subArray.Length;

                for (int i = 0; i < subArrayLength; i++)
                {
                    for (int j = 0; j < subArrayLength; j++)
                    {
                        if(j == i)
                        {
                            continue;
                        }
                        else if (subArray[i] % subArray[j] == 0)
                        {
                            sum += (subArray[i] / subArray[j]);
                            break;
                        }
                    }                    
                }
            }
            return sum;
        }

        static int CalculateEvenlyDivisible(List<List<int>> listOfLists)
        {
            int sum = 0;

            foreach (var list in listOfLists)
            {
                int listLength = list.Count;

                for (int i = 0; i < listLength; i++)
                {
                    for (int j = 0; j < listLength; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        else if (list[i] % list[j] == 0)
                        {
                            sum += (list[i] / list[j]);
                            break;
                        }
                    }
                }
            }
            return sum;
        }

        private static int CalculateChecksum(int[][] jaggedArray)
        {
            int sum = 0;
            
            foreach (var subArray in jaggedArray)
            {
                int minValue = subArray.Min();
                int maxValue = subArray.Max();
                sum += (maxValue - minValue);
            }

            return sum;
        }

        private static int CalculateChecksum(List<List<int>> listOfLists)
        {
            int sum = 0;
            
            foreach(var list in listOfLists)
            {
                int minValue = list.Min();
                int maxValue = list.Max();
                sum += (maxValue - minValue);
            }

            return sum;
        }

        private static int[][] ParseAsJaggedArray(string path, char delimiter)
        {
            string[] rawFile = File.ReadAllLines(path);

            int[][] fullArray = new int[rawFile.Length][];
            int i = 0;

            foreach (string line in rawFile)
            {
                string[] lineParts = line.Split(delimiter);
                int[] intArray = new int[lineParts.Length];

                for (int j = 0; j < lineParts.Length; j++)
                {
                    intArray[j] = int.Parse(lineParts[j]);
                }

                fullArray[i] = intArray;
                i++;
            }

            return fullArray;
        }

        private static List<List<int>> ParseAsListOfLists(string path, char delimiter)
        {
            string[] rawFile = File.ReadAllLines(path);

            var fullList = new List<List<int>>();

            foreach (string line in rawFile)
            {
                string[] lineParts = line.Split(delimiter);
                var row = new List<int>();

                foreach(string part in lineParts)
                {
                    row.Add(int.Parse(part));
                }

                fullList.Add(row);
            }

            return fullList;
        }
    }
}
