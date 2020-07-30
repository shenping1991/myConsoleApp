using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ConsoleAppList2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.AddRange(new int[] { 40, 50, 80, 70, 11 });

            int[] nums = list.ToArray();
            Console.WriteLine("集合转数组输出：");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            List<int> list2 = nums.ToList();
            list2.Sort();
            Console.WriteLine("数组转换成集合输出：");
            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i]);
            }
            Console.ReadKey();



        }
    }
}
