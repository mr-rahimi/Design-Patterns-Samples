using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.Prototype
{
    public abstract class Prototype
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public abstract Prototype Clone();
    }

    public class Product : Prototype
    {
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
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
