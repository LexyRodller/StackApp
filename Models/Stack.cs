using System;
using System.Collections.Generic;

namespace StackApp.Models
{
    public class Stack<T>
    {
        private List<T> items;

        public Stack()
        {
            items = new List<T>();
        }

        public T? CurrentItem => items.Count > 0 ? items[items.Count - 1] : default(T);
        public int Count => items.Count;
        public bool IsEmpty => items.Count == 0;

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return item;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}