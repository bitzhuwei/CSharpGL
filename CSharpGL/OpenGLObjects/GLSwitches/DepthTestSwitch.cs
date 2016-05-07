using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class DepthTestSwitch : GLSwitch
    {

        byte originalEnabled;

        public DepthTestSwitch() : this(true) { }

        public DepthTestSwitch(bool enable)
        {
            this.Enable = enable;
        }

        public override string ToString()
        {
            return string.Format("Depth Test: {0}", this.Enable);
        }

        public override void On()
        {
            this.originalEnabled = GL.IsEnabled(GL.GL_DEPTH_TEST);

            if (this.originalEnabled == 0)
            {
                if (this.Enable)
                { GL.Enable(GL.GL_DEPTH_TEST); }
            }
            else
            {
                if (!this.Enable)
                { GL.Disable(GL.GL_DEPTH_TEST); }
            }
        }

        public override void Off()
        {
            if (this.originalEnabled == 0)
            {
                if (this.Enable)
                { GL.Disable(GL.GL_DEPTH_TEST); }
            }
            else
            {
                if (!this.Enable)
                { GL.Enable(GL.GL_DEPTH_TEST); }
            }
        }

        public bool Enable { get; set; }
    }

}
