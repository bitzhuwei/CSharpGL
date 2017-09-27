using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Control(widget) in OpenGL window.
    /// </summary>
    public interface IGLControl
    {
        /// <summary>
        /// Parent control.
        /// </summary>
        IGLControl Parent { get; set; }

        /// <summary>
        /// Children controls.
        /// </summary>
        List<IGLControl> Children { get; }

        /// <summary>
        /// Left up position(relative to Parent Control).
        /// </summary>
        ivec2 LeftUp { get; set; }

        /// <summary>
        /// Width.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Perform layout for this control.
        /// </summary>
        void Layout();

        /// <summary>
        /// Who renders this control?
        /// </summary>
        IGLControlRenderer Renderer { get; set; }
    }
}
