using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glEnable(GLenum cap) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.enables.Add(cap);
        }
        public static void glDisable(GLenum cap) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.enables.Remove(cap);
        }
    }
}
