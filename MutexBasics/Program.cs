using System;
using System.Threading;

namespace MutexBasics
{
    class MainClass
    {
        static Mutex mutex = new Mutex();

        public static void Main(string[] args)
        {
            Console.WriteLine("================== MUTEX basic Implementation ==================");
            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(new ThreadStart(MutexDemo));
                t.Name = String.Format("Thread {0}", i + 1);
                t.Start();
            }
        }
        static void MutexDemo()
        {
            try
            {
                mutex.WaitOne();        // Acquiring Mutex Lock

                Console.WriteLine(Thread.CurrentThread.Name + ": Entering the Domain");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + ": Leaving the Domain");
            }
            finally
            {
                Console.WriteLine();

                mutex.ReleaseMutex();   // Releasing Mutex
            }
        }
    }
}
