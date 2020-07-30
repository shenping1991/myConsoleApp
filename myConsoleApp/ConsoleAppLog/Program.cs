using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleAppLog
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入密码：");

            string str = Console.ReadLine();
            if (str == "123")
            {
                AddLog("密码正确");
            }
            else
            {
                AddLog("密码错误");
            }
        }
        /// <summary>    
        /// 日志记录，写入txt文件    
        /// </summary>    
        /// <param name="msg">记录内容</param>    
        /// <returns></returns>    
        public static void AddLog(string msg)
        {
            StreamWriter stream;
            try
            {
                //写入日志内容
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string filename = System.DateTime.Now.ToString("yyyy-MM-dd");
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileAbstractPath = path + "\\log" + filename + ".txt";
                //方法1
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                stream = new StreamWriter(fs, Encoding.Default);
                //方法2
                //stream = new StreamWriter(fileAbstractPath, true, Encoding.Default);
                //开始写入       
                stream.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":" + msg);
                //System.Environment.NewLine
                stream.Write("\r\n");
                //清空缓冲区                 
                stream.Flush();
                //关闭流                 
                stream.Close();
                stream.Dispose();
                fs.Close();
                fs.Dispose();
                Console.WriteLine("请查看日志信息：" + fileAbstractPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>    
        /// 将日志记录换行    
        /// </summary>    
        /// <param name="saveFolder">文件保存的目录</param>    
        /// <param name="rows">换几行</param>    
        public static void AddLine(int rows)
        {
            string saveFolder = "Log";
            try
            {
                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveFolder);
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileAbstractPath = filePath + "\\" + fileName + ".txt";
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入      
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < rows; i++)
                {
                    sb.Append(System.Environment.NewLine);
                }
                string newline = sb.ToString();
                sw.Write(newline);
                //清空缓冲区                 
                sw.Flush();
                //关闭流                 
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string tishiMsg = "[" + datetime + "]写入日志出错：" + ex.Message;
                Console.WriteLine(tishiMsg);
            }
        }

        public static void Delete(int day)
        {
            if (day > 0)
            {
                DateTime keepDay = DateTime.Now.AddDays(-day);
                //if (string.IsNullOrEmpty(saveFolder))
                //{
                //    DBHelper db = new DBHelper();
                //    DataTable dt = db.RunTxtDataTable("select * from TN_SyncStrategy");
                //    saveFolder = dt.Rows[0]["Col_LogFilePath"].ToString();
                //}
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\");
                if (Directory.Exists(filePath))
                {
                    DirectoryInfo d = new DirectoryInfo(filePath);
                    FileInfo[] fileInfo = d.GetFiles();
                    foreach (FileInfo NextFile in fileInfo)  //遍历文件               
                    {
                        DateTime createtime = NextFile.CreationTime;
                        if (DateTime.Compare(createtime, keepDay) < 0)
                        {
                            AddLog("删除日志文件" + NextFile.Name);
                            NextFile.Delete();
                        }
                    }
                }
            }
        }
    }
}
