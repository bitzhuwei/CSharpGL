using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LineWidthSwitch : GLSwitch
    {
        static float min;
        static float max;

        static LineWidthSwitch()
        {
            OpenGL.LineWidthRange(out min, out max);
            //OpenGL.GetFloat(GetTarget.LineWidthGranularity, lineWidthRange);//TODO: what does LineWidthGranularity mean?
        }

        /// <summary>
        /// 
        /// </summary>
        public float MinLineWidth { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public float MaxLineWidth { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public float LineWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LineWidthSwitch() : this(1.0f) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineWidth"></param>
        public LineWidthSwitch(float lineWidth)
        {
            this.LineWidth = lineWidth;
            this.MinLineWidth = min;
            this.MaxLineWidth = max;
        }

        float[] original = new float[1];

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return string.Format("Line Width: {0}", LineWidth);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOn()
        {
            OpenGL.GetFloat(GetTarget.LineWidth, original);

            OpenGL.LineWidth(LineWidth);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.LineWidth(original[0]);
        }
    }
}
