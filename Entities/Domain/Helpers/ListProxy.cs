using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    internal class ListProxy<T> : IList<T>
    {
        public ListProxy(IList<T> list)
        {
            ListImplementation = list;
        }

        public IList<T> ListImplementation { get; set; }

        public Action<T, IList<T>> AddAction { get; set; }

        public Func<T, IList<T>, bool> RemoveAction { get; set; }

        public T this[int index] { get => ListImplementation[index]; set => ListImplementation[index] = value; }

        public int Count => ListImplementation.Count;

        public bool IsReadOnly => ListImplementation.IsReadOnly;

        public virtual void Add(T item)
        {
            if (AddAction == null)
            {
                ListImplementation.Add(item);
            }
            else
            {
                AddAction.Invoke(item, ListImplementation);
            }
        }

        public void Clear()
        {
            ListImplementation.Clear();
        }

        public bool Contains(T item)
        {
            return ListImplementation.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ListImplementation.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ListImplementation.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ListImplementation.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ListImplementation.Insert(index, item);
        }

        public bool Remove(T item)
        {
            if (RemoveAction == null)
            {
                return ListImplementation.Remove(item);
            }
            else
            {
                return RemoveAction.Invoke(item, ListImplementation);
            }
        }

        public void RemoveAt(int index)
        {
            ListImplementation.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ListImplementation.GetEnumerator();
        }
    }
}
