using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4LineLoop(
            RenderContext context, int count,
            GLVertexArrayObject vao, GLProgram program, Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();

            ivec4 viewport = context.viewport;  // ivec4(x, y, width, height)
            var endpoints = new VertexCodeBase[2];
            var fragCoords = stackalloc vec3[2];
            for (uint c = 0; c < count; c++) {
                //var group = new LinearInterpolationInfoGroup(2);
                for (uint i = 0; i < 2; i++) {
                    uint gl_VertexID = (uint)((c + i) % count); //TODO: line-loop vs indices & count.
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

                //vec3 fragCoord0 = group.array[0].fragCoord, fragCoord1 = group.array[1].fragCoord;
                //{
                //    vec3 diff = (fragCoord0 - fragCoord1); // discard line that is too small.
                //    if (Math.Abs(diff.x) < epsilon
                //        && Math.Abs(diff.y) < epsilon
                //        && Math.Abs(diff.z) < epsilon
                //        ) { continue; }
                //}

                var fsInstances = FindFragmentsInLine(//fragCoord0, fragCoord1,
                    fragCoords[0], fragCoords[1],
                    endpoints[0], endpoints[1], program);
                result.Add(fsInstances);
            }

            return result;
        }
    }
}
