using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class GLSwitch
    {

        private bool switchOn = false;

        /// <summary>
        /// You want to enable or disable this switch?
        /// </summary>
        public bool Enable { get; set; }


        public GLSwitch()
        {
            this.Enable = true;
        }

        public void On()
        {
            if (this.Enable)
            {
                this.switchOn = true;
                this.SwitchOn();
            }
        }

        public void Off()
        {
            if (this.switchOn)
            {
                this.switchOn = false;
                this.SwitchOff();
            }
        }

        protected abstract void SwitchOn();

        protected abstract void SwitchOff();
    }

}
