using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glPointSize(GLfloat size) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (size <= 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            context.pointSize = size;
        }
    }
}
