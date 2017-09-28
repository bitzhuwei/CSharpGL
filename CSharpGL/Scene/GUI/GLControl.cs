using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Control(widget) in OpenGL window.
    /// </summary>
    public abstract class GLControl
    {

        /// <summary>
        /// Parent control.
        /// </summary>
        public GLControl Parent { get; set; }

        private List<GLControl> children = new List<GLControl>();
        /// <summary>
        /// Children controls.
        /// </summary>
        public List<GLControl> Children { get { return this.children; } }

        /// <summary>
        /// Left distance to parent control.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Bottom distance to parent control.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Width of this control.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of this control.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Layout for this control.
        /// </summary>
        public virtual void Layout() { }

        /// <summary>
        /// Who renders this control?
        /// </summary>
        public IGLControlRenderer Renderer { get; set; }

    }
}
