using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    [Editor(typeof(ScriptComponentListEditor), typeof(UITypeEditor))]
    public class ScriptComponentList : IList<ScriptComponent>
    {

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
            list.Insert(index, item);
            item.BindingObject = this.bindingObject;
        }

        public void RemoveAt(int index)
        {
            ScriptComponent obj = list[index];
            list.RemoveAt(index);
            obj.BindingObject = null;
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
        }

        public void AddRange(IEnumerable<ScriptComponent> items)
        {
            foreach (var item in items)
            {
                item.BindingObject = this.bindingObject;
            }
            list.AddRange(items);
        }

        public void Clear()
        {
            list.Clear();

            foreach (var item in this.list)
            {
                item.BindingObject = null;
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
            item.BindingObject = null;
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
