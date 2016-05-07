using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class CullFaceSwitch : GLSwitch
    {

        byte originalEnabled;

        public CullFaceSwitch() : this(true) { }

        public CullFaceSwitch(bool enable)
        {
            this.Enable = enable;
        }

        public override string ToString()
        {
            return string.Format("Cull Face: {0}", this.Enable);
        }

        public override void On()
        {
            this.originalEnabled = GL.IsEnabled(GL.GL_CULL_FACE);

            if (this.originalEnabled == 0)
            {
                if (this.Enable)
                { GL.Enable(GL.GL_CULL_FACE); }
            }
            else
            {
                if (!this.Enable)
                { GL.Disable(GL.GL_CULL_FACE); }
            }
        }

        public override void Off()
        {
            if (this.originalEnabled == 0)
            {
                if (this.Enable)
                { GL.Disable(GL.GL_CULL_FACE); }
            }
            else
            {
                if (!this.Enable)
                { GL.Enable(GL.GL_CULL_FACE); }
            }
        }

        public bool Enable { get; set; }
    }

}
