using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glLineWidth(GLfloat width) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.lineWidth = width;
        }
    }
}
