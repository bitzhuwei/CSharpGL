namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// </summary>
    /// <typeparam name="T">要实现<see cref="ITreeNode&lt;T&gt;"/>接口的类型</typeparam>
    public interface ITreeNode<T>// where T : ITreeNode<T>
    {
        /// <summary>
        /// parent node.
        /// </summary>
        ITreeNode<T> Parent { get; set; }

        /// <summary>
        /// Content of this node.
        /// </summary>
        T Content { get; }

        /// <summary>
        /// children nodes.
        /// </summary>
        ChildList<T> Children { get; }
    }
}