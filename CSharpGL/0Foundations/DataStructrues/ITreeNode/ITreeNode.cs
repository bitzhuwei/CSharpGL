namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// <para>General tree node.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeNode<T>
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