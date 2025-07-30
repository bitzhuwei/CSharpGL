using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL {
    public unsafe partial class GLProgram {
        unsafe class UniformVarInShader {
            public readonly uint type;
            public readonly string name;
            public readonly int size;
            public readonly int location;

            public UniformVarInShader(uint type, string name, int size, int location) {
                this.type = type;
                this.name = name;
                this.size = size;
                this.location = location;
            }

            public override string ToString() {
                return string.Format("{0} {1}; size:{2}, location:{3}", type, name, size, location);
            }

            internal UniformVariable? GetUniformVariable(uint programId) {
                var gl = GL.current; if (gl == null) { return null; }
                if (type == GL.GL_FLOAT) {
                    var value = new float[1];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformFloat(this.name, value[0]);
                }
                else if (type == GL.GL_FLOAT_VEC2) {
                    var value = new float[2];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformVec2(this.name, new vec2(value[0], value[1]));
                }
                else if (type == GL.GL_FLOAT_VEC3) {
                    var value = new float[3];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformVec3(this.name, new vec3(value[0], value[1], value[2]));
                }
                else if (type == GL.GL_FLOAT_VEC4) {
                    var value = new float[4];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformVec4(this.name, new vec4(value[0], value[1], value[2], value[3]));
                }
                else if (type == GL.GL_INT) {
                    var value = new int[1];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformInt32(this.name, value[0]);
                }
                else if (type == GL.GL_INT_VEC2) {
                    var value = new int[2];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformIVec2(this.name, new ivec2(value[0], value[1]));
                }
                else if (type == GL.GL_INT_VEC3) {
                    var value = new int[3];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformIVec3(this.name, new ivec3(value[0], value[1], value[2]));
                }
                else if (type == GL.GL_INT_VEC4) {
                    var value = new int[4];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformIVec4(this.name, new ivec4(value[0], value[1], value[2], value[3]));
                }
                else if (type == GL.GL_BOOL) {
                    var value = new int[1];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformBool(this.name, value[0] != 0);
                }
                else if (type == GL.GL_BOOL_VEC2) {
                    var value = new int[2];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformBVec2(this.name, new bvec2(value[0], value[1]));
                }
                else if (type == GL.GL_BOOL_VEC3) {
                    var value = new int[3];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformBVec3(this.name, new bvec3(value[0], value[1], value[2]));
                }
                else if (type == GL.GL_BOOL_VEC4) {
                    var value = new int[4];
                    gl.glGetUniformiv(programId, location, value);
                    return new UniformBVec4(this.name, new bvec4(value[0], value[1], value[2], value[3]));
                }
                else if (type == GL.GL_FLOAT_MAT2) {
                    var value = new float[4];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformMat2(this.name, new mat2(value[0], value[1], value[2], value[3]));
                }
                else if (type == GL.GL_FLOAT_MAT3) {
                    var value = new float[9];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformMat3(this.name, new mat3(
                        new vec3(value[0], value[1], value[2]),
                        new vec3(value[3], value[4], value[5]),
                        new vec3(value[6], value[7], value[8])));
                }
                else if (type == GL.GL_FLOAT_MAT4) {
                    // TODO: try var value = stackalloc float[16];
                    var value = new float[16];
                    gl.glGetUniformfv(programId, location, value);
                    return new UniformMat4(this.name, new mat4(
                        new vec4(value[0], value[1], value[2], value[3]),
                        new vec4(value[4], value[5], value[6], value[7]),
                        new vec4(value[8], value[9], value[10], value[11]),
                        new vec4(value[12], value[13], value[14], value[15])));
                }
                else if (type == GL.GL_SAMPLER_1D
                    || type == GL.GL_SAMPLER_2D
                    || type == GL.GL_SAMPLER_3D
                    || type == GL.GL_SAMPLER_CUBE
                    || type == GL.GL_SAMPLER_1D_SHADOW
                    || type == GL.GL_SAMPLER_2D_SHADOW
                    || type == GL.GL_SAMPLER_2D_RECT
                    || type == GL.GL_SAMPLER_2D_ARRAY
                    || type == GL.GL_SAMPLER_2D_RECT_SHADOW
                    || type == 0x904D // uniform image2D xxx;
                    || type == 0x9063 // uniform uimage2D xxx;
                    || type == 0x9067 // uniform uimageBuffer xxx;
                    || type == 0x92DB // uniform atomic_uint xxx;
                    ) {
                    return null;// not need to deal with these.
                }
                else // TODO: not dealt with uniform array or blocks.
                {
                    Log.Write(string.Format("Not dealt with uniform type:[{0}]", type));
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private UniformVarInShader[] LoadAllUniformsInShader() {
            var gl = GL.current; if (gl == null) { return new UniformVarInShader[0]; }
            uint programId = this.programId;
            int count = GetActivetUniformCount(programId);
            int maxNameLength = GetActionUniformNameMaxLength(programId);
            var variables = new UniformVarInShader[count];
            var nameLength = new GLsizei[1];// useless in C#.
            var uniformVarSize = new GLint[1];
            var uniformVarType = new GLenum[1];
            for (uint index = 0; index < count; index++) {
                var il = new StringBuilder(maxNameLength);
                gl.glGetActiveUniform(programId, index, maxNameLength, nameLength, uniformVarSize, uniformVarType, il);
                string name = il.ToString();
                int location = this.GetUniformLocation(name);
                variables[index] = new UniformVarInShader(uniformVarType[0], name, uniformVarSize[0], location);
            }

            return variables;
        }

        private int GetActionUniformNameMaxLength(uint programId) {
            //  Get the info log length.
            var gl = GL.current; if (gl == null) { return -1; }
            var infoLength = stackalloc int[1];
            gl.glGetProgramiv(programId, GL.GL_ACTIVE_UNIFORM_MAX_LENGTH, infoLength);
            return infoLength[0];
        }

        /// <summary>
        /// How many uniform variables are there?
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        private int GetActivetUniformCount(uint programId) {
            //  Get the info log length.
            var gl = GL.current; if (gl == null) { return -1; }
            var infoLength = stackalloc int[1];
            gl.glGetProgramiv(programId, GL.GL_ACTIVE_UNIFORMS, infoLength);
            return infoLength[0];
        }
    }
}