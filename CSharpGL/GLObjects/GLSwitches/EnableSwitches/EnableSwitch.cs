namespace CSharpGL {
    /// <summary>
    /// GL.Enable(cap); or GL.Disable(cap);
    /// </summary>
    public abstract unsafe class EnableSwitch : GLSwitch {
        /// <summary>
        ///
        /// </summary>
        protected bool enableCapacityWhenStateOn;

        /// <summary>
        /// GL.Enable(capacity);
        /// </summary>
        public uint Capacity { get; protected set; }

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        public bool EnableCapacity { get; set; }

        private bool originalEnableCapacity;

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public EnableSwitch(uint capacity, bool enableCapacity = true) {
            this.Capacity = capacity;
            this.EnableCapacity = enableCapacity;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            if (this.EnableCapacity) { return string.Format("OpenGL.Enable({0});", Capacity); }
            else { return string.Format("OpenGL.Disable({0});", Capacity); }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            this.enableCapacityWhenStateOn = this.EnableCapacity;
            this.originalEnableCapacity = gl.glIsEnabled(this.Capacity);
            if (this.enableCapacityWhenStateOn) {
                if (!this.originalEnableCapacity) { gl.glEnable(Capacity); }
            }
            else {
                if (this.originalEnableCapacity) { gl.glDisable(Capacity); }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            if (this.enableCapacityWhenStateOn) {
                if (!this.originalEnableCapacity) { gl.glDisable(Capacity); }
            }
            else {
                if (this.originalEnableCapacity) { gl.glEnable(Capacity); }
            }
        }
    }
}