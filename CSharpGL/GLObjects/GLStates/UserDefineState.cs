using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Define operation when this state is on\off.
    /// </summary>
    public class UserDefineState : GLState
    {
        /// <summary>
        /// Operation when this state is turned on.
        /// </summary>
        public event EventHandler On;

        /// <summary>
        /// Operation when this state is turned off.
        /// </summary>
        public event EventHandler Off;

        protected override void StateOn()
        {
            var on = this.On;
            if (on != null)
            {
                on(this, EventArgs.Empty);
            }
        }

        protected override void StateOff()
        {
            var off = this.Off;
            if (off != null)
            {
                off(this, EventArgs.Empty);
            }
        }
    }
}
