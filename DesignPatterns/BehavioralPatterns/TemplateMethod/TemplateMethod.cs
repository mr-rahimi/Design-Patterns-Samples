using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethod
{
    abstract class Context
    {
        protected abstract void Task1();
        protected abstract void Task2();
        public void TemplateMethod()
        {
            Task1();
            Console.WriteLine("some action");
            Task2();
        }
    }
    class Method1 : Context
    {
        protected override void Task1()
        {
            Console.WriteLine("Task1 Method1");
        }
        protected override void Task2()
        {
            Console.WriteLine("Task2 Method1");
        }
    }
    class Method2 : Context
    {
        protected override void Task1()
        {
            Console.WriteLine("Task1 Method2");
        }
        protected override void Task2()
        {
            Console.WriteLine("Task2 Method2");
        }
    }
    public class Using
    {
        public static void Use()
        {
            Context context1 = new Method1();
            Context context2 = new Method2();

            context1.TemplateMethod();
            context2.TemplateMethod();
            // Wait for user

            Console.ReadKey();
        }
    }
}
