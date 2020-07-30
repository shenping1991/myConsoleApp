using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppThread1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(new ThreadStart(PrintNumbers));
            //t1.Start();
            //Console.WriteLine("");
            //Thread t3 = new Thread(PrintNumbersWithDelay);
            //t3.Start();
            ////PrintNumbers();
            //Console.WriteLine("");
            //Thread t2 = new Thread(new ParameterizedThreadStart(PrintNumbers));
            //t2.Start(10);
            ////Console.ReadLine();
            //Console.WriteLine("");

            //Thread t4 = new Thread(PrintNumbersWithDelay4);
            //t4.Start();
            //Thread.Sleep(TimeSpan.FromSeconds(6));
            //t4.Abort();
            //Console.WriteLine("t4 has been aborted");

            Console.WriteLine("Start Program....");
            Thread t5 = new Thread(PrintNumbersWithStatus);
            t5.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(t5.ThreadState.ToString());
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t5.Abort();
            Console.WriteLine("t5 has been aborted");
            Console.WriteLine(t5.ThreadState.ToString());

            Console.ReadLine();
        }
        static void PrintNumbersWithStatus()
        {
            Console.WriteLine("Starting...");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
        static void PrintNumbers()
        {
            Console.WriteLine("t1 Starting...");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("t1:" + i + " ");
            }
            Console.WriteLine("t1 end...");
        }

        static void PrintNumbers(object count)
        {
            Console.WriteLine("t2 Starting....");
            for (int i = 0; i < Convert.ToInt32(count); i++)
            {
                Console.Write("t2:" + i+" ");
            }
            Console.WriteLine("t2 end...");
        }

        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("t3 Starting....");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.Write("t3:" + i + " ");
            }
            Console.WriteLine("t3 end...");
        }
        static void PrintNumbersWithDelay4()
        {
            Console.WriteLine("t4 Starting....");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("t4:" + i + " ");
            }
            Console.WriteLine("t4 end...");
        }
    }
}
