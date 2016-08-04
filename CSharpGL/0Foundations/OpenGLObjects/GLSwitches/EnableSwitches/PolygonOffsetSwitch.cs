using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public abstract class PolygonOffsetSwitch : EnableSwitch
    {

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetSwitch() : this(PolygonOffset.Fill, true) { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="pullNear"></param>
        public PolygonOffsetSwitch(PolygonOffset mode, bool pullNear)
            : base((uint)mode, true)
        {
            this.PullNear = pullNear;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Polygon Offset: {0} {1}",
                (PolygonOffset)this.Capacity,
                this.PullNear ? "Near" : "Far");
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                float value = this.PullNear ? -1.0f : 1.0f;
                OpenGL.PolygonOffset(value, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PullNear { get; set; }
    }

}
