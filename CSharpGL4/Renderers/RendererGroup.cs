using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains some renderers in its children.
    /// </summary>
    public class RendererGroup : RendererBase
    {
        /// <summary>
        /// contains some renderers in its children.
        /// </summary>
        /// <param name="renderers"></param>
        public RendererGroup(params RendererBase[] renderers)
        {
            foreach (var item in renderers)
            {
                this.Children.Add(item);
            }
        }
    }
}
