using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Strategy
{
    class Context
    {
        public void Execute(IStrategy strategy)
        {
            strategy.ExecuteStrategy(this);
        }
    }
    interface IStrategy
    {
        void ExecuteStrategy(Context context);
    }
    class Strategy1 : IStrategy
    {
        public void ExecuteStrategy(Context context)
        {
            Console.WriteLine("Strategy1 Done");
        }
    }
    class Strategy2 : IStrategy
    {
        public void ExecuteStrategy(Context context)
        {
            Console.WriteLine("Strategy2 Done");
        }
    }
    public class Using
    {
        public static void Use()
        {
            Context context = new Context();
            context.Execute(new Strategy1());
            context.Execute(new Strategy2());
            // Wait for user

            Console.ReadKey();
        }
    }
}
