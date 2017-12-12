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

        private byte accumBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte AccumBits
        {
            get { return accumBits; }
            set { accumBits = value; }
        }
        private byte accumRedBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte AccumRedBits
        {
            get { return accumRedBits; }
            set { accumRedBits = value; }
        }
        private byte accumGreenBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte AccumGreenBits
        {
            get { return accumGreenBits; }
            set { accumGreenBits = value; }
        }
        private byte accumBlueBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte AccumBlueBits
        {
            get { return accumBlueBits; }
            set { accumBlueBits = value; }
        }
        private byte accumAlphaBits = 0;
        /// <summary>
        /// initi with accumulation buffer?
        /// </summary>
        public byte AccumAlphaBits
        {
            get { return accumAlphaBits; }
            set { accumAlphaBits = value; }
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
