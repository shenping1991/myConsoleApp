using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.XSSF;
using System.Data;
using System.IO;
using System.Web;

namespace ConsoleAppExcel
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("导出用户数据到excel：");
            //create excel
            //OutputExcel();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("输入导入excel文件：");
            string importFilePath =AppDomain.CurrentDomain.BaseDirectory+"\\"+ Console.ReadLine();
            string importResult=ImportExcel(importFilePath);
            Console.WriteLine(importResult);
        }
        /// <summary>
        /// 导出excel文件
        /// </summary>
        private static void OutputExcel()
        {
            DbHelper dp = new DbHelper();
            string strsql="select * from hs_user where Col_LoginName='sp'";
            DataTable dt= dp.Query(strsql).Tables[0];
            HSSFWorkbook wb = new HSSFWorkbook();
            ISheet sheet1 = wb.CreateSheet("用户");
            IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("编号");
            row1.CreateCell(1).SetCellValue("账号");
            row1.CreateCell(2).SetCellValue("姓名");
            if (dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count;i++){
                    IRow rowtemp = sheet1.CreateRow(i + 1);
                    rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["Col_ID"].ToString());
                    rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["Col_LoginName"].ToString());
                    rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["Col_Name"].ToString());
                }
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            wb.Write(ms);
            //wb.Write(ms);
            //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            //System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            //wb = null;
            //ms.Close();
            //ms.Dispose();
            string filename=System.DateTime.Now.ToString("yyyyMMddHHssmm").ToString();
            string filepath=AppDomain.CurrentDomain.BaseDirectory;
            FileStream fs = new FileStream(filepath + "\\" + filename+".xls", FileMode.Create);
            byte[] buffer = new byte[10000];
            int sourceBytes;
            int j = 1;
            do
            {
                sourceBytes = ms.Read(buffer, 0, buffer.Length);
                j += 1;
                if (sourceBytes != 0)
                {
                    ms.Write(buffer, 0, sourceBytes);
                }
            }
            while (sourceBytes > 0);
            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, (int)ms.Length);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            ms.Close();
            wb = null;
            Console.WriteLine("请查看excel文件：" + filepath + filename + ".xls");
        }
        /// <summary>
        /// 导入excel文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static string ImportExcel(string filePath)
        {
            string result = "";
            NPOI.SS.UserModel.ISheet sheet = null;
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
                    sheet = hssfworkbook.GetSheetAt(0);
                }
            }
            catch (Exception)
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    NPOI.XSSF.UserModel.XSSFWorkbook hssfworkbook2 = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
                    sheet = hssfworkbook2.GetSheetAt(0);
                }
            }
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();

            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }
            while (rows.MoveNext())
            {
                NPOI.SS.UserModel.IRow row = (NPOI.SS.UserModel.IRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                if (row.LastCellNum != -1)
                {
                    if ((dr[0] == null | dr[0].ToString() == "") && (dr[1] == null | dr[1].ToString() == "") && (dr[2] == null | dr[2].ToString() == ""))
                    {

                    }
                    else
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            dt = Distinct(dt, new string[] { "A", "B", "C"});

            DataView myDataView = new DataView(dt);
            string[] strComuns = { "C" };
            if (myDataView.ToTable(true, strComuns).Rows.Count < dt.Rows.Count)
            {
                result = "用户表存在相同的账号数据";
                return result;
            }
            DbHelper dp = new DbHelper();
            foreach(DataRow dr in dt.Rows)
            {
                string strsql = "insert into hs_user1 values ('" + dr["B"] + "','" + dr["C"] + "')";
                dp.RunTxt(strsql);
            }
            result = "导入成功";
            return result;
        }
        /// <summary>
        /// 数据去重复
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filedNames"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable dt, string[] filedNames)
        {
            DataView dv = dt.DefaultView;
            DataTable DistTable = dv.ToTable("Dist", true, filedNames);
            return DistTable;
        }
    }
}
