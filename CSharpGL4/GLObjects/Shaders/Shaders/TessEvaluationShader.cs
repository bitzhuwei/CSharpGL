using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A GLSL fragment shader.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class TessEvaluationShader : Shader
    {

        /// <summary>
        /// A GLSL fragment shader.
        /// </summary>
        /// <param name="source">Source code.</param>
        public TessEvaluationShader(string source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        protected override void DoInitialize()
        {
            base.Create((uint)ShaderType.TessEvaluationShader, this.Source);
        }

        /// <summary>
        /// Source Code.
        /// </summary>
        public string Source { get; private set; }

    }
}