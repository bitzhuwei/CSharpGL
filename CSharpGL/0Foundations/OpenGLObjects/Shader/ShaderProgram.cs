using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A shader program object.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class ShaderProgram
    {
        private static OpenGL.glCreateProgram glCreateProgram;
        private static OpenGL.glAttachShader glAttachShader;
        private static OpenGL.glLinkProgram glLinkProgram;
        private static OpenGL.glDetachShader glDetachShader;
        private static OpenGL.glDeleteProgram glDeleteProgram;
        private static OpenGL.glGetAttribLocation glGetAttribLocation;
        private static OpenGL.glUseProgram glUseProgram;
        private static OpenGL.glGetProgramiv glGetProgramiv;
        private static OpenGL.glUniform1ui glUniform1ui;
        private static OpenGL.glUniform2ui glUniform2ui;
        private static OpenGL.glUniform3ui glUniform3ui;
        private static OpenGL.glUniform4ui glUniform4ui;
        private static OpenGL.glUniform1uiv glUniform1uiv;
        private static OpenGL.glUniform2uiv glUniform2uiv;
        private static OpenGL.glUniform3uiv glUniform3uiv;
        private static OpenGL.glUniform4uiv glUniform4uiv;
        private static OpenGL.glUniform1i glUniform1i;
        private static OpenGL.glUniform2i glUniform2i;
        private static OpenGL.glUniform3i glUniform3i;
        private static OpenGL.glUniform4i glUniform4i;
        private static OpenGL.glUniform1iv glUniform1iv;
        private static OpenGL.glUniform2iv glUniform2iv;
        private static OpenGL.glUniform3iv glUniform3iv;
        private static OpenGL.glUniform4iv glUniform4iv;
        private static OpenGL.glUniform1f glUniform1f;
        private static OpenGL.glUniform2f glUniform2f;
        private static OpenGL.glUniform3f glUniform3f;
        private static OpenGL.glUniform4f glUniform4f;
        private static OpenGL.glUniform1fv glUniform1fv;
        private static OpenGL.glUniform2fv glUniform2fv;
        private static OpenGL.glUniform3fv glUniform3fv;
        private static OpenGL.glUniform4fv glUniform4fv;
        private static OpenGL.glUniformMatrix2fv glUniformMatrix2fv;
        private static OpenGL.glUniformMatrix3fv glUniformMatrix3fv;
        private static OpenGL.glUniformMatrix4fv glUniformMatrix4fv;
        private static OpenGL.glGetUniformLocation glGetUniformLocation;

        /// <summary>
        /// Initialize this shader program object.
        /// </summary>
        /// <param name="shaders"></param>
        public void Initialize(params Shader[] shaders)
        {
            //if (shaders.Length < 1) { throw new ArgumentException(); }

            if (glCreateProgram == null)
            {
                glCreateProgram = OpenGL.GetDelegateFor<OpenGL.glCreateProgram>();
                glAttachShader = OpenGL.GetDelegateFor<OpenGL.glAttachShader>();
                glLinkProgram = OpenGL.GetDelegateFor<OpenGL.glLinkProgram>();
                glDetachShader = OpenGL.GetDelegateFor<OpenGL.glDetachShader>();
                glDeleteProgram = OpenGL.GetDelegateFor<OpenGL.glDeleteProgram>();
                glGetAttribLocation = OpenGL.GetDelegateFor<OpenGL.glGetAttribLocation>();
                glUseProgram = OpenGL.GetDelegateFor<OpenGL.glUseProgram>();
                glGetProgramiv = OpenGL.GetDelegateFor<OpenGL.glGetProgramiv>();
                glGetUniformLocation = OpenGL.GetDelegateFor<OpenGL.glGetUniformLocation>();
            }

            uint programId = glCreateProgram();

            foreach (var item in shaders)
            {
                glAttachShader(programId, item.ShaderObject);
            }

            glLinkProgram(programId);

            if (this.GetLinkStatus(programId) == false)
            {
                string log = this.GetInfoLog(programId);
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}",
                        programId, log));
            }

            foreach (var item in shaders)
            {
                glDetachShader(programId, item.ShaderObject);
            }

            this.ProgramId = programId;
        }

        /// <summary>
        /// Query location/index of specified <paramref name="attributeName"/>.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public int GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            int location;
            if (!attributeNamesToLocations.TryGetValue(attributeName, out location))
            {
                location = glGetAttribLocation(this.ProgramId, attributeName);
                if (location < 0)
                {
                    Debug.WriteLine(string.Format("Failed to getAttribLocation for [{0}]", attributeName));
                }

                attributeNamesToLocations[attributeName] = location;
            }

            //  Return the attribute location.
            return location;
        }

        /// <summary>
        /// Use this program.
        /// </summary>
        public void Bind()
        {
            glUseProgram(this.ProgramId);
        }

        /// <summary>
        /// Stop using this program.
        /// </summary>
        public void Unbind()
        {
            glUseProgram(0);
        }

        private bool GetLinkStatus(uint program)
        {
            int[] parameters = new int[] { 0 };
            glGetProgramiv(program, OpenGL.GL_LINK_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        private string GetInfoLog(uint program)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(program, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            OpenGL.GetDelegateFor<OpenGL.glGetProgramInfoLog>()(program, bufSize, IntPtr.Zero, il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, int[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1iv == null) { glUniform1iv = OpenGL.GetDelegateFor<OpenGL.glUniform1iv>(); }
                glUniform1iv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, float[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1fv == null) { glUniform1fv = OpenGL.GetDelegateFor<OpenGL.glUniform1fv>(); }
                glUniform1fv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, bvec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2iv == null) { glUniform2iv = OpenGL.GetDelegateFor<OpenGL.glUniform2iv>(); }
                int count = values.Length;
                var value = new int[count * 2];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x ? 1 : 0;
                    value[index++] = values[i].y ? 1 : 0;
                }
                glUniform2iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, uvec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2uiv == null) { glUniform2uiv = OpenGL.GetDelegateFor<OpenGL.glUniform2uiv>(); }
                int count = values.Length;
                var value = new uint[count * 2];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                }
                glUniform2uiv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, ivec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2iv == null) { glUniform2iv = OpenGL.GetDelegateFor<OpenGL.glUniform2iv>(); }
                int count = values.Length;
                var value = new int[count * 2];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                }
                glUniform2iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, vec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2fv == null) { glUniform2fv = OpenGL.GetDelegateFor<OpenGL.glUniform2fv>(); }
                int count = values.Length;
                var value = new float[count * 2];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                }
                glUniform2fv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, bvec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3iv == null) { glUniform3iv = OpenGL.GetDelegateFor<OpenGL.glUniform3iv>(); }
                int count = values.Length;
                var value = new int[count * 3];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x ? 1 : 0;
                    value[index++] = values[i].y ? 1 : 0;
                    value[index++] = values[i].z ? 1 : 0;
                }
                glUniform3iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, uvec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3uiv == null) { glUniform3uiv = OpenGL.GetDelegateFor<OpenGL.glUniform3uiv>(); }
                int count = values.Length;
                var value = new uint[count * 3];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                }
                glUniform3uiv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, ivec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3iv == null) { glUniform3iv = OpenGL.GetDelegateFor<OpenGL.glUniform3iv>(); }
                int count = values.Length;
                var value = new int[count * 3];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                }
                glUniform3iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, vec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3fv == null) { glUniform3fv = OpenGL.GetDelegateFor<OpenGL.glUniform3fv>(); }
                int count = values.Length;
                var value = new float[count * 3];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                }
                glUniform3fv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, bvec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4iv == null) { glUniform4iv = OpenGL.GetDelegateFor<OpenGL.glUniform4iv>(); }
                int count = values.Length;
                var value = new int[count * 4];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x ? 1 : 0;
                    value[index++] = values[i].y ? 1 : 0;
                    value[index++] = values[i].z ? 1 : 0;
                    value[index++] = values[i].w ? 1 : 0;
                }
                glUniform4iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, uvec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4uiv == null) { glUniform4uiv = OpenGL.GetDelegateFor<OpenGL.glUniform4uiv>(); }
                int count = values.Length;
                var value = new uint[count * 4];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                    value[index++] = values[i].w;
                }
                glUniform4uiv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, ivec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4iv == null) { glUniform4iv = OpenGL.GetDelegateFor<OpenGL.glUniform4iv>(); }
                int count = values.Length;
                var value = new int[count * 4];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                    value[index++] = values[i].w;
                }
                glUniform4iv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, vec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4fv == null) { glUniform4fv = OpenGL.GetDelegateFor<OpenGL.glUniform4fv>(); }
                int count = values.Length;
                var value = new float[count * 4];
                int index = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    value[index++] = values[i].x;
                    value[index++] = values[i].y;
                    value[index++] = values[i].z;
                    value[index++] = values[i].w;
                }
                glUniform4fv(GetUniformLocation(uniformName), count, value);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public int SetUniform(string uniformName, bool v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1i == null) { glUniform1i = OpenGL.GetDelegateFor<OpenGL.glUniform1i>(); }
                glUniform1i(GetUniformLocation(uniformName), v0 ? 1 : 0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public int SetUniform(string uniformName, bool[] v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1iv == null) { glUniform1iv = OpenGL.GetDelegateFor<OpenGL.glUniform1iv>(); }
                //TODO: note tested yet.
                var values = new int[v0.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = v0[i] ? 1 : 0;
                }
                glUniform1iv(GetUniformLocation(uniformName), values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public int SetUniform(string uniformName, uint v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1ui == null) { glUniform1ui = OpenGL.GetDelegateFor<OpenGL.glUniform1ui>(); }
                glUniform1ui(GetUniformLocation(uniformName), v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public int SetUniform(string uniformName, uint v0, uint v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2ui == null) { glUniform2ui = OpenGL.GetDelegateFor<OpenGL.glUniform2ui>(); }
                glUniform2ui(GetUniformLocation(uniformName), v0, v1);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public int SetUniform(string uniformName, uint v0, uint v1, uint v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3ui == null) { glUniform3ui = OpenGL.GetDelegateFor<OpenGL.glUniform3ui>(); }
                glUniform3ui(GetUniformLocation(uniformName), v0, v1, v2);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public int SetUniform(string uniformName, uint v0, uint v1, uint v2, uint v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4ui == null) { glUniform4ui = OpenGL.GetDelegateFor<OpenGL.glUniform4ui>(); }
                glUniform4ui(GetUniformLocation(uniformName), v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int SetUniform(string uniformName, uint[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1uiv == null) { glUniform1uiv = OpenGL.GetDelegateFor<OpenGL.glUniform1uiv>(); }
                glUniform1uiv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public int SetUniform(string uniformName, int v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1i == null) { glUniform1i = OpenGL.GetDelegateFor<OpenGL.glUniform1i>(); }
                glUniform1i(GetUniformLocation(uniformName), v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public int SetUniform(string uniformName, int v0, int v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2i == null) { glUniform2i = OpenGL.GetDelegateFor<OpenGL.glUniform2i>(); }
                glUniform2i(GetUniformLocation(uniformName), v0, v1);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public int SetUniform(string uniformName, int v0, int v1, int v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3i == null) { glUniform3i = OpenGL.GetDelegateFor<OpenGL.glUniform3i>(); }
                glUniform3i(GetUniformLocation(uniformName), v0, v1, v2);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public int SetUniform(string uniformName, int v0, int v1, int v2, int v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4i == null) { glUniform4i = OpenGL.GetDelegateFor<OpenGL.glUniform4i>(); }
                glUniform4i(GetUniformLocation(uniformName), v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public int SetUniform(string uniformName, float v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1f == null) { glUniform1f = OpenGL.GetDelegateFor<OpenGL.glUniform1f>(); }
                glUniform1f(GetUniformLocation(uniformName), v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public int SetUniform(string uniformName, float v0, float v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2f == null) { glUniform2f = OpenGL.GetDelegateFor<OpenGL.glUniform2f>(); }
                glUniform2f(GetUniformLocation(uniformName), v0, v1);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public int SetUniform(string uniformName, float v0, float v1, float v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3f == null) { glUniform3f = OpenGL.GetDelegateFor<OpenGL.glUniform3f>(); }
                glUniform3f(GetUniformLocation(uniformName), v0, v1, v2);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public int SetUniform(string uniformName, float v0, float v1, float v2, float v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4f == null) { glUniform4f = OpenGL.GetDelegateFor<OpenGL.glUniform4f>(); }
                glUniform4f(location, v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix2(string uniformName, mat2[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix2fv == null) { glUniformMatrix2fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix2fv>(); }
                var values = new float[m.Length * 4];
                for (int index = 0, i = 0; i < m.Length; i++)
                {
                    float[] array = m[i].ToArray();
                    for (int j = 0; j < 4; j++)
                    {
                        values[index++] = array[j];
                    }
                }
                glUniformMatrix2fv(location, m.Length / 4, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix3(string uniformName, mat3[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix3fv == null) { glUniformMatrix3fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix3fv>(); }
                var values = new float[m.Length * 9];
                for (int index = 0, i = 0; i < m.Length; i++)
                {
                    float[] array = m[i].ToArray();
                    for (int j = 0; j < 9; j++)
                    {
                        values[index++] = array[j];
                    }
                }
                glUniformMatrix3fv(location, m.Length / 9, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix4(string uniformName, mat4[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix4fv == null) { glUniformMatrix4fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix4fv>(); }
                var values = new float[m.Length * 16];
                for (int index = 0, i = 0; i < m.Length; i++)
                {
                    float[] array = m[i].ToArray();
                    for (int j = 0; j < 16; j++)
                    {
                        values[index++] = array[j];
                    }
                }
                glUniformMatrix4fv(location, m.Length / 16, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix2(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix2fv == null) { glUniformMatrix2fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix2fv>(); }
                glUniformMatrix2fv(location, m.Length / 4, false, m);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix3(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix3fv == null) { glUniformMatrix3fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix3fv>(); }
                glUniformMatrix3fv(location, m.Length / 9, false, m);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public int SetUniformMatrix4(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix4fv == null) { glUniformMatrix4fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix4fv>(); }
                glUniformMatrix4fv(location, m.Length / 16, false, m);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <returns></returns>
        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            int location;
            if (!uniformNamesToLocations.TryGetValue(uniformName, out location))
            {
                location = glGetUniformLocation(this.ProgramId, uniformName);
                if (location < 0)
                { Debug.WriteLine(string.Format("No uniform found for the name [{0}]", uniformName)); }

                uniformNamesToLocations[uniformName] = location;
            }

            //  Return the uniform location.
            return location;
        }

        /// <summary>
        /// Gets the shader program object.
        /// </summary>
        public uint ProgramId { get; protected set; }

        /// <summary>
        /// A mapping of uniform names to locations. This allows us to very easily specify
        /// uniform data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> uniformNamesToLocations = new Dictionary<string, int>();

        /// <summary>
        /// A mapping of attribute names to locations. This allows us to very easily specify
        /// attribute data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> attributeNamesToLocations = new Dictionary<string, int>();
    }
}