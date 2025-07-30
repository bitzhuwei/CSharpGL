using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4LineStripAdjacency(
            RenderContext context, int count, DrawElementsType type, IntPtr indices,
            GLVertexArrayObject vao, GLProgram program, GLBuffer indexBuffer,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();

            int elementBytes = ByteLength(type);
            int indexCount = indexBuffer.Size / elementBytes;
            IntPtr pointer = indexBuffer.Data;
            //var groupList = new List<LinearInterpolationInfoGroup>();
            ivec4 viewport = context.viewport;  // ivec4(x, y, width, height)
            var endpoints = new VertexCodeBase[4];
            var fragCoords = stackalloc vec3[4];
            for (int indexID = indices.ToInt32() / elementBytes, c = 0; c < count - 3 && indexID < indexCount - 3; indexID++, c++) {
                //var group = new LinearInterpolationInfoGroup(4);
                for (int i = 0; i < 4; i++) {
                    uint gl_VertexID = GetVertexID(pointer, type, indexID + i);
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

                //if (groupList.Contains(group)) { continue; } // discard the same line.
                //else { groupList.Add(group); }

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
