using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glStencilMask
    /// </summary>
    public class StencilMaskSwitch : GLSwitch
    {
        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public uint BeforeMask { get; set; }

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public uint AfterMask { get; set; }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public StencilMaskSwitch() : this(uint.MaxValue, uint.MaxValue) { }

        /// <summary>
        /// glStencilMask
        /// </summary>
        /// <param name="beforeMask"></param>
        /// <param name="afterMask"></param>
        public StencilMaskSwitch(uint beforeMask, uint afterMask)
        {
            this.BeforeMask = beforeMask;
            this.AfterMask = afterMask;
        }

        private float[] original = new float[1];

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilMask({0}) - glStencilMask({1})", BeforeMask, AfterMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.StencilMask(this.BeforeMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.StencilMask(this.AfterMask);
        }
    }
}
