using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppThreadSafe
{
    class ThreadSafe
    {
        static bool done;
        static object locker = new object();
        bool upper;

        //委托
        //public delegate void ThreadStart();
        //ParameterizedThreadStart的特性是在使用之前我们必需对我们想要的类型（这里是bool）进行装箱操作，并且它只能接收一个参数。
        //public delegate void ParameterizedThreadStart(object obj);
        static void Main(string[] args)
        {
            Thread t1=new Thread(Go);
            t1.Start();
            Go();
            //线程想要暂停或Sleep一段时间 10s
            Thread.Sleep(TimeSpan.FromSeconds(3));

            Thread t2 = new Thread(Go1);
            t2.Start();
            //一个线程也可以使用它的Join方法来等待另一个线程结束：
            t2.Join();

            Console.WriteLine("");
            //使用匿名方法来启动线程
            Thread t3 = new Thread(delegate() { Console.WriteLine ("Hello!"); });
            t3.Start();

            Console.WriteLine("");
            //创建TheadStart委托 来指明方法从哪里开始运行
            //Thread t4 = new Thread(new ThreadStart(Say));
            //t4.Start(); 
            //Say();

            //带参数
            Thread t5 = new Thread(Say);
            t5.Start(true);//需装箱
            Say(false);
            Console.WriteLine("");
            //匿名方法调用一个普通的方法
            string text = "Before";
            Thread t6 = new Thread(delegate() { WriteText(text); });
            text = "After";
            t6.Start();

            //将对象实例的方法而不是静态方法传入到线程
            //对象实例的属性可以告诉线程要做什么
            ThreadSafe instance1 = new ThreadSafe();
            instance1.upper = true;
            Thread t7 = new Thread(instance1.SayHello);
            t7.Start();
            ThreadSafe instance2 = new ThreadSafe();
            instance2.SayHello();
            

            Console.WriteLine("");
            //线程命名
            Thread.CurrentThread.Name = "main";
            Thread t8 = new Thread(GetThreadName);
            t8.Name = "t8";
            t8.Start();
            GetThreadName();

            Thread t9 = new Thread(delegate() { Console.ReadLine(); });
            t9.Start();
            t9.Join(1000);//
            Console.WriteLine("Read Complete");
        }
        static void GetThreadName()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        static void WriteText(string text)
        {
            Console.WriteLine(text);
        }
        void SayHello()
        {
            Console.Write(upper ? "HELLO EVERYONE" : "Hello");
        }
        static void Go()
        {
            //线程安全
            //当两个线程争夺一个锁的时候（在这个例子里是locker），一个线程等待，或者说被阻止到那个锁变的可用。
            //确保了在同一时刻只有一个线程能进入临界区
            lock (locker)//当读写公共字段的时候，提供一个排他锁
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }
        static void Go1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i);
            }
        }
        //static void Say()
        //{
        //    Console.Write("Hello!");
        //}
        static void Say(object upperCase)
        {
            bool upper = (bool)upperCase;
            Console.Write(upper?"HELLO!":"Hello!");
        }
    }
}
