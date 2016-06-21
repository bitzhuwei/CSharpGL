using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    [Editor(typeof(IListEditor<SceneObject>), typeof(UITypeEditor))]
    public class SceneObjectList : IList<SceneObject>
    {

        List<SceneObject> list = new List<SceneObject>();

        public SceneObject Parent { get; set; }

        public SceneObjectList(SceneObject parent = null)
        {
            this.Parent = parent;
        }

        public int IndexOf(SceneObject item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, SceneObject item)
        {
            list.Insert(index, item);
            item.Parent = this.Parent;
            item.RefreshRelativeTransform();
        }

        public void RemoveAt(int index)
        {
            SceneObject obj = list[index];
            list.RemoveAt(index);
            obj.Parent = null;
            obj.RefreshRelativeTransform();
        }

        public SceneObject this[int index]
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

        public void Add(SceneObject item)
        {
            item.Parent = this.Parent;
            list.Add(item);
            item.RefreshRelativeTransform();
        }

        public void AddRange(IEnumerable<SceneObject> items)
        {
            foreach (var item in items)
            {
                item.Parent = this.Parent;
            }
            list.AddRange(items);
            foreach (var item in items)
            {
                item.RefreshRelativeTransform();
            }
        }

        public void Clear()
        {
            foreach (var item in this.list)
            {
                item.Parent = null;
            }

            list.Clear();
            foreach (var item in this.list)
            {
                item.RefreshRelativeTransform();
            }
        }

        public bool Contains(SceneObject item)
        {
            return list.Contains(item);
        }

        public void CopyTo(SceneObject[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<SceneObject>)(this.list)).IsReadOnly; }
        }

        public bool Remove(SceneObject item)
        {
            bool result = list.Remove(item);
            item.Parent = null;
            item.RefreshRelativeTransform();
            return result;
        }

        public IEnumerator<SceneObject> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
