using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpGL
{

    /// <summary>
    /// 用<see cref="Add(item)"/>时自动实现双向绑定。
    /// </summary>
    class ILayoutCollection : ICollection<ILayout>
    {
        private ILayout container;
        ICollection<ILayout> collection = new Collection<ILayout>();

        public ILayoutCollection(ILayout container)
        {
            this.container = container;
        }
        public void Add(ILayout item)
        {
            item.Container = this.container;
            item.ParentLastSize = this.container.Size;
            this.collection.Add(item);
        }

        public void Clear()
        {
            ILayout[] ie = (from item in this.collection select item).ToArray();

            this.collection.Clear();

            foreach (var item in this.collection)
            {
                item.Container = null;
            }
        }

        public bool Contains(ILayout item)
        {
            return this.collection.Contains(item);
        }

        public void CopyTo(ILayout[] array, int arrayIndex)
        {
            this.collection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<ILayout>)this.collection).IsReadOnly; }
        }

        public bool Remove(ILayout item)
        {
            bool result = this.collection.Remove(item);
            if (item != null) { item.Container = null; }
            return result;
        }

        public IEnumerator<ILayout> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }
    }

}

