using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// A shader program object.
    /// </summary>
    public partial class ShaderProgram
    {
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
                glUniform2iv(location, count, value);
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
                glUniform2uiv(location, count, value);
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
                glUniform2iv(location, count, value);
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
                glUniform2fv(location, count, value);
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
                glUniform3iv(location, count, value);
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
                glUniform3uiv(location, count, value);
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
                glUniform3iv(location, count, value);
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
                glUniform3fv(location, count, value);
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
                glUniform4iv(location, count, value);
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
                glUniform4uiv(location, count, value);
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
                glUniform4iv(location, count, value);
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
                glUniform4fv(location, count, value);
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
                glUniform1i(location, v0 ? 1 : 0);
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
                glUniform1iv(location, values.Length, values);
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
                glUniform1ui(location, v0);
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
                glUniform2ui(location, v0, v1);
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
                glUniform3ui(location, v0, v1, v2);
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
                glUniform4ui(location, v0, v1, v2, v3);
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
                glUniform1i(location, v0);
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
                glUniform2i(location, v0, v1);
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
                glUniform3i(location, v0, v1, v2);
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
                glUniform4i(location, v0, v1, v2, v3);
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
                glUniform1f(location, v0);
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
                glUniform2f(location, v0, v1);
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
                glUniform3f(location, v0, v1, v2);
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
    }
}