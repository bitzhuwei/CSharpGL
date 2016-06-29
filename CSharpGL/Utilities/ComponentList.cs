using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

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

        public event EventHandler<AddItemEventArgs<TComponent>> ItemAdded;
        public event EventHandler<RemoveItemEventArgs<TComponent>> ItemRemoved;

        List<TComponent> list = new List<TComponent>();

        private TBinding bindingObject;

        public ComponentList(TBinding bindingObject = default(TBinding))
        {
            this.bindingObject = bindingObject;
        }

        public int IndexOf(TComponent item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, TComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Insert(index, item);

            EventHandler<AddItemEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<TComponent>(item)); }
        }

        public void RemoveAt(int index)
        {
            TComponent obj = list[index];
            list.RemoveAt(index);
            obj.BindingObject = default(TBinding);

            EventHandler<RemoveItemEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            { ItemRemoved(this, new RemoveItemEventArgs<TComponent>(obj)); }
        }

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

        public void Add(TComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Add(item);

            EventHandler<AddItemEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<TComponent>(item)); }
        }

        public void AddRange(IEnumerable<TComponent> items)
        {
            foreach (var item in items)
            {
                item.BindingObject = this.bindingObject;
            }
            list.AddRange(items);

            EventHandler<AddItemEventArgs<TComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            {
                foreach (var item in items)
                {
                    ItemAdded(this, new AddItemEventArgs<TComponent>(item));
                }
            }
        }

        public void Clear()
        {
            var array = this.list.ToArray();
            list.Clear();

            foreach (var item in array)
            {
                item.BindingObject = default(TBinding);
            }

            EventHandler<RemoveItemEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            {
                foreach (var item in array)
                {
                    ItemRemoved(this, new RemoveItemEventArgs<TComponent>(item));
                }
            }
        }

        public bool Contains(TComponent item)
        {
            return list.Contains(item);
        }

        public void CopyTo(TComponent[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<TComponent>)(this.list)).IsReadOnly; }
        }

        public bool Remove(TComponent item)
        {
            bool result = list.Remove(item);
            if (result)
            {
                item.BindingObject = default(TBinding);

                EventHandler<RemoveItemEventArgs<TComponent>> ItemRemoved = this.ItemRemoved;
                if (ItemRemoved != null)
                { ItemRemoved(this, new RemoveItemEventArgs<TComponent>(item)); }
            }
            return result;
        }

        public IEnumerator<TComponent> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public interface IBindingObject<TBinding>
    {
        TBinding BindingObject { get; set; }
    }

}
