namespace CSharpGL {
    /// <summary>
    /// Toggle of depth mask.
    /// </summary>
    public unsafe class DepthMaskSwitch : GLSwitch {
        /// <summary>
        ///  Writable when this switch is turned on?
        /// </summary>
        public bool writable = true;

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// Toggle of depth mask.
        /// </summary>
        public DepthMaskSwitch() : this(true) { }

        /// <summary>
        /// Toggle of depth mask.
        /// </summary>
        /// <param name="writable">Writable when this switch is turned on?</param>
        public DepthMaskSwitch(bool writable) {
            this.writable = writable;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("Depth Mask: On: {0}; Off: {1}.",
                this.writable ? "writable" : "not writeble",
                this.writable ? "not writable" : "writeble");
        }

        private bool lastState;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            this.lastState = this.writable;
            gl.glDepthMask(this.lastState);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glDepthMask(!lastState);
        }
    }
}