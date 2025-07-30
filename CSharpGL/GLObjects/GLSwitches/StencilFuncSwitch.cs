using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glStencilFunc
    /// </summary>
    public unsafe class StencilFuncSwitch : GLSwitch {
        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public EStencilFunc beforeFunc;

        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public readonly int beforeReference;

        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public readonly uint beforeMask;
        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public EStencilFunc afterFunc;

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public readonly int afterReference;

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public readonly uint afterMask;

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public StencilFuncSwitch() : this(EStencilFunc.Always, 0, uint.MaxValue, EStencilFunc.Always, 0, uint.MaxValue) { }

        /// <summary>
        /// glStencilFunc
        /// </summary>
        /// <param name="beforeFunc"></param>
        /// <param name="beforeReference"></param>
        /// <param name="beforeMask"></param>
        /// <param name="afterFunc"></param>
        /// <param name="afterReference"></param>
        /// <param name="afterMask"></param>
        public StencilFuncSwitch(EStencilFunc beforeFunc, int beforeReference, uint beforeMask,
            EStencilFunc afterFunc, int afterReference, uint afterMask) {
            this.beforeFunc = beforeFunc;
            this.beforeReference = beforeReference;
            this.beforeMask = beforeMask;

            this.afterFunc = afterFunc;
            this.afterReference = afterReference;
            this.afterMask = afterMask;
        }

        private float[] original = new float[10];

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("glStencilFunc({0}, {1}, {2}); - glStencilFunc({3}, {4}, {5});",
                beforeFunc, beforeReference, beforeMask,
                afterFunc, afterReference, afterMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilFunc((uint)this.beforeFunc, this.beforeReference, this.beforeMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilFunc((uint)this.afterFunc, this.afterReference, this.afterMask);
        }
    }
}
