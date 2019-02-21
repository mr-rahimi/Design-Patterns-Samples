using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainOfRepository
{
    public abstract class Logger
    {
        protected Logger _successor;
        public void SetSuccessor(Logger successor)
        {
            _successor = successor;
        }
        public abstract void Log(string message);
    }
    public class DbLogger : Logger
    {
        public override void Log(string message)
        {
            try
            {
                //some code for log to db
            }
            catch (Exception)
            {
                _successor.Log(message);
            }
        }
    }
    public class FileLogger : Logger
    {
        public override void Log(string message)
        {
            try
            {
                //some code for log to file
            }
            catch (Exception)
            {
                _successor.Log(message);
            }
        }
    }
    public class Using
    {
        public static void Use()
        {
            DbLogger dbLogger = new DbLogger();
            FileLogger fileLogger = new FileLogger();

            dbLogger.SetSuccessor(fileLogger);

            dbLogger.Log("some message");
            // Wait for user

            Console.ReadKey();
        }
    }
}
