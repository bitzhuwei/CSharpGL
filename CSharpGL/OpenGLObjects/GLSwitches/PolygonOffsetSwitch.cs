using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonOffsetSwitch : EnableSwitch
    {
        byte originalEnabled;

        public PolygonOffsetSwitch() : this(PolugonOffset.Fill, true) { }

        public PolygonOffsetSwitch(PolugonOffset mode, bool pullNear)
            :base((uint)mode, true)
        {
            this.PullNear = pullNear; 
        }

        public override string ToString()
        {
            return string.Format("Polygon Offset: {0} {1}", 
                (PolugonOffset)this.Cap,
                this.PullNear ? "Near" : "Far");
        }

        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.EnableCap)
            {
                float value = this.PullNear ? -1.0f : 1.0f;
                GL.PolygonOffset(value, value);
            }
        }

        public bool PullNear { get; set; }
    }

}
