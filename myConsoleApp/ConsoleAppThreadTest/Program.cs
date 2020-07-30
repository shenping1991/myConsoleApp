using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppThreadTest
{
    class ThreadTest
    {
        bool done;
        static bool staticdone;
        static void Main(string[] args)
        {
            //demo1
            //Thread t = new Thread(WriteY);
            //t.Start();
            //while (true) Console.Write("x");
            //demo2 CLR分配每个线程到它自己的内存堆栈上，来保证局部变量的分离运行。
            new Thread(GO).Start();
            GO();
            Console.WriteLine("");
            //demo3 当线程们引用了一些公用的目标实例的时候，他们会共享数据。
            ThreadTest td = new ThreadTest();
            new Thread(td.commonGo).Start();
            td.commonGo();
            Console.WriteLine("");
            //demo4 静态字段提供了另一种在线程间共享数据的方式
            new Thread(demo4GO).Start();
            demo4GO();
        }
        static void WriteY()
        {
            while (true) Console.Write("Y");
        }
        //demo2共享数据
        static void GO()
        {
            int i=0;
            do
            {
                i++;
                Console.Write("&");
            } while (i < 5);
        }
        //demo3
        void commonGo()
        {
            if (!done) { done = true; Console.Write("Done"); }
        }
        //demo4
        static void demo4GO()
        {
            if (!staticdone) { staticdone = true; Console.WriteLine("Done"); }
        }
    }
}
