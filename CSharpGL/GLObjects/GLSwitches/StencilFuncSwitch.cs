using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glStencilFunc
    /// </summary>
    public class StencilFuncSwitch : GLSwitch
    {
        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public EStencilFunc BeforeFunc { get; set; }

        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public int BeforeReference { get; private set; }

        /// <summary>
        /// before sending drawing command to GPU.
        /// </summary>
        public uint BeforeMask { get; private set; }
        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public EStencilFunc AfterFunc { get; set; }

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public int AfterReference { get; private set; }

        /// <summary>
        /// after sending drawing command to GPU.
        /// </summary>
        public uint AfterMask { get; private set; }

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
            EStencilFunc afterFunc, int afterReference, uint afterMask)
        {
            this.BeforeFunc = beforeFunc;
            this.BeforeReference = beforeReference;
            this.BeforeMask = beforeMask;

            this.AfterFunc = afterFunc;
            this.AfterReference = afterReference;
            this.AfterMask = afterMask;
        }

        private float[] original = new float[10];

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilFunc({0}, {1}, {2}); - glStencilFunc({3}, {4}, {5});",
                BeforeFunc, BeforeReference, BeforeMask,
                AfterFunc, AfterReference, AfterMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.StencilFunc((uint)this.BeforeFunc, this.BeforeReference, this.BeforeMask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.StencilFunc((uint)this.AfterFunc, this.AfterReference, this.AfterMask);
        }
    }
}
