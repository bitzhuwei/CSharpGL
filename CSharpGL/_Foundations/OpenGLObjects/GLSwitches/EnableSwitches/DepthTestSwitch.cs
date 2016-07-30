using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class DepthTestSwitch : EnableSwitch
    {

        /// <summary>
        /// 
        /// </summary>
        public DepthTestSwitch()
            : base(OpenGL.GL_DEPTH_TEST, true)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DepthTestSwitch(bool enableCapacity)
            : base(OpenGL.GL_DEPTH_TEST, enableCapacity)
        { }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_DEPTH_TEST);"; }
            else
            { return "OpenGL.Disable(GL_DEPTH_TEST);"; }
        }

    }

}
