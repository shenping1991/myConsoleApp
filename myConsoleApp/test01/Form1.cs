using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test01
{
    public partial class FrmMain : Form
    {
        private List<Books>bookList=new List<Books>();
        public FrmMain()
        {
            InitializeComponent();
            this.GVBook.AutoGenerateColumns = false;
        }
        public void showBooks()
        {
            //对象初始化器
            Books objBook1 = new Books()
            {
                BarCode = "1001",
                //BookId=2,
                BookName = "C#",
                Author = "张丽",
                PublishDate = Convert.ToDateTime("2016-12-1"),
                PublisherId=2
            };
            bookList.Add(objBook1);//添加到集合中
            //展示数据，添加数据源
            this.GVBook.DataSource =this.bookList;
           
        }
        //显示图书列表
        private void btn_showList_Click(object sender, EventArgs e)
        {
            showBooks();

        }
        //添加集合元素
        private void btn_addItem_Click(object sender, EventArgs e)
        {
            Books objBookNew = new Books()
            {
                BarCode = "2001",
                //BookId=2,
                BookName = "C#实战",
                Author = "王明",
                PublishDate = Convert.ToDateTime("2016-10-1"),
                PublisherId = 4
            };
            bookList.Add(objBookNew);
            this.GVBook.DataSource = null;
            this.GVBook.DataSource = this.bookList;
        }
        //插入元素
        private void btn_insertItem_Click(object sender, EventArgs e)
        {
            Books objBookIn = new Books()
            {
                BarCode = "12211",
                BookName = "C#原理",
                Author = "刘洋",
                PublishDate = Convert.ToDateTime("2017-1-1"),
                PublisherId = 5
            };
            bookList.Insert(1,objBookIn);
            this.GVBook.DataSource = null;
            this.GVBook.DataSource = this.bookList;
        }
        //删除元素
        private void btn_delItem_Click(object sender, EventArgs e)
        {
            //找到要删除的编号
            string barCode = this.GVBook.CurrentRow.Cells["BarCode"].Value.ToString();
            Books delBook = null;
            //for (int i = 0; i < this.bookList.Count; i++)
            //{
            //    if (bookList[i].BarCode.ToString() == barCode)
            //    {
            //        delBook = bookList[i];
            //        break;
            //    }
                
            //}
            //使用Linq查询
            delBook = (from b in bookList where b.BarCode.ToString().Equals(barCode) select b).First<Books>();

            bookList.Remove(delBook);
            this.GVBook.DataSource = null;
            this.GVBook.DataSource = this.bookList;
        }

    }
}
