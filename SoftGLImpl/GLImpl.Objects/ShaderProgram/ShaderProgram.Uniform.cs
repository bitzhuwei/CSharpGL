using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class GLProgram {
        public UniformVariable? GetUniformVariable(int location) {
            if (this.location2Uniform.TryGetValue(location, out var v)) {
                return v.variable;
            }
            else { return null; }
        }

        public unsafe void SetUniform4fv(int location, int count, bool transpose, float* value) {
            mat4 matrix;

            if (transpose) {
                matrix = new mat4(
                     new vec4(value[0], value[4], value[8], value[12]),
                     new vec4(value[1], value[5], value[9], value[13]),
                     new vec4(value[2], value[6], value[10], value[14]),
                     new vec4(value[3], value[7], value[11], value[15])
                     );
            }
            else {
                matrix = new mat4(
                      new vec4(value[0], value[1], value[2], value[3]),
                      new vec4(value[4], value[5], value[6], value[7]),
                      new vec4(value[8], value[9], value[10], value[11]),
                      new vec4(value[12], value[13], value[14], value[15])
                      );

            }

            if (count == 1) {
                this.SetUniform(location, matrix);
            }
            else {
                var v = new mat4[count];
                for (int i = 0; i < count; i++) {
                    v[i] = matrix;
                }
                this.SetUniform(location, v);
            }
        }

        public unsafe void SetUniform3fv(int location, int count, bool transpose, float* value) {
            mat3 matrix;

            if (transpose) {
                matrix = new mat3(
                   new vec3(value[0], value[3], value[6]),
                   new vec3(value[1], value[4], value[7]),
                   new vec3(value[2], value[5], value[8])
                   );
            }
            else {
                matrix = new mat3(
                   new vec3(value[0], value[1], value[2]),
                   new vec3(value[3], value[4], value[5]),
                   new vec3(value[6], value[7], value[8])
                   );
            }

            if (count == 1) {
                this.SetUniform(location, matrix);
            }
            else {
                var v = new mat3[count];
                for (int i = 0; i < count; i++) {
                    v[i] = matrix;
                }
                this.SetUniform(location, v);
            }
        }

        public unsafe void SetUniform2fv(int location, int count, bool transpose, float* value) {
            mat2 matrix;

            if (transpose) {
                matrix = new mat2(
                   new vec2(value[0], value[2]),
                   new vec2(value[1], value[3])
                   );
            }
            else {
                matrix = new mat2(
                   new vec2(value[0], value[1]),
                   new vec2(value[2], value[3])
                   );
            }

            if (count == 1) {
                this.SetUniform(location, matrix);
            }
            else {
                var v = new mat2[count];
                for (int i = 0; i < count; i++) {
                    v[i] = matrix;
                }
                this.SetUniform(location, v);
            }
        }

        public unsafe void SetUniform4ui(int location, uint v0, uint v1, uint v2, uint v3) {
            SetUniform(location, new uvec4(v0, v1, v2, v3));
        }

        public unsafe void SetUniform3ui(int location, uint v0, uint v1, uint v2) {
            SetUniform(location, new uvec3(v0, v1, v2));
        }

        public unsafe void SetUniform2ui(int location, uint v0, uint v1) {
            SetUniform(location, new uvec2(v0, v1));
        }

        public unsafe void SetUniform1ui(int location, uint v0) {
            SetUniform(location, v0);
        }

        public unsafe void SetUniform4i(int location, int v0, int v1, int v2, int v3) {
            SetUniform(location, new ivec4(v0, v1, v2, v3));
        }

        public unsafe void SetUniform3i(int location, int v0, int v1, int v2) {
            SetUniform(location, new ivec3(v0, v1, v2));
        }

        public unsafe void SetUniform2i(int location, int v0, int v1) {
            SetUniform(location, new ivec2(v0, v1));
        }

        public unsafe void SetUniform1i(int location, int v0) {
            SetUniform(location, v0);
        }

        public unsafe void SetUniform4f(int location, float v0, float v1, float v2, float v3) {
            SetUniform(location, new vec4(v0, v1, v2, v3));
        }

        public unsafe void SetUniform3f(int location, float v0, float v1, float v2) {
            SetUniform(location, new vec3(v0, v1, v2));
        }

        public unsafe void SetUniform2f(int location, float v0, float v1) {
            SetUniform(location, new vec2(v0, v1));
        }

        public unsafe void SetUniform1f(int location, float v0) {
            SetUniform(location, v0);
        }


        internal void SetUniform(int location, Object value) {
            if (value == null) { return; }

            Dictionary<int, UniformValue> locationUniformDict = this.location2Uniform;
            if (locationUniformDict.TryGetValue(location, out var uniformValue)) {
                if (uniformValue.variable.fieldInfo.FieldType != value.GetType()) { throw new ArgumentException("value"); }

                uniformValue.value = value;
            }
            else {
                // TODO: what to do when specified uniform variable not exists? Silent or throwing exception?
            }
        }
    }
}
