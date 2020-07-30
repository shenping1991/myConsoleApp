using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppClass
{
    public class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public void setWidth(int w)
        {
            Width = w;
        }
        public void setHeight(int h)
        {
            Height = h;
        }
        // 虚方法
        public virtual void Draw()//当有一个定义在类中的函数需要在继承类中实现时，可以使用虚方法
        {
            Console.WriteLine("执行基类的画图任务");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画一个圆形");
            base.Draw();
        }
    }
    public interface PaintCost
    {
        int getCost(int area);
    }
    class Rectangle : Shape, PaintCost
    {
        public int getArea()
        {
            return (Width * Height);
        }
        public int getCost(int area)
        {
            return area * 70;
        }
        public override void Draw()
        {
            Console.WriteLine("画一个长方形");
            base.Draw();
        }
    }
    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("画一个三角形");
            base.Draw();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // 使用 foreach 循环对该列表的派生类进行循环访问，并对其中的每个 Shape 对象调用 Draw 方法 
            foreach (var shape in shapes)
            {
                shape.Draw();
            }

            Rectangle rect = new Rectangle();
            int area;
            rect.setWidth(3);
            rect.setHeight(4);
            area = rect.getArea();
            Console.WriteLine("Cost:{0}", rect.getCost(area));

            Console.WriteLine("按下任意键退出。");
            Console.ReadKey();
        }
    }
}
