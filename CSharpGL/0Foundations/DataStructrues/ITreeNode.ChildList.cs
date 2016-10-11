using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// children in <see cref="ITreeNode&lt;T&gt;"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //[Editor(typeof(IListEditor<T>), typeof(UITypeEditor))]
    public class ChildList<T> : IList<T> where T : ITreeNode<T>
    {
        /// <summary>
        /// invoked when an item is added into this list.
        /// </summary>
        public event EventHandler<AddItemEventArgs<T>> ItemAdded;

        /// <summary>
        /// invoked when an item is removed from this list.
        /// </summary>
        public event EventHandler<RemoveItemEventArgs<T>> ItemRemoved;

        private List<T> list = new List<T>();

        /// <summary>
        /// parent of this list's items.
        /// </summary>
        public T Parent { get; set; }

        /// <summary>
        /// children in <see cref="ITreeNode&lt;T&gt;"/>.
        /// </summary>
        /// <param name="parent"></param>
        public ChildList(T parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 System.Collections.Generic.List&lt;T&gt; 中第一个匹配项的从零开始的索引。
        /// </summary>
        /// <param name="item">要在 System.Collections.Generic.List&lt;T&gt; 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在整个 System.Collections.Generic.List&lt;T&gt; 中找到 item 的第一个匹配项，则为该项的从零开始的索引；否则为-1。</returns>
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        /// <summary>
        /// 将元素插入 System.Collections.Generic.List&lt;T&gt; 的指定索引处。
        /// </summary>
        /// <param name="index">从零开始的索引，应在该位置插入 item。</param>
        /// <param name="item">要插入的对象。对于引用类型，该值可以为 null。</param>
        public void Insert(int index, T item)
        {
            item.Parent = this.Parent;
            list.Insert(index, item);
            //item.RefreshRelativeTransform();

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<T>(item)); }
        }

        /// <summary>
        /// 移除 System.Collections.Generic.List&lt;T&gt; 的指定索引处的元素。
        /// </summary>
        /// <param name="index">要移除的元素的从零开始的索引。</param>
        public void RemoveAt(int index)
        {
            T obj = list[index];
            list.RemoveAt(index);
            obj.Parent = default(T);
            //obj.RefreshRelativeTransform();

            EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            { ItemRemoved(this, new RemoveItemEventArgs<T>(obj)); }
        }

        /// <summary>
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引。</param>
        /// <returns>指定索引处的元素。</returns>
        public T this[int index]
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
        /// 将对象添加到 System.Collections.Generic.List&lt;T&gt; 的结尾处。
        /// </summary>
        /// <param name="item">要添加到 System.Collections.Generic.List&lt;T&gt; 的末尾处的对象。对于引用类型，该值可以为 null。</param>
        public void Add(T item)
        {
            item.Parent = this.Parent;
            list.Add(item);
            //item.RefreshRelativeTransform();

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            { ItemAdded(this, new AddItemEventArgs<T>(item)); }
        }

        /// <summary>
        /// 将指定集合的元素添加到 System.Collections.Generic.List&lt;T&gt; 的末尾。
        /// </summary>
        /// <param name="items">一个集合，其元素应被添加到 System.Collections.Generic.List&lt;T&gt; 的末尾。集合自身不能为 null，但它可以包含为null 的元素（如果类型 T 为引用类型）。</param>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                item.Parent = this.Parent;
            }
            list.AddRange(items);
            foreach (var item in items)
            {
                //item.RefreshRelativeTransform();
            }

            EventHandler<AddItemEventArgs<T>> ItemAdded = this.ItemAdded;
            if (ItemAdded != null)
            {
                foreach (var item in items)
                {
                    ItemAdded(this, new AddItemEventArgs<T>(item));
                }
            }
        }

        /// <summary>
        /// 从 System.Collections.Generic.List&lt;T&gt;中移除所有元素。
        /// </summary>
        public void Clear()
        {
            var array = this.list.ToArray();
            this.list.Clear();

            foreach (var item in array)
            {
                item.Parent = default(T);
                //item.RefreshRelativeTransform();
            }

            EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
            if (ItemRemoved != null)
            {
                foreach (var item in array)
                {
                    ItemRemoved(this, new RemoveItemEventArgs<T>(item));
                }
            }
        }

        /// <summary>
        /// 确定某元素是否在 System.Collections.Generic.List&lt;T&gt;中。
        /// </summary>
        /// <param name="item">要在 System.Collections.Generic.List&lt;T&gt; 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在 System.Collections.Generic.List&lt;T&gt; 中找到 item，则为 true，否则为 false。</returns>
        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// 将整个 System.Collections.Generic.List&lt;T&gt; 复制到兼容的一维数组中，从目标数组的指定索引位置开始放置。
        /// </summary>
        /// <param name="array">作为从 System.Collections.Generic.List&lt;T&gt; 复制的元素的目标位置的一维 System.Array。System.Array必须具有从零开始的索引。</param>
        /// <param name="arrayIndex">array 中从零开始的索引，从此处开始复制。</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 获取 System.Collections.Generic.List&lt;T&gt; 中实际包含的元素数。
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// 获取一个值，该值指示 System.Collections.Generic.ICollection&lt;T&gt; 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get { return ((ICollection<T>)(this.list)).IsReadOnly; }
        }

        /// <summary>
        /// 从 System.Collections.Generic.List&lt;T&gt; 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="item">要从 System.Collections.Generic.List&lt;T&gt; 中移除的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果成功移除 item，则为 true；否则为 false。如果在 System.Collections.Generic.List&lt;T&gt; 中没有找到item，该方法也会返回 false。</returns>
        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            if (result)
            {
                item.Parent = default(T);
                //item.RefreshRelativeTransform();

                EventHandler<RemoveItemEventArgs<T>> ItemRemoved = this.ItemRemoved;
                if (ItemRemoved != null)
                { ItemRemoved(this, new RemoveItemEventArgs<T>(item)); }
            }

            return result;
        }

        /// <summary>
        /// 返回循环访问 System.Collections.Generic.List&lt;T&gt; 的枚举数。
        /// </summary>
        /// <returns>用于 System.Collections.Generic.List&lt;T&gt; 的 System.Collections.Generic.List&lt;T&gt;.Enumerator。</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
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
            return string.Format("Count: {0}", this.list.Count);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddItemEventArgs<T> : EventArgs
    {
        /// <summary>
        /// newly added item.
        /// </summary>
        public T NewItem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newItem"></param>
        public AddItemEventArgs(T newItem)
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
    public class RemoveItemEventArgs<T> : EventArgs
    {
        /// <summary>
        /// removed item.
        /// </summary>
        public T RemovedItem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="removedItem"></param>
        public RemoveItemEventArgs(T removedItem)
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