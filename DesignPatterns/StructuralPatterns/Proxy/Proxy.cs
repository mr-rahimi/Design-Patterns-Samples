using System;
 using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Proxy
{
    public interface Subject
    {
        void PerformAction();
    }

    public class RealSubject : Subject
    {
        public void PerformAction()
        {
            Console.WriteLine("RealSubject action performed.");
        }
    }
    public class Proxy : Subject
    {
        private RealSubject _realSubject;

        public void PerformAction()
        {
            if (_realSubject == null)
                _realSubject = new RealSubject();

            _realSubject.PerformAction();
        }
    }
    public class Using
    {
        public static void Use()
        {
            Proxy proxy = new Proxy();
            proxy.PerformAction();
            // Wait for user

            Console.ReadKey();
        }
    }
}
