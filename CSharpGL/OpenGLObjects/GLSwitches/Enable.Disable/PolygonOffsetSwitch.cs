using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class PolygonOffsetSwitch : EnableSwitch
    {

        public PolygonOffsetSwitch() : this(PolygonOffset.Fill, true) { }

        public PolygonOffsetSwitch(PolygonOffset mode, bool pullNear)
            :base((uint)mode, true)
        {
            this.PullNear = pullNear; 
        }

        public override string ToString()
        {
            return string.Format("Polygon Offset: {0} {1}", 
                (PolygonOffset)this.Capacity,
                this.PullNear ? "Near" : "Far");
        }

        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                float value = this.PullNear ? -1.0f : 1.0f;
                OpenGL.PolygonOffset(value, value);
            }
        }

        public bool PullNear { get; set; }
    }

}
