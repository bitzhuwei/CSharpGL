using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace System
{
    /// <summary>
    /// 通用的树结点。
    /// </summary>
    /// <typeparam name="T">要实现<see cref="ITreeNode"/>接口的类型</typeparam>
    public interface ITreeNode<T> where T : ITreeNode<T>
    {
        T Self { get; }

        /// <summary>
        /// 父结点。
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// 子结点。
        /// </summary>
        IList<T> Children { get; }
    }
}
