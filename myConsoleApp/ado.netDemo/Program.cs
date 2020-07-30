using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引用对应数据的命名空间
using System.Data;
using System.Data.SqlClient;


namespace ado.netDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //数据库连接
        //    string connString = "";
        //    //创建连接对象
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = connString;
        //    //创建command对象
        //    //string sql = "insert into SysAdmins(AdminName,LoginPwd,StatusId,RoleId) values('sp0411','123','1','2')";

        //    string sql = "select AdminName from SysAdmins where AdminId={0} and LoginPwd='{1}'";
        //    Console.WriteLine("请输入用户ID：");
        //    string AdminId = Console.ReadLine();
        //    Console.WriteLine("请输入密码：");
        //    string LoginPwd = Console.ReadLine();
        //    sql = string.Format(sql, AdminId, LoginPwd);
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    conn.Open();//打开数据库
        //    object result = cmd.ExecuteScalar();
        //    if (result != null && result.ToString() == "sp")
        //        Console.WriteLine("登录成功！");
        //    else
        //        Console.WriteLine("登录失败！");
        //    conn.Close();//关闭数据库
        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("请输入图书分类编号：");
            string categoryId = Console.ReadLine();
            List<Book> list = new BookService().GetBookByCategoryId(categoryId);
            foreach (Book book in list)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", book.Author, book.BarCode, book.BookName, book.BookId);
            }

            Book objbook = new Book();
            string book2 = objbook.GetBook("2012110", "C#");//传参到类的公用方法
            Console.WriteLine(book2);

            int c = Book.Add(10, 20);
            Console.WriteLine("类静态方法：" + c);
            Book book3 = new Book(10032,"C#教程","小丽");//构造函数初始化属性，传参顺序不可变

            //对象初始化器
            //简化对象属性的初始化，属性之间用，隔开
            //参数顺序，个数不限
            Book book4 = new Book()
            {
                BarCode = "2010",
                Author = "珊珊",
                BookName = "面向对象"
            };
            Console.WriteLine("图书信息：" + book4);
           
            //泛型集合的使用
            List<int> scoreList = new List<int>();
            scoreList.Add(86);
            scoreList.Add(90);
            scoreList.Add(65);
            foreach (int score in scoreList)
            {
                Console.WriteLine(score);
            }
            Console.WriteLine("-------------");
            //插入元素
            scoreList.Insert(2, 60);
            Console.WriteLine("-------------");
            //获取元素总数
            Console.WriteLine("集合元素总数" + scoreList.Count);
            Console.WriteLine("-------------");
            //遍历集合
            foreach (int score in scoreList)
            {
                Console.WriteLine(score);

            }
            Console.WriteLine("-------------");
            for (int i = 0; i < scoreList.Count; i++)
            {
                Console.WriteLine(scoreList[i]);
            }
            Console.WriteLine("-------------");
            //删除一个元素
            scoreList.RemoveAt(2);
            
            for (int i = 0; i < scoreList.Count; i++)
            {
                Console.WriteLine(scoreList[i]);
            }
            Console.WriteLine("-------------");
            //删除所有元素
            scoreList.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("集合元素个数：" + scoreList.Count);
            Console.ReadLine();
        }
    }
}
