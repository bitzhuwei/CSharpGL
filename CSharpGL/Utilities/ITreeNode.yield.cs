using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace System
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
        public static IEnumerable<T> DFSEnumerateRecursively<T>(ITreeNode<T> treeNode)
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
        public static IEnumerable<T> BFSEnumerateNonRecursively<T>(ITreeNode<T> treeNode)
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
