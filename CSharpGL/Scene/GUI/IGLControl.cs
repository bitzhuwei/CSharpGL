using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLControl
    {
        /// <summary>
        /// 
        /// </summary>
        IGLControl Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<IGLControl> Children { get; }

        /// <summary>
        /// 
        /// </summary>
        ivec2 LeftUp { get; set; }

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
        void Layout();

        /// <summary>
        /// 
        /// </summary>
        IGLControlRenderer Renderer { get; set; }
    }
}
