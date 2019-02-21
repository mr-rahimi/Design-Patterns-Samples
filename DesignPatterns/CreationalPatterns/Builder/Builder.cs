using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.Builder
{
    public class Product
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
    }
    public interface IProductBuilder
    {
        void SetName();
        void SetColor();
        void SetWeight();
        Product GetProduct();
    }
    public class ProductBuilder1 : IProductBuilder
    {
        private Product _product = new Product();

        public Product GetProduct()
        {
            return _product;
        }

        public void SetColor()
        {
            _product.Color = "Red";
        }

        public void SetName()
        {
            _product.Name = "Pride";
        }

        public void SetWeight()
        {
            _product.Weight = "700";
        }
    }
    public class BuildDirector
    {
        public static void BuildProduct(IProductBuilder builder)
        {
            builder.SetColor();
            builder.SetName();
            builder.SetWeight();
        }
    }
    public class Using
    {
        public static void Use()
        {
            IProductBuilder builder = new ProductBuilder1();
            BuildDirector.BuildProduct(builder);
            Product product1 = builder.GetProduct();

            // Wait for user

            Console.ReadKey();
        }
    }
}
