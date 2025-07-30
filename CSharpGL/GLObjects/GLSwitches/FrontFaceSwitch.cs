namespace CSharpGL {
    /// <summary>
    /// This function sets what defines a front face. Counter ClockWise by default.
    /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
    /// </summary>
    public unsafe class FrontFaceSwitch : GLSwitch {
        //private GLint[] originalPolygonMode = new GLint[1];
        private GLint originalMode;

        public FrontFaceMode mode;

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        public FrontFaceSwitch() : this(FrontFaceMode.CCW) { }

        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        /// <param name="mode"></param>
        public FrontFaceSwitch(FrontFaceMode mode) {
            this.mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glFrontFace({0})", mode);
        }

        private uint lastMode;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            var original = stackalloc GLint[1];
            gl.glGetIntegerv((GLenum)GetTarget.FrontFace, original);
            this.originalMode = original[0];

            this.lastMode = (uint)this.mode;
            if (this.lastMode != original[0]) {
                gl.glFrontFace(this.lastMode);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            if (this.lastMode != originalMode) {
                gl.glFrontFace((GLenum)originalMode);
            }
        }
    }
}