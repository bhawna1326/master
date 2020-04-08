using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace PracticeLibrary
{
    //[Synchronization] for entire class
    public class MultithreadingDemo
    {
        public static int count = 0;
        public object padlock = new object();
        public void Method(object a)
        {
            count++;
            Console.WriteLine("Method for Multithreading: {0}, {1}", count, a);
            count--;

        }

        public void Calculate()
        {
            lock (padlock)
            {
                Console.WriteLine(" Thread {0} is Executing: ", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    //Thread.Sleep(new Random().Next(5));
                    Console.WriteLine("{0}", i);
                }
            }
        }

        //Mutex
        private static Mutex mutex = new Mutex();
        public static void MutexDemo()
        {
            try
            {
                mutex.WaitOne();
                Console.WriteLine("after wait one: {0}", Thread.CurrentThread.Name);
                Thread.Sleep(2000);
                Console.WriteLine("leaving the method: {0}", Thread.CurrentThread.Name);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        //Semaphore
        private static Semaphore semaphore = new Semaphore(2, 4);

        public static void SemphoreDemo(object id)
        {
            Console.WriteLine(id + "-->>Wants to Get Enter");
            try
            {
                semaphore.WaitOne();
                Console.WriteLine(" Success: " + id + " is in!");
                Thread.Sleep(2000);
                Console.WriteLine(id + "<<-- is Evacuating");
            }
            finally
            {
                semaphore.Release();
            }

        }

    }
}
