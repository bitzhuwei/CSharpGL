using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class GLSwitch
    {

        private bool inUse = false;

        /// <summary>
        /// You want to use this switch?
        /// </summary>
        public bool InUse { get; set; }


        public GLSwitch()
        {
            this.InUse = true;
        }

        public void On()
        {
            if (this.InUse)
            {
                this.inUse = true;
                this.SwitchOn();
            }
        }

        public void Off()
        {
            if (this.inUse)
            {
                this.inUse = false;
                this.SwitchOff();
            }
        }

        protected abstract void SwitchOn();

        protected abstract void SwitchOff();
    }

}
