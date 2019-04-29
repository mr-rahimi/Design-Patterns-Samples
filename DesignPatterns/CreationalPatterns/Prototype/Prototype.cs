using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.Prototype
{
    public interface IPrototype 
    {
         object Clone();
    }

    public class Product : IPrototype
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Using
    {
        public static void Use()
        {
            Product product1 = new Product()
            {
                Color = "Red",
                Name = "Product1"
            };
            Product product2 = (Product)product1.Clone();
            // Wait for user

            Console.ReadKey();
        }
    }
}
