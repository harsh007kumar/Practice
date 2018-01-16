using System;
using System.Threading;

namespace SemaphoreBasics
{
    class MainClass
    {
        // Here in Constructor of Semaphone
        // 1st integer specifies : Inital no of Request that can be granted for Semaphore
        // 2nd integer specifies : Maximum no of concurrent enteries that can be granted for Semaphore, Optionally reserving few enteries
        static Semaphore sOb = new Semaphore(2, 4);

        public static void Main(string[] args)
        {
            for (int y = 0;y < 5;y++)
            {
                new Thread(DoWork).Start(y+1);
            }
            Console.WriteLine("Hello World!");
        }
        static void DoWork(object id)
        {
            Console.WriteLine(id+" Trying to Enter");
            try
            {
                sOb.WaitOne();
                Console.WriteLine(id+" : Entered");
                Thread.Sleep(2000);
            }
            finally
            {
                Console.WriteLine(id + " : Leaving");
                sOb.Release();;
            }
        }
    }
}
