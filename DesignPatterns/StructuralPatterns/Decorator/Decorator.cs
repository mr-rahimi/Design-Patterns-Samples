using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    public abstract class Component
    {
        public abstract void Operation();
    }
    public class ConcreteComponent:Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }
    abstract class Decorator : Component

    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }
    class ConcreteDecoratorA : Decorator

    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
    class ConcreteDecoratorB : Decorator

    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        public void AddedBehavior()
        {
        }
    }
    public class Using
    {
        public static void Use()
        {
            ConcreteComponent component = new ConcreteComponent();
            ConcreteDecoratorA componentDecoratorA = new ConcreteDecoratorA();
            ConcreteDecoratorB componentDecoratorB = new ConcreteDecoratorB();

            componentDecoratorA.SetComponent(component);
            componentDecoratorB.SetComponent(component);

            componentDecoratorA.Operation();
            componentDecoratorB.AddedBehavior();
            // Wait for user

            Console.ReadKey();
        }
    }
}
