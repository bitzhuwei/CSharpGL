using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 渲染事件的参数。
    /// </summary>
    public class RenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public RenderEventArgs(RenderModes renderMode, IScientificCamera camera)
        {
            this.RenderMode = renderMode;
            this.Camera = camera;
        }

        public IScientificCamera Camera { get; set; }

        public RenderModes RenderMode { get; set; }
    }
}
