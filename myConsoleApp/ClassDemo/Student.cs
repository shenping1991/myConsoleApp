using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassDemo
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public Student()//构造函数  对象初始化
        {
        }
        private int _studentid=1002;//字段，成员变量
        private string _studentname="小明";
        //private int _age=20;
        private string _sex="男";
        public int StudentId //属性 访问私有字段
        {
            set { _studentid = value; }
            get { return _studentid; } 
        }
        
        public string studentName 
        {
            set { _studentname = value; }
            get { return _studentname; } 
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
           
        }
        public int Age//只读属性，单独存在，不是直接返回私有属性的值，而是调用方法或业务逻辑
        {
            get
            {
                return DateTime.Now.Year - _birthday.Year;
            }
        }

        //public int Age 
        //{
        //    set { 

        //    if (_age < 20) _age = 20;
        //    else _age = value;

        //    }
        //    get { return _age; } 
        //}
        
        public string Sex 
        {
            set { _sex = value; }
            get { return _sex; } 
        }

        public void display()
        {
            Console.WriteLine("您的名字是:{0},性别:{1},年龄:{2},编号：{3}", studentName, Sex, Age, StudentId);
        }
        
    }
}
