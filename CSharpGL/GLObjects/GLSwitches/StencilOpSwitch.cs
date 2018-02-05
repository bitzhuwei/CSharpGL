using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glStencilFunc
    /// </summary>
    public class StencilOpSwitch : GLSwitch
    {
        /// <summary>
        /// Specifies the action to take when the stencil test fails.
        /// </summary>
        public EStencilOp BeforeStencilTestFail { get; set; }

        /// <summary>
        /// Specifies the stencil action when the stencil test passes, but the depth test fails.
        /// </summary>
        public EStencilOp BeforeDepthTestFail { get; set; }

        /// <summary>
        /// Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. 
        /// </summary>
        public EStencilOp BeforeDepthTestPass { get; set; }

        /// <summary>
        /// Specifies the action to take when the stencil test fails.
        /// </summary>
        public EStencilOp AfterStencilTestFail { get; set; }

        /// <summary>
        /// Specifies the stencil action when the stencil test passes, but the depth test fails.
        /// </summary>
        public EStencilOp AfterDepthTestFail { get; set; }

        /// <summary>
        /// Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. 
        /// </summary>
        public EStencilOp AfterDepthTestPass { get; set; }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public StencilOpSwitch() : this(EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Keep) { }

        /// <summary>
        /// glStencilFunc
        /// </summary>
        /// <param name="beforeStencilTestFail">Specifies the action to take when the stencil test fails.</param>
        /// <param name="beforeDepthTestFail">Specifies the stencil action when the stencil test passes, but the depth test fails.</param>
        /// <param name="beforeDepthTestPass">Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. </param>
        /// <param name="afterStencilTestFail"></param>
        /// <param name="afterDepthTestFail"></param>
        /// <param name="afterDepthTestPass"></param>
        public StencilOpSwitch(EStencilOp beforeStencilTestFail, EStencilOp beforeDepthTestFail, EStencilOp beforeDepthTestPass,
            EStencilOp afterStencilTestFail, EStencilOp afterDepthTestFail, EStencilOp afterDepthTestPass)
        {
            this.BeforeStencilTestFail = beforeStencilTestFail;
            this.BeforeDepthTestFail = beforeDepthTestFail;
            this.BeforeDepthTestPass = beforeDepthTestPass;

            this.AfterStencilTestFail = afterStencilTestFail;
            this.AfterDepthTestFail = afterDepthTestFail;
            this.AfterDepthTestPass = afterDepthTestPass;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilOp({0}, {1}, {2}) - glStencilOp({3}, {4}, {5})",
                BeforeStencilTestFail, BeforeDepthTestFail, BeforeDepthTestPass,
                AfterStencilTestFail, AfterDepthTestFail, AfterDepthTestPass
                );
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.StencilOp((uint)this.BeforeStencilTestFail, (uint)this.BeforeDepthTestFail, (uint)this.BeforeDepthTestPass);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            GL.Instance.StencilOp((uint)this.AfterStencilTestFail, (uint)this.AfterDepthTestFail, (uint)this.AfterDepthTestPass);
        }
    }
}
