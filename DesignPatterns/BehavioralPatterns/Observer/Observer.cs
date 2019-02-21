using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Observer
{
    class Subject
    {
        private List<Observer> observers = new List<Observer>();
        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }
        private int _x;
        public int x
        {
            get
            {
                return x;

            }
            set
            {
                foreach (var observer in observers)
                {
                    observer.Update();
                }
                _x = value;
            }
        }
    }
    interface IObserver
    {
        void Update();
    }
    class Observer : IObserver
    {
        public void Update()
        {
            Console.WriteLine("subject changed");
        }
    }
    public class Using
    {
        public static void Use()
        {
            Subject s = new Subject();

            Observer o1 = new Observer();
            Observer o2 = new Observer();

            s.AddObserver(o1);
            s.AddObserver(o2);

            s.x = 5;
            // Wait for user

            Console.ReadKey();
        }
    }

}
