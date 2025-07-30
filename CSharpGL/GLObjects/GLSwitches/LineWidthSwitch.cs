namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class LineWidthSwitch : GLSwitch {
        ///// <summary>
        ///// 
        ///// </summary>
        //public static readonly float min;

        ///// <summary>
        ///// 
        ///// </summary>
        //public static readonly float max;

        //static LineWidthSwitch() {
        //    var gl = GL.current; if (gl == null) { return; }
        //    float[] lineWidthRange = new float[2];
        //    gl.glGetFloatv((GLenum)GetTarget.LineWidthRange, lineWidthRange);
        //    min = lineWidthRange[0];
        //    max = lineWidthRange[1];
        //    //OpenGL.GetFloat(GetTarget.LineWidthGranularity, lineWidthRange);//TODO: what does LineWidthGranularity mean?
        //}

        ///// <summary>
        /////
        ///// </summary>
        //public float MinLineWidth { get; private set; }

        ///// <summary>
        /////
        ///// </summary>
        //public float MaxLineWidth { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public float lineWidth;

        // Activator needs a non-parameter constructor.
        /// <summary>
        ///
        /// </summary>
        public LineWidthSwitch() : this(1.0f) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineWidth"></param>
        public LineWidthSwitch(float lineWidth) {
            this.lineWidth = lineWidth;
            //this.MinLineWidth = min;
            //this.MaxLineWidth = max;
        }

        private float[] original = new float[1];

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("Line Width: {0}", lineWidth);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            fixed (float* p = original) {
                gl.glGetFloatv((GLenum)GetTarget.LineWidth, p);
            }

            gl.glLineWidth(lineWidth);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glLineWidth(original[0]);
        }
    }
}