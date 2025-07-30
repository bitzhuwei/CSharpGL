using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glStencilMask
    /// </summary>
    public unsafe class StencilMaskSwitch : GLSwitch {
        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public uint beforeMask;

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public uint afterMask;

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
        public StencilMaskSwitch(uint beforeMask, uint afterMask) {
            this.beforeMask = beforeMask;
            this.afterMask = afterMask;
        }

        private float[] original = new float[1];

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("glStencilMask({0}) - glStencilMask({1})", beforeMask, afterMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilMask(this.beforeMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilMask(this.afterMask);
        }
    }
}
