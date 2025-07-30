using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe Dictionary<uint, VertexCodeBase> VertexShaderStage(int count, GLVertexArrayObject vao, GLProgram program) {
            var vs = program.VertexShader;
            Debug.Assert(vs != null);

            // init pass-buffers to record output from vertex shader.
            //FieldInfo[] outFieldInfos = (from item in vs.name2outVar select item.Value.fieldInfo).ToArray();
            uint vertexCount = (uint)count;// GetVertexCount(vao, indexBuffer, type);
            //int vertexSize = GetVertexSize(outFieldInfos);
            var vertexID2Shader = new Dictionary<uint, VertexCodeBase>((int)vertexCount);// gl_VertexID -> shader object
            //var passBuffers = new PassBuffer[1 + outFieldInfos.Length];
            //var pointers = new void*[1 + outFieldInfos.Length];
            //{
            //    // the first pass-buffer stores gl_Position.
            //    var passBuffer = new PassBuffer(PassType.Vec4, (int)vertexCount);
            //    pointers[0] = (void*)passBuffer.Mapbuffer();
            //    passBuffers[0] = passBuffer;
            //}
            //for (int i = 1; i < passBuffers.Length; i++) {
            //    var outField = outFieldInfos[i - 1];
            //    PassType passType = outField.FieldType.GetPassType();
            //    var passBuffer = new PassBuffer(passType, (int)vertexCount);
            //    pointers[i] = (void*)passBuffer.Mapbuffer();
            //    passBuffers[i] = passBuffer;
            //}

            // execute vertex shader for each vertex.
            for (uint gl_VertexID = 0; gl_VertexID < count; gl_VertexID++) {
                var instance = vs.ApplyCodeInstance() as VertexCodeBase; // an executable vertex shader.
                Debug.Assert(instance != null);
                vertexID2Shader.Add(gl_VertexID, instance);
                instance.gl_VertexID = (int)gl_VertexID; // setup gl_VertexID.
                instance.gl_InstanceID = 0;// .. and other build-in variables
                // setup "in SomeType varName;" vertex attributes.
                Dictionary<uint, VertexAttribDesc> locVertexAttribDict = vao.LocVertexAttribDict;
                foreach (PassVariable inVar in vs.name2inVar.Values) {
                    // Dictionary<string, InVariable>.Values
                    if (locVertexAttribDict.TryGetValue(inVar.location, out var desc)) {
                        var dataStore = (byte*)desc.vbo.Data;
                        int byteIndex = desc.GetDataIndex(gl_VertexID);
                        var ptr = (IntPtr)(dataStore + byteIndex);
                        //var value = dataStore.ToStruct(inVar.fieldInfo.FieldType, byteIndex);
                        var value = Marshal.PtrToStructure(ptr, inVar.fieldInfo.FieldType);
                        inVar.fieldInfo.SetValue(instance, value);
                    }
                }
                // setup "uniform SomeType varName;" in vertex shader.
                Dictionary<string, UniformValue> nameUniformDict = program.name2Uniform;
                foreach (UniformVariable uniformVar in vs.Name2uniformVar.Values) {
                    string name = uniformVar.fieldInfo.Name;
                    if (nameUniformDict.TryGetValue(name, out var obj)) {
                        if (obj.value != null) {
                            uniformVar.fieldInfo.SetValue(instance, obj.value);
                        }
                    }
                }

                instance.main(); // execute vertex shader code.

                //// copy data to pass-buffer.
                //{
                //    PassBuffer passBuffer = passBuffers[0];
                //    var array = (vec4*)pointers[0];
                //    array[gl_VertexID] = instance.gl_Position;
                //}
                //for (int i = 1; i < passBuffers.Length; i++) {
                //    var outField = outFieldInfos[i - 1];
                //    var obj = outField.GetValue(instance);
                //    Debug.Assert(obj != null);
                //    switch (outField.FieldType.GetPassType()) {
                //    case PassType.Float: { var array = (float*)pointers[i]; array[gl_VertexID] = (float)obj; } break;
                //    case PassType.Vec2: { var array = (vec2*)pointers[i]; array[gl_VertexID] = (vec2)obj; } break;
                //    case PassType.Vec3: { var array = (vec3*)pointers[i]; array[gl_VertexID] = (vec3)obj; } break;
                //    case PassType.Vec4: { var array = (vec4*)pointers[i]; array[gl_VertexID] = (vec4)obj; } break;
                //    case PassType.Mat2: { var array = (mat2*)pointers[i]; array[gl_VertexID] = (mat2)obj; } break;
                //    case PassType.Mat3: { var array = (mat3*)pointers[i]; array[gl_VertexID] = (mat3)obj; } break;
                //    case PassType.Mat4: { var array = (mat4*)pointers[i]; array[gl_VertexID] = (mat4)obj; } break;
                //    default:
                //    throw new NotImplementedException();
                //    }
                //    // a general way to do this:
                //    //var obj = outField.GetValue(instance);
                //    //byte[] bytes = obj.ToBytes();
                //    //PassBuffer passBuffer = passBuffers[i];
                //    //var array = (byte*)passBuffer.AddrOfPinnedObject();
                //    //for (int t = 0; t < bytes.Length; t++) {
                //    //    array[gl_VertexID * vertexSize + t] = bytes[t];
                //    //}
                //}
            }

            //for (int i = 0; i < passBuffers.Length; i++) {
            //    passBuffers[i].Unmapbuffer();
            //}

            //return passBuffers;
            return vertexID2Shader;
        }

    }
}
