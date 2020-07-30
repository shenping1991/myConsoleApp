using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            ////订购
            //Console.WriteLine("品种及价格：1=(小杯, ￥3.0) 2=(中杯, ￥4.0) 3=(大杯, ￥5.0)");
            //Console.WriteLine("您的选择是：");
            //string numb = Console.ReadLine();

            //int numbInt = Convert.ToInt32(numb);
            
            //if (numb != "")
            //{
            //    switch (numbInt)
            //    {
            //        case 1:
            //            Console.WriteLine("小杯，价格3元");
            //            break;
            //        case 2:
            //            Console.WriteLine("中杯，价格4元");
            //            break;
            //        case 3:
            //            Console.WriteLine("大杯，价格5元");
            //            break;
            //        default:
            //            Console.WriteLine("输入有误！");
            //            break;
            //    }
            //    Console.WriteLine("谢谢使用，欢迎再次光临！");
            //}
            //Console.ReadLine();
            #endregion
            #region
            ////调用外部静态方法
            //Console.WriteLine("欢迎使用whileApp");
            //string str = Console.ReadLine();
            //bool flag = false;
            //while (flag == false)
            //{
            //    if (str == "get")
            //    {
            //        doGet();
            //        flag = true;
            //        break;
            //    }
            //    else if(str=="put")
            //    {
            //        doPut();
            //        flag = true;
            //        break;
            //    }
            //}

            ////foreach查找元素
            //string[] str2 = { "JAN", "FEB", "MAR", "sp", "ry" };
            //foreach (string s in str2)
            //{
            //    if (s == "JAN" || s == "MAR" || s == "FEB")
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        
            ////根据位置给出路线
            //route myRoute;
            //int myDirection=-1;
            //double myDistance;
            //do
            //{
            //    Console.WriteLine("Select a direction:");
            //    myDirection = Convert.ToInt32(Console.ReadLine());
            //} while (myDirection < 1 || myDirection > 4);
            
            //Console.WriteLine("Input a distance:");
            //myDistance = Convert.ToDouble(Console.ReadLine());
            //myRoute.direction = (orientation)myDirection;
            //myRoute.distance = myDistance;
            //Console.WriteLine("指定方向{0}的距离是{1}", myRoute.direction, myRoute.distance);
            #endregion
            #region
            ////倒叙
            //Console.WriteLine("输入字符串：");
            //string strIn = Console.ReadLine();
            //string strOut = "";
            //for (int i = strIn.Length-1; i >=0 ; i--)
            //{
            //    strOut = strOut + strIn.Substring(i,1);

            //}
            //Console.WriteLine("倒叙字符串：{0}", strOut);

            ////复利存储计算
            //Console.WriteLine("输入初次存入的金额、年利率、计算期、每月向帐户中额外存入的金额");
            //string strInfo=Console.ReadLine();
            //string[] arr = strInfo.Split(',');

            //double MoneyFirst = Convert.ToDouble(arr[0]);
            //double Yprofite = Convert.ToDouble(arr[1]);
            //double cycle = Convert.ToDouble(arr[2]);
            //double extra = Convert.ToDouble(arr[3]);
            //double sum = (MoneyFirst * (1 + Yprofite) * Yprofite + extra * 12) * cycle + MoneyFirst;
            //Console.WriteLine("最后拿到的总金额{0}", sum);
            
            ////阶乘
            //long sum2 = 0;
            //long x = 1;
            //for (int i = 1; i <= 13; i++)
            //{
            //    x *= i;
            //    sum2 = sum2 + x;  
            //}
            //Console.WriteLine(sum2);
            #endregion
            //冒泡排序--相邻数比较大数下沉 循环  选择排序  插入排序（希尔排序）
            int []arr={1,8,6,3};
            int temp;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-1-i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i <= arr.Length-1; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadLine();

        }
        
        //结构体
        //struct route
        //{
        //    public orientation direction;
        //    public double distance;
        //}
        ////枚举类型
        //enum orientation
        //{
        //    North=1,South,East,West
        //}
        public static void doGet()
        {
            Console.WriteLine("获取文件OK");
        }
        public static void doPut()
        {
            Console.WriteLine("传输文件OK");
        }
    }
}
