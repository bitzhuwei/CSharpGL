using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains some renderers in its children.
    /// </summary>
    public class GroupNode : SceneNodeBase
    {
        /// <summary>
        /// contains some renderers in its children.
        /// </summary>
        /// <param name="renderers"></param>
        public GroupNode(params SceneNodeBase[] renderers)
        {
            foreach (var item in renderers)
            {
                this.Children.Add(item);
            }
        }
    }
}
