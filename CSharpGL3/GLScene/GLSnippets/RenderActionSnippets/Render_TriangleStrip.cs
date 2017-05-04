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
    public class Render_TriangleStrip : GLSnippet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        public override void BeforeChildren(GLAction glAction, GLNode glNode)
        {
            var action = glAction as RenderAction;
            var node = glNode as GLTriangleStripNode;
            Debug.Assert(action != null);
            Debug.Assert(node != null);

            if (action.Context.vertexArrayObject == null)
            {
                VertexArrayObject vao = node.GetVertexArrayObject(action.Context.indexBuffer, action.Context.vertexAttributeBuffers.ToArray());
                action.Context.vertexArrayObject = vao;
            }

            action.Context.Render();
        }

    }
}
