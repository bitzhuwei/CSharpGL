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
        private byte colorBitDepth = 32;
        /// <summary>
        /// 
        /// </summary>
        public byte ColorBitDepth
        {
            get { return colorBitDepth; }
            set { colorBitDepth = value; }
        }
    }
}
