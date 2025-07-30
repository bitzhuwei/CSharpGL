namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class PointSizeSwitch : GLSwitch {
        ///// <summary>
        ///// 
        ///// </summary>
        //public static readonly float min;

        ///// <summary>
        ///// 
        ///// </summary>
        //public static readonly float max;

        //static PointSizeSwitch() {
        //    var gl = GL.current; if (gl == null) { return; }
        //    float[] pointSizeRange = new float[2];
        //    gl.glGetFloatv((GLenum)GetTarget.PointSizeRange, pointSizeRange);
        //    min = pointSizeRange[0];
        //    max = pointSizeRange[1];
        //    //GL.GetFloat(GetTarget.PointSizeGranularity, pointSizeWidthRange);//TODO: what does PointSizeGranularity mean?
        //}

        ///// <summary>
        /////
        ///// </summary>
        //public float MinPointSize { get; private set; }

        ///// <summary>
        /////
        ///// </summary>
        //public float MaxPointSize { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public float pointSize;

        // Activator needs a non-parameter constructor.
        /// <summary>
        ///
        /// </summary>
        public PointSizeSwitch() : this(1.0f) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pointSize"></param>
        public PointSizeSwitch(float pointSize) {
            this.pointSize = pointSize;
            //this.MinPointSize = min;
            //this.MaxPointSize = max;
        }

        private float original;//= new float[1];

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Point Size: {0}", pointSize);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            var value = stackalloc float[1];
            gl.glGetFloatv((GLenum)GetTarget.PointSize, value);
            this.original = value[0];

            gl.glPointSize(pointSize);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glPointSize(this.original);
        }
    }
}