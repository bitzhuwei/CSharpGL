using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpGL
{

    /// <summary>
    /// 用<see cref="Add"/>、<see cref="Insert"/>时自动实现双向绑定。
    /// 用<see cref="Clear"/>、<see cref="Remove"/>、<see cref="RemoveAt"/>时自动实现双向解绑。
    /// </summary>
    class ILayoutList : IList<UIRenderer>
    {
        private UIRenderer parent;
        List<UIRenderer> list = new List<UIRenderer>();

        public ILayoutList(UIRenderer container)
        {
            this.parent = container;
        }

        public int IndexOf(UIRenderer item)
        {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, UIRenderer item)
        {
            item.Parent = this.parent;
            item.ParentLastSize = this.parent.Size;
            this.list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            UIRenderer item = this.list[index];
            if (item != null)
            { item.Parent = null; }

            this.list.RemoveAt(index);
        }

        public UIRenderer this[int index]
        {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }

        public void Add(UIRenderer item)
        {
            item.Parent = this.parent;
            item.ParentLastSize = this.parent.Size;
            this.list.Add(item);
        }

        public void Clear()
        {
            UIRenderer[] array = this.list.ToArray();

            this.list.Clear();

            foreach (var item in array)
            {
                item.Parent = null;
            }
        }

        public bool Contains(UIRenderer item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(UIRenderer[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<UIRenderer>)this.list).IsReadOnly; }
        }

        public bool Remove(UIRenderer item)
        {
            bool result = this.list.Remove(item);
            if (result)
            {
                if (item != null)
                { item.Parent = null; }
            }

            return result;
        }

        public IEnumerator<UIRenderer> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}
