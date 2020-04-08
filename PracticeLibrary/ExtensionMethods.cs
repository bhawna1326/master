using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Show me the output from Class1");
        }
    }
    public static class ExtensionMethods
    {
        public static void NewMethod(this Class1 obj)
        {
            obj.Display();
            Console.WriteLine("Hello I am extended method of Class1: ");
        }
    }
}
