using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class RefAndOut
    {
        public void SwapNubers(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("Swapped numbers are: {0}, {1}", x, y);
        }

        public void OutExampleSumNumbers(int a, int b, out int c)
        {            
            c = a + b;
        }
    }
}
