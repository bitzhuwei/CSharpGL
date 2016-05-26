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
        /// <param name="enableCapacity"></param>
        public EnableSwitch(uint capacity, bool enableCapacity)
        {
            byte original = OpenGL.IsEnabled(capacity);

            this.Init(capacity, enableCapacity, original != 0);
        }

        public EnableSwitch(uint capacity, bool enableCapacity, bool originalEnableCapacity)
        {
            this.Init(capacity, enableCapacity, originalEnableCapacity);
        }

        private void Init(uint capacity, bool enableCapacity, bool originalEnableCapacity)
        {
            this.Capacity = capacity; this.EnableCapacity = enableCapacity;
            this.originalEnableCapacity = originalEnableCapacity;
        }

        public override string ToString()
        {
            if (this.EnableCapacity)
            { return string.Format("GL.Enable({0});", Capacity); }
            else
            { return string.Format("GL.Disable({0});", Capacity); }
        }

        protected override void SwitchOn()
        {
            this.enableCapacityWhenSwitchOn = this.EnableCapacity;
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

    public class CullFaceSwitch : EnableSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public CullFaceSwitch(bool enableCapacity = true)
            : base(OpenGL.GL_CULL_FACE, enableCapacity)
        { }

        public override string ToString()
        {
            if (this.EnableCapacity)
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
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DepthTestSwitch(bool enableCapacity = true)
            : base(OpenGL.GL_DEPTH_TEST, enableCapacity)
        { }

        public override string ToString()
        {
            if (this.EnableCapacity)
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
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public PointSmoothSwitch(bool enableCapacity = true)
            : base(OpenGL.GL_POINT_SMOOTH, enableCapacity)
        { }

        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "GL.Enable(GL_POINT_SMOOTH);"; }
            else
            { return "GL.Disable(GL_POINT_SMOOTH);"; }
        }

    }
}
