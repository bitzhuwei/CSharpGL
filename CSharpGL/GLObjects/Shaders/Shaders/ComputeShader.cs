using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A GLSL compute shader.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class ComputeShader : Shader
    {

        /// <summary>
        /// A GLSL compute shader.
        /// </summary>
        /// <param name="source">Source code.</param>
        public ComputeShader(string source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        protected override void DoInitialize()
        {
            base.Create((uint)ShaderType.ComputeShader, this.Source);
        }

        /// <summary>
        /// Source Code.
        /// </summary>
        public string Source { get; private set; }

    }
}