using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A GLSL vertex shader.
    /// </summary>
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class VertexShader : Shader
    {

        /// <summary>
        /// A GLSL vertex shader.
        /// </summary>
        /// <param name="source">Source code.</param>
        /// <param name="attributeNames">"inPosition" in "in vec3 inPosition" in shader code.</param>
        public VertexShader(string source, params string[] attributeNames)
        {
            this.Source = source;
            this.AttributeNames = attributeNames;
        }

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <param name="source"></param>
        public override void Initialize()
        {
            base.Create((uint)ShaderType.VertexShader, this.Source);
        }

        /// <summary>
        /// Source Code.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// "inPosition" in "in vec3 inPosition" in shader code.
        /// </summary>
        public string[] AttributeNames { get; private set; }

    }
}