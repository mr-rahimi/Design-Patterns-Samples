using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        void Display();
    }
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual void Display()
        {
            Console.WriteLine($"id:{Id} ,name:{Name} ,description:{Description}");
        }
    }
    abstract class Decorator : IProduct
    {
        protected Product product;
        public Decorator(Product product)
        {
            this.product = product;
        }

        public int Id { get => ((IProduct)product).Id; set => ((IProduct)product).Id = value; }
        public string Name { get => ((IProduct)product).Name; set => ((IProduct)product).Name = value; }
        public string Description { get => ((IProduct)product).Description; set => ((IProduct)product).Description = value; }

        public virtual void Display()
        {
            ((IProduct)product).Display();
        }
    }
    class ToJsonDecorator : Decorator
    {
        public ToJsonDecorator(Product product) : base(product)
        {
        }
        public string ToJson()
        {
            return product.ToString();
        }
        public override void Display()
        {
            Console.WriteLine(ToJson());
        }
    }
    class ToXmlDecorator : Decorator
    {
        public ToXmlDecorator(Product product) : base(product)
        {
        }
        public string ToXml()
        {
            return this.ToString();
        }
        public override void Display()
        {
            Console.WriteLine(ToXml());
        }
    }
    public class Using
    {
        public static void Use()
        {
            Product product = new Product() { Id = 1, Name = "Mobile", Description = "Mobile Description" };

            ToJsonDecorator toJsonDecorator = new ToJsonDecorator(product);
            ToXmlDecorator toXmlDecorator = new ToXmlDecorator(product);

            product.Display();
            toJsonDecorator.Display();
            Console.WriteLine(toXmlDecorator.ToXml());
            // Wait for user

            Console.ReadKey();
        }
    }
}
