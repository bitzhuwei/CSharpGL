using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
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
    }
}
