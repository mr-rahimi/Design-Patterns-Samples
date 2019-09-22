using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Memento
{
    public interface IMemento<T>
    {
        T State { get; }
        T CreateState();
        void RestoreState(T state);
    }

    // memento
    public class Snapshot
    {
        public Snapshot(string name, string family)
        {
            this.Name = name;
            this.Family = family;
        }
        public string Name { get; set; }
        public string Family { get; set; }
    }

    // originator
    public class Person : IMemento<Snapshot>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }

        public Snapshot State { get; set; }

        public Snapshot CreateState()
        {
            return new Snapshot(this.Name, this.Family);
        }

        public void RestoreState(Snapshot state)
        {
            this.Name = state.Name;
            this.Family = state.Family;
        }
    }
    public class Using
    {
        public static void Use()
        {
            var person = new Person() { Name = "John", Family = "Doe", Mobile="1234" };
            Console.WriteLine($"before store state \n name:{person.Name}\n family:{person.Family} \n mobile:{person.Mobile}");

            var state = person.CreateState();

            person.Name = "Tom";
            person.Family = "Watson";
            person.Mobile = "5678";

            Console.WriteLine($"after change state \n name:{person.Name}\n family:{person.Family} \n mobile:{person.Mobile}");

            person.RestoreState(state);

            Console.WriteLine($"after restore state \n name:{person.Name}\n family:{person.Family} \n mobile:{person.Mobile}");

            // Wait for user

            Console.ReadKey();
        }
    }
}
