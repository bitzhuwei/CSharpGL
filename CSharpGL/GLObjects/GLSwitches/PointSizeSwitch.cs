namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PointSizeSwitch : GLSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly float min;

        /// <summary>
        /// 
        /// </summary>
        public static readonly float max;

        static PointSizeSwitch()
        {
            float[] pointSizeRange = new float[2];
            GL.Instance.GetFloatv((uint)GetTarget.PointSizeRange, pointSizeRange);
            min = pointSizeRange[0];
            max = pointSizeRange[1];
            //GL.GetFloat(GetTarget.PointSizeGranularity, pointSizeWidthRange);//TODO: what does PointSizeGranularity mean?
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

        // Activator needs a non-parameter constructor.
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

        private float[] original = new float[1];

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
        protected override void StateOn()
        {
            GL.Instance.GetFloatv((uint)GetTarget.PointSize, original);

            GL.Instance.PointSize(PointSize);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.PointSize(original[0]);
        }
    }
}