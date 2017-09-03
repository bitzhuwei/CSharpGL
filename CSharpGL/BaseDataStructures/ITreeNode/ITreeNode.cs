namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// <para>General tree node.</para>
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// parent node.
        /// </summary>
        ITreeNode Parent { get; set; }

        /// <summary>
        /// children nodes.
        /// </summary>
        TreeNodeChildren Children { get; }
    }
}