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
        /// <param name="order"></param>
        /// <returns></returns>
        public static IEnumerable<T> Traverse<T>(this ITreeNode<T> treeNode, TraverseOrder order)
            where T : ITreeNode<T>
        {
            switch (order)
            {
                case TraverseOrder.Pre:
                    foreach (var item in PreorderTraverse(treeNode))
                    {
                        yield return item;
                    }
                    break;
                case TraverseOrder.Post:
                    foreach (var item in PostorderTraverse(treeNode))
                    {
                        yield return item;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// traverse every item in the tree node in post-order.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> PostorderTraverse<T>(ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            for (int i = 0; i < treeNode.Children.Count; i++)
            {
                T child = treeNode.Children[i];
                IEnumerable<T> enumerable = PostorderTraverse(child);
                foreach (T item in enumerable)
                {
                    yield return item;
                }
            }

            yield return treeNode.Self;
        }

        /// <summary>
        /// traverse every item in the tree node in pre-order.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> PreorderTraverse<T>(ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            yield return treeNode.Self;

            for (int i = 0; i < treeNode.Children.Count; i++)
            {
                T child = treeNode.Children[i];
                IEnumerable<T> enumerable = PreorderTraverse(child);
                foreach (T item in enumerable)
                {
                    yield return item;
                }
            }
        }

        ///// <summary>
        ///// traverse every item in the tree node recursively.
        ///// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="treeNode"></param>
        ///// <returns></returns>
        //public static IEnumerable<T> DFSEnumerateRecursively<T>(this ITreeNode<T> treeNode)
        //    where T : ITreeNode<T>
        //{
        //    yield return treeNode.Self;
        //    for (int i = 0; i < treeNode.Children.Count; i++)
        //    {
        //        T child = treeNode.Children[i];
        //        IEnumerable<T> enumerable = DFSEnumerateRecursively(child);
        //        foreach (T item in enumerable)
        //        {
        //            yield return item;
        //        }
        //    }
        //}

        ///// <summary>
        ///// traverse every item in the tree node non-recursively.
        ///// <para>Use this when <paramref name="treeNode"/>'s structure is NOT flat.</para>
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="treeNode"></param>
        ///// <returns></returns>
        //public static IEnumerable<T> BFSEnumerateNonRecursively<T>(this ITreeNode<T> treeNode)
        //    where T : ITreeNode<T>
        //{
        //    var stack = new Stack<ITreeNode<T>>();
        //    stack.Push(treeNode);
        //    while (stack.Count > 0)
        //    {
        //        ITreeNode<T> current = stack.Pop();
        //        foreach (T item in current.Children)
        //        {
        //            stack.Push(item);
        //        }
        //        yield return current.Self;
        //    }
        //}
    }

    /// <summary>
    /// traverse order.
    /// </summary>
    public enum TraverseOrder
    {
        /// <summary>
        /// pre-order traverse.
        /// </summary>
        Pre,

        /// <summary>
        /// post-order traverse.
        /// </summary>
        Post,
    }
}