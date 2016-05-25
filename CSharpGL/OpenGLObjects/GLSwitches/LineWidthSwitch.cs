using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class LineWidthSwitch : GLSwitch
    {
        static float min;
        static float max;

        private float originalLineWidth ;

        static LineWidthSwitch()
        {
            GL.LineWidthRange(out min, out max);
            //GL.GetFloat(GetTarget.LineWidthGranularity, lineWidthRange);//TODO: what does LineWidthGranularity mean?
        }

        public float MinLineWidth { get; private set; }
        public float MaxLineWidth { get; private set; }

        public float LineWidth { get; set; }

        public LineWidthSwitch() : this(1.0f) { }

        public LineWidthSwitch(float lineWidth)
        {
            float[] original = new float[1];
            GL.GetFloat(GetTarget.LineWidth, original);
            this.Init(lineWidth, original[0]);
        }

        public LineWidthSwitch(float targetLineWidth, float currentLineWidth)
        {
            this.Init(targetLineWidth, currentLineWidth);
        }

        private void Init(float targetLineWidth, float currentLineWidth)
        {
            this.LineWidth = targetLineWidth;
            this.originalLineWidth = currentLineWidth;
            this.MinLineWidth = min;
            this.MaxLineWidth = max;
        }

        public override string ToString()
        {
            return string.Format("Line Width: {0}/{1}", LineWidth, originalLineWidth);
        }

        protected override void SwitchOn()
        {
            GL.LineWidth(LineWidth);
        }

        protected override void SwitchOff()
        {
            GL.LineWidth(originalLineWidth);
        }
    }
}
