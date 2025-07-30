using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glHint(GLenum target, GLenum mode) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.hintDict.Set(target, mode);
        }

    }
}
