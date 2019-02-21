using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Flyweight
{
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        // Constructor

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }
    public class Using
    {
        public static void Use()
        {
            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fw= factory.GetFlyweight("X");
            fw.Operation(1);

            Flyweight fw1 = factory.GetFlyweight("Y");
            fw1.Operation(1);
            // Wait for user

            Console.ReadKey();
        }
    }
}
