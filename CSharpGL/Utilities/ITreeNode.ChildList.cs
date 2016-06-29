using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// children in <see cref="ITreeNode"/>&lt;<typeparamref name="T"/>&gt;.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //[Editor(typeof(IListEditor<T>), typeof(UITypeEditor))]
    public class ChildList<T> : IList<T> where T : ITreeNode<T>
    {

        public event EventHandler<AddItemEventArgs<T>> ItemAdded;
        public event EventHandler<RemoveItemEventArgs<T>> ItemRemoved;

        List<T> list = new List<T>();

        public T Parent { get; set; }

        public ChildList(T parent = default(T))
        {
            this.Parent = parent;
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            item.Parent = this.Parent;
            list.Insert(index, item);
            //item.RefreshRelativeTransform();

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<T>(item)); }
        }

        public void RemoveAt(int index)
        {
            T obj = list[index];
            list.RemoveAt(index);
            obj.Parent = default(T);
            //obj.RefreshRelativeTransform();

            EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            { ItemRemoved(this, new RemoveItemEventArgs<T>(obj)); }
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            item.Parent = this.Parent;
            list.Add(item);
            //item.RefreshRelativeTransform();

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<T>(item)); }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                item.Parent = this.Parent;
            }
            list.AddRange(items);
            foreach (var item in items)
            {
                //item.RefreshRelativeTransform();
            }

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            {
                foreach (var item in items)
                {
                    ItemAdded(this, new AddItemEventArgs<T>(item));
                }
            }
        }

        public void Clear()
        {
            var array = this.list.ToArray();
            this.list.Clear();

            foreach (var item in array)
            {
                item.Parent = default(T);
                //item.RefreshRelativeTransform();
            }

            EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            {
                foreach (var item in array)
                {
                    ItemRemoved(this, new RemoveItemEventArgs<T>(item));
                }
            }
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<T>)(this.list)).IsReadOnly; }
        }

        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            if (result)
            {
                item.Parent = default(T);
                //item.RefreshRelativeTransform();

                EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
                if (ItemRemoved != null)
                { ItemRemoved(this, new RemoveItemEventArgs<T>(item)); }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("Count: {0}", this.list.Count);
        }
    }
}
