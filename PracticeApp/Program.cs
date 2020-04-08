using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeLibrary;
using System.Threading;

namespace PracticeApp
{
    class Program
    {

        public static event SampleDel event1;

        struct Shape
        {
            public Shape(int x1, int y1)
            {
                X = x1;
                Y = y1;
            }

            public int X { get; }

            public int Y { get; }
        }
        public static void Main(string[] args)
        {
            Shape shape = new Shape(4, 5);
            Console.WriteLine("{0}, {1}", shape.X, shape.Y);

            // ConstReadOnlyStatic
            ConstReadonlyStatic constReadonlyStatic = new ConstReadonlyStatic();

            //RefAndOut (swap numbers and testing Out params)
            RefAndOut refAndOut = new RefAndOut();
            int a = 6;
            int b = 9;
            int c;
            refAndOut.SwapNubers(ref a, ref b);
            refAndOut.OutExampleSumNumbers(a, b, out c);
            Console.WriteLine("sum of numbers is : {0}", c);

            // ExtensionMethods
            Class1 c1 = new Class1();
            c1.Display();
            c1.NewMethod();


            //DisposeVsFinalize
            DisposeVsFinalize d = new DisposeVsFinalize();
            d.Dispose();
            d = null;

            // DelegatesDemo
            DelegatesDemo dd = new DelegatesDemo();
            SumDelegate sd = new SumDelegate(dd.Sum);
            Console.WriteLine("sum is: {0}", sd.Invoke(30, 40));
            sd += dd.Multiply; //multicast delegate
            Console.WriteLine("Multiply : {0}", sd.Invoke(1, 2));

            SumDelegate[] sd1 =
            {
                new SumDelegate(dd.Sum),
                new SumDelegate(dd.Multiply)
            };
            for (int i = 0; i < sd1.Length; i++)
            {
                Console.WriteLine("{0}", sd1[i](2, 5));
                Console.WriteLine("{0}", sd1[i](8, 5));
                Console.WriteLine("{0}", sd1[i](4, 6));
            }

            //EventsDemo
            EventsDemo ed = new EventsDemo();
            event1 += new SampleDel(ed.India);
            event1 += new SampleDel(ed.USA);
            event1 += new SampleDel(ed.Netherlands);

            event1.Invoke();
            event1 -= new SampleDel(ed.USA);
            event1.Invoke();

            ed.Action("hello");
            ed.xyz += new StrDel(ed.Action);


            //MicrosoftEventsPattern demo
            MicrosoftEventPattern mep = new MicrosoftEventPattern();
            mep.MyEvent += new MicrosoftEventPattern.MyDelegate(mep.DisplayMsg);
            mep.RaiseEvent("Hello from the event!!!");

            // Patter 2 demo
            MicrosoftEventPattern2 mep2 = new MicrosoftEventPattern2();
            mep2.MyEvent2 += new MicrosoftEventPattern2.MyDelegate2(mep2.DisplayMsg);
            mep2.RaiseEvent("Hello MEP !!!!", 26);

            //IEnumerableDemo
            IEnumerableDemo id = new IEnumerableDemo();
            id.Print();
            id.ListOperations();


            Test t1 = new Test();
            t1.Name = "Bhawna";
            t1.Surname = "Deonani";
            Test t2 = new Test();
            t2.Name = "Darwin";
            t2.Surname = "Rajpal";
            Test myList = new Test();
            myList.Add(t1);
            myList.Add(t2);
            foreach (Test obj in myList)
            {
                Console.WriteLine("Name:- " + obj.Name + " Surname :- " + obj.Surname);
            }

            // static Polymorphism
            StaticPolymorphism sp = new StaticPolymorphism();
            sp.Add(1, 2);
            sp.Add("bhawna", "deonani");

            //Dynamic Polymorphism
            //Method hiding using new keyword
            Base b2 = new Base();
            b2.Foo();

            Base base1 = new Child1();
            base1.Foo();

            Child1 child1 = new Child1();
            child1.Foo();

            // Method overriding
            Base b3 = new Child2();
            b3.Foo();

            Child1 child11 = new Child3();
            child11.Foo();

            //Abstract methods
            Base2 b123 = new ChildAbstract();
            b123.Test();
            b123.Test1();

            //Interfaces, you can create interface objects only for instance of class
            // Meaning that You cannot instantiate an interface
            // even if the object here is of interface type but the memory is allocated only for the class
            IInterface1 iiii = new A();
            iiii.Print();

            A aa = new A();
            aa.Sum(2, 3);
            aa.Display();

            B bb = new B();
            bb.Sum(33, 44);
            bb.Print();

            // this can only call interface 1 methods
            IInterface1 ii1 = aa;
            ii1.Print();
            ii1.Sum(5, 6);


            //This can only call interface 2 methods
            IInterface2 ii2 = aa;
            ii2.Display();

            if (ii1 is IInterface2)
            {
                IInterface2 interface2 = (IInterface2)ii1;
                interface2.Display();
            }

            IInterface2 int21 = ii1 as IInterface2;
            int21.Display();

            //ConstructorsDemo

            ClassConst cd = new ClassDerived();
            ClassConst cd1 = new ClassDerived("Bhawna");

            //Array
            ArrayClass ar = new ArrayClass();
            ar.ReverseArray();

            //Ienumerable
            Test1 t11 = new Test1();
            t11.Display();

            IEnumerable<int> e1 = t11.GetPowersofTwo();
            foreach (int i in e1)
            {
                Console.WriteLine(i.ToString());
            }

            //Singleton Demo
            //only one object is created via using a static property and Private constructor
            SingletonClass a1 = SingletonClass.Instance;
            a1.Test();

            //Threadsafe singleton demo
            ThreadSafeSingleton tss = ThreadSafeSingleton.Instance;
            tss.Test();

            ThreadSafeSingleton1 tss1 = ThreadSafeSingleton1.Instance;
            tss1.Test();

            //Thread Safe Singleton without using locks and no lazy instantiation
            ThreadSafeSingletonNoLocksNoLazy tnl = ThreadSafeSingletonNoLocksNoLazy.Instance;
            tnl.Test();

            LazySingleton ls = LazySingleton.Instance;
            ls.Test();

            //using .NET 4's Lazy<T> type
            LazyClassSingleton lcs = LazyClassSingleton.Instance;
            lcs.Test();

            //Object Pooling in .Net
            Factory f = new Factory();
            Student s1 = f.GetStudentObject();
            s1.FirstName = "BHawna"; s1.LastName = "deonani";
            Console.WriteLine("First object: {0}, {1}: ", s1.FirstName, s1.LastName);
            Student s2 = f.GetStudentObject();
            s2.FirstName = "Darwin"; s2.LastName = "Rajpal";
            Console.WriteLine("Second Object: {0}, {1}: ", s2.FirstName, s2.LastName);
            Student s3 = f.GetStudentObject();
            if (s3.FirstName == null && s3.LastName == null)
            { s3.FirstName = "Nyra"; s3.LastName = "Darwin Rajpal"; }
            Console.WriteLine("Third Object: {0}, {1}: ", s3.FirstName, s3.LastName);
            Student s4 = f.GetStudentObject();
            if (s4.FirstName == null && s4.LastName == null)
            { s4.FirstName = "N"; s4.LastName = "DR"; }
            Console.WriteLine("Fourth Object: {0}, {1}: ", s4.FirstName, s4.LastName);
            Student s5 = f.GetStudentObject();
            if (s5.FirstName == null && s5.LastName == null)
            { s5.FirstName = "Hello"; s5.LastName = "World"; }
            Console.WriteLine("Fifth Object: {0}, {1}: ", s5.FirstName, s5.LastName);


            // ACtionFuncPredicate Demo

            ActionFuncPredicate afp = new ActionFuncPredicate();

            Action<int> action = new Action<int>(afp.ActionMethod);
            action.Invoke(100);

            Func<int, int, int> func = new Func<int, int, int>(afp.FuncMethodSum);
            func.Invoke(2, 3);

            Predicate<int> predicate = new Predicate<int>(afp.IsPositive);
            predicate.Invoke(3);
            predicate.Invoke(-234);

            //Generics Demo (provides typesafety, performance, and code reuse)
            GenericsDemo gd = new GenericsDemo();
            int a12 = 3, b12 = 4;
            string str1 = "bhawna", str2 = "deonani";
            gd.Swap(ref a12, ref b12);
            gd.Swap(ref str1, ref str2);

            gd.ReverseUsingStack();

            //MultithreadingDemo
            Console.WriteLine("Main method");
            MultithreadingDemo md1 = new MultithreadingDemo();
            int a222 = 10;
            Thread t = new Thread(new ParameterizedThreadStart(md1.Method));
            Thread t21 = new Thread(new ParameterizedThreadStart(md1.Method));
            t.Start(a222);
            t21.Start(a222);

            Thread[] tArr = new Thread[5];
            for (int i = 0; i < tArr.Length; i++)
            {
                tArr[i] = new Thread(new ThreadStart(md1.Calculate));
                Console.WriteLine("Working from Thread: {0}", i);
                tArr[i].Name = i.ToString();
            }

            foreach(Thread ttt in tArr)
            {
                ttt.Start();
            }

            for(int i =0; i< 4; i++)
            {
                Thread tmutex = new Thread(new ThreadStart(MultithreadingDemo.MutexDemo));
                tmutex.Name = string.Format("Thread {0} :", i + 1);
                tmutex.Start();
            }

            //Semaphore demo
            for(int i =0; i< 5; i++)
            {
                Thread abc = new Thread(new ParameterizedThreadStart(MultithreadingDemo.SemphoreDemo));
                abc.Start(i);
            }

            
            
            Console.ReadLine();
        }
    }
}
