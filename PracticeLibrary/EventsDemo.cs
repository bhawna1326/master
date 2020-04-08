using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public delegate void SampleDel();
    public delegate void StrDel(string s);
    public class EventsDemo
    {
        public event StrDel xyz;
        public void India() => Console.WriteLine("India");
        public void USA() => Console.WriteLine("USA");
        public void Netherlands() => Console.WriteLine("Netherlands");
       
        public void Action(string s)
        {
            Console.WriteLine("{0}", s);
        }
    }
}
