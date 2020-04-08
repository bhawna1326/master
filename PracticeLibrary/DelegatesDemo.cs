using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public delegate int SumDelegate(int a, int b);
    public class DelegatesDemo
    {
        public int Sum(int a, int b) => a + b;

        public int Multiply(int a, int b) => a * b;
    }
}
