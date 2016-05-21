using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSharpGL.UILayout
{
    public class GLControlCollection : ICollection<GLControl>
    {
        private GLContainer container;
        Collection<GLControl> collection = new Collection<GLControl>();

        public GLControlCollection(GLContainer gLContainer)
        {
            this.container = gLContainer;
        }
        public void Add(GLControl item)
        {
            item.Container = this.container;
            this.collection.Add(item);
        }

        public void Clear()
        {
            GLControl[] ie = (from item in this.collection select item).ToArray();

            this.collection.Clear(); 

            foreach (var item in this)
            {
                item.Container = null;
            }
        }

        public bool Contains(GLControl item)
        {
            return this.collection.Contains(item);
        }

        public void CopyTo(GLControl[] array, int arrayIndex)
        {
            this.collection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<GLControl>)this.collection).IsReadOnly; }
        }

        public bool Remove(GLControl item)
        {
            bool result = this.collection.Remove(item);
            if (item != null) { item.Container = null; }
            return result;
        }

        public IEnumerator<GLControl> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }
    }
}
