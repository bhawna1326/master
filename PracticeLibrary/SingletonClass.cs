using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    //Not a Threadsafe implementation of Singleton
    //Bad Code do not use it
    //A private constructor is basically called from the public static property
    //it is sealed so cannot be inherited and hence no chance of creating objects from child class
    public sealed class SingletonClass
    {

        private SingletonClass()
        { }

        private static SingletonClass instance = null;
        public static SingletonClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonClass();
                }
                return instance;
            }

        }
        public void Test()
        {
            Console.WriteLine("Test Singleton");
        }
    }


    // Thread Safe implementation of Singleton class
    //just add lock to the above implementation to make it thread safe
    public sealed class ThreadSafeSingleton
    {
        private ThreadSafeSingleton()
        { }
        private readonly static object padlock = new object();
        private static ThreadSafeSingleton instance = null;
        public static ThreadSafeSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                    return instance;
                }

            }
        }
        public void Test()
        {
            Console.WriteLine("Thread safe Singleton");
        }
    }

    //Thread safe singleton with double check over locking
    public sealed class ThreadSafeSingleton1
    {
        private ThreadSafeSingleton1()
        { }
        private readonly static object padlock = new object();
        private static ThreadSafeSingleton1 instance = null;
        public static ThreadSafeSingleton1 Instance
        {
            get
            {
                if (instance == null) // only this is the new line added to above implementation
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ThreadSafeSingleton1();
                        }
                        
                    }
                }
                return instance;
            }
        }
        public void Test()
        {
            Console.WriteLine("Thread safe Singleton with double checks");
        }
    }

    //Thread Safe Singleton without using locks and no lazy instantiation
    public sealed class ThreadSafeSingletonNoLocksNoLazy
    {
        private static readonly ThreadSafeSingletonNoLocksNoLazy instance = new ThreadSafeSingletonNoLocksNoLazy();

        static ThreadSafeSingletonNoLocksNoLazy()
        {
        }

        private ThreadSafeSingletonNoLocksNoLazy() { }
        public static ThreadSafeSingletonNoLocksNoLazy Instance
        {
            get
            {
                return instance;
            }
            
        }
        public void Test()
        {
            Console.WriteLine("Thread safe Singleton without locks and no lazy instantiation");
        }
    }


    //fully lazy instantiation
    public sealed class LazySingleton
    {
        private LazySingleton() { }
        public static LazySingleton Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            static Nested() { }

            internal static readonly LazySingleton instance = new LazySingleton();
        }

        public void Test()
        {
            Console.WriteLine("Fully Lazy Singleton Instantiation");
        }
    }

    //using .NET 4's Lazy<T> type
    public sealed class LazyClassSingleton
    {
        private static readonly Lazy<LazyClassSingleton> lazy = new Lazy<LazyClassSingleton>(() => new LazyClassSingleton());

        public static LazyClassSingleton Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void Test()
        {
            Console.WriteLine("using .NET 4's Lazy<T> type");
        }
    }
}
