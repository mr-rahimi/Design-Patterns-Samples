using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Iterator
{
    class Iterator
    {
        //1
        private Aggregate _aggregate;
        //2
        private int _current = 0;

        // 3
        public Iterator(Aggregate collection)
        {
            this._aggregate = collection;
        }

        //4
        public object First()
        {
            _current = 0;
            return _aggregate[_current];
        }
        public object Next()
        {
            _current += 1;
            if (!IsDone)
                return _aggregate[_current];
            else

                return null;
        }
        public object CurrentItem
        {
            get { return _aggregate[_current]; }
        }
        public bool IsDone
        {
            get { return _current >= _aggregate.Count; }
        }
    }
    class Aggregate
    {
        //1
        private ArrayList _items = new ArrayList();
        //2
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        // 3
        public int Count
        {
            get { return _items.Count; }
        }
        //4
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
    public class Using
    {
        public static void Use()
        {
            Aggregate a = new Aggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate

            Iterator i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            // Wait for user

            Console.ReadKey();
        }
    }
}
