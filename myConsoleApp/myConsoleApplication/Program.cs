using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Collections;

namespace myConsoleApplication
{
    class Rectangle
    {
        double length;
        double width;
        public void Acceptdetails()
        {
            length = 3;
            width = 4.2;
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length:{0}", length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area:{0}", GetArea());
        }
    }
    //结构
    struct book
    {
        private string bname;
        private string author;
        private string subject;
        private int book_id;

        public void getValues(string n, string a, string sj, int id)
        {
            bname = n;
            author = a;
            subject = sj;
            book_id = id;
        }
        public void display()
        {
            Console.WriteLine("书名:{0},作者:{1},科目:{2},编号:{3}", bname,author,subject,book_id);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
            //class Rectangle
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.WriteLine("Size of int:{0}", sizeof(int));

            //变量定义及初始化
            Single a;
            Double b;
            a = 10;
            b = 5;
            Console.WriteLine("a={0},b={1}",a,b);

            int c = 1;
            int f = 1;
            int d,e;
            d = ++c;
            e = f++;
            Console.WriteLine("c={0},d={1}",c,d);
            Console.WriteLine("c={0},e={1}", f, e);
            
            //三元运算符 b = (a == 1) ? 20 : 30;

            book book1 = new book();
            book book2=new book();
            book1.getValues("C#","xiaoming","code",1111);
            book2.getValues("C++", "zhangsan", "code2", 2222);
            book1.display();
            book2.display();
            //FileStream文件流，创建并打开文件，写入数据
            FileStream fs = new FileStream("E:\\webTestProj\\test\\test.txt", FileMode.Append, FileAccess.Write,
                FileShare.Write);
            fs.Close();
            StreamWriter sw = new StreamWriter("E:\\webTestProj\\test\\test.txt", true, Encoding.ASCII);
            string NextLine = "This is the appended line";
            sw.Write(NextLine);
            sw.Close();
                        
            
            //温度转换华氏温度转摄氏温度  centigrade=(5*(Fahrenheit-32))/9

            Console.Write("请输入华氏温度\n");
            float centigrade, fahrenheit;
            string strdeg;
            strdeg = Console.ReadLine();
            fahrenheit = float.Parse(strdeg);
            centigrade=(5*(fahrenheit-32))/9;
            Console.Write("华氏温度{0}=摄氏温度{1}", fahrenheit, centigrade);
            Console.Write("\n");
            //输入数字

            Console.Write("请输入一组数据,用逗号隔开\n");
            string str = Console.ReadLine();
            string[] strArray = str.Split(',');
            foreach(string s in strArray){
                int i = int.Parse(s.Trim());
                if (i % 2 == 0) { continue; }
                Console.WriteLine("该组数中的奇数" + i.ToString());
            }
            
            Console.Write("请输入一组数据,用逗号隔开");
            string str1 = Console.ReadLine();
            string[] strArray1 = str1.Split(',');
            ArrayList al=new ArrayList(strArray1);
            Console.Write("输入需要删除的数据");
            string value = Console.ReadLine();
            for (int i = 0; i < al.Count; i++)
            {
                if ((al[i].ToString()) == value)
                    {
                    al.RemoveAt(i);
                    i --;
                }
                   else
                {
                       Console.Write(al[i]+"\t");  
                  }
            }
            
            Double d2 = 36;
            Console.WriteLine(d2);

            Console.WriteLine("请输入姓名");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入语文成绩");
            string userEnglish=Console.ReadLine();
            Console.WriteLine("请输入数学成绩");
            string userMath = Console.ReadLine();

            double total = Convert.ToDouble(userEnglish) + Convert.ToDouble(userMath);
            Console.WriteLine("您的姓名{0},您的总成绩{1}", userName, total);
            Console.WriteLine("请输入年份：");
            int year = Convert.ToInt32(Console.ReadLine());
            bool strres = ((year % 400 == 0 )|| (year % 4 == 0 && year % 100 != 0));
            if (strres == true)
            {
                Console.WriteLine("是闰年");
            }
            else
            {
                Console.WriteLine("不是闰年");
            }
            
            try { 
            Console.WriteLine("请输入年份");   
            int year1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入月份");
            int month1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入日期");
            int day = 0;
            switch (month1)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        day = 31;
                        break;
                    }
                case 2:
                    if ((year1 % 400 == 0) || (year1 % 4 == 0 && year % 100 != 0))
                    {
                        day = 29;
                    }
                    else
                    {
                        day = 28;
                    }
                    break;
                default: day = 30;
                    break;
            }
            Console.WriteLine("{0}年{1}月有{2}天",year1,month1,day);
            }
            catch
            {
                Console.WriteLine("输入有误，程序退出");
            }
            
            //水仙花数
            for (int i = 0; i < 1000; i++)
            {
                int numa = i /100;//百位
                int numb = i % 100/10;//十位
                int numc = i % 10;//个位

                if (numa * numa * numa + numb * numb * numb + numc * numc * numc == i)
                {
                    Console.Write("{0}", i + "\t");
                }
                
            }
            Console.Write("\n");
            //九九乘法表
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    double s = i * j;
                    Console.Write("{0}*{1}={2}\t", i,j,s);
                    if (j == i)
                    {
                        Console.Write("\n");
                    }
                }
            }

            Console.ReadLine();
        }
    }

}
