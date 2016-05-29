using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
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

        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_POINT_SMOOTH);"; }
            else
            { return "OpenGL.Disable(GL_POINT_SMOOTH);"; }
        }

    }

}
