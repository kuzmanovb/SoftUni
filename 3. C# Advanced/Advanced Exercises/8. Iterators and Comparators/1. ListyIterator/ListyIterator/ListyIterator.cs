using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> store;
        private int count;

        public ListyIterator(List<T> input)
        {
            this.store = input;
            this.count = 0;
        }

        public bool Move()
        {
            if (count < store.Count-1)
            {
                count++;
                return true;
            }

            return false;

        }
        public void Print()
        {
            if (store.Any())
            {
                Console.WriteLine(this.store[count]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
        public bool HasNext()
        {
            if (count < store.Count - 1)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.store)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
