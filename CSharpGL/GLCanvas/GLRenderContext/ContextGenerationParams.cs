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

        private byte stencilBits = 8;
        /// <summary>
        /// 
        /// </summary>
        public byte StencilBits
        {
            get { return stencilBits; }
            set { stencilBits = value; }
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

        private bool useStencilBuffer = false;
        /// <summary>
        /// attach a stencil buffer to FBO in render context?
        /// </summary>
        public bool UseStencilBuffer
        {
            get { return useStencilBuffer; }
            set { useStencilBuffer = value; }
        }
    }
}
