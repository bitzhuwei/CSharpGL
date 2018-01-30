using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;

namespace CSharpGL
{
    public partial class ShaderProgram
    {
        private class SubroutineUniform
        {
            public readonly string varNameInShader;
            public readonly string subroutine;

            public SubroutineUniform(string varNameInShader, string subroutine)
            {
                this.varNameInShader = varNameInShader;
                this.subroutine = subroutine;
            }

            public override string ToString()
            {
                return string.Format("var:{0}, subroutine:{1}", this.varNameInShader, subroutine);
            }
        }

        private Dictionary<ShaderType, List<SubroutineUniform>> subroutineUniformDict = new Dictionary<ShaderType, List<SubroutineUniform>>();

        /// <summary>
        /// Sets up a new value to specified uniform variable and mark it as updated so that the new value will be sent to shader before rendering.
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="shaderType"></param>
        /// <param name="subroutine"></param>
        /// <returns></returns>
        public void SetSubroutineUniform(string varNameInShader, ShaderType shaderType, string subroutine)
        {
            List<SubroutineUniform> list;
            if (subroutineUniformDict.TryGetValue(shaderType, out list))
            {
                list.Add(new SubroutineUniform(varNameInShader, subroutine));
            }
            else
            {
                list = new List<SubroutineUniform>();
                list.Add(new SubroutineUniform(varNameInShader, subroutine));
                this.subroutineUniformDict.Add(shaderType, list);
            }
        }

        /// <summary>
        /// Note: invoke this right after glUseProgram().
        /// </summary>
        /// <returns></returns>
        public bool SetSubroutineUniforms()
        {
            if (glGetSubroutineUniformLocation == null)
            {
                glGetSubroutineUniformLocation = GL.Instance.GetDelegateFor("glGetSubroutineUniformLocation", GLDelegates.typeof_int_uint_uint_string) as GLDelegates.int_uint_uint_string;
                glGetSubroutineIndex = GL.Instance.GetDelegateFor("glGetSubroutineIndex", GLDelegates.typeof_uint_uint_uint_string) as GLDelegates.uint_uint_uint_string;
                glUniformSubroutinesuiv = GL.Instance.GetDelegateFor("glUniformSubroutinesuiv", GLDelegates.typeof_void_uint_int_uintN) as GLDelegates.void_uint_int_uintN;
            }

            var size = new int[1];
            GL.Instance.GetIntegerv(GL.GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS, size);
            foreach (var item in this.subroutineUniformDict)
            {
                var indices = new uint[size[0]];
                ShaderType shaderType = item.Key;
                List<SubroutineUniform> list = item.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    SubroutineUniform uniform = list[i];
                    int location = glGetSubroutineUniformLocation(this.ProgramId, (uint)shaderType, uniform.varNameInShader);
                    if (location < 0) { throw new Exception(string.Format("{0} is not an active subroutine uinform in the {1}", uniform.varNameInShader, shaderType)); }
                    uint index = glGetSubroutineIndex(this.ProgramId, (uint)shaderType, uniform.subroutine);
                    if (index == GL.GL_INVALID_INDEX) { throw new Exception(string.Format("The specified subrouine [{0}] is not active in the current bound program for the {1} stage.", uniform.subroutine, shaderType)); }
                    else
                    {
                        indices[location] = index;
                    }
                }
                glUniformSubroutinesuiv((uint)shaderType, indices.Length, indices);
            }
        }

    }
}