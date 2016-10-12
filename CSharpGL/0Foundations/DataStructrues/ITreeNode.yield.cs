using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static partial class ITreeNodeHelper
    {
        /// <summary>
        /// traverse every item in the tree node recursively.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> DFSEnumerateRecursively<T>(this ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            yield return treeNode.Self;
            for (int i = 0; i < treeNode.Children.Count; i++)
            {
                T child = treeNode.Children[i];
                IEnumerable<T> enumerable = DFSEnumerateRecursively(child);
                foreach (T item in enumerable)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// traverse every item in the tree node non-recursively.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is NOT flat.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> BFSEnumerateNonRecursively<T>(this ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            var stack = new Stack<ITreeNode<T>>();
            stack.Push(treeNode);
            while (stack.Count > 0)
            {
                ITreeNode<T> current = stack.Pop();
                foreach (T item in current.Children)
                {
                    stack.Push(item);
                }
                yield return current.Self;
            }
        }
    }
}