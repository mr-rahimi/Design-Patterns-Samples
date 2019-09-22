using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{
    public class Logger
    {
        public ILogger LogImplementor { protected get; set; }
        public void LogError(string message)
        {
            LogImplementor.Log(message);
        }
        public void LogInfo(string message)
        {
            LogImplementor.Log(message);
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("log to database: " + message);
        }
    }
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("log to file : "+ message);
        }
    }
    
    public class Using
    {
        public static void Use()
        {
            var logger = new Logger();
            logger.LogImplementor= new FileLogger();
            logger.LogInfo("some info");
            logger.LogImplementor= new DatabaseLogger();
            logger.LogInfo("some info");

            // Wait for user

            Console.ReadKey();
        }
    }
}
