using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class ModernNode
    {
        private const string strModernNode = "ModernNode";

        /// <summary>
        /// 
        /// </summary>
        [Category(strModernNode)]
        [Description("rendering in multiple ways.")]
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// index buffer is accessable randomly or only by frame.
        /// </summary>
        [Category(strModernNode)]
        [Description("index buffer is accessable randomly or only by frame.")]
        public IndexBuffer.ControlMode ControlMode { get; set; }
    }
}