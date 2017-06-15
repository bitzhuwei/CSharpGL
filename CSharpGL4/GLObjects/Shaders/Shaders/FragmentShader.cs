using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A GLSL fragment shader.
    /// </summary>
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class FragmentShader : Shader
    {

        /// <summary>
        /// A GLSL fragment shader.
        /// </summary>
        /// <param name="source">Source code.</param>
        public FragmentShader(string source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <param name="source"></param>
        protected override void DoInitialize()
        {
            base.Create((uint)ShaderType.FragmentShader, this.Source);
        }

        /// <summary>
        /// Source Code.
        /// </summary>
        public string Source { get; private set; }

    }
}