using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace LockMonitorSynchronization_Basics
{
    [Synchronization]
    class MainClass : ContextBoundObject
    {
        static Object ob = new object();

        public void Calculate()
        {
            #region Use of Synchornization Attribute handles race-condition
            {
                Console.WriteLine(Thread.CurrentThread.Name + " : Executing");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write(" {0},", i);
                }

                Console.WriteLine();
            }
            #endregion

            /*
            #region UsingLock
            lock (ob)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " : Executing");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write(" {0},", i);
                }

                Console.WriteLine();
            }
            #endregion

            #region Using Monitor
            Monitor.Enter(ob);
            try
            {
                Console.WriteLine(Thread.CurrentThread.Name + " : Executing");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write(" {0},", i);
                }

                Console.WriteLine();
            }
            finally
            { Monitor.Exit(ob); }
            #endregion

            */

        }
        public static void Main(string[] args)
        {
            MainClass m = new MainClass();
            Thread[] t = new Thread[5];

            for (int x = 0; x < 5; x++)
            {
                t[x] = new Thread(new ThreadStart(m.Calculate));
                t[x].Name = String.Format("Thread: {0}", 1 + x);
                t[x].Start();
            }
            //foreach (Thread th in t)
            //{ th.Start(); }

            Console.WriteLine("Hello World!");
        }
    }
}

