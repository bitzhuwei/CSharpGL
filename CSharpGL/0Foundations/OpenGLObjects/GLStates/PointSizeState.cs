namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PointSizeState : GLState
    {
        private static float min;
        private static float max;

        static PointSizeState()
        {
            OpenGL.PointSizeRange(out min, out max);
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

        /// <summary>
        ///
        /// </summary>
        public PointSizeState() : this(1.0f) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pointSize"></param>
        public PointSizeState(float pointSize)
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
            OpenGL.GetFloat(GetTarget.PointSize, original);

            OpenGL.PointSize(PointSize);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            OpenGL.PointSize(original[0]);
        }
    }
}