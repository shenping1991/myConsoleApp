using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleAppJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=Path.GetFullPath("JsonData.json");
            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            FileStream fs = File.OpenRead(path);
            //byte[] content = new byte[fs.Length];
            //fs.Close();
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            string data = sr.ReadToEnd();
            if (data != "")
            {
                //JArray jsonobj = JsonSerialize(data);
                JArray jsonobj = (JArray)JsonConvert.DeserializeObject("[" + data + "]");
                if (jsonobj == null || jsonobj.Count == 0)
                {
                    Console.WriteLine("Json格式错误");
                }
                else
                {
                    Console.WriteLine(jsonobj[0]["Service"]["Route"]["SerialNO"].ToString());
                }
            }
        }
        public static JArray JsonSerialize(string obj)
        {
            JArray obiectjson = new JArray();
            try
            {
                obiectjson = (obj == "") ? null : (JArray)JsonConvert.DeserializeObject("[" + obj + "]");
            }
            catch (Exception ex)
            {

            }
            return obiectjson;
        }
    }
}
