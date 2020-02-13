using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;
        public Stack()
        {
            this.stack = new List<T>();
        }

        public void Push(params T[] items)
        {

            stack.AddRange(items);
        }
        public void Pop()
        {
            if (stack.Any())
            {
                stack.RemoveAt(stack.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
