using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class MicrosoftEventPattern
    {
        public delegate void MyDelegate(string message);
        public event MyDelegate MyEvent;

        public void RaiseEvent(string message)
        {
            MyEvent?.Invoke(message);
        }

        public void DisplayMsg(string s)
        {
            Console.WriteLine("the msg to be displayed is : {0}", s);
        }
    }

    public class MicrosoftEventPattern2
    {
        public delegate void MyDelegate2(object sender, MyEventArgs e);
        public event MyDelegate2 MyEvent2;

        public class MyEventArgs: EventArgs
        {
            public readonly string message;
            public int a;
            public MyEventArgs(string msg, int b)
            {
                message = msg;
                a = b;
            }


        }
        public void RaiseEvent(string message, int a)
        {
            if(MyEvent2 != null)
            {
                MyEvent2(this, new MicrosoftEventPattern2.MyEventArgs(message, a));
            }
        }

        public void DisplayMsg(object sender, MicrosoftEventPattern2.MyEventArgs e)
        {
            if(sender is MicrosoftEventPattern2)
            {
                MicrosoftEventPattern2 mep2 = (MicrosoftEventPattern2)sender;
                Console.WriteLine("the msg to be displayed is : {0}, {1}", e.message, e.a);

            }
        }
    }
}
