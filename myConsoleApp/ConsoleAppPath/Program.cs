using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleAppPath
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取当前运行程序的目录(该进程从中启动的目录)
            string fileDir = Environment.CurrentDirectory;
            Console.WriteLine("当前程序目录：" + fileDir);
            //一个文件目录
            string filePath = "E:\\webTestProj\\ConsoleApplication\\myConsoleApplication\\ConsoleAppPath\\test.html";
            Console.WriteLine("该文件的目录：" + filePath);
            string str = "获取文件的全路径：" + Path.GetFullPath(filePath);
            Console.WriteLine(str);
            str = "获取文件所在目录：" + Path.GetDirectoryName(filePath);
            Console.WriteLine(str);
            str = "获取文件含有后缀名：" + Path.GetFileName(filePath);
            Console.WriteLine(str);
            str = "获取文件不包含后缀名：" + Path.GetFileNameWithoutExtension(filePath);
            Console.WriteLine(str);
            str = "获取路径后缀扩展名称：" + Path.GetExtension(filePath);
            Console.WriteLine(str);
            str = "获取路径的根目录：" + Path.GetPathRoot(filePath);
            Console.WriteLine(str);
            Console.WriteLine("--------------------------------------------------");
            string strPath = "获取程序的基目录："+System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(strPath);
            strPath = "获取模块的完整路径：" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine(strPath);
            strPath = "获取应用程序的当前工作目录：" + System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(strPath);
            strPath = "获取和设置包括该应用程序的目录的名称：" + System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine(strPath);
            //strPath = "获取启动了应用程序的可执行文件的路径：" + System.Windows.Forms.Application.StartupPath;
            //Console.WriteLine(strPath);
            //strPath = "获取启动了应用程序的可执行文件的路径及文件名：" + System.Windows.Forms.Application.ExecutablePath;
            //Console.WriteLine(strPath);


        }
    }
}
