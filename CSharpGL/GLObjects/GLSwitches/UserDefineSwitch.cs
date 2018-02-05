using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Define operation when this state is on\off.
    /// </summary>
    public class UserDefineSwitch : GLSwitch
    {
        /// <summary>
        /// Operation when this state is turned on.
        /// </summary>
        public event EventHandler TurnOn;

        /// <summary>
        /// Operation when this state is turned off.
        /// </summary>
        public event EventHandler TurnOff;

        /// <summary>
        /// 
        /// </summary>
        protected override void StateOn()
        {
            var on = this.TurnOn;
            if (on != null)
            {
                on(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void StateOff()
        {
            var off = this.TurnOff;
            if (off != null)
            {
                off(this, EventArgs.Empty);
            }
        }
    }
}
