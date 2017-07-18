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
        public SceneNodeBase RootElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPass">Is This the first pass of rendering?</param>
        public abstract void Render(bool firstPass);

        /// <summary>
        /// Base type for rendering actions.
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public ActionBase(SceneNodeBase rootElement, ICamera camera)
        {
            this.RootElement = rootElement;
            this.Camera = camera;
        }

    }
}
