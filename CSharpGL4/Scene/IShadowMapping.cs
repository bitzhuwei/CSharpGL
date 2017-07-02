using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IShadowMapping
    {
        /// <summary>
        /// 
        /// </summary>
        bool EnableShadowMapping { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        void RenderForShadowMapping(RenderEventArgs arg);
    }

}