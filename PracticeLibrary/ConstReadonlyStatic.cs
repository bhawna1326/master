using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class ConstReadonlyStatic
    {
        readonly int a;
        const int b = 10;
        static readonly int c;

        public ConstReadonlyStatic()
        {
            a = 100;
            Console.WriteLine("Hello In non static const: {0}, {1}", a, b);
        }

        static ConstReadonlyStatic()
        {
            // executed first before the public constructor
            c = 329;
            Console.WriteLine("Hello In static const: {0}", c);
        }
    }
}
