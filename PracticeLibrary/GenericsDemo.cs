using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class GenericsDemo
    {
        public void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;

            Console.WriteLine("Swapped values: {0}, {1}", a, b);
        }

        public void ReverseUsingStack()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Stack<int> stack = new Stack<int>(arr);
            int count = stack.Count;

            for(int i = 0; i< count;i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }

}
