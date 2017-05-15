using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Implementation of OpenGL on Windows System.
    /// </summary>
    public partial class WinGL : GL
    {
        /// <summary>
        /// Single instance of <see cref="WinGL"/>.
        /// </summary>
        public static readonly WinGL WinGLInstance = new WinGL();
        private WinGL() { GL.Init(this); }

        public override IntPtr GetCurrentContext()
        {
            throw new NotImplementedException();
        }
    }
}