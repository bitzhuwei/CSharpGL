namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class PolygonModeSwitch : GLSwitch {
        private GLint originalFrontMode;
        private GLint originalBackMode;

        /// <summary>
        ///
        /// </summary>
        public PolygonMode mode;

        // Activator needs a non-parameter constructor.
        /// <summary>
        ///
        /// </summary>
        public PolygonModeSwitch() : this(PolygonMode.Fill) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        public PolygonModeSwitch(PolygonMode mode) {
            this.mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Polygon Mode: {0}", mode);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            var original = stackalloc GLint[2];
            gl.glGetIntegerv((GLenum)GetTarget.PolygonMode, original);
            this.originalFrontMode = original[0];
            this.originalBackMode = original[1];

            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, (GLenum)this.mode);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            if (originalFrontMode == originalBackMode) {
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, (uint)(originalFrontMode));
            }
            else {
                //TODO: not tested yet
                gl.glPolygonMode(GL.GL_FRONT, (uint)originalFrontMode);
                gl.glPolygonMode(GL.GL_BACK, (uint)originalBackMode);
            }
        }
    }
}