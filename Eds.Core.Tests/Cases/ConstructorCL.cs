using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Core.Tests.Cases
{
    public class ConstructorCL
    {
        public class BaseClass
        {
            private string name;
            private int age;
            private string addr;
            public BaseClass()
            {
                Console.WriteLine("No Info");
            }
            public BaseClass(string name)
            {
                this.name = name;
                Console.WriteLine("name=" + this.name);
            }
            public BaseClass(string name, int age)
            {
                this.name = name;
                this.age = age;
                Console.WriteLine(string.Format("name={0},age={1}", this.name, this.age));
            }

            public BaseClass(string name, int age, string addr)
            {
                this.name = name;
                this.age = age;
                this.addr = addr;
                Console.WriteLine(string.Format("name={0},age={1},addr={2}", this.name, this.age, this.addr));
            }
        }

        public class ItemClass : BaseClass
        {
            private string name;
            private int age;

            public ItemClass()
                : this("demo")
            {
                //Console.WriteLine("No Info");
            }
            public ItemClass(string name)
                : this("jimmy", 20)
            {
                this.name = name;
                Console.WriteLine("name=" + this.name);
            }
            public ItemClass(string name, int age)
            {
                this.name = name;
                this.age = age;
                Console.WriteLine(string.Format("name={0},age={1}", this.name, this.age));
            }
            public ItemClass(string name, int age, string addr)
                : base("jeason", 20, "shanghai")
            {
                Console.WriteLine("name=" + name);
            }

            //public static void Main()
            //{
            //    ItemClass ic1 = new ItemClass("mike");
            //    ItemClass ic2 = new ItemClass();
            //    ItemClass ic3 = new ItemClass("mike",21,"chengdu");
            //}
        }
    }
}
