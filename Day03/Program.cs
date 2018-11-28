using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mySpiralClass = new Spiral1(289326);// answer is 419
            //var testCase = mySpiralClass.ManhattanDistance();

            //Console.WriteLine(testCase);

            Debug.Assert(Spiral2.ManhattanDistance(1) == 0);
            Debug.Assert(Spiral2.ManhattanDistance(12) == 3);
            Debug.Assert(Spiral2.ManhattanDistance(23) == 2);
            Debug.Assert(Spiral2.ManhattanDistance(1024) == 31);

            int myNumber = 289326;
            var actual = Spiral3.ManhattanDistance(myNumber);
            Console.WriteLine(actual);

            Debug.Assert(ComplexSpiral.CalculateFirstValueGreaterThanInput(1) == 2);
            Debug.Assert(ComplexSpiral.CalculateFirstValueGreaterThanInput(20) == 23);
            Debug.Assert(ComplexSpiral.CalculateFirstValueGreaterThanInput(100) == 122);
            Debug.Assert(ComplexSpiral.CalculateFirstValueGreaterThanInput(750) == 806);

            Console.WriteLine(ComplexSpiral.CalculateFirstValueGreaterThanInput((uint)myNumber));
            Console.WriteLine(ComplexSpiral.CalculateFirstValueGreaterThanInput(0));
        }
    }
}
