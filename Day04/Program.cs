using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            Debug.Assert(ValidatePassphrasePart1("aa bb cc dd ee") == true);
            Debug.Assert(ValidatePassphrasePart1("aa bb cc dd aa") == false);
            Debug.Assert(ValidatePassphrasePart1("aa bb cc dd aaa") == true);

            var input = File.ReadAllLines("C:/Users/Ed/Documents/AdventOfCode/2017/Day04/input.txt");

            int totalValidPart1 = 0;
            foreach(string passphrase in input)
            {
                bool result = ValidatePassphrasePart1(passphrase);
                if (result)
                {
                    totalValidPart1++;
                }
            }

            Console.WriteLine(totalValidPart1);

            //Part 2
            Debug.Assert(ValidatePassphrasePart2("abcde fghij") == true);
            Debug.Assert(ValidatePassphrasePart2("abcde xyz ecdab") == false);
            Debug.Assert(ValidatePassphrasePart2("a ab abc abd abf abj") == true);
            Debug.Assert(ValidatePassphrasePart2("iiii oiii ooii oooi oooo") == true);
            Debug.Assert(ValidatePassphrasePart2("oiii ioii iioi iiio") == false);

            int totalValidPart2 = 0;
            foreach (string passphrase in input)
            {
                bool result = ValidatePassphrasePart2(passphrase);
                if (result)
                {
                    totalValidPart2++;
                }
            }

            Console.WriteLine(totalValidPart2);
        }

        static bool ValidatePassphrasePart1(string passphrase)
        {
            bool isValid;

            string[] parts = passphrase.Split(' ');

            for(int i = 0; i < parts.Length - 1; i++)
            {
                for(int j = 0; j < parts.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (parts[i] == parts[j])
                    {
                        isValid = false;
                        return isValid;
                    }
                }
            };
            isValid = true;

            return isValid;
        }
        static bool ValidatePassphrasePart2(string passphrase)
        {
            bool isValid;

            string[] parts = passphrase.Split(' ');
            var listOfParts = new List<char[]>();

            foreach (string part in parts)
            {
                listOfParts.Add(part.ToCharArray());
            }

            var allPartsSplit = new List<SortedDictionary<char, int>>();
                        
            foreach (var list in listOfParts)
            {
                var dictionaryOfCounts = new SortedDictionary<char, int>();

                var distinctValues = list.Distinct();

                foreach (var distinctValue in distinctValues)
                {
                    dictionaryOfCounts.Add(distinctValue, list.Count(o => o.Equals(distinctValue)));
                }

                allPartsSplit.Add(dictionaryOfCounts);
            }

            foreach (var item1 in allPartsSplit)
            {
                foreach (var item2 in allPartsSplit)
                {
                    if (item1 == item2)
                    {
                        continue;
                    }
                    if(item1.Count != item2.Count)
                    {
                        continue;
                    }
                    
                    for (int i = 0; i < item1.Count; i++)
                    {
                        if(!(item1.ElementAt(i).Key == item2.ElementAt(i).Key && item1.ElementAt(i).Value == item2.ElementAt(i).Value))
                        {
                            break;
                        }
                        if(i == (item1.Count - 1) && item1.ElementAt(i).Key == item2.ElementAt(i).Key && item1.ElementAt(i).Value == item2.ElementAt(i).Value)
                        {
                            return isValid = false;
                        }
                    }
                }
            }
            
            return isValid = true;
        }
    }
}
