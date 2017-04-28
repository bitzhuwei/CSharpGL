using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static partial class ILayoutHelper
    {
        /// <summary>
        /// traverse every child in the tree appliedNode recursively.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static IEnumerable<ILayout<T>> Traverse<T>(this ILayout<T> treeNode, TraverseOrder order)
        {
            switch (order)
            {
                case TraverseOrder.Pre:
                    foreach (ILayout<T> item in PreorderTraverse(treeNode))
                    {
                        yield return item;
                    }
                    break;

                case TraverseOrder.Post:
                    foreach (ILayout<T> item in PostorderTraverse(treeNode))
                    {
                        yield return item;
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// traverse every child in the tree appliedNode in post-order.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<ILayout<T>> PostorderTraverse<T>(ILayout<T> treeNode)
        {
            if (treeNode != null)
            {
                for (int i = 0; i < treeNode.Children.Count; i++)
                {
                    ILayout<T> child = treeNode.Children[i];
                    IEnumerable<ILayout<T>> enumerable = PostorderTraverse(child);
                    foreach (ILayout<T> item in enumerable)
                    {
                        yield return item;
                    }
                }

                yield return treeNode;
            }
        }

        /// <summary>
        /// traverse every child in the tree appliedNode in pre-order.
        /// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<ILayout<T>> PreorderTraverse<T>(ILayout<T> treeNode)
        {
            if (treeNode != null)
            {
                yield return treeNode;

                for (int i = 0; i < treeNode.Children.Count; i++)
                {
                    ILayout<T> child = treeNode.Children[i];
                    IEnumerable<ILayout<T>> enumerable = PreorderTraverse(child);
                    foreach (ILayout<T> item in enumerable)
                    {
                        yield return item;
                    }
                }
            }
        }

        ///// <summary>
        ///// traverse every child in the tree appliedNode recursively.
        ///// <para>Use this when <paramref name="treeNode"/>'s structure is flat.</para>
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="treeNode"></param>
        ///// <returns></returns>
        //public static IEnumerable<T> DFSEnumerateRecursively<T>(this ITreeNode treeNode)
        //    where T : ITreeNode
        //{
        //    yield return treeNode.Value;
        //    for (int i = 0; i < treeNode.Children.Count; i++)
        //    {
        //        T child = treeNode.Children[i];
        //        IEnumerable<T> enumerable = DFSEnumerateRecursively(child);
        //        foreach (T child in enumerable)
        //        {
        //            yield return child;
        //        }
        //    }
        //}

        ///// <summary>
        ///// traverse every child in the tree appliedNode non-recursively.
        ///// <para>Use this when <paramref name="treeNode"/>'s structure is NOT flat.</para>
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="treeNode"></param>
        ///// <returns></returns>
        //public static IEnumerable<T> BFSEnumerateNonRecursively<T>(this ITreeNode treeNode)
        //    where T : ITreeNode
        //{
        //    var stack = new Stack<ITreeNode>();
        //    stack.Push(treeNode);
        //    while (stack.Count > 0)
        //    {
        //        ITreeNode current = stack.Pop();
        //        foreach (T child in current.Children)
        //        {
        //            stack.Push(child);
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