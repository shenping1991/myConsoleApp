using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ConsoleAppCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();

            Console.WriteLine("add numbs:");
            arr.Add(45);
            arr.Add(60);
            arr.Add(30);
            Console.WriteLine("Capacity:{0}", arr.Capacity);
            Console.WriteLine("Count:{0}", arr.Count);
            Console.WriteLine("Contains:{0}",arr.Contains(45));

            //Console.WriteLine("Remove:{0}", arr.RemoveAt(0));

            Console.WriteLine("arr:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("arr sort:");
            arr.Sort();
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            arr.AddRange(new int[] { 10, 90, 67 });

            arr.Add("big");
            arr.Add("small");

            if (!arr.Contains("big"))
            {
                arr.Add("big");
            }
            else
            {
                Console.WriteLine("is Contains");
            }

            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
    }
}
