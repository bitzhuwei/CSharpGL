using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4LineStripAdjacency(
            RenderContext context, int count,
            GLVertexArrayObject vao, GLProgram program, Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();

            ivec4 viewport = context.viewport; // ivec4(x, y, width, height)
            var endpoints = new VertexCodeBase[4];
            var fragCoords = stackalloc vec3[4];
            for (uint c = 0; c < count - 3; c++) {
                //var group = new LinearInterpolationInfoGroup(4);
                for (uint i = 0; i < 4; i++) {
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

                //vec3 fragCoord1 = group.array[1].fragCoord, fragCoord2 = group.array[2].fragCoord;
                //{
                //    vec3 diff = (fragCoord1 - fragCoord2); // discard line that is too small.
                //    if (Math.Abs(diff.x) < epsilon
                //        && Math.Abs(diff.y) < epsilon
                //        && Math.Abs(diff.z) < epsilon
                //        ) { continue; }
                //}

                var fsInstances = FindFragmentsInLine(//fragCoord1, fragCoord2,
                    fragCoords[1], fragCoords[2],
                    endpoints[1], endpoints[2], program);
                result.Add(fsInstances);
            }

            return result;
        }
    }
}
