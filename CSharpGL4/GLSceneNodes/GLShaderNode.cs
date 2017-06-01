using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class GLShaderNode : GLSceneNode
    {
        private static readonly Type type = typeof(GLShaderNode);
        internal override Type SelfTypeCache { get { return type; } }
    }
}
