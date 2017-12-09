using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class StencilOpState : GLState
    {
        /// <summary>
        /// Specifies the action to take when the stencil test fails.
        /// </summary>
        public EStencilOp StencilTestFail { get; set; }

        /// <summary>
        /// Specifies the stencil action when the stencil test passes, but the depth test fails.
        /// </summary>
        public EStencilOp DepthTestFail { get; private set; }

        /// <summary>
        /// Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. 
        /// </summary>
        public EStencilOp DepthTestPass { get; private set; }

        ///// <summary>
        /////
        ///// </summary>
        //public StencilOpState() : this(1.0f) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stencilTestFail">Specifies the action to take when the stencil test fails.</param>
        /// <param name="dethTestFail">Specifies the stencil action when the stencil test passes, but the depth test fails.</param>
        /// <param name="depthTestPass">Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. </param>
        public StencilOpState(EStencilOp stencilTestFail, EStencilOp dethTestFail, EStencilOp depthTestPass)
        {
            this.StencilTestFail = stencilTestFail;
            this.DepthTestFail = dethTestFail;
            this.DepthTestPass = depthTestPass;
        }

        private float[] original = new float[10];

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilFunc({0}, {1}, {2});", StencilTestFail);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            //GL.Instance.GetFloatv(GL.gl_stencil_, original);

            GL.Instance.StencilOp((uint)this.StencilTestFail, (uint)this.DepthTestFail, (uint)this.DepthTestPass);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            //GL.Instance.LineWidth(original[0]);
        }
    }
}
