using System.Drawing;

namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class ClearColorSwitch : GLSwitch {
        public vec3 clearColor = new vec3();

        ///// <summary>
        /////
        ///// </summary>
        //public Color ClearColor {
        //    get {
        //        return Color.FromArgb(
        //            (int)(alpha * 255),
        //            (int)(clearColor.x * 255),
        //            (int)(clearColor.y * 255),
        //            (int)(clearColor.z * 255));
        //    }
        //    set {
        //        this.clearColor.x = value.R / 255.0f;
        //        this.clearColor.y = value.G / 255.0f;
        //        this.clearColor.z = value.B / 255.0f;
        //    }
        //}

        /// <summary>
        /// Alpha value.
        /// </summary>
        public float alpha = 1.0f;
        ///// <summary>
        /////
        ///// </summary>
        //public ClearColorSwitch() : this(Color.Black) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="clearColor"></param>
        /// <param name="alpha">Ranges between [0, 1.0].</param>
        public ClearColorSwitch(/*Color*/vec3 clearColor, float alpha = 1.0f) {
            this.clearColor = clearColor;
            this.alpha = alpha;
        }

        private float[] original = new float[4];

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("glClearColor({0}, {1}, {2}, {3});",
                clearColor.x, clearColor.y, clearColor.z, alpha);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            fixed (float* p = original) {
                gl.glGetFloatv((GLenum)GetTarget.ColorClearValue, p);
            }

            gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, alpha);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glClearColor(original[0], original[1], original[2], original[3]);
        }
    }
}