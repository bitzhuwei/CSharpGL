namespace CSharpGL
{
    /// <summary>
    /// Toggle of depth mask.
    /// </summary>
    public class DepthMaskSwitch : GLSwitch
    {
        private bool writable = false;

        /// <summary>
        ///  Writable when this switch is turned on?
        /// </summary>
        public bool Writable
        {
            get { return writable; }
            set { writable = value; }
        }

        /// <summary>
        /// Toggle of depth mask.
        /// </summary>
        /// <param name="writable">Writable when this switch is turned on?</param>
        public DepthMaskSwitch(bool writable = false)
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
        protected override void SwitchOn()
        {
            this.lastState = this.Writable;
            OpenGL.DepthMask(this.lastState);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.DepthMask(!lastState);
        }
    }
}