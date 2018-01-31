using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GLControl
    {
        /// <summary>
        /// Reset controls in OpenGL canvas.
        /// 
        /// <para>This coordinate system is shown as below.</para>
        /// <para>   /\ y</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |-----------------&gt;x</para>
        /// <para>(0, 0)</para>
        /// </summary>
        /// <param name="node"></param>
        internal static void Reset(GLControl node)
        {
            if (node == null) { return; }

            var parent = node.Parent;
            if (parent != null)
            {
                node.parentLastWidth = parent.width;
                node.parentLastHeight = parent.height;
            }

            foreach (var item in node.Children)
            {
                GLControl.Reset(item);
            }
        }

    }
}
