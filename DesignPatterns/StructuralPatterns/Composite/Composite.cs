using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Composite
{
    public abstract class Component
    {
        protected string name;

        // Constructor

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    public class Composite:Component
    {
        private List<Component> _children = new List<Component>();
        public Composite(string name):base(name)
        {
        }

        public override void Add(Component c)
        {
            _children.Add(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes

            foreach (Component component in _children)
            {
                component.Display(depth + 2);
            }
        }

        public override void Remove(Component c)
        {
            _children.Remove(c);
        }
    }
    public class Leaf : Component
    {
        public Leaf(string name)
      : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
    public class Using
    {
        public static void Use()
        {
            Component root = new Composite("root");

            Component child = new Composite("child");
            root.Add(child);

            Component leaf = new Leaf("leaf");
            root.Add(leaf);

            root.Display(1);
            // Wait for user

            Console.ReadKey();
        }
    }
}
