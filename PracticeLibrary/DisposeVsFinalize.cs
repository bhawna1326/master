using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class DisposeVsFinalize : IDisposable
    {
        private static bool disposed = false;
        public DisposeVsFinalize()
        {
            Console.WriteLine("Object is created!");
        }

        ~DisposeVsFinalize()
        {
            Console.WriteLine("Desctructor/Finalize is called");
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }     

        public static void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    // clear your managed resources
                    Console.WriteLine("Managed resources to be disposed! Called from Dispose");
                }
                else
                {
                    Console.WriteLine("Clear your unmanaged resources!");
                }
                disposed = true;
            }
        }
    }
}
