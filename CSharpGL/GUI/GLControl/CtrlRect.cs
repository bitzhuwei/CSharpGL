using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
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
        public void Layout()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        public void Render(IControlRenderer renderer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
