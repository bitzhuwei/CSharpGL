using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static GLenum glGetError() {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return 0x0502/*GL_INVALID_OPERATION*/; }

            var errorCode = context.ErrorCode;
            context.ErrorCode = GL.GL_NO_ERROR;
            return errorCode;
        }
    }
}
