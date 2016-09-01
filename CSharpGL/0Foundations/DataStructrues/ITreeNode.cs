namespace CSharpGL
{
    /// <summary>
    /// 通用的树结点。
    /// </summary>
    /// <typeparam name="T">要实现<see cref="ITreeNode&lt;T&gt;"/>接口的类型</typeparam>
    public interface ITreeNode<T> where T : ITreeNode<T>
    {
        /// <summary>
        /// this.
        /// </summary>
        T Self { get; }

        /// <summary>
        /// parent node.
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// children nodes.
        /// </summary>
        ChildList<T> Children { get; }
    }
}