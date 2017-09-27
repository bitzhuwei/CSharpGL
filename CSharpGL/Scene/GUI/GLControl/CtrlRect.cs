using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control. // TODO: what's this?
    /// </summary>
    public class CtrlRect : IGLControl
    {
        #region IGLControl 成员

        /// <summary>
        /// 
        /// </summary>
        public IGLControl Parent { get; set; }

        private List<IGLControl> children = new List<IGLControl>();
        /// <summary>
        /// 
        /// </summary>
        public List<IGLControl> Children { get { return this.children; } }

        /// <summary>
        /// 
        /// </summary>
        public ivec2 LeftUp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Layout() { }

        /// <summary>
        /// 
        /// </summary>
        public IGLControlRenderer Renderer { get; set; }

        #endregion
    }
}
