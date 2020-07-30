using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Student stu = new Student();
            stu.StudentId = 1001;
            stu.studentName = "小明";
            //stu.Age = 18;
            stu.Birthday =Convert.ToDateTime("1991-10-10");
            stu.Sex = "男";
            //Console.WriteLine("您的名字是:{0}，性别:{1}，年龄:{2}",stu.studentName,stu.Sex,stu.Age);
            stu.display();


            Console.ReadLine();



        }


    }
}
