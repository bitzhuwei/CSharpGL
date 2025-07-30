using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {

        public static void glDepthRange(GLclampd nearVal, GLclampd farVal) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (nearVal < 0.0) { nearVal = 0.0; }
            if (1.0 < nearVal) { nearVal = 1.0; }
            if (farVal < 0.0) { farVal = 0.0; }
            if (1.0 < farVal) { farVal = 1.0; }

            context.depthRangeNear = nearVal;
            context.depthRangeFar = farVal;
        }

        public static void glDepthRangef(float nearVal, float farVal) {
            glDepthRange(nearVal, farVal);
        }
    }
}
