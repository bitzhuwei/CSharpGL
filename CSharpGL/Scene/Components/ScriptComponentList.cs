using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    [Editor(typeof(IListEditor<ScriptComponent>), typeof(UITypeEditor))]
    public class ScriptComponentList : IList<ScriptComponent>
    {

        public event EventHandler<AddItemEventArgs<ScriptComponent>> ItemAdded;
        public event EventHandler<RemoveItemEventArgs<ScriptComponent>> ItemRemoved;

        List<ScriptComponent> list = new List<ScriptComponent>();

        private SceneObject bindingObject;

        public ScriptComponentList(SceneObject bindingObject = null)
        {
            this.bindingObject = bindingObject;
        }

        public int IndexOf(ScriptComponent item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, ScriptComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Insert(index, item);

            EventHandler<AddItemEventArgs<ScriptComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<ScriptComponent>(item)); }
        }

        public void RemoveAt(int index)
        {
            ScriptComponent obj = list[index];
            list.RemoveAt(index);
            obj.BindingObject = null;

            EventHandler<RemoveItemEventArgs<ScriptComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            { ItemRemoved(this, new RemoveItemEventArgs<ScriptComponent>(obj)); }
        }

        public ScriptComponent this[int index]
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

        public void Add(ScriptComponent item)
        {
            item.BindingObject = this.bindingObject;
            list.Add(item);

            EventHandler<AddItemEventArgs<ScriptComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<ScriptComponent>(item)); }
        }

        public void AddRange(IEnumerable<ScriptComponent> items)
        {
            foreach (var item in items)
            {
                item.BindingObject = this.bindingObject;
            }
            list.AddRange(items);

            EventHandler<AddItemEventArgs<ScriptComponent>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            {
                foreach (var item in items)
                {
                    ItemAdded(this, new AddItemEventArgs<ScriptComponent>(item));
                }
            }
        }

        public void Clear()
        {
            var array = this.list.ToArray();
            list.Clear();

            foreach (var item in array)
            {
                item.BindingObject = null;
            }

            EventHandler<RemoveItemEventArgs<ScriptComponent>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            {
                foreach (var item in array)
                {
                    ItemRemoved(this, new RemoveItemEventArgs<ScriptComponent>(item));
                }
            }
        }

        public bool Contains(ScriptComponent item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ScriptComponent[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<ScriptComponent>)(this.list)).IsReadOnly; }
        }

        public bool Remove(ScriptComponent item)
        {
            bool result = list.Remove(item);
            if (result)
            {
                item.BindingObject = null;

                EventHandler<RemoveItemEventArgs<ScriptComponent>> ItemRemoved = this.ItemRemoved;
                if (ItemRemoved != null)
                { ItemRemoved(this, new RemoveItemEventArgs<ScriptComponent>(item)); }
            }
            return result;
        }

        public IEnumerator<ScriptComponent> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
