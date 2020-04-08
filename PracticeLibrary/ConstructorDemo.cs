using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public abstract class ClassConst
    {
        static int a;
        static ClassConst()
        {
            a = 10;
            Console.WriteLine("Inside static constructor, {0}", a.ToString());
        }

        public ClassConst(): this("Deonani")
        {
            Console.WriteLine("default Constructor of base class");
        }

        public ClassConst(string s)
        {
            Console.WriteLine("base class const: {0}",s);
        }
    }

    public class ClassDerived: ClassConst
    {
        public ClassDerived()
        {
            Console.WriteLine("Inside dervied class default Constructor");
        }

        public ClassDerived(string a)
        {
            Console.WriteLine("derived class const: {0}",a);
        }
    }
}
