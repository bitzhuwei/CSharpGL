using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class Render_VertexBufferNode : Snippet
    {
        public override void Apply(SceneAction action, GLNode node)
        {
            Debug.Assert(action.ThisTypeCache == typeof(RenderAction));
            Debug.Assert(node.ThisTypeCache == typeof(GLVertexBufferNode));

            throw new NotImplementedException();
        }
    }
}
