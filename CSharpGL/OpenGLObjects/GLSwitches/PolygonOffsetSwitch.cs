using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonOffsetSwitch : GLSwitch
    {
        byte originalEnabled;

        public PolygonOffsetSwitch() : this(PolugonOffset.Fill, true) { }

        public PolygonOffsetSwitch(PolugonOffset mode, bool pullNear)
        {
            this.Mode = mode; this.PullNear = pullNear; 
        }

        public override string ToString()
        {
            return string.Format("Polygon Offset: {0} {1}", this.Mode,
                this.PullNear ? "Near" : "Far");
        }

        public override void On()
        {
            this.originalEnabled = GL.IsEnabled((uint)this.Mode);

            if (this.originalEnabled == 0)
            { GL.Enable((uint)this.Mode); }

            float value = this.PullNear ? -1.0f : 1.0f;
            GL.PolygonOffset(value, value);
        }

        public override void Off()
        {
            if (this.originalEnabled == 0)
            { GL.Disable((uint)this.Mode); }
        }

        public PolugonOffset Mode { get; set; }

        public bool PullNear { get; set; }
    }

}
