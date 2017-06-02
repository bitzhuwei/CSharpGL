namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// <para>General tree node.</para>
    /// </summary>
    public interface ITreeNode<T>
    {
        /// <summary>
        /// parent node.
        /// </summary>
        ITreeNode<T> Parent { get; set; }

        /// <summary>
        /// children nodes.
        /// </summary>
        TreeNodeChildren<T> Children { get; }
    }
}