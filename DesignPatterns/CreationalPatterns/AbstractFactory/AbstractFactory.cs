using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    //step1: create base type(interface or class or abstact class)
    public interface IProductType1
    {
    }
    public interface IProductType2
    {
    }
    //step2: create concrete types of base types(class)
    public class ProductA1 : IProductType1
    {
    }
    public class ProductB1 : IProductType1
    {
    }
    public class ProductA2 : IProductType2
    {
    }
    public class ProductB2 : IProductType2
    {
    }
    //step3: create creator type(interface or class or abstact class)
    public abstract class Creator
    {
        public abstract IProductType1 ProductType1FactoryMethod();
        public abstract IProductType2 ProductType2FactoryMethod();
    }
    //step2: create concrete types of creator type(class)
    public class ProductACreator : Creator
    {
        public override IProductType1 ProductType1FactoryMethod()
        {
            return new ProductA1();
        }

        public override IProductType2 ProductType2FactoryMethod()
        {
            return new ProductA2();

        }
    }
    public class ProductBCreator : Creator
    {
        public override IProductType1 ProductType1FactoryMethod()
        {
            return new ProductB1();
        }

        public override IProductType2 ProductType2FactoryMethod()
        {
            return new ProductB2();
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
                IProductType1 product1 = creator.ProductType1FactoryMethod();
                IProductType2 product2 = creator.ProductType2FactoryMethod();
                Console.WriteLine("Created {0}", product1.GetType().Name);
                Console.WriteLine("Created {0}", product1.GetType().Name);
            }

            // Wait for user

            Console.ReadKey();
        }
    }
}
