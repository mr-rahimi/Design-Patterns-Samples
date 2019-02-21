using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    public class Singleton
    {
        // step 1 
        public static Singleton _instance;
        // step 2
        protected Singleton()
        {
        }
        // step 3
        public static Singleton Instance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}
