using System;
using System.Threading;

namespace MultiThreadingBasics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //////// Thread ////////////
            Thread t = Thread.CurrentThread;
            t.Name = "PrimaryThread";
            Console.WriteLine(t.Name);
            Console.WriteLine(t.Priority);
            Console.WriteLine(t.IsAlive);
            Console.WriteLine(t.IsBackground);
            Console.WriteLine(t.ExecutionContext);
            Console.WriteLine(Thread.CurrentContext.ContextID);
            Console.WriteLine(Thread.GetDomain().FriendlyName);
            
            Console.WriteLine();
            Thread tt = new Thread(myFun);//Thread class accepts a delegate parameter.
            tt.Name = "Thread1";
            Thread t2 = new Thread(myFun2);
            t2.Name = "Thread2";
            t2.IsBackground = true;    // It Decides wether or not the Application would wait for Thread (Setting thread as => ForeGround/BackGround)
            tt.Start();
            t2.Priority=ThreadPriority.Highest;//Setting Thread Priority
            t2.Start();
            Console.WriteLine("Main thread Running");

            Console.WriteLine("Hello World!");
        }
        static void myFun()
        {
            Console.WriteLine("Running 1st Thread");
        }
        static void myFun2()
        {
            Console.WriteLine("Running 2nd Thread");
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} completed", Thread.CurrentThread.Name);
        }
    }
}
