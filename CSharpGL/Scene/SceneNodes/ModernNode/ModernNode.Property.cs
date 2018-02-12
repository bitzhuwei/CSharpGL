using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class ModernNode
    {
        private const string strModernNode = "ModernNode";

        /// <summary>
        /// Rendering something using multiple GLSL shader programs and VBO(VAO).
        /// </summary>
        [Category(strModernNode)]
        [Description("Rendering something using multiple GLSL shader programs and VBO(VAO).")]
        public ModernRenderUnit RenderUnit { get; private set; }

    }
}