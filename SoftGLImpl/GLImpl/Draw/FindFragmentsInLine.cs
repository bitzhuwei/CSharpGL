using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        /// <summary>
        /// Find fragments in the specified line.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="endpoints"></param>
        /// <param name="result"></param>
        unsafe private static FragmentCodeBase[] FindFragmentsInLine(vec3 start, vec3 end,
            VertexCodeBase endpoints0, VertexCodeBase endpoints1, GLProgram program) {
            if (start.x > end.x) { var tmp = start; start = end; end = tmp; }
            var fs = program.FragmentShader; Debug.Assert(fs != null && fs.codeType != null);

            var (fsInstances, weights) = DoFindFragmentsInLine(start, end, fs);
            Debug.Assert(fsInstances.Length == weights.Length);
            if (fsInstances.Length == 0) { return fsInstances; }

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
                        //Debug.Assert(v0 != null && v1 != null);
                        inValues[index] = [v0, v1]; inValueTypes[index] = endpointField.FieldType; index++;
                    }
                }
            }
            // setup "in SomeType varName;" vertex attributes.
            {
                int index = 0; foreach (var pair in name2inVar) {
                    var inValue = inValues[index]; var type = inValueTypes[index]; index++;
                    var field = pair.Value.fieldInfo;
                    {
                        var v0 = inValue[0]; var v1 = inValue[1];
                        for (int s = 0; s < fsInstances.Length; s++) {
                            var instance = fsInstances[s]; var weight = weights[s];
                            var value = v0 * weight.x + v1 * weight.y;
                            field.SetValue(instance, value);
                        }
                    }
                    #region old way
                    //if (false) { }
                    //else if (type == typeof(float)) {
                    //    var v0 = (float)inValue[0]; var v1 = (float)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec2)) {
                    //    var v0 = (vec2)inValue[0]; var v1 = (vec2)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec3)) {
                    //    var v0 = (vec3)inValue[0]; var v1 = (vec3)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(vec4)) {
                    //    var v0 = (vec4)inValue[0]; var v1 = (vec4)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat2)) {
                    //    var v0 = (mat2)inValue[0]; var v1 = (mat2)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat3)) {
                    //    var v0 = (mat3)inValue[0]; var v1 = (mat3)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
                    //        field.SetValue(instance, value);
                    //    }
                    //}
                    //else if (type == typeof(mat4)) {
                    //    var v0 = (mat4)inValue[0]; var v1 = (mat4)inValue[1];
                    //    for (int s = 0; s < fsInstances.Length; s++) {
                    //        var instance = fsInstances[s]; var weight = weights[s];
                    //        var value = v0 * weight.x + v1 * weight.y;
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

        private static (FragmentCodeBase[], vec2[]) DoFindFragmentsInLine(
            vec3 start, vec3 end, GLFragmentShader fs) {
            // now start.X <= end.X
            if (start.y < end.y) { return FindFragmentsInLine1(start, end, fs); }
            else { return FindFragmentsInLine2(start, end, fs); }
        }

        /// <summary>
        /// from start(0, height - 1) to end(width - 1, 0)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="endpoints0"></param>
        /// <param name="endpoints1"></param>
        /// <param name="result"></param>
        private static (FragmentCodeBase[], vec2[]) FindFragmentsInLine2(
            vec3 start, vec3 end, GLFragmentShader fs) {
            var x0 = (int)start.x; var y0 = (int)start.y;
            var x1 = (int)end.x; var y1 = (int)end.y;
            //float dx = end.x - start.x, dy = start.y - end.y;
            float dx = x1 - x0, dy = y0 - y1;
            if (dx >= dy) {
                var fsInstances = new FragmentCodeBase[x1 - x0 + 1]; var weights = new vec2[x1 - x0 + 1]; var cursor = 0;
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var a = (x0 + 0.5f - start.x) / (end.x - start.x);
                        var pixel = new vec3(x0 + 0.5f, y0 + 0.5f, start.z + a * (end.z - start.z));
                        float lp0 = (pixel - start).length(); float lp1 = (pixel - end).length();
                        float sum = lp0 + lp1; float p0 = lp1 / sum; float p1 = lp0 / sum;
                        //var fragment = new Fragment(pixel, endpoints0, endpoints1, p0, p1);
                        //result.Add(fragment);
                        var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                        Debug.Assert(instance != null);
                        instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                        fsInstances[cursor] = instance; weights[cursor] = new vec2(p0, p1); cursor++;
                    }
                    if (p > 0) {
                        y0 -= 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
                return (fsInstances, weights);
            }
            else {
                var fsInstances = new FragmentCodeBase[y0 - y1 + 1]; var weights = new vec2[y0 - y1 + 1]; var cursor = 0;
                float p = dx + dx - dy;
                for (; y0 >= y1; y0--) {
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }
                    {
                        var a = (y0 + 0.5f - end.y) / (start.y - end.y);
                        var pixel = new vec3(x0 + 0.5f, y0 + 0.5f, end.z + a * (start.z - end.z));
                        float lp0 = (pixel - start).length(); float lp1 = (pixel - end).length();
                        float sum = lp0 + lp1; float p0 = lp1 / sum; float p1 = lp0 / sum;
                        //var fragment = new Fragment(pixel, endpoints0, endpoints1, p0, p1);
                        //result.Add(fragment);
                        var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                        Debug.Assert(instance != null);
                        instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                        fsInstances[cursor] = instance; weights[cursor] = new vec2(p0, p1); cursor++;
                    }
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
                return (fsInstances, weights);
            }
        }

        /// <summary>
        /// from start(0, 0) to end(width - 1, height - 1)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="endpoints0"></param>
        /// <param name="endpoints1"></param>
        /// <param name="result"></param>
        private static (FragmentCodeBase[], vec2[]) FindFragmentsInLine1(
            vec3 start, vec3 end, GLFragmentShader fs) {
            var x0 = (int)start.x; var y0 = (int)start.y;
            var x1 = (int)end.x; var y1 = (int)end.y;
            //float dx = end.x - start.x, dy = end.y - start.y;
            float dx = x1 - x0, dy = y1 - y0;
            if (dx >= dy) {
                var fsInstances = new FragmentCodeBase[x1 - x0 + 1]; var weights = new vec2[x1 - x0 + 1]; var cursor = 0;
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var a = (x0 + 0.5f - start.x) / (end.x - start.x);
                        var pixel = new vec3(x0 + 0.5f, y0 + 0.5f, start.z + a * (end.z - start.z));
                        float lp0 = (pixel - start).length(); float lp1 = (pixel - end).length();
                        float sum = lp0 + lp1; float p0 = lp1 / sum; float p1 = lp0 / sum;
                        //var fragment = new Fragment(pixel, endpoints0, endpoints1, p0, p1);
                        //result.Add(fragment);
                        var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                        Debug.Assert(instance != null);
                        instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                        fsInstances[cursor] = instance; weights[cursor] = new vec2(p0, p1); cursor++;
                    }
                    if (p >= 0) {
                        y0 += 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
                return (fsInstances, weights);
            }
            else {
                var fsInstances = new FragmentCodeBase[y1 - y0 + 1]; var weights = new vec2[y1 - y0 + 1]; var cursor = 0;
                float p = dx + dx - dy;
                for (; y0 <= y1; y0++) {
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }// the last pixel
                    {
                        var a = (y0 + 0.5f - start.y) / (end.y - start.y);
                        var pixel = new vec3(x0 + 0.5f, y0 + 0.5f, start.z + a * (end.z - start.z));
                        float lp0 = (pixel - start).length(); float lp1 = (pixel - end).length();
                        float sum = lp0 + lp1; float p0 = lp1 / sum; float p1 = lp0 / sum;
                        //var fragment = new Fragment(pixel, endpoints0, endpoints1, p0, p1);
                        //result.Add(fragment);
                        var instance = fs.ApplyCodeInstance() as FragmentCodeBase; // an executable fragment shader.
                        Debug.Assert(instance != null);
                        instance.gl_FragCoord = new vec4(pixel, 1.0f); // setup fragment coordinate in window/screen space.
                        fsInstances[cursor] = instance; weights[cursor] = new vec2(p0, p1); cursor++;
                    }
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
                return (fsInstances, weights);
            }
        }
    }
}
