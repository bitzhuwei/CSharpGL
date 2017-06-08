using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLCanvas
    {
        /// <summary>
        /// 
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Repaint();

        /// <summary>
        /// 
        /// </summary>
        IGLRenderContext RenderContext { get; }
    }
}
