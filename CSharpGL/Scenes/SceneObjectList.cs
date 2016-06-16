using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class SceneObjectList : IList<SceneObject>
    {

        public SceneObject Parent { get; set; }

        public SceneObjectList(SceneObject parent = null)
        {
            this.Parent = parent;
        }

        List<SceneObject> list = new List<SceneObject>();
        public int IndexOf(SceneObject item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, SceneObject item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
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
            list.Add(item);
            item.Parent = this.Parent;
        }

        public void AddRange(IEnumerable<SceneObject> items)
        {
            list.AddRange(items);
        }

        public void Clear()
        {
            foreach (var item in this.list)
            {
                item.Parent = null;
            }

            list.Clear();
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
            get { return ((ICollection<SceneObject>)this).IsReadOnly; }
        }

        public bool Remove(SceneObject item)
        {
            item.Parent = null;
            return list.Remove(item);
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
