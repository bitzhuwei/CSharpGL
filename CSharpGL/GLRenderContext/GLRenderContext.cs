using System;
using System.Drawing;

namespace CSharpGL {
    /// <summary>
    /// OpenGL render context.
    /// </summary>
    public abstract partial class GLRenderContext {

        /// <summary>
        /// Control.Handle
        /// </summary>
        public readonly IntPtr handle;

        /// <summary>
        /// Control.Width
        /// </summary>
        public int width;

        /// <summary>
        /// Control.Height
        /// </summary>
        public int height;

        ///// <summary>
        ///// the bit depth.
        ///// </summary>
        //public readonly ContextGenerationParams genParams;

        /// <summary>
        /// Gets the render context handle.
        /// </summary>
        public readonly IntPtr hRC;

        /// <summary>
        /// Gets the device context handle.
        /// </summary>
        public readonly IntPtr hDC;

        /// <summary>
        /// openGL function pointers.
        /// </summary>
        public readonly GL glFunctions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="genParams"></param>
        /// <param name="hDC"></param>
        /// <param name="hRC"></param>
        /// <param name="glFunctions"></param>
        protected GLRenderContext(IntPtr handle, int width, int height, /*ContextGenerationParams genParams,*/ IntPtr hDC, IntPtr hRC, GL glFunctions) {
            this.handle = handle;
            this.width = width;
            this.height = height;
            //this.genParams = genParams;
            this.hDC = hDC;
            this.hRC = hRC;
            this.glFunctions = glFunctions;
        }

        /// <summary>
        /// Sets the dimensions of the render context.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public virtual void SetDimensions(int width, int height) {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public virtual void MakeCurrent() {
            GL.current = this.glFunctions;
        }

        public virtual void CancelCurrent() {
            GL.current = null;
        }

        /// <summary>
        /// Blit(Bit Block Transfer) the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hDC">Graphics.GetHdc()</param>
        public abstract bool Blit(IntPtr hDC);

    }
}