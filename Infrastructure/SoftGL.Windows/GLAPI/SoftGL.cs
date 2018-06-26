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
        public static readonly SoftGL CSharpGLInstance = new SoftGL();
        private SoftGL() : base() { }

        public override IntPtr GetCurrentContext()
        {
            //return Win32.wglGetCurrentContext();
            throw new NotImplementedException();
        }
    }
}