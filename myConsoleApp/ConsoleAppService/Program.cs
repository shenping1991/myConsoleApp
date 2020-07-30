using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Timers;
using System.Threading;

using Pro.Common;
namespace ConsoleAppService
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "TimingService.ini";
            IniFile myIni = new IniFile(Environment.CurrentDirectory + "\\TimingService.ini");
            //写入配置信息
            myIni.WriteInt("TimingService", "exeCount", 1);
            myIni.WriteString("exe0", "FilePath", @"C:\Program Files\Internet Explorer\iexplore.exe");
            myIni.WriteString("exe0", "ExecTimeMinutes", "30");
            //读取配置信息
            //Console.WriteLine(myIni.ReadString("TimingService", "exeCount", ""));
            //Console.WriteLine(myIni.ReadString("exe0", "FilePath", ""));
            //Console.WriteLine(myIni.ReadString("exe0", "ExecTimeMinutes", ""));
            //执行

            int timing = Convert.ToInt32(myIni.ReadString("exe0", "ExecTimeMinutes", "30"));
            //方法二：使用System.Timers.Timer类
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = timing * 60000;////执行间隔时间,单位为毫秒;60000此时时间间隔为1分钟  
            timer.Enabled = true;//设置是否执行System.Timers.Timer.Elapsed事件 
            timer.AutoReset = false;//false是执行一次，true是一直执行
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RunAutoExe);//当到达时间的时候执行MethodTimer2事件 
            
            //Program obj = new Program();
            //方法一 调用线程执行方法，在方法中实现死循环，每个循环Sleep设定时间
            //Thread thread = new Thread(new ThreadStart(obj.Method1));
            //thread.Start();
            //方法三
            //System.Threading.Timer
            // threadTimer = new System.Threading.Timer(new System.Threading.TimerCallback(obj.Method3),
            //null,0, 100);
            //while (true)
            //{
            //    Console.WriteLine("test_" + Thread.CurrentThread.ManagedThreadId.ToString());
            //    Thread.Sleep(100);
            //}
            string strLine;
            do
            {
                strLine = Console.ReadLine();
            } while (strLine != null && strLine != "exit");
            
        }
        void Method3(Object state)
        {
            Console.WriteLine(DateTime.Now.ToString()
        + "_" +Thread.CurrentThread.ManagedThreadId.ToString());
        }
        //根据配置文件自动运行exe
        private static void RunAutoExe(object source, ElapsedEventArgs e)
        {
            IniFile myIni = new IniFile(Environment.CurrentDirectory + "\\TimingService.ini");
            string filePath = myIni.ReadString("exe0", "FilePath", "");
            if (filePath != "")
            {
                for (int i = 0;i<10; i++){
                    Process.Start(filePath);
                }
                return;
            }
            else
            {
                Console.WriteLine("目录下未找到，该程序");
                return;
            }
        }
    }
}
