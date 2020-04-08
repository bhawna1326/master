using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class StaticPolymorphism
    {
        public void Add(int a, int b)
        {
            Console.WriteLine((a + b).ToString());
        }

        //return type is not considered as part of static polymorphism rules
        //only method name, type and number of params should be taken in account
        public string Add(string a, string b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }
    }

    //Method hiding using new keyword
    public class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine("inside base class");
        }
    }

    public class Child1 : Base
    {
        public new virtual void Foo()
        {
            Console.WriteLine("Inside Child 1");
        }

    }

    public class Child3 : Child1
    {
        public override void Foo()
        {
            Console.WriteLine("Inside Child 3");
        }

    }

    public class Child2: Base
    {
        public override void Foo()
        {
            Console.WriteLine("Inside Child2");
        }
    }

    //abstract class demo
    public abstract class Base2
    {
        public void Test1()
        {
            Console.WriteLine("nonabstract method Test2");
        }
        public abstract void Test();
    }

    public class ChildAbstract: Base2
    {
        public override void Test()
        {
            Console.WriteLine("Inside abstract child class");
        }
    }
}
