using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>

    public abstract unsafe class GLSwitch : IGLSwitch {
        private bool inUse = false;

        /// <summary>
        /// You want to use this switch?
        /// </summary>
        public bool enabled = true;

        ///// <summary>
        /////
        ///// </summary>
        //public GLSwitch() {
        //    this.enabled = true;
        //}

        /// <summary>
        ///
        /// </summary>
        public void On() {
            if (this.enabled) {
                this.inUse = true;
                this.StateOn();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Off() {
            if (this.inUse) {
                this.inUse = false;
                this.StateOff();
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected abstract void StateOn();

        /// <summary>
        ///
        /// </summary>
        protected abstract void StateOff();
    }
}