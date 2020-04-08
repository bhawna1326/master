using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    
    public interface IInterface1
    {
        void Print();
        void Sum(int a, int b);
    }

    public interface IInterface2
    {
        void Display();
    }

    public class A: TestClass, IInterface1, IInterface2
    {
        public void Print()
        {
            Console.WriteLine("Calling Print for interface1");
        }

        public override void Sum(int a, int b)
        {
            Console.WriteLine((a+b).ToString());
        }

        public void Display()
        {
            Console.WriteLine("Calling Display for interface 2");

        }
    }

    public abstract class TestClass
    {
        public abstract void Sum(int a, int b);
    }
    public class B: TestClass, IInterface1
    {
        public void BPrint()
        {
            Console.WriteLine("Inside class B");
        }

        public void Print()
        {
            Console.WriteLine("Inside class B by implementing interface 1");
        }

        public override void Sum(int a, int b)
        {
            Console.WriteLine((a + b).ToString());
        }


    }

}
