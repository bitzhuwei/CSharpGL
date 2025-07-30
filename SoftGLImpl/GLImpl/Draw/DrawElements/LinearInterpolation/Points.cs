using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4Points(
            RenderContext context, int count, DrawElementsType type, IntPtr indices,
            GLVertexArrayObject vao, GLProgram program, GLBuffer indexBuffer,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var fs = program.FragmentShader; Debug.Assert(fs != null && fs.codeType != null);
            var vs = program.VertexShader; Debug.Assert(vs != null && vs.codeType != null);

            var elementBytes = ByteLength(type);
            int indexCount = indexBuffer.Size / elementBytes;
            IntPtr pointer = indexBuffer.Data;
            //var gl_VertexIDList = new List<uint>();
            ivec4 viewport = context.viewport;
            int indexID = indices.ToInt32() / elementBytes;
            var fsCount = count; if (fsCount > indexCount - indexID) { fsCount = indexCount - indexID; }
            var fsInstances = new FragmentCodeBase[fsCount]; var endpoints = new VertexCodeBase[fsCount]; var cursor = 0;
            for (var c = 0; c < count && indexID < indexCount; indexID++, c++) {
                uint gl_VertexID = GetVertexID(pointer, type, indexID);
                //if (gl_VertexIDList.Contains(gl_VertexID)) { continue; }
                //else { gl_VertexIDList.Add(gl_VertexID); }

                System.Diagnostics.Debug.Assert(vertexID2Shader.ContainsKey(gl_VertexID));
                var shaderObj = vertexID2Shader[gl_VertexID];
                var fragCoord = new vec3(
                    (shaderObj.gl_Position.x + 1) / 2.0f * viewport.z + viewport.x,
                    (shaderObj.gl_Position.y + 1) / 2.0f * viewport.w + viewport.y,
                    (shaderObj.gl_Position.z + 1) / 2.0f * (float)(context.depthRangeFar - context.depthRangeNear) + (float)context.depthRangeNear);
                //var fragment = new Fragment(fragCoord, shaderObj);
                //result.Add(fragment);
                var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                Debug.Assert(instance != null);
                instance.gl_FragCoord = new vec4(fragCoord, 1.0f); // setup fragment coordinate in window/screen space.
                fsInstances[cursor] = instance; endpoints[cursor] = shaderObj; cursor++;
            }
            // way #1
            // setup "in SomeType varName;" vertex attributes.
            var name2inVar = fs.name2inVar; var name2fieldInfo = vs.name2fielfInfo;
            foreach (var pair in name2inVar) {
                var field = pair.Value.fieldInfo;
                if (name2fieldInfo.TryGetValue(field.Name, out var endpointField)) {
                    for (int s = 0; s < fsInstances.Length; s++) {
                        var instance = fsInstances[s];
                        var value = endpointField.GetValue(endpoints[s]);
                        field.SetValue(instance, value);
                    }
                }
            }
            foreach (var instance in fsInstances) {
                // TODO: uniform var in shader should be a static member in C# ?
                // setup "uniform SomeType varName;" in fragment shader.
                Dictionary<string, UniformValue> nameUniformDict = program.name2Uniform;
                foreach (UniformVariable uniformVar in fs.Name2uniformVar.Values) {
                    string name = uniformVar.fieldInfo.Name;
                    if (nameUniformDict.TryGetValue(name, out var obj)) {
                        if (obj.value != null) {
                            uniformVar.fieldInfo.SetValue(instance, obj.value);
                        }
                    }
                }

                instance.main(); // execute fragment shader code.
            }
            // way #3
            //ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            //var countdown = new CountdownEvent(scanlines.Length);
            //for (int i = 0; i < scanlines.Length; i++) {
            //    var state = new InitParamScaneline(scanlines[i], inverseMat, endpoints0, endpoints1, endpoints2, result, countdown);
            //    ThreadPool.QueueUserWorkItem(fillScanline, state, true);
            //}
            //countdown.Wait(1000);//wait for 1 second at most

            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();
            result.Add(fsInstances);
            return result;
        }
    }
}
