//using System.Drawing;

namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class AccumBufferSwitch : GLSwitch {
        private vec3 clearValue = new vec3(0, 0, 0);

        ///// <summary>
        /////
        ///// </summary>
        //public System.Drawing.Color ClearValue {
        //    get {
        //        return System.Drawing.Color.FromArgb(
        //            (int)(clearAlphazValue * 255),
        //            (int)(clearValue.x * 255),
        //            (int)(clearValue.y * 255),
        //            (int)(clearValue.z * 255));
        //    }
        //    set {
        //        this.clearValue.x = value.R / 255.0f;
        //        this.clearValue.y = value.G / 255.0f;
        //        this.clearValue.z = value.B / 255.0f;
        //    }
        //}

        /// <summary>
        /// Alpha value.
        /// </summary>
        public float clearAlphazValue = 0.0f;

        //// Activator needs a non-parameter constructor.
        ///// <summary>
        /////
        ///// </summary>
        //public AccumBufferSwitch() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="clearColor"></param>
        /// <param name="clearAlphazValue">Ranges between [0, 1.0].</param>
        public AccumBufferSwitch(/*System.Drawing.Color*/vec3 clearColor, float clearAlphazValue) {
            this.clearValue = clearColor;
            this.clearAlphazValue = clearAlphazValue;
        }

        private float[] original = new float[4];

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("glClearAccum({0}, {1}, {2}, {3});",
                clearValue.x, clearValue.y, clearValue.z, clearAlphazValue);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            fixed (float* p = original) {
                gl.glGetFloatv((GLenum)GetTarget.AccumClearValue, p);
            }

            gl.glClearAccum(clearValue.x, clearValue.y, clearValue.z, clearAlphazValue);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glClearAccum(original[0], original[1], original[2], original[3]);
        }
    }
}
