using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharpGL
{
    //“CSharpGL.IListEditor<CSharpGL.ComponentList<TBinding,TComponent>>”: 特性参数不能使用类型参数
    //[Editor(typeof(IListEditor<ComponentList<TBinding, TComponent>>), typeof(UITypeEditor))]
    /// <summary>
    /// a list of components who bind to the specified binding object.
    /// </summary>
    /// <typeparam name="TBinding"></typeparam>
    /// <typeparam name="TComponent"></typeparam>
    public abstract class ComponentList<TBinding, TComponent> : IList<TComponent> where TComponent : IBindingObject<TBinding>
    {
        /// <summary>
        ///
        /// </summary>
        public event EventHandler<AddComponentEventArgs<TComponent>> ItemAdded;

        /// <summary>
        ///
        /// </summary>
        public event EventHandler<RemoveComponentEventArgs<TComponent>> ItemRemoved;

        private List<TComponent> list = new List<TComponent>();

        private readonly TBinding bindingObject;

        /// <summary>
        /// a list of components who bind to the specified binding object.
        /// </summary>
        /// <param name="bindingObject"></param>
        public ComponentList(TBinding bindingObject)
        {
            Debug.Assert(bindingObject != null);

            this.bindingObject = bindingObject;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public int IndexOf(TComponent item)
        {
            return list.IndexOf(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="child"></param>
        public void Insert(int index, TComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Insert(index, item);

            EventHandler<AddComponentEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddComponentEventArgs<TComponent>(item)); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            TComponent obj = list[index];
            list.RemoveAt(index);
            obj.BindingObject = default(TBinding);

            EventHandler<RemoveComponentEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            { ItemRemoved(this, new RemoveComponentEventArgs<TComponent>(obj)); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TComponent this[int index]
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="child"></param>
        public void Add(TComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Add(item);

            EventHandler<AddComponentEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddComponentEventArgs<TComponent>(item)); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<TComponent> items)
        {
            foreach (TComponent item in items)
            {
                item.BindingObject = this.bindingObject;
            }
            list.AddRange(items);

            EventHandler<AddComponentEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            {
                foreach (TComponent item in items)
                {
                    ItemAdded(this, new AddComponentEventArgs<TComponent>(item));
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            TComponent[] array = this.list.ToArray();
            list.Clear();

            foreach (TComponent item in array)
            {
                item.BindingObject = default(TBinding);
            }

            EventHandler<RemoveComponentEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            {
                foreach (TComponent item in array)
                {
                    ItemRemoved(this, new RemoveComponentEventArgs<TComponent>(item));
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool Contains(TComponent item)
        {
            return list.Contains(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TComponent[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsReadOnly
        {
            get { return ((ICollection<TComponent>)(this.list)).IsReadOnly; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool Remove(TComponent item)
        {
            bool result = list.Remove(item);
            if (result)
            {
                item.BindingObject = default(TBinding);

                EventHandler<RemoveComponentEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
                if (ItemRemoved != null)
                { ItemRemoved(this, new RemoveComponentEventArgs<TComponent>(item)); }
            }
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TComponent> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBinding"></typeparam>
    public interface IBindingObject<TBinding>
    {
        /// <summary>
        ///
        /// </summary>
        TBinding BindingObject { get; set; }
    }


    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddComponentEventArgs<T> : EventArgs
    {
        /// <summary>
        /// newly added child.
        /// </summary>
        public T NewItem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newItem"></param>
        public AddComponentEventArgs(T newItem)
        {
            this.NewItem = newItem;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Added item: {0}", NewItem);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RemoveComponentEventArgs<T> : EventArgs
    {
        /// <summary>
        /// removed child.
        /// </summary>
        public T RemovedItem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="removedItem"></param>
        public RemoveComponentEventArgs(T removedItem)
        {
            this.RemovedItem = removedItem;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Removed item: {0}", RemovedItem);
        }
    }
}