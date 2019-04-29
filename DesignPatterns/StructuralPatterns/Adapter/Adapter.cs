using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    public class OldLogger
    {
        public virtual void LogError()
        {
            Console.WriteLine("old log error");
        }
        public virtual void LogInfo()
        {
            Console.WriteLine("old log info");
        }
    }
    public class Logger
    {
        public virtual void LogError()
        {
            Console.WriteLine("log error");
        }
        public virtual void LogInfo()
        {
            Console.WriteLine("log info");
        }
    }
    class OldLoggerAdapter: Logger
    {
        OldLogger oldProduct = new OldLogger();
        public override void LogError()
        {
            oldProduct.LogError();
        } 
        public override void LogInfo()
        {
            oldProduct.LogInfo();
        } 
    }
    public class Using
    {
        public static void Use()
        {
            Logger logger = new OldLoggerAdapter();
            logger.LogInfo(); 
            // Wait for user

            Console.ReadKey();
        }
    }
}
