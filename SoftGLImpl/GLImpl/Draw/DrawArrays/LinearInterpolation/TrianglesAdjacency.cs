using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4TrianglesAdjacency(
            RenderContext context, int count,
            GLVertexArrayObject vao, GLProgram program,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();

            ivec4 viewport = context.viewport;  // ivec4(x, y, width, height)
            count = (count - count % 6);
            var endpoints = new VertexCodeBase[6];
            var fragCoords = stackalloc vec3[6];
            for (uint c = 0; c < count - 5; c += 6) {
                //var group = new LinearInterpolationInfoGroup(6);
                for (uint i = 0; i < 6; i++) {
                    uint gl_VertexID = c + i;
                    System.Diagnostics.Debug.Assert(vertexID2Shader.ContainsKey(gl_VertexID));
                    var shaderObj = vertexID2Shader[gl_VertexID];
                    endpoints[i] = shaderObj;
                    vec4 gl_Position = shaderObj.gl_Position;
                    vec3 fragCoord = new vec3(
                        (gl_Position.x + 1) / 2.0f * viewport.z + viewport.x,
                        (gl_Position.y + 1) / 2.0f * viewport.w + viewport.y,
                        (gl_Position.z + 1) / 2.0f * (float)(context.depthRangeFar - context.depthRangeNear) + (float)context.depthRangeNear);
                    //group.array[i] = new LinearInterpolationInfo(gl_VertexID, fragCoord);
                    fragCoords[i] = fragCoord;
                }

                //vec3 fragCoord0 = group.array[0].fragCoord;
                //vec3 fragCoord2 = group.array[2].fragCoord;
                //vec3 fragCoord4 = group.array[4].fragCoord;

                var primitive = FindFragmentsInTriangle_V3(//fragCoord0, fragCoord2, fragCoord4,
                    fragCoords[0], fragCoords[2], fragCoords[4],
                    endpoints[0], endpoints[2], endpoints[4], program);
                result.Add(primitive);
            }

            return result;
        }
    }
}
