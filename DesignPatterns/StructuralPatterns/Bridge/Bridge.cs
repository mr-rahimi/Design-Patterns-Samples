using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{
    public abstract class Abstraction
    {
        public Implementor Implementor { protected get; set; }
        public abstract void Operation();
    }
    public abstract class Implementor
    {
        public abstract void Operation();
    }
    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            Implementor.Operation();
        }
    }
    public class ConcreteImplementorA : Implementor

    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }
    public class ConcreteImplementorB : Implementor

    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
    public class Using
    {
        public static void Use()
        {
            Abstraction abstraction = new RefinedAbstraction();
            abstraction.Implementor = new ConcreteImplementorA();
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
            // Wait for user

            Console.ReadKey();
        }
    }
}
