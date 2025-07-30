using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        //private static readonly Dictionary<uint, int[]> pValuesiDict = new Dictionary<uint, int[]>();
        //private static readonly Dictionary<uint, float[]> pValuesfDict = new Dictionary<uint, float[]>();

        public static unsafe void glGetIntegerv(GLenum pname, GLint* pValues) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }
            if (pValues == null) { return; }

            if (false) { }
            else if (pname == GL.GL_VIEWPORT) {
                pValues[0] = context.viewport.x;
                pValues[1] = context.viewport.y;
                pValues[2] = context.viewport.z;
                pValues[3] = context.viewport.w;
            }
            //else if (pValuesiDict.ContainsKey(pname)) {
            //    int[] values = pValuesiDict[pname];
            //    for (int i = 0; i < pValues.Length; i++) {
            //        pValues[i] = values[i];
            //    }
            //}
            else {
                // TODO: do something..
            }
        }

        public static unsafe void glGetFloatv(uint pname, float* pValues) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }
            if (pValues == null) { return; }
            /*
            GL_INVALID_ENUM is generated if pname is not an accepted value.
            GL_INVALID_VALUE is generated on any of glGetBooleani_v, glGetIntegeri_v, or glGetInteger64i_v if index is outside of the valid range for the indexed state target.
             */
            switch (pname) {
            case (GLenum)GetTarget.PointSize: pValues[0] = context.pointSize; break;
            case (GLenum)GetTarget.LineWidth: pValues[0] = context.lineWidth; break;
            default: throw new NotImplementedException();
            }
            //if (false) { }
            ////else if (pValuesfDict.ContainsKey(pname)) {
            ////    float[] values = pValuesfDict[pname];
            ////    for (int i = 0; i < pValues.Length; i++) {
            ////        pValues[i] = values[i];
            ////    }
            ////}
            //else {
            //    //// TODO: do something..
            //    //if (pname == GL.GL_COLOR_CLEAR_VALUE) {
            //    //    int length = pValues.Length;
            //    //    vec4 c = context.clearColor;
            //    //    if (length >= 1) { pValues[0] = c.x; } // r
            //    //    if (length >= 2) { pValues[1] = c.y; } // g
            //    //    if (length >= 3) { pValues[2] = c.z; } // b
            //    //    if (length >= 4) { pValues[3] = c.w; } // a
            //    //}
            //}
        }

    }
}
