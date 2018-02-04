using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// children in <see cref="GLControl"/>.
    /// </summary>
    [Editor(typeof(IListEditor<GLControl>), typeof(UITypeEditor))]
    public class GLControlChildren : IList<GLControl>
    {
        internal readonly List<GLControl> children = new List<GLControl>();

        /// <summary>
        /// parent of this list's items.
        /// </summary>
        private readonly GLControl parent;

        /// <summary>
        /// children in <paramref name="parent"/>.
        /// </summary>
        /// <param name="parent"></param>
        public GLControlChildren(GLControl parent)
        {
            Debug.Assert(parent != null);

            this.parent = parent;
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 System.Collections.Generic.List&lt;T&gt; 中第一个匹配项的从零开始的索引。
        /// </summary>
        /// <param name="item">要在 System.Collections.Generic.List&lt;T&gt; 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在整个 System.Collections.Generic.List&lt;T&gt; 中找到 item 的第一个匹配项，则为该项的从零开始的索引；否则为-1。</returns>
        public int IndexOf(GLControl item)
        {
            return children.IndexOf(item);
        }

        /// <summary>
        /// 将元素插入 System.Collections.Generic.List&lt;T&gt; 的指定索引处。
        /// </summary>
        /// <param name="index">从零开始的索引，应在该位置插入 item。</param>
        /// <param name="item">要插入的对象。对于引用类型，该值可以为 null。</param>
        public void Insert(int index, GLControl item)
        {
            item.parent = this.parent;
            children.Insert(index, item);
        }

        /// <summary>
        /// 移除 System.Collections.Generic.List&lt;T&gt; 的指定索引处的元素。
        /// </summary>
        /// <param name="index">要移除的元素的从零开始的索引。</param>
        public void RemoveAt(int index)
        {
            GLControl obj = children[index];
            this.children.RemoveAt(index);
            if (obj != null) { obj.parent = null; }
        }

        /// <summary>
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引。</param>
        /// <returns>指定索引处的元素。</returns>
        public GLControl this[int index]
        {
            get
            {
                return children[index];
            }
            set
            {
                children[index] = value;
            }
        }

        /// <summary>
        /// 将对象添加到 System.Collections.Generic.List&lt;T&gt; 的结尾处。
        /// </summary>
        /// <param name="item">要添加到 System.Collections.Generic.List&lt;T&gt; 的末尾处的对象。对于引用类型，该值可以为 null。</param>
        public void Add(GLControl item)
        {
            if (item == null) { return; }

            item.parent = this.parent;
            children.Add(item);

            GLControl.LayoutAfterAddChild(item, this.parent);
            GLControl.UpdateAbsLocation(item, this.parent);
        }

        /// <summary>
        /// 将指定集合的元素添加到 System.Collections.Generic.List&lt;T&gt; 的末尾。
        /// </summary>
        /// <param name="items">一个集合，其元素应被添加到 System.Collections.Generic.List&lt;T&gt; 的末尾。集合自身不能为 null，但它可以包含为null 的元素（如果类型 T 为引用类型）。</param>
        public void AddRange(IEnumerable<GLControl> items)
        {
            foreach (var item in items)
            {
                if (item != null)
                { item.parent = this.parent; children.Add(item); }
            }

            foreach (var item in items)
            {
                if (item != null)
                {
                    GLControl.LayoutAfterAddChild(item, this.parent);
                    GLControl.UpdateAbsLocation(item, this.parent);
                }
            }
        }

        /// <summary>
        /// 从 System.Collections.Generic.List&lt;T&gt;中移除所有元素。
        /// </summary>
        public void Clear()
        {
            GLControl[] array = this.children.ToArray();
            this.children.Clear();

            foreach (var item in array)
            {
                item.parent = null;
            }
        }

        /// <summary>
        /// 确定某元素是否在 System.Collections.Generic.List&lt;T&gt;中。
        /// </summary>
        /// <param name="item">要在 System.Collections.Generic.List&lt;T&gt; 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在 System.Collections.Generic.List&lt;T&gt; 中找到 item，则为 true，否则为 false。</returns>
        public bool Contains(GLControl item)
        {
            return children.Contains(item);
        }

        /// <summary>
        /// 将整个 System.Collections.Generic.List&lt;T&gt; 复制到兼容的一维数组中，从目标数组的指定索引位置开始放置。
        /// </summary>
        /// <param name="array">作为从 System.Collections.Generic.List&lt;T&gt; 复制的元素的目标位置的一维 System.Array。System.Array必须具有从零开始的索引。</param>
        /// <param name="arrayIndex">array 中从零开始的索引，从此处开始复制。</param>
        public void CopyTo(GLControl[] array, int arrayIndex)
        {
            children.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 获取 System.Collections.Generic.List&lt;T&gt; 中实际包含的元素数。
        /// </summary>
        public int Count
        {
            get { return children.Count; }
        }

        /// <summary>
        /// 获取一个值，该值指示 System.Collections.Generic.ICollection&lt;T&gt; 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get { return ((ICollection<GLControl>)(this.children)).IsReadOnly; }
        }

        /// <summary>
        /// 从 System.Collections.Generic.List&lt;T&gt; 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="item">要从 System.Collections.Generic.List&lt;T&gt; 中移除的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果成功移除 item，则为 true；否则为 false。如果在 System.Collections.Generic.List&lt;T&gt; 中没有找到item，该方法也会返回 false。</returns>
        public bool Remove(GLControl item)
        {
            bool result = children.Remove(item);
            if (result)
            {
                if (item != null) { item.parent = null; }
            }

            return result;
        }

        /// <summary>
        /// 返回循环访问 System.Collections.Generic.List&lt;T&gt; 的枚举数。
        /// </summary>
        /// <returns>用于 System.Collections.Generic.List&lt;T&gt; 的 System.Collections.Generic.List&lt;T&gt;.Enumerator。</returns>
        public IEnumerator<GLControl> GetEnumerator()
        {
            return children.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Count: {0}", this.children.Count);
        }
    }

    ///// <summary>
    /////
    ///// </summary>
    //public class AddTreeNodeEventArgs<T> : EventArgs
    //{
    //    /// <summary>
    //    /// newly added item.
    //    /// </summary>
    //    public T NewItem { get; private set; }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="newItem"></param>
    //    public AddTreeNodeEventArgs(T newItem)
    //    {
    //        this.NewItem = newItem;
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString()
    //    {
    //        return string.Format("Added item: {0}", NewItem);
    //    }
    //}

    ///// <summary>
    /////
    ///// </summary>
    //public class RemoveTreeNodeEventArgs<T> : EventArgs
    //{
    //    /// <summary>
    //    /// removed item.
    //    /// </summary>
    //    public T RemovedItem { get; private set; }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="removedItem"></param>
    //    public RemoveTreeNodeEventArgs(T removedItem)
    //    {
    //        this.RemovedItem = removedItem;
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString()
    //    {
    //        return string.Format("Removed item: {0}", RemovedItem);
    //    }
    //}
}