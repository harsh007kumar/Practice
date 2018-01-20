using System;
using System.Threading;

namespace AutoResetEvent_Class_Basics
{
    class MainClass
    {
        static AutoResetEvent AutoReset1 = new AutoResetEvent(true);
        static AutoResetEvent AutoReset2 = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            for (int x = 1; x < 6; x++)
            {
                Thread t = new Thread(new ThreadStart(letsPlayWithThreads));
                t.Name = "Thread " + x;
                t.Start();
            }
            for (int y = 1; y < 5; y++)
            {
                Console.WriteLine("Press any key to release an thread from AutoResetEvent 1");
                Console.ReadLine();
                AutoReset1.Set();
                Thread.Sleep(250);
            }
            for (int z = 1; z < 6; z++)
            {
                Console.WriteLine("Press any key to release an thread from AutoResetEvent 2");
                Console.ReadLine();
                AutoReset2.Set();
            }
        }

        private static void letsPlayWithThreads()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine("{0} Waiting for AutoResetEvent 1",name);
            AutoReset1.WaitOne();
            Console.WriteLine("{0} Releases from AutoResetEvent 1",name);

            Console.WriteLine("{0} Waiting for AutoResetEvent 2",name);
            AutoReset2.WaitOne();
            Console.WriteLine("{0} Releases from AutoResetEvent 2",name);
        }
    }
}
