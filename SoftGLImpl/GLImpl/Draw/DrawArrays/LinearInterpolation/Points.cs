using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4Points(
            RenderContext context, int count,
            GLVertexArrayObject vao, GLProgram program,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var fs = program.FragmentShader; Debug.Assert(fs != null && fs.codeType != null);
            var vs = program.VertexShader; Debug.Assert(vs != null && vs.codeType != null);
            //var inValues = new object[inFieldInfos.Length][];
            //var inValueTypes = new Type[inFieldInfos.Length];
            //for (int i = 0; i < inFieldInfos.Length; i++) {
            //    var field = inFieldInfos[i];
            //    if (name2fielfInfo.TryGetValue(field.Name, out var endpointField)) {
            //        var v0 = endpointField.GetValue(endpoints0);
            //        var v1 = endpointField.GetValue(endpoints1);
            //        var v2 = endpointField.GetValue(endpoints2);
            //        Debug.Assert(v0 != null && v1 != null && v2 != null);
            //        inValues[i] = [v0, v1, v2]; inValueTypes[i] = v0.GetType();
            //    }
            //}
            ivec4 viewport = context.viewport;
            // TODO: maybe this is where gl_PointSize should work.
            var fsInstances = new FragmentCodeBase[count]; var endpoints = new VertexCodeBase[count]; var cursor = 0;
            for (uint c = 0; c < count; c++) {
                uint gl_VertexID = c;
                System.Diagnostics.Debug.Assert(vertexID2Shader.ContainsKey(gl_VertexID));
                var shaderObj = vertexID2Shader[gl_VertexID];
                var gl_Position = shaderObj.gl_Position;
                vec3 fragCoord = new vec3(
                    (gl_Position.x + 1) / 2.0f * viewport.z + viewport.x,
                    (gl_Position.y + 1) / 2.0f * viewport.w + viewport.y,
                    (gl_Position.z + 1) / 2.0f * (float)(context.depthRangeFar - context.depthRangeNear) + (float)context.depthRangeNear);
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
                //fragment.discard = instance.discard;
                //if (!instance.discard) {// if this fragment is not discarded.
                //    PassVariable[] outVariables = fs.name2outVar.Values.ToArray();
                //    var outBuffers = new PassBuffer[outVariables.Length];
                //    for (int index = 0; index < outVariables.Length; index++) {
                //        PassVariable outVar = outVariables[index];
                //        var outBuffer = new PassBuffer(outVar.fieldInfo.FieldType.GetPassType(), 1);
                //        var pointer = outBuffer.Mapbuffer();
                //        var value = outVar.fieldInfo.GetValue(instance);
                //        Debug.Assert(value != null);
                //        switch (outBuffer.elementType) {
                //        case PassType.Float: {// make sure no negtive values
                //            var v = (float)value;
                //            if (v < 0) { v = 0; } else if (v > 1) { v = 1; }
                //            ((float*)pointer)[0] = v >= 0 ? v : 0;
                //        }
                //        break;
                //        case PassType.Vec2: {// make sure no negtive values
                //            var v = (vec2)value;
                //            if (v.x < 0) { v.x = 0; } else if (v.x > 1) { v.x = 1; }
                //            if (v.y < 0) { v.y = 0; } else if (v.y > 1) { v.y = 1; }
                //            ((vec2*)pointer)[0] = v;
                //        }
                //        break;
                //        case PassType.Vec3: {// make sure no negtive values
                //            var v = (vec3)value;
                //            if (v.x < 0) { v.x = 0; } else if (v.x > 1) { v.x = 1; }
                //            if (v.y < 0) { v.y = 0; } else if (v.y > 1) { v.y = 1; }
                //            if (v.z < 0) { v.z = 0; } else if (v.z > 1) { v.z = 1; }
                //            ((vec3*)pointer)[0] = v;
                //        }
                //        break;
                //        case PassType.Vec4: {// make sure no negtive values
                //            var v = (vec4)value;
                //            if (v.x < 0) { v.x = 0; } else if (v.x > 1) { v.x = 1; }
                //            if (v.y < 0) { v.y = 0; } else if (v.y > 1) { v.y = 1; }
                //            if (v.z < 0) { v.z = 0; } else if (v.z > 1) { v.z = 1; }
                //            if (v.w < 0) { v.w = 0; } else if (v.w > 1) { v.w = 1; }
                //            ((vec4*)pointer)[0] = v;
                //        }
                //        break;
                //        case PassType.Mat2: ((mat2*)pointer)[0] = (mat2)value; break;
                //        case PassType.Mat3: ((mat3*)pointer)[0] = (mat3)value; break;
                //        case PassType.Mat4: ((mat4*)pointer)[0] = (mat4)value; break;
                //        default: throw new NotDealWithNewEnumItemException(typeof(PassType));
                //        }
                //        outBuffer.Unmapbuffer();
                //        outBuffers[index] = outBuffer;
                //    }
                //    fragment.outVariables = outBuffers;
                //}
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
