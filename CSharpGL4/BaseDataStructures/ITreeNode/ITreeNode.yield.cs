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
        /// <param name="treeNode"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static IEnumerable<ITreeNode<T>> Traverse<T>(this ITreeNode<T> treeNode, TraverseOrder order) where T : class, ITreeNode<T>
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
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<ITreeNode<T>> PostorderTraverse<T>(ITreeNode<T> treeNode) where T : class, ITreeNode<T>
        {
            if (treeNode != null)
            {
                for (int i = 0; i < treeNode.Children.Count; i++)
                {
                    ITreeNode<T> child = treeNode.Children[i];
                    IEnumerable<ITreeNode<T>> enumerable = PostorderTraverse(child);
                    foreach (var item in enumerable)
                    {
                        yield return item;
                    }
                }

                yield return treeNode;
            }
        }

        /// <summary>
        /// traverse every item in the tree node in pre-order.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<ITreeNode<T>> PreorderTraverse<T>(ITreeNode<T> treeNode) where T : class, ITreeNode<T>
        {
            if (treeNode != null)
            {
                yield return treeNode;

                for (int i = 0; i < treeNode.Children.Count; i++)
                {
                    ITreeNode<T> child = treeNode.Children[i];
                    IEnumerable<ITreeNode<T>> enumerable = PreorderTraverse(child);
                    foreach (var item in enumerable)
                    {
                        yield return item;
                    }
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
        //public static IEnumerable<T> DFSEnumerateRecursively<T>(this ITreeNode treeNode)where T : class , ITreeNode<T>
        //    where T : ITreeNode
        //{
        //    yield return treeNode.Value;
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
        //public static IEnumerable<T> BFSEnumerateNonRecursively<T>(this ITreeNode treeNode)where T : class , ITreeNode<T>
        //    where T : ITreeNode
        //{
        //    var stack = new Stack<ITreeNode>();
        //    stack.Push(treeNode);
        //    while (stack.Count > 0)
        //    {
        //        ITreeNode current = stack.Pop();
        //        foreach (T item in current.Children)
        //        {
        //            stack.Push(item);
        //        }
        //        yield return current.Value;
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