using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////循环遍历
            //for (int i = 1; i <= 5; i++)
            //{
            //    int s = i * i;
            //    Console.WriteLine("for方法平方数：{0}",s);  
            //}
            //Console.ReadLine();
            //int j=1,k=1;
            //while (j <= 5)
            //{
            //    int s = j * j;
            //    Console.WriteLine("while方法平方数：{0}", s);
            //    j++;
            //}
            //Console.ReadLine();
            //do
            //{
            //    int s = k * k;
            //    Console.WriteLine("do-while方法平方数：{0}", s);
            //    k++;
            //} while (k <= 5);
            //Console.ReadLine();

            //水仙花数
            int num_g, num_s, num_b;
            int count = 0;
            string results="水仙花数：";
            for (int i = 100; i < 999; i++)
            {
                num_g = i % 10;
                num_s = i / 10 % 10;
                num_b = i / 100;
                if (Math.Pow(num_g, 3) + Math.Pow(num_s, 3) + Math.Pow(num_b, 3) == i)
                {
                    results += i + ",";
                    count++;
                }
                if (count == 2)
                {
                    break;
                }
            }
            Console.WriteLine(results);
            Console.ReadKey();
            //韩信点兵
            for (int i = 1000; i < 1100; i++)
            {
                if (i % 3 == 2 && i % 5 == 4 && i % 7 == 6)
                {
                    Console.WriteLine("总人数{0}",i);
                }
            }
            Console.ReadKey();
            //输入5个大写字母
            bool flag;
            do
            {
                flag = true;
                Console.Write("请输入五位数大写字母:");
                string str = Console.ReadLine();
                if (str.Length != 5)
                {
                    Console.WriteLine("字符个数错误");
                    flag = false;
                    continue;
                }
                foreach (char ch in str)
                {
                    if (ch < 'A' || ch > 'Z')
                    {
                       Console.WriteLine("字符输入错误");
                       flag = false;
                       break;
                    }
                }
            }while(flag==false);
            if(flag==true){
                Console.WriteLine("输入正确");
            }
            Console.ReadLine();

            //输入一个整数
            bool flagInt;
            do
            {
                flagInt = true;
                Console.WriteLine("请输入一个整数");
                string a = Console.ReadLine();
                if (Convert.ToInt32(a) < 0)
                {
                    Console.WriteLine("请输入正整数!");
                    flagInt = false;
                    continue;
                }
                else
                {
                    for (int i = 0; i <= Convert.ToInt32(a); i++)
                    {
                        Console.WriteLine(i);
                        flagInt = false;
                    }
                    break;
                }

            } while (flagInt == false);
            Console.ReadLine();
        }
    }
}
