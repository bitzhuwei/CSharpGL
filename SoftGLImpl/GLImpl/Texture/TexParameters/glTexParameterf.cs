using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    partial class SoftGL {
        public static void glTexParameterf(GLenum target, GLenum pname, GLfloat param) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (!Enum.IsDefined(typeof(BindTextureTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }

            var texture = GetCurrentTexture(context, target);
            if (texture != null) { texture.SetProperty(pname, param); }
        }
    }
}
