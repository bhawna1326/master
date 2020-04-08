using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class ArrayClass
    { 
        public void ReverseArray()
        {
            Array ar = Array.CreateInstance(typeof(int), 3);
            ar.SetValue(1, 0);
            ar.SetValue(2, 1);
            ar.SetValue(10, 2);
            //static method in Array class hence using classname instaed of object

            int pos = Array.BinarySearch(ar, 10);

            Console.WriteLine("Searched position is :{0}", pos);
            Array.Reverse(ar);
            Console.WriteLine(ar.Rank);
            foreach(int i in ar)
            {
                Console.WriteLine(i);
            }
        }
    }

}
