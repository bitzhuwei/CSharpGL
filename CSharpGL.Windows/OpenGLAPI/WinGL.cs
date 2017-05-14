using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// The OpenGL class wraps Sun's OpenGL 3D library.
    /// </summary>
    public partial class WinGL : GL
    {
        /// <summary>
        /// Single instance of <see cref="WinGL"/>.
        /// </summary>
        public static readonly WinGL Instance = new WinGL();
        private WinGL() { }

        /// <summary>
        /// Check if error exists.
        /// </summary>
        public void CheckError()
        {
            ErrorCode error = (ErrorCode)OpenGL.GetError();
            if (error != ErrorCode.NoError)
            {
                //var stack = new StackTrace();
                //StackFrame frame = stack.GetFrame(1);

                Debug.WriteLine(string.Format("OpenGL error: {0}", error));
            }
        }

    }
}