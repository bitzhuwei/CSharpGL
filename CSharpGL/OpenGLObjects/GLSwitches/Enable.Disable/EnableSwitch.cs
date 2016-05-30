using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// GL.Enable(cap); or GL.Disable(cap);
    /// </summary>
    public abstract class EnableSwitch : GLSwitch
    {

        protected bool enableCapacityWhenSwitchOn;

        /// <summary>
        /// GL.Enable(capacity);
        /// </summary>
        public uint Capacity { get; private set; }

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        public bool EnableCapacity { get; set; }
        private bool originalEnableCapacity;

        /// <summary>
        /// GL.Enable(capacity);
        /// </summary>
        /// <param name="capacity"></param>
        public EnableSwitch(uint capacity) : this(capacity, true) { }

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public EnableSwitch(uint capacity, bool enableCapacity)
        {
            byte original = OpenGL.IsEnabled(capacity);

            this.Init(capacity, enableCapacity);
        }

        private void Init(uint capacity, bool enableCapacity)
        {
            this.Capacity = capacity; this.EnableCapacity = enableCapacity;
        }

        public override string ToString()
        {
            if (this.EnableCapacity)
            { return string.Format("OpenGL.Enable({0});", Capacity); }
            else
            { return string.Format("OpenGL.Disable({0});", Capacity); }
        }

        protected override void SwitchOn()
        {
            this.enableCapacityWhenSwitchOn = this.EnableCapacity;
            this.originalEnableCapacity = OpenGL.IsEnabled(this.Capacity) != 0;
            if (this.enableCapacityWhenSwitchOn)
            {
                if (!this.originalEnableCapacity)
                { OpenGL.Enable(Capacity); }
            }
            else
            {
                if (this.originalEnableCapacity)
                { OpenGL.Disable(Capacity); }
            }
        }

        protected override void SwitchOff()
        {
            if (this.enableCapacityWhenSwitchOn)
            {
                if (!this.originalEnableCapacity)
                { OpenGL.Disable(Capacity); }
            }
            else
            {
                if (this.originalEnableCapacity)
                { OpenGL.Enable(Capacity); }
            }
        }

    }

   

}
