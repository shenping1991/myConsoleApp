using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace ConsoleAppDbOprate
{
    public class Program
    {
        static void Main(string[] args)
        {
            DbHelper dp = new DbHelper();
            string sql = "select * from hs_User where Col_LoginName='admin'";
            DataTable dt = dp.Query(sql).Tables[0];
            Console.WriteLine(dt.Rows[0][0].ToString());
        }
        
    }
}
