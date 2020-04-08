using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class IEnumerableDemo
    {
        IEnumerable<int> Values => Enumerable.Range(1, 10);

        List<string> list = new List<string>();
        public void Print()
        {
            foreach (int i in Values)
            {
                Console.WriteLine(i);
            }
        }

        public void ListOperations()
        {
            list.Add("Bhawna");
            list.Add("BDeonani");
            list.Add("BHello");
            IEnumerable<string> names = from n in list where n.StartsWith("B") select n;
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }

    public class Test : IEnumerable
    {
        Test[] Items = null;
        int freeIndex = 0;
        public String Name { get; set; }
        public string Surname { get; set; }
        public Test()
        {
            Items = new Test[10];
        }
        public void Add(Test item)
        {
            Items[freeIndex] = item;
            freeIndex++;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (object o in Items)
            {
                if (o == null)
                {
                    break;
                }

                yield return o;
            }
        }
    }

    public class Test1
    {
        public void Display()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> i = list;


            foreach (int i1 in i)
            {
                Console.WriteLine(i1.ToString());
            }

        }
        public IEnumerable<int> GetPowersofTwo()
        {
            for (int i = 1; i < 10; i++)
                yield return (int)System.Math.Pow(2, i);
            yield break;
        }
    }
}
