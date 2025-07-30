using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL.Windows {
    /// <summary>
    /// 
    /// </summary>
    public class ContextGenerationParams {
        public byte colorBits = 32;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte accumBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte accumRedBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte accumGreenBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte accumBlueBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte accumAlphaBits = 0;
        public byte depthBits = 24;
        /// <summary>
        /// update render context version?
        /// </summary>
        public bool updateContextVersion = true;
        /// <summary>
        /// initi with stencil buffer?
        /// </summary>
        public byte stencilBits = 0;
    }
}
