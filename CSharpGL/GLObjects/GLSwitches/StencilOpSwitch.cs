using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glStencilFunc
    /// </summary>
    public unsafe class StencilOpSwitch : GLSwitch {
        /// <summary>
        /// Specifies the action to take when the stencil test fails.
        /// </summary>
        public EStencilOp beforeStencilTestFail;

        /// <summary>
        /// Specifies the stencil action when the stencil test passes, but the depth test fails.
        /// </summary>
        public EStencilOp beforeDepthTestFail;

        /// <summary>
        /// Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. 
        /// </summary>
        public EStencilOp beforeDepthTestPass;

        /// <summary>
        /// Specifies the action to take when the stencil test fails.
        /// </summary>
        public EStencilOp afterStencilTestFail;

        /// <summary>
        /// Specifies the stencil action when the stencil test passes, but the depth test fails.
        /// </summary>
        public EStencilOp afterDepthTestFail;

        /// <summary>
        /// Specifies the stencil action when both the stencil test and the depth test pass, or when the stencil test passes and either there is no depth buffer or depth testing is not enabled. 
        /// </summary>
        public EStencilOp afterDepthTestPass;

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
            EStencilOp afterStencilTestFail, EStencilOp afterDepthTestFail, EStencilOp afterDepthTestPass) {
            this.beforeStencilTestFail = beforeStencilTestFail;
            this.beforeDepthTestFail = beforeDepthTestFail;
            this.beforeDepthTestPass = beforeDepthTestPass;

            this.afterStencilTestFail = afterStencilTestFail;
            this.afterDepthTestFail = afterDepthTestFail;
            this.afterDepthTestPass = afterDepthTestPass;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("glStencilOp({0}, {1}, {2}) - glStencilOp({3}, {4}, {5})",
                beforeStencilTestFail, beforeDepthTestFail, beforeDepthTestPass,
                afterStencilTestFail, afterDepthTestFail, afterDepthTestPass
                );
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilOp((uint)this.beforeStencilTestFail, (uint)this.beforeDepthTestFail, (uint)this.beforeDepthTestPass);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glStencilOp((uint)this.afterStencilTestFail, (uint)this.afterDepthTestFail, (uint)this.afterDepthTestPass);
        }
    }
}
