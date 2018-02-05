namespace CSharpGL
{
    /// <summary>
    /// Toggle of depth mask.
    /// </summary>
    public class DepthMaskSwitch : GLSwitch
    {
        private bool writable = true;

        /// <summary>
        ///  Writable when this switch is turned on?
        /// </summary>
        public bool Writable
        {
            get { return writable; }
            set { writable = value; }
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// Toggle of depth mask.
        /// </summary>
        public DepthMaskSwitch() : this(true) { }

        /// <summary>
        /// Toggle of depth mask.
        /// </summary>
        /// <param name="writable">Writable when this switch is turned on?</param>
        public DepthMaskSwitch(bool writable)
        {
            this.Writable = writable;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("Depth Mask: On: {0}; Off: {1}.",
                this.writable ? "writable" : "not writeble",
                this.writable ? "not writable" : "writeble");
        }

        private bool lastState;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            this.lastState = this.Writable;
            GL.Instance.DepthMask(this.lastState);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.DepthMask(!lastState);
        }
    }
}