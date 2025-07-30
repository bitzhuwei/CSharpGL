using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        /// <summary>
        /// Find fragments in the specified triangle.
        /// </summary>
        /// <param name="fragCoord0"></param>
        /// <param name="fragCoord1"></param>
        /// <param name="fragCoord2"></param>
        /// <param name="endpoints0"></param>
        /// <param name="endpoints1"></param>
        /// <param name="endpoints2"></param>
        /// <param name="result"></param>
        unsafe private static FragmentCodeBase[] FindFragmentsInTriangle_V3(
            vec3 fragCoord0, vec3 fragCoord1, vec3 fragCoord2,
            VertexCodeBase endpoints0, VertexCodeBase endpoints1, VertexCodeBase endpoints2,
            GLProgram program) {
            int left = (int)fragCoord0.x, right = left;
            if (left > (int)fragCoord1.x) { left = (int)fragCoord1.x; }
            if (left > (int)fragCoord2.x) { left = (int)fragCoord2.x; }
            if (right < (int)fragCoord1.x) { right = (int)fragCoord1.x; }
            if (right < (int)fragCoord2.x) { right = (int)fragCoord2.x; }
            //int bottom = left, top = left;
            //if (bottom > (int)fragCoord1.y) { bottom = (int)fragCoord1.y; }
            //if (bottom > (int)fragCoord2.y) { bottom = (int)fragCoord2.y; }
            //if (top < (int)fragCoord1.y) { top = (int)fragCoord1.y; }
            //if (top < (int)fragCoord2.y) { top = (int)fragCoord2.y; }

            var scanlines = new Scanline[right - left + 1];// we'll find the vertial scanlines
            LocateScanlines(fragCoord0, fragCoord1, left, scanlines);
            LocateScanlines(fragCoord1, fragCoord2, left, scanlines);
            LocateScanlines(fragCoord2, fragCoord0, left, scanlines);
            var count = 0;
            for (int i = 0; i < scanlines.Length; i++) { count += (scanlines[i].end.y - scanlines[i].start.y + 1); }
            if (count == 0) { Array.Empty<FragmentCodeBase>(); }

            var fs = program.FragmentShader; Debug.Assert(fs != null && fs.codeType != null);
            var vs = program.VertexShader; Debug.Assert(vs != null && vs.codeType != null);
            var name2inVar = fs.name2inVar; var name2fieldInfo = vs.name2fielfInfo;
            var inValues = new dynamic?[name2inVar.Count][];
            var inValueTypes = new Type[name2inVar.Count];
            {
                int index = 0; foreach (var pair in name2inVar) {
                    var field = pair.Value.fieldInfo;
                    if (name2fieldInfo.TryGetValue(field.Name, out var endpointField)) {
                        dynamic? v0 = endpointField.GetValue(endpoints0);
                        dynamic? v1 = endpointField.GetValue(endpoints1);
                        dynamic? v2 = endpointField.GetValue(endpoints2);
                        //Debug.Assert(v0 != null && v1 != null && v2 != null);
                        inValues[index] = [v0, v1, v2]; inValueTypes[index] = endpointField.FieldType; index++;
                    }
                }
            }
            var fsInstances = new FragmentCodeBase[count]; var weights = new vec3[count]; int cursor = 0;
            var matrix = new mat3(fragCoord0, fragCoord1, fragCoord2);
            var inverseMat = CodeBase.inverse(matrix);
            // way #1
            for (int i = 0; i < scanlines.Length; i++) {
                var scanline = scanlines[i];
                var min = scanline.start; var max = scanline.end;
                for (int y = min.y; y <= max.y; y++) {
                    //if (pointsAtLine.Contains(y)) { continue; }

                    float a = (min.y != max.y) ? (y + 0.5f - min.y) / (max.y - min.y) : (0);
                    //float x = min.x + alpha * (max.x - min.x);
                    float z = min.depth + a * (max.depth - min.depth);
                    //var pixel = new vec3(x, y - 0.5f, z);
                    var pixel = new vec3(min.x + 0.5f, y + 0.5f, z);// pixel.x += 0.5f; pixel.y += 0.5f;
                    Debug.Assert(min.x > -10000 && min.x < 10000 && y > -10000 && y < 10000 && z > -10000 && z < 10000);
                    vec3 p012 = inverseMat * pixel;
                    //// note: "sum" is not needed.
                    // float sum = p012.x + p012.y + p012.z;
                    //// note: so, just need to assign values to p0, p1, p2.
                    //var p0 = p012.x; var p1 = p012.y; var p2 = p012.z;
                    //var fragment = new Fragment(pixel, endpoints0, endpoints1, endpoints2, p012.x, p012.y, p012.z);
                    //result.Add(fragment);
                    var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                    Debug.Assert(instance != null);
                    instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                    fsInstances[cursor] = instance; weights[cursor] = p012; cursor++;
                }
            }
            // way #3
            ////ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            //var countdown = new CountdownEvent(scanlines.Length);
            //cursor = 0;
            //for (int i = 0; i < scanlines.Length; i++) {
            //    var state = new InitParamScaneline(scanlines[i], inverseMat, fs, fsInstances, weights, cursor, countdown);
            //    var min = scanlines[i].start; var max = scanlines[i].end;
            //    cursor += max.y - min.y + 1;
            //    ThreadPool.QueueUserWorkItem(fillScanline, state, true);
            //}
            //countdown.Wait(1000);//wait for 1 second at most

            // way #1
            // setup "in SomeType varName;" vertex attributes.
            {
                int index = 0; foreach (var pair in name2inVar) {
                    var inValue = inValues[index]; var type = inValueTypes[index]; index++;
                    var field = pair.Value.fieldInfo;
                    {
                        var v0 = inValue[0]; var v1 = inValue[1]; var v2 = inValue[2];
                        for (int s = 0; s < fsInstances.Length; s++) {
                            var instance = fsInstances[s]; var weight = weights[s];
                            var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                            field.SetValue(instance, value);
                        }
                    }
                    #region old way
                    //if (false) { }
                    //else if (type == typeof(float)) {
                    //    var v0 = (float)inValue[0]; var v1 = (float)inValue[1]; var v2 = (float)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec2)) {
                    //    var v0 = (vec2)inValue[0]; var v1 = (vec2)inValue[1]; var v2 = (vec2)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec3)) {
                    //    var v0 = (vec3)inValue[0]; var v1 = (vec3)inValue[1]; var v2 = (vec3)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec4)) {
                    //    var v0 = (vec4)inValue[0]; var v1 = (vec4)inValue[1]; var v2 = (vec4)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat2)) {
                    //    var v0 = (mat2)inValue[0]; var v1 = (mat2)inValue[1]; var v2 = (mat2)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat3)) {
                    //    var v0 = (mat3)inValue[0]; var v1 = (mat3)inValue[1]; var v2 = (mat3)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat4)) {
                    //    var v0 = (mat4)inValue[0]; var v1 = (mat4)inValue[1]; var v2 = (mat4)inValue[2];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y + v2 * weight.z;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else { throw new NotDealWithNewEnumItemException(type); }
                    #endregion
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


            return fsInstances;
        }

        class InitParamScaneline {
            public Scanline scanline;
            public mat3 inverseMat;
            //public VertexCodeBase endpoints0;
            //public VertexCodeBase endpoints1;
            //public VertexCodeBase endpoints2;
            public GLFragmentShader fs;
            public FragmentCodeBase[] fsInstances;
            public vec3[] weights;
            public int cursor;
            public CountdownEvent countdown;

            public InitParamScaneline(Scanline scanline, mat3 inverseMat, GLFragmentShader fs, FragmentCodeBase[] fsInstances, vec3[] weights, int cursor, CountdownEvent countdown) {
                this.scanline = scanline;
                this.inverseMat = inverseMat;
                //this.endpoints0 = endpoints0;
                //this.endpoints1 = endpoints1;
                //this.endpoints2 = endpoints2;
                this.fs = fs;
                this.fsInstances = fsInstances;
                this.weights = weights;
                this.cursor = cursor;
                this.countdown = countdown;
            }
        }
        private static unsafe readonly Action<InitParamScaneline> fillScanline = (state) => {
            var min = state.scanline.start; var max = state.scanline.end;
            var cursor = state.cursor;
            for (int y = min.y; y <= max.y; y++) {
                float a = (min.y != max.y) ? (y + 0.5f - min.y) / (max.y - min.y) : (0);
                float z = min.depth + a * (max.depth - min.depth);
                var pixel = new vec3(min.x + 0.5f, y + 0.5f, z);// pixel.x += 0.5f; pixel.y += 0.5f;
                Debug.Assert(min.x > -10000 && min.x < 10000 && y > -10000 && y < 10000 && z > -10000 && z < 10000);
                vec3 p012 = state.inverseMat * pixel;
                //var fragment = new Fragment(pixel, endpoints0, endpoints1, endpoints2, p012.x, p012.y, p012.z);
                //result.Add(fragment);
                var instance = state.fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                Debug.Assert(instance != null);
                instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                state.fsInstances[cursor] = instance; state.weights[cursor] = p012; cursor++;
            }
            state.countdown.Signal();
        };
        private static void LocateScanlines(vec3 start, vec3 end,
            int left, Scanline[] scanlines) {
            if (start.x < end.x) { DoLocateScanlines(start, end, left, scanlines); }
            else { DoLocateScanlines(end, start, left, scanlines); }
        }

        private static void DoLocateScanlines(vec3 start, vec3 end, int left, Scanline[] scanlines) {
            // now start.x <= end.x
            if (start.y < end.y) { LocateScanlines1(start, end, left, scanlines); }
            else { LocateScanlines2(start, end, left, scanlines); }
        }


        /// <summary>
        /// from start(0, height - 1) to end(width - 1, 0)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        private static void LocateScanlines2(vec3 start, vec3 end, int left, Scanline[] scanlines) {
            var x0 = (int)start.x; var y0 = (int)start.y;
            var x1 = (int)end.x; var y1 = (int)end.y;
            //float dx = end.x - start.x, dy = start.y - end.y;
            float dx = x1 - x0, dy = y0 - y1;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    var a = (x0 + 0.5f - start.x) / (end.x - start.x);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0, start.z + a * (end.z - start.z));
                    }
                    if (p > 0) {
                        y0 -= 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
            }
            else {
                float p = dx + dx - dy;
                for (; y0 >= y1; y0--) {
                    var a = (y0 + 0.5f - end.y) / (start.y - end.y);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0, end.z + a * (start.z - end.z));
                    }
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
            }
        }

        /// <summary>
        /// from start(0, 0) to end(width - 1, height - 1)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        private static void LocateScanlines1(vec3 start, vec3 end, int left, Scanline[] scanlines) {
            var x0 = (int)start.x; var y0 = (int)start.y;
            var x1 = (int)end.x; var y1 = (int)end.y;
            //float dx = end.x - start.x, dy = end.y - start.y;
            float dx = x1 - x0, dy = y1 - y0;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    var a = (x0 + 0.5f - start.x) / (end.x - start.x);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0, start.z + a * (end.z - start.z));
                    }
                    if (p >= 0) {
                        y0 += 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
            }
            else {
                float p = dx + dx - dy;
                for (; y0 <= y1; y0++) {
                    var a = (y0 + 0.5f - start.y) / (end.y - start.y);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }// the last pixel
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0, start.z + a * (end.z - start.z));
                    }
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
            }
        }
    }
}
