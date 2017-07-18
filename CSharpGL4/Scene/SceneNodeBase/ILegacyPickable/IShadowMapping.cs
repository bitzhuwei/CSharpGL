using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Supports shadow mapping.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IShadowMapping
    {
        /// <summary>
        /// Is casting shadow for this object enabled?
        /// </summary>
        bool EnableShadowMapping { get; set; }

        /// <summary>
        /// Cast shadow to specified texture in framebuffer.
        /// </summary>
        /// <param name="arg"></param>
        void CastShadow(RenderEventArgs arg);
    }

}