using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class ContextGenerationParams
    {
        private byte colorBits = 32;
        /// <summary>
        /// 
        /// </summary>
        public byte ColorBits
        {
            get { return colorBits; }
            set { colorBits = value; }
        }

        private byte depthBits = 24;
        /// <summary>
        /// 
        /// </summary>
        public byte DepthBits
        {
            get { return depthBits; }
            set { depthBits = value; }
        }

        private bool updateContextVersion = true;
        /// <summary>
        /// update render context version?
        /// </summary>
        public bool UpdateContextVersion
        {
            get { return updateContextVersion; }
            set { updateContextVersion = value; }
        }

        private byte stencilBits = 0;
        /// <summary>
        /// initi with stencil buffer?
        /// </summary>
        public byte StencilBits
        {
            get { return stencilBits; }
            set { stencilBits = value; }
        }
    }
}
