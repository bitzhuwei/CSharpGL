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
    public class Render_VertexBufferNode : GLSnippet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public override void BeforeChildren(GLAction action, GLNode node)
        {
            Debug.Assert(action.ThisTypeCache == typeof(RenderAction));
            Debug.Assert(node.ThisTypeCache == typeof(GLVertexBufferNode));

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public override void AfterChildren(GLAction action, GLNode node)
        {
            Debug.Assert(action.ThisTypeCache == typeof(RenderAction));
            Debug.Assert(node.ThisTypeCache == typeof(GLVertexBufferNode));

            throw new NotImplementedException();
        }
    }
}
