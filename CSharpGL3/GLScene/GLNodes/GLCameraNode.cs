using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// map to 'in vec3 inPosition;' in vertex shader.
    /// </summary>
    public sealed class GLCameraNode : GLNode
    {

        private static readonly Type type = typeof(GLCameraNode);
        internal override Type SelfTypeCache { get { return type; } }

        public GLCameraNode() { }

    }
}
