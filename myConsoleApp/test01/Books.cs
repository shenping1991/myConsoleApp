using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test01
{
    /// <summary>
    /// Book对象
    /// </summary>
    public class Books
    {
        public Books()//构造函数  对象初始化 方法名称和类名一致，无返回值
        {
        }
        public Books(int bookId, string bookName)
        {
            this.BookId = bookId;
            this.BookName = bookName;
        }
        public Books(int bookId, string bookName, string author)
            : this(bookId, bookName)//构造函数重载
        {
            this.Author = author;
        }
        #region Model
        private int _bookId;
        private string _barcode;
        private string _bookname;
        private string _author;
        private int _publisherId;
        private DateTime _publishDate;


        /// <summary>
        /// 图书编号
        /// </summary>
        public int BookId
        {
            set { _bookId = value; }
            get { return _bookId; }
        }
        /// <summary>
        /// 图书条码
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 图书名称
        /// </summary>
        public string BookName
        {
            set { _bookname = value; }
            get { return _bookname; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 出版社编号
        /// </summary>
        public int PublisherId
        {
            set { _publisherId = value; }
            get { return _publisherId; }
        }

        public DateTime PublishDate
        {
            set { _publishDate = value; }
            get { return _publishDate; }
        }
        /// <summary>
        /// 根据条件查询图书信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public string GetBook(string barCode, string bookName)
        {
            return string.Format("图书条码：{0}  图书名称：{1}", barCode, bookName);
        }
        public void ShowBook()
        {
            string info = string.Format("图书条码：{0}  图书名称：{1}", BarCode, BookName);
            Console.WriteLine(info);
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
        #endregion
    }
}
