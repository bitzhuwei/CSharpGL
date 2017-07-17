using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Base type for rendering actions.
    /// </summary>
    public abstract class ActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        public RendererBase RootElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Render();

        /// <summary>
        /// Base type for rendering actions.
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public ActionBase(RendererBase rootElement, ICamera camera)
        {
            this.RootElement = rootElement;
            this.Camera = camera;
        }

    }
}
