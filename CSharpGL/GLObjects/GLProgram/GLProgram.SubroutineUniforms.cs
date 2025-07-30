using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;

namespace CSharpGL {
    public unsafe partial class GLProgram {
        private unsafe class SubroutineUniform {
            public readonly string varNameInShader;
            public readonly string subroutine;

            public SubroutineUniform(string varNameInShader, string subroutine) {
                this.varNameInShader = varNameInShader;
                this.subroutine = subroutine;
            }

            public override string ToString() {
                return string.Format("var:{0}, subroutine:{1}", this.varNameInShader, subroutine);
            }
        }

        private Dictionary<Shader.Kind, List<SubroutineUniform>> subroutineUniformDict = new();

        /// <summary>
        /// Sets up a new value to specified uniform variable and mark it as updated so that the new value will be sent to shader before rendering.
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="shaderType"></param>
        /// <param name="subroutine"></param>
        /// <returns></returns>
        public void SetSubroutineUniform(string varNameInShader, Shader.Kind shaderType, string subroutine) {
            //List<SubroutineUniform> list;
            if (subroutineUniformDict.TryGetValue(shaderType, out var list)) {
                list.Add(new SubroutineUniform(varNameInShader, subroutine));
            }
            else {
                list = new List<SubroutineUniform>();
                list.Add(new SubroutineUniform(varNameInShader, subroutine));
                this.subroutineUniformDict.Add(shaderType, list);
            }
        }

        /// <summary>
        /// Note: invoke this right after glUseProgram().
        /// </summary>
        /// <returns></returns>
        public bool SetSubroutineUniforms() {
            var gl = GL.current; if (gl == null) { return false; }
            //if (glGetSubroutineUniformLocation == null) {
            //	gl.glGetSubroutineUniformLocation = GL.Instance.GetDelegateFor("glGetSubroutineUniformLocation", GLDelegates.typeof_int_uint_uint_string) as GLDelegates.int_uint_uint_string;
            //	gl.glGetSubroutineIndex = GL.Instance.GetDelegateFor("glGetSubroutineIndex", GLDelegates.typeof_uint_uint_uint_string) as GLDelegates.uint_uint_uint_string;
            //	gl.glUniformSubroutinesuiv = GL.Instance.GetDelegateFor("glUniformSubroutinesuiv", GLDelegates.typeof_void_uint_int_uintN) as GLDelegates.void_uint_int_uintN;
            //}

            var size = stackalloc int[1];
            gl.glGetIntegerv(0x8DE8/*GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS*/, size);
            foreach (var item in this.subroutineUniformDict) {
                var indices = new uint[size[0]];
                var shaderType = item.Key;
                List<SubroutineUniform> list = item.Value;
                for (int i = 0; i < list.Count; i++) {
                    SubroutineUniform uniform = list[i];
                    int location = gl.glGetSubroutineUniformLocation(this.programId, (uint)shaderType, uniform.varNameInShader);
                    if (location < 0) { throw new Exception(string.Format("{0} is not an active subroutine uinform in the {1}", uniform.varNameInShader, shaderType)); }
                    uint index = gl.glGetSubroutineIndex(this.programId, (uint)shaderType, uniform.subroutine);
                    if (index == 0xFFFFFFFFu/*GL_INVALID_INDEX*/) { throw new Exception(string.Format("The specified subrouine [{0}] is not active in the current bound program for the {1} stage.", uniform.subroutine, shaderType)); }
                    else { indices[location] = index; }
                }
                fixed (uint* p = indices) {
                    gl.glUniformSubroutinesuiv((GLenum)shaderType, indices.Length, p);
                }
            }
            return true;
        }

    }
}