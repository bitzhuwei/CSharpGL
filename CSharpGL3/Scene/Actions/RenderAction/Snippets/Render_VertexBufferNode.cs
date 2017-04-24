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
    public class Render_VertexBufferNode : Snippet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public override void BeforeChildren(SceneAction action, GLNode node)
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
        public override void AfterChildren(SceneAction action, GLNode node)
        {
            Debug.Assert(action.ThisTypeCache == typeof(RenderAction));
            Debug.Assert(node.ThisTypeCache == typeof(GLVertexBufferNode));

            throw new NotImplementedException();
        }
    }
}
