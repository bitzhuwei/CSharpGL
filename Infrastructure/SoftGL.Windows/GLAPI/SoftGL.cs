using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Implementation of OpenGL on Windows System.
    /// </summary>
    public partial class SoftGL : GL
    {
        private SoftGLRenderContext currentContext;

        /// <summary>
        /// Single instance of <see cref="SoftGL"/>.
        /// </summary>
        public static readonly SoftGL SoftGLInstance = new SoftGL();
        private SoftGL() : base() { }

        public override IntPtr GetCurrentContext()
        {
            SoftGLRenderContext context = this.currentContext;

            return context == null ? IntPtr.Zero : context.Pointer;
        }
    }
}