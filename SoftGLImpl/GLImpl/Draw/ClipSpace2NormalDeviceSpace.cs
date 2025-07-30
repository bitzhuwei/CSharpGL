using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        private static unsafe void ClipSpace2NormalDeviceSpace(Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            //if (passBuffer.elementType != PassType.Vec4) { throw new Exception(String.Format("This pass-buffer must be of vec4 type!")); }

            //var array = (vec4*)passBuffer.Mapbuffer();
            //int length = passBuffer.Length();
            //for (int i = 0; i < length; i++) {
            //    vec4 gl_Position = array[i];
            //    float w = gl_Position.w;
            //    if (w != 0) {
            //        gl_Position.x = gl_Position.x / w;
            //        gl_Position.y = gl_Position.y / w;
            //        gl_Position.z = gl_Position.z / w;
            //        gl_Position.w = 1;
            //    }
            //    array[i] = gl_Position;
            //}
            //passBuffer.Unmapbuffer();
            foreach (var pair in vertexID2Shader) {
                var shaderObj = pair.Value;
                vec4 gl_Position = shaderObj.gl_Position;
                float w = gl_Position.w;
                if (w != 0) {
                    shaderObj.gl_Position.x = gl_Position.x / w;
                    shaderObj.gl_Position.y = gl_Position.y / w;
                    shaderObj.gl_Position.z = gl_Position.z / w;
                    shaderObj.gl_Position.w = 1;
                }
            }
        }
    }
}
