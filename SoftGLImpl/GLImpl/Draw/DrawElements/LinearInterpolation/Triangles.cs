using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4Triangles(
            RenderContext context, int count, DrawElementsType type, IntPtr indices,
            GLVertexArrayObject vao, GLProgram program, GLBuffer indexBuffer,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();

            int elementBytes = ByteLength(type);
            int indexCount = indexBuffer.Size / elementBytes;
            IntPtr pointer = indexBuffer.Data;
            //var groupList = new List<LinearInterpolationInfoGroup>();
            ivec4 viewport = context.viewport;  // ivec4(x, y, width, height)
            count = (count - count % 3);
            // way #1
            var endpoints = new VertexCodeBase[3]; var fragCoords = stackalloc vec3[3];
            for (int indexID = indices.ToInt32() / ByteLength(type), c = 0; c < count - 2 && indexID < indexCount - 2; indexID += 3, c += 3) {
                //var group = new LinearInterpolationInfoGroup(3);
                for (int i = 0; i < 3; i++) {
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

                //vec3 fragCoord0 = group.array[0].fragCoord;
                //vec3 fragCoord1 = group.array[1].fragCoord;
                //vec3 fragCoord2 = group.array[2].fragCoord;

                var fsInstances = FindFragmentsInTriangle_V3(//fragCoord0, fragCoord1, fragCoord2,
                    fragCoords[0], fragCoords[1], fragCoords[2],
                    endpoints[0], endpoints[1], endpoints[2], program);
                result.Add(fsInstances);
            }
            // way #2
            // this is faster a little bit.
            //const int fromInclusive = 0; int toExclusive = count / 3;
            //int start = indices.ToInt32() / elementBytes;
            //int to2 = (indexCount - start) / 3;
            //if (to2 < toExclusive) { toExclusive = to2; }
            //Parallel.For(fromInclusive, toExclusive, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount },
            //t => {
            //    int indexID = t * 3 + start;
            //    var endpoints = new VertexCodeBase[3];
            //    var fragCoords = stackalloc vec3[3];
            //    //var group = new LinearInterpolationInfoGroup(3);
            //    for (int i = 0; i < 3; i++) {
            //        uint gl_VertexID = GetVertexID(pointer, type, indexID + i);
            //        System.Diagnostics.Debug.Assert(vertexID2Shader.ContainsKey(gl_VertexID));
            //        var shaderObj = vertexID2Shader[gl_VertexID];
            //        endpoints[i] = shaderObj;
            //        vec4 gl_Position = shaderObj.gl_Position;
            //        vec3 fragCoord = new vec3((gl_Position.x + 1) / 2.0f * viewport.z + viewport.x,
            //            (gl_Position.y + 1) / 2.0f * viewport.w + viewport.y,
            //            (gl_Position.z + 1) / 2.0f * (float)(context.depthRangeFar - context.depthRangeNear) + (float)context.depthRangeNear);
            //        //group.array[i] = new LinearInterpolationInfo(gl_VertexID, fragCoord);
            //        fragCoords[i] = fragCoord;
            //    }

            //    //if (groupList.Contains(group)) { continue; } // discard the same line.
            //    //else { groupList.Add(group); }

            //    //vec3 fragCoord0 = group.array[0].fragCoord;
            //    //vec3 fragCoord1 = group.array[1].fragCoord;
            //    //vec3 fragCoord2 = group.array[2].fragCoord;

            //    FindFragmentsInTriangle(//fragCoord0, fragCoord1, fragCoord2,
            //        fragCoords[0], fragCoords[1], fragCoords[2],
            //        endpoints[0], endpoints[1], endpoints[2], result);
            //});

            // way #3
            ////ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            //int toExclusive = count / 3;
            //int start = indices.ToInt32() / elementBytes;
            //int to2 = (indexCount - start) / 3;
            //if (to2 < toExclusive) { toExclusive = to2; }
            //var countdown = new CountdownEvent(toExclusive);
            //for (int indexID = indices.ToInt32() / ByteLength(type), c = 0; c < count - 2 && indexID < indexCount - 2; indexID += 3, c += 3) {
            //    var state = new InitParamTriangles(indexID, pointer, type, vertexID2Shader, program, inFieldInfos, name2fielfInfo, result, viewport, context, countdown);
            //    ThreadPool.QueueUserWorkItem(interpolateDrawElementsTriangles, state, true);
            //}
            //countdown.Wait(1000);//wait for 1 second at most

            return result;
        }


        private static unsafe readonly Action<InitParamTriangles> interpolateDrawElementsTriangles = (state) => {
            var endpoints = new VertexCodeBase[3];
            var fragCoords = stackalloc vec3[3];
            for (int i = 0; i < 3; i++) {
                uint gl_VertexID = GetVertexID(state.pointer, state.type, state.indexID + i);
                System.Diagnostics.Debug.Assert(state.vertexID2shader.ContainsKey(gl_VertexID));
                var shaderObj = state.vertexID2shader[gl_VertexID];
                endpoints[i] = shaderObj;
                vec4 gl_Position = shaderObj.gl_Position;
                const float delta = 1f;
                vec3 fragCoord = new vec3((gl_Position.x + delta) / 2.0f * state.viewport.z + state.viewport.x,
                    (gl_Position.y + delta) / 2.0f * state.viewport.w + state.viewport.y,
                    (gl_Position.z + delta) / 2.0f * (float)(state.context.depthRangeFar - state.context.depthRangeNear) + (float)state.context.depthRangeNear);
                //group.array[i] = new LinearInterpolationInfo(gl_VertexID, fragCoord);
                fragCoords[i] = fragCoord;
            }

            //if (groupList.Contains(group)) { continue; } // discard the same line.
            //else { groupList.Add(group); }

            //vec3 fragCoord0 = group.array[0].fragCoord;
            //vec3 fragCoord1 = group.array[1].fragCoord;
            //vec3 fragCoord2 = group.array[2].fragCoord;

            var fsInstances = FindFragmentsInTriangle_V3(//fragCoord0, fragCoord1, fragCoord2,
                fragCoords[0], fragCoords[1], fragCoords[2],
                endpoints[0], endpoints[1], endpoints[2], state.program);
            state.result.Add(fsInstances);
            state.countdown.Signal();
        };

        class InitParamTriangles {
            public readonly int indexID;
            public readonly IntPtr pointer;
            public readonly DrawElementsType type;
            public readonly Dictionary<uint, VertexCodeBase> vertexID2shader;
            public readonly GLProgram program;
            public readonly System.Reflection.FieldInfo[] inFieldInfos;
            public readonly Dictionary<string, System.Reflection.FieldInfo> name2fielfInfo;
            public readonly ConcurrentBag<FragmentCodeBase[]> result;
            public readonly ivec4 viewport;
            public readonly RenderContext context;
            public readonly CountdownEvent countdown;

            public InitParamTriangles(int indexID, nint pointer, DrawElementsType type,
                Dictionary<uint, VertexCodeBase> vertexID2shader, GLProgram program,
                System.Reflection.FieldInfo[] inFieldInfos, Dictionary<string, System.Reflection.FieldInfo> name2fielfInfo,
                ConcurrentBag<FragmentCodeBase[]> result,
                ivec4 viewport, RenderContext context, CountdownEvent countdown) {
                this.indexID = indexID;
                this.pointer = pointer;
                this.type = type;
                this.vertexID2shader = vertexID2shader;
                this.program = program;
                this.inFieldInfos = inFieldInfos;
                this.name2fielfInfo = name2fielfInfo;
                this.result = result;
                this.viewport = viewport;
                this.context = context;
                this.countdown = countdown;
            }
        }
    }
}
