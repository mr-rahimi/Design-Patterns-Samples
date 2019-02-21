using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.State
{
    class Subject
    {
        public IState State { get; set; }
        public Subject(IState state)
        {
            State = state;
        }
        public void Execute()
        {
            State.Handle(this);
        }
    }
    interface IState
    {
        void Handle(Subject subject);
    }
    class State1 : IState
    {
        public void Handle(Subject subject)
        {
            Console.WriteLine("Task1");
        }
    }
    class State2 : IState
    {
        public void Handle(Subject subject)
        {
            Console.WriteLine("Task2");
        }
    }
    public class Using
    {
        public static void Use()
        {
            Subject s = new Subject(new State1());
            s.Execute();
            s.State = new State2();
            s.Execute();
            // Wait for user

            Console.ReadKey();
        }
    }
}
