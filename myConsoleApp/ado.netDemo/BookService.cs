using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ado.netDemo
{
    /// <summary>
    /// 图书数据访问类
    /// </summary>
   
    
    class BookService
    {
        /// <summary>
        /// 通过图书分类编号查找图书
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Book> GetBookByCategoryId(string categoryId)
        {
            string sql = "select BookId,BookName,BarCode,Author from Books where BookCategory='{0}'";
            sql = string.Format(sql, categoryId);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Book> bookList = new List<Book>();//实体对象  以对象的方式通过list返回客户端
            while (objReader.Read())
            {
                bookList.Add(new Book()
                {
                    BookId = Convert.ToInt32(objReader["BookId"]),
                    BookName = objReader["BookName"].ToString(),
                    BarCode = objReader["BarCode"].ToString(),
                    Author = objReader["Author"].ToString()
                });

            }
            objReader.Close();//关闭读取器
            return bookList;
        }

    }
}
