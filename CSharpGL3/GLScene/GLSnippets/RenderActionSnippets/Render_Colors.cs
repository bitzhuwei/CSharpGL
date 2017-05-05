using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class Render_Colors : GLSnippet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        public override void BeforeChildren(GLAction glAction, GLNode glNode)
        {
            var action = glAction as RenderAction;
            var node = glNode as GLColorsNode;
            Debug.Assert(action != null);
            Debug.Assert(node != null);

            VertexBuffer vertexAttributeBuffer = node.GetVertexAttributeBuffer();
            action.Context.vertexAttributeBuffers.Add(vertexAttributeBuffer);
        }

    }
}
