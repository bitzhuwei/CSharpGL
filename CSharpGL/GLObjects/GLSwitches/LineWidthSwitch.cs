namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class LineWidthSwitch : GLSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly float min;

        /// <summary>
        /// 
        /// </summary>
        public static readonly float max;

        static LineWidthSwitch()
        {
            float[] lineWidthRange = new float[2];
            GL.Instance.GetFloatv((uint)GetTarget.LineWidthRange, lineWidthRange);
            min = lineWidthRange[0];
            max = lineWidthRange[1];
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

        // Activator needs a non-parameter constructor.
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

        private float[] original = new float[1];

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
        protected override void StateOn()
        {
            GL.Instance.GetFloatv((uint)GetTarget.LineWidth, original);

            GL.Instance.LineWidth(LineWidth);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.LineWidth(original[0]);
        }
    }
}