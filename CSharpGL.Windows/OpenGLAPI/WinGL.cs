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
        public static readonly WinGL Instance = new WinGL();
        private WinGL() { }

        //protected override GL GetInstance()
        //{
        //    return WinGL.Instance;
        //}

    }
}