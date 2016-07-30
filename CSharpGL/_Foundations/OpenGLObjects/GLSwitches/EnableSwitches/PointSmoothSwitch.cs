using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PointSmoothSwitch : EnableSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public PointSmoothSwitch()
            : base(OpenGL.GL_POINT_SMOOTH, true)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public PointSmoothSwitch(bool enableCapacity)
            : base(OpenGL.GL_POINT_SMOOTH, enableCapacity)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_POINT_SMOOTH);"; }
            else
            { return "OpenGL.Disable(GL_POINT_SMOOTH);"; }
        }

    }

}
