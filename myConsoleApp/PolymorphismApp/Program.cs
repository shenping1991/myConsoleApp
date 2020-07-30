using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PolymorphismApp
{
    //多态练习
    public interface IAnimal
    {
        //string AnimalName;
        void behavior();

    }
    public class Dog:IAnimal
    {
        string DogAge;
        public void behavior()
        {
            Console.WriteLine("行为：{0}", "好动，热情");
        }
    }
    public class Cat : IAnimal
    {
        string CateSex;
        public void behavior()
        {
            Console.WriteLine("行为：{0}", "喜静，高冷");
        }

    }
    
    class Program
    {
        public static void Behavior(IAnimal myIAnimal)
        {
            myIAnimal.behavior();
        }
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            dog.behavior();//一个类调用类的方法
            cat.behavior();
            Behavior(dog);//多态性调用
        }
    }
    
}
