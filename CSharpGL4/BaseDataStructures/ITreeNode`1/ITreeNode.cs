namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// <para>General tree node.</para>
    /// </summary>
    public interface ITreeNode<T> where T : class, ITreeNode<T>
    {
        /// <summary>
        /// parent node.
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// Self.
        /// </summary>
        T ThisObj { get; }

        /// <summary>
        /// children nodes.
        /// </summary>
        TreeNodeChildren<T> Children { get; }
    }
}