using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.IO;

namespace ConsoleAppXml
{
    public class Program
    {
        static void Main(string[] args)
        {
            TreeXml treexml = new TreeXml();
            //string filetext = File.ReadAllText(Path.GetFullPath(treexml.treePath));
            string filepath = AppDomain.CurrentDomain.BaseDirectory + treexml.treePath;
            string filetext = File.ReadAllText(filepath);
            treexml.LoadXml(filetext);
            DataTable dtModule = treexml.GetModule();
            for (int i = 0; i < dtModule.Rows.Count; i++)
            {
                DataTable dtSubModule = treexml.GetSubModule(dtModule.Rows[i]["id"].ToString());
                Console.WriteLine(dtModule.Rows[i]["id"].ToString());
                Console.WriteLine(dtSubModule.Rows[0]["SubModuleName"].ToString());
            }
            
        }
    }
}
