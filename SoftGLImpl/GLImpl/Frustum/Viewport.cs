using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        /// <summary>
        /// ivec4(x, y, width, height)
        /// </summary>
        private ivec4 viewport;

        public static void glViewport(GLint x, GLint y, GLsizei width, GLsizei height) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (width < 0 || height < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            context.viewport.x = x; context.viewport.y = y;
            context.viewport.z = width; context.viewport.w = height;

            //bool firstBound = ((context != null) && (!context.bounded) && (context.deviceContextHandle != IntPtr.Zero));
            //if (firstBound) { context.bounded = true; }
            context.bounded = true;
        }
    }
}
