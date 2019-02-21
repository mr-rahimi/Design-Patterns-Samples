using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    public class OldProduct
    {
        public void Request()
        {
            Console.WriteLine("old requesting");
        }
    }
    public class Product
    {
        public virtual void Request()
        {
            Console.WriteLine("new requesting");
        }
    }
    class OldProductAdapter:Product
    {
        OldProduct oldProduct = new OldProduct();
        public override void Request()
        {
            oldProduct.Request();
        } 
    }
    public class Using
    {
        public static void Use()
        {
            Product product = new OldProductAdapter();
            product.Request(); 
            // Wait for user

            Console.ReadKey();
        }
    }
}
