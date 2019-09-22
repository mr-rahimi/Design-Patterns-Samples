using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethod
{
    //step1: create base type(interface or class or abstact class)
    public interface IProduct
    {
    }
    //step2: create concrete types of base types(class)
    public class ProductA:IProduct
    {
    }
    public class ProductB : IProduct
    {
    }
    //step3: create base creator type(interface or class or abstact class)
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }
    //step2: create concrete types of creator type(class)
    public class ProductACreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }
    public class ProductBCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
    public class DoUsing
    {
        public static void Use()
        {
            Creator[] creators = new Creator[2];

            creators[0] = new ProductACreator();
            creators[1] = new ProductBCreator();

            // Iterate over creators and create products

            foreach (Creator creator in creators)
            {
                IProduct product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user

            Console.ReadKey();
        }
    }
}
