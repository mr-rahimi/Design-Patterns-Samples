using System;
 using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Proxy
{
    public interface IBusiness
    {
        int Create(string name);
        string Read(int id);
        void Update(int id, string name);
        void Delete(int id);
    }

    public class Business : IBusiness
    {
        private static Dictionary<int, string> persons = new Dictionary<int, string>();
        public int Create(string name)
        {
            var key = 0;
            if (persons.Any())
                key = persons.Max(x => x.Key) + 1;
            persons.Add(key, name);
            return key;
        }

        public void Delete(int id)
        {
            persons.Remove(id);
        }

        public string Read(int id)
        {
            string value;
            if (!persons.TryGetValue(id, out value))
                throw new KeyNotFoundException();
            return value;
        }

        public void Update(int id, string name)
        {
            string value;
            if (!persons.TryGetValue(id, out value))
                throw new KeyNotFoundException();
            persons[id] = name;
        }
    }
    public class BusinessProxy : IBusiness
    {
        private IBusiness _business;
        public BusinessProxy()
        {
            _business = new Business();
        }

        public int Create(string name)
        {
            Console.WriteLine("persion is creating");
            var key = _business.Create(name);
            Console.WriteLine("person was created");
            return key;
        }

        public void Delete(int id)
        {
            Console.WriteLine("persion is deleting");
            _business.Delete(id);
            Console.WriteLine("person was deleted");
        }

        public string Read(int id)
        {
            Console.WriteLine("persion is reading");
            var value = _business.Read(id);
            Console.WriteLine("persion is read");
            return value;
        }

        public void Update(int id, string name)
        {
            Console.WriteLine("persion is updating");
            _business.Update(id, name);
            Console.WriteLine("person was updated");
        }
    }
    public class Using
    {
        public static void Use()
        {
            BusinessProxy proxy = new BusinessProxy();
            var id = proxy.Create("Mohammad");
            var value = proxy.Read(id);
            // Wait for user

            Console.ReadKey();
        }
    }
}
