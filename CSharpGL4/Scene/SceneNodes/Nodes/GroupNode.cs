using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains some nodes in its children.
    /// </summary>
    public class GroupNode : SceneNodeBase
    {
        /// <summary>
        /// contains some nodes in its children.
        /// </summary>
        /// <param name="nodes"></param>
        public GroupNode(params SceneNodeBase[] nodes)
        {
            foreach (var item in nodes)
            {
                this.Children.Add(item);
            }
        }
    }
}
