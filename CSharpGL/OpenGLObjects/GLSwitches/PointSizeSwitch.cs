using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PointSizeSwitch : GLSwitch
    {
        static float min;
        static float max;

        static PointSizeSwitch()
        {
            OpenGL.PointSizeRange(out min, out max);
            //OpenGL.GetFloat(GetTarget.PointSizeGranularity, pointSizeWidthRange);//TODO: what does PointSizeGranularity mean?
        }

        /// <summary>
        /// 
        /// </summary>
        public float MinPointSize { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public float MaxPointSize { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public float PointSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PointSizeSwitch() : this(1.0f) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointSize"></param>
        public PointSizeSwitch(float pointSize)
        {
            this.PointSize = pointSize;
            this.MinPointSize = min;
            this.MaxPointSize = max;
        }

        float[] original = new float[1];
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Point Size: {0}", PointSize);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOn()
        {
            OpenGL.GetFloat(GetTarget.PointSize, original);

            OpenGL.PointSize(PointSize);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.PointSize(original[0]);
        }
    }
}
