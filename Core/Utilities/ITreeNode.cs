using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 通用的树结点。
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// 父结点。
        /// </summary>
        ITreeNode Parent { get; }

        /// <summary>
        /// 子结点。
        /// </summary>
        IList<ITreeNode> Children { get; }
    }
}
