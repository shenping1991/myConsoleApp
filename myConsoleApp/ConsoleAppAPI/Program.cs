using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ConsoleAppAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("json 实例");

            //string 转化数组
            Console.WriteLine("字符串转json数组：");
            string json2 = @"['sp','kate','apple']";
            JArray arr2 = JArray.Parse(json2);
            Console.WriteLine(arr2.Type);
            Console.WriteLine(arr2[0]);
            Console.WriteLine("-----------------------");

            Console.WriteLine("字符串对象数组转json数组：");
            string json3 = @"[{name:'sp',age:'20'},{name:'kate',age:'22'}]";
            JArray arr3 = JArray.Parse(json3);
            Console.WriteLine(arr3.Type);
            Console.WriteLine(arr3[1]["name"]);
            Console.WriteLine("-----------------------");

            Console.WriteLine("字符串转json对象：");
            string jsonstr = @"{
            code:'200',
            data:{name:'sp',pwd:'123'}}";
            JObject userInfo = JObject.Parse(jsonstr);
            Console.WriteLine(userInfo["data"]["name"]);
            Console.WriteLine("-----------------------");

            Console.WriteLine("字符串转json对象数组：");
            JArray jsonobj = new JArray();
            jsonobj = (JArray)JsonConvert.DeserializeObject("["+jsonstr+"]");
            Console.WriteLine(jsonobj[0]["code"]);
            Console.WriteLine(jsonobj[0]["data"]["pwd"]);
            Console.WriteLine("-----------------------");

            Console.WriteLine("读取json文件中json对象：");
            //转化Json 文件
            using (StreamReader sr = File.OpenText(@"C:\Users\Administrator\Desktop\testdemo\txt.json"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(sr));
                Console.WriteLine(o["PERNR"]);
            }

            Console.WriteLine("json数组转换json字符串：");
            //json对象转换json字符串
            JArray arr = new JArray();
            arr.Add(new JValue("sp"));
            arr.Add(new JValue("kate"));
            string jsonstr1 = arr.ToString();
            Console.WriteLine(jsonstr1);

            Console.WriteLine("json对象转换json字符串：");
            JObject obj = new JObject();
            obj.Add("name", new JValue("sp"));
            obj.Add("age", new JValue("20"));
            Console.WriteLine(obj.ToString());

            Console.WriteLine("创建对象方式2,使用匿名对象：");
            JObject obj2 = JObject.FromObject(new { name = "sp", birthday = System.DateTime.Now });
            Console.WriteLine(obj2.ToString());



        }
    }
}
