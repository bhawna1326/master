using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class ActionFuncPredicate
    {
        public void ActionMethod(int a)
        {
            Console.WriteLine("For action method: {0}", a);
        }

        public int FuncMethodSum(int a, int b)
        {
            Console.WriteLine("Sum from FuncMethod: {0}", (a+b).ToString());
            return a + b;
        }

        public bool IsPositive(int c)
        {
            if(c >0)
            {
                Console.WriteLine("Value is positive");
                return true;
            }
            else
            {
                Console.WriteLine("Value is negative");
                return false;
            }
        }
    }
}
