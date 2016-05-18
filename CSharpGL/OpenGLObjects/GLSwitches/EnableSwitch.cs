using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// GL.Enable(cap); or GL.Disable(cap);
    /// </summary>
    public class EnableSwitch : GLSwitch
    {

        byte originalEnabled;
        private uint cap;

        public uint Cap
        {
            get { return cap; }
        }

        public bool EnableCap { get; set; }

        /// <summary>
        /// GL.Enable(cap);
        /// </summary>
        /// <param name="cap"></param>
        public EnableSwitch(uint cap) : this(cap, true) { }

        /// <summary>
        /// GL.Enable(cap); or GL.Disable(cap);
        /// </summary>
        /// <param name="cap"></param>
        /// <param name="enableCap"></param>
        public EnableSwitch(uint cap, bool enableCap)
        {
            this.cap = cap;
            this.EnableCap = enableCap;
        }

        public override string ToString()
        {
            if (this.EnableCap)
            { return string.Format("GL.Enable({0});", cap); }
            else
            { return string.Format("GL.Disable({0});", cap); }
        }

        protected override void SwitchOn()
        {
            this.originalEnabled = GL.IsEnabled(cap);

            if (this.EnableCap)
            {
                if (this.originalEnabled == 0)
                { GL.Enable(cap); }
            }
            else
            {
                if (this.originalEnabled != 0)
                { GL.Disable(cap); }
            }
        }

        protected override void SwitchOff()
        {
            if (this.EnableCap)
            {
                if (this.originalEnabled == 0)
                { GL.Disable(cap); }
            }
            else
            {
                if (this.originalEnabled != 0)
                { GL.Enable(cap); }
            }
        }

    }

    public class CullFaceSwitch : EnableSwitch
    {
        public CullFaceSwitch(bool enableCap)
            : base(GL.GL_CULL_FACE, enableCap)
        { }
    }

    public class DepthTestSwitch: EnableSwitch
    {
        public DepthTestSwitch(bool enableCap)
            : base(GL.GL_DEPTH_TEST, enableCap)
        { }
    }
}
