using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using JC.Common;

//namespace Pro.Help
//{
    public class DbHelper
    {
        private static string connstr = "";
        public DbHelper()
        {
            connstr = System.Configuration.ConfigurationManager.AppSettings["Connstring"].ToString();
            string[] connstrArr = connstr.Split(';');
            connstr="";
            foreach (string str in connstrArr)
            {
                string name = str.Substring(0, str.IndexOf("="));
                string value = str.Substring(str.IndexOf("=") + 1, str.Length - name.Length - 1);
                if (name == "pwd")
                {
                    value = JC.Common.Encryptor.Decrypt(value);
                }
                connstr += name + "=" + value + ";";
            }
            connstr.TrimEnd(';');
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString,connection))
                {
                    try 
	                {	        
		                connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if(Object.Equals(obj,null)||(Object.Equals(obj,System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }

	                }
	                catch (System.Data.SqlClient.SqlException e)
	                {
		                connection.Close();
		                throw e;
	                }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public  DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }

//}
