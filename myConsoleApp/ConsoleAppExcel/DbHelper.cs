using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using JC.Common;
using System.Configuration;
//namespace Pro.Help
//{
    public class DbHelper
    {
        private static string connstr = "";
        private SqlConnection conn;
        public SqlCommand cmd = new SqlCommand();
        public DbHelper()
        {
            connstr = "server=.;database=antdb2190301;user id=sa;pwd=eP3wOk+r4zA=";
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

        public int RunTxt(string sql)
        {
            return (int)Run(CommandType.Text, sql, 0, null, true);
        }

        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <param name="cmdType">类型</param>
        /// <param name="cmdTxt">sql语句</param>
        /// <param name="flag">0 ExecuteNonQuery 1ExecuteScalar 2 DataTable</param>
        /// <returns></returns>
        private object Run(CommandType cmdType, string cmdTxt, int flag, SqlParameter[] prams, bool IsOpen)
        {
            this.cmd.CommandType = cmdType;
            this.cmd.CommandText = cmdTxt;
            if (prams != null)
            {
                cmd.Parameters.Clear();
                for (int i = 0; i < prams.Length; i++)
                    cmd.Parameters.Add(prams[i]);
            }

            object o;
            if (IsOpen)
            {
                this.Open();
            }
            this.cmd.Connection = this.conn;
            if (flag == 0)
                o = cmd.ExecuteNonQuery();

            else if (flag == 1)
                o = cmd.ExecuteScalar();
            else if (flag == -1)
            {
                cmd.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int));
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                o = Int32.Parse(cmd.Parameters["@Result"].Value.ToString());
            }
            else
            {

                System.Data.DataSet ds = new System.Data.DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = this.cmd;
                da.SelectCommand.CommandTimeout = 1000;
                da.Fill(ds);
                o = ds.Tables[0];
            }
            if (IsOpen)
            {
                this.Close();
            }
            return o;
        }
        public void Open()
        {
            conn = new SqlConnection(connstr);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

    }

//}
