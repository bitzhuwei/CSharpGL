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

        private byte originalEnabled;
        private bool lastEnableCap;
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

            this.lastEnableCap = this.EnableCap;
            if (this.lastEnableCap)
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
            if (this.lastEnableCap)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCap">true for enable, false for disable</param>
        public CullFaceSwitch(bool enableCap = true)
            : base(GL.GL_CULL_FACE, enableCap)
        { }

        public override string ToString()
        {
            if (this.EnableCap)
            { return "GL.Enable(GL_CULL_FACE);"; }
            else
            { return "GL.Disable(GL_CULL_FACE);"; }
        }

    }

    public class DepthTestSwitch : EnableSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCap">true for enable, false for disable</param>
        public DepthTestSwitch(bool enableCap = true)
            : base(GL.GL_DEPTH_TEST, enableCap)
        { }

        public override string ToString()
        {
            if (this.EnableCap)
            { return "GL.Enable(GL_DEPTH_TEST);"; }
            else
            { return "GL.Disable(GL_DEPTH_TEST);"; }
        }

    }

    public class PointSmoothSwitch : EnableSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCap">true for enable, false for disable</param>
        public PointSmoothSwitch(bool enableCap = true)
            : base(GL.GL_POINT_SMOOTH, enableCap)
        { }

        public override string ToString()
        {
            if (this.EnableCap)
            { return "GL.Enable(GL_POINT_SMOOTH);"; }
            else
            { return "GL.Disable(GL_POINT_SMOOTH);"; }
        }

    }
}
