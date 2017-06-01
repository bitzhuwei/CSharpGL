using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// A node in scene that maintains some <see cref="GLState"/>s.
    /// </summary>
    public abstract class LightModelNode : SceneNode
    {
        public abstract ShaderProgram GetShaderProgram();

        /// <summary>
        /// Names of aLl attributes in vertex shader.
        /// </summary>
        /// <returns></returns>
        public abstract string[] GetAttributeNames();
    }
}
