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
        internal int glUniform(string uniformName, int[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1iv == null) { glUniform1iv = GL.Instance.GetDelegateFor("glUniform1iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                glUniform1iv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        internal int glUniform(string uniformName, float[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1fv == null) { glUniform1fv = GL.Instance.GetDelegateFor("glUniform1fv", GLDelegates.typeof_void_int_int_floatN) as GLDelegates.void_int_int_floatN; }
                glUniform1fv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        internal int glUniform(string uniformName, bvec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2iv == null) { glUniform2iv = GL.Instance.GetDelegateFor("glUniform2iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 2];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, uvec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2uiv == null) { glUniform2uiv = GL.Instance.GetDelegateFor("glUniform2uiv", GLDelegates.typeof_void_int_int_uintN) as GLDelegates.void_int_int_uintN; }
                int count = values.Length;
                var value = new uint[count * 2];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, ivec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2iv == null) { glUniform2iv = GL.Instance.GetDelegateFor("glUniform2iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 2];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, vec2[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2fv == null) { glUniform2fv = GL.Instance.GetDelegateFor("glUniform2fv", GLDelegates.typeof_void_int_int_floatN) as GLDelegates.void_int_int_floatN; }
                int count = values.Length;
                var value = new float[count * 2];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, bvec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3iv == null) { glUniform3iv = GL.Instance.GetDelegateFor("glUniform3iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 3];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, uvec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3uiv == null) { glUniform3uiv = GL.Instance.GetDelegateFor("glUniform3uiv", GLDelegates.typeof_void_int_int_uintN) as GLDelegates.void_int_int_uintN; }
                int count = values.Length;
                var value = new uint[count * 3];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, ivec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3iv == null) { glUniform3iv = GL.Instance.GetDelegateFor("glUniform3iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 3];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, vec3[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3fv == null) { glUniform3fv = GL.Instance.GetDelegateFor("glUniform3fv", GLDelegates.typeof_void_int_int_floatN) as GLDelegates.void_int_int_floatN; }
                int count = values.Length;
                var value = new float[count * 3];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, bvec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4iv == null) { glUniform4iv = GL.Instance.GetDelegateFor("glUniform4iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 4];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, uvec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4uiv == null) { glUniform4uiv = GL.Instance.GetDelegateFor("glUniform4uiv", GLDelegates.typeof_void_int_int_uintN) as GLDelegates.void_int_int_uintN; }
                int count = values.Length;
                var value = new uint[count * 4];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, ivec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4iv == null) { glUniform4iv = GL.Instance.GetDelegateFor("glUniform4iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                int count = values.Length;
                var value = new int[count * 4];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, vec4[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4fv == null) { glUniform4fv = GL.Instance.GetDelegateFor("glUniform4fv", GLDelegates.typeof_void_int_int_floatN) as GLDelegates.void_int_int_floatN; }
                int count = values.Length;
                var value = new float[count * 4];
                int index = 0;
                for (int i = 0; i < values.Length; i++)
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
        internal int glUniform(string uniformName, bool v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1i == null) { glUniform1i = GL.Instance.GetDelegateFor("glUniform1i", GLDelegates.typeof_void_int_int) as GLDelegates.void_int_int; }
                glUniform1i(location, v0 ? 1 : 0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        internal int glUniform(string uniformName, bool[] v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1iv == null) { glUniform1iv = GL.Instance.GetDelegateFor("glUniform1iv", GLDelegates.typeof_void_int_int_intN) as GLDelegates.void_int_int_intN; }
                //TODO: not tested yet.
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
        internal int glUniform(string uniformName, uint v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1ui == null) { glUniform1ui = GL.Instance.GetDelegateFor("glUniform1ui", GLDelegates.typeof_void_int_uint) as GLDelegates.void_int_uint; }
                glUniform1ui(location, v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal int glUniform(string uniformName, uint v0, uint v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2ui == null) { glUniform2ui = GL.Instance.GetDelegateFor("glUniform2ui", GLDelegates.typeof_void_int_uint_uint) as GLDelegates.void_int_uint_uint; }
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
        internal int glUniform(string uniformName, uint v0, uint v1, uint v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3ui == null) { glUniform3ui = GL.Instance.GetDelegateFor("glUniform3ui", GLDelegates.typeof_void_int_uint_uint_uint) as GLDelegates.void_int_uint_uint_uint; }
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
        internal int glUniform(string uniformName, uint v0, uint v1, uint v2, uint v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4ui == null) { glUniform4ui = GL.Instance.GetDelegateFor("glUniform4ui", GLDelegates.typeof_void_int_uint_uint_uint_uint) as GLDelegates.void_int_uint_uint_uint_uint; }
                glUniform4ui(location, v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        internal int glUniform(string uniformName, uint[] values)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1uiv == null) { glUniform1uiv = GL.Instance.GetDelegateFor("glUniform1uiv", GLDelegates.typeof_void_int_int_uintN) as GLDelegates.void_int_int_uintN; }
                glUniform1uiv(location, values.Length, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        internal int glUniform(string uniformName, int v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1i == null) { glUniform1i = GL.Instance.GetDelegateFor("glUniform1i", GLDelegates.typeof_void_int_int) as GLDelegates.void_int_int; }
                glUniform1i(location, v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal int glUniform(string uniformName, int v0, int v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2i == null) { glUniform2i = GL.Instance.GetDelegateFor("glUniform2i", GLDelegates.typeof_void_int_int_int) as GLDelegates.void_int_int_int; }
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
        internal int glUniform(string uniformName, int v0, int v1, int v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3i == null) { glUniform3i = GL.Instance.GetDelegateFor("glUniform3i", GLDelegates.typeof_void_int_int_int_int) as GLDelegates.void_int_int_int_int; }
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
        internal int glUniform(string uniformName, int v0, int v1, int v2, int v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4i == null) { glUniform4i = GL.Instance.GetDelegateFor("glUniform4i", GLDelegates.typeof_void_int_int_int_int_int) as GLDelegates.void_int_int_int_int_int; }
                glUniform4i(location, v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        internal int glUniform(string uniformName, float v0)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform1f == null) { glUniform1f = GL.Instance.GetDelegateFor("glUniform1f", GLDelegates.typeof_void_int_float) as GLDelegates.void_int_float; }
                glUniform1f(location, v0);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal int glUniform(string uniformName, float v0, float v1)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform2f == null) { glUniform2f = GL.Instance.GetDelegateFor("glUniform2f", GLDelegates.typeof_void_int_float_float) as GLDelegates.void_int_float_float; }
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
        internal int glUniform(string uniformName, float v0, float v1, float v2)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform3f == null) { glUniform3f = GL.Instance.GetDelegateFor("glUniform3f", GLDelegates.typeof_void_int_float_float_float) as GLDelegates.void_int_float_float_float; }
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
        internal int glUniform(string uniformName, float v0, float v1, float v2, float v3)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniform4f == null) { glUniform4f = GL.Instance.GetDelegateFor("glUniform4f", GLDelegates.typeof_void_int_float_float_float_float) as GLDelegates.void_int_float_float_float_float; }
                glUniform4f(location, v0, v1, v2, v3);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniform(string uniformName, mat2 m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix2fv == null) { glUniformMatrix2fv = GL.Instance.GetDelegateFor("glUniformMatrix2fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }
                float[] array = m.ToArray();
                glUniformMatrix2fv(location, 1, false, array);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniform(string uniformName, mat3 m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix3fv == null) { glUniformMatrix3fv = GL.Instance.GetDelegateFor("glUniformMatrix3fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }
                float[] array = m.ToArray();
                glUniformMatrix3fv(location, 1, false, array);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniform(string uniformName, mat4 m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix4fv == null) { glUniformMatrix4fv = GL.Instance.GetDelegateFor("glUniformMatrix4fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                float[] array = m.ToArray();

                glUniformMatrix4fv(location, 1, false, array); // NOTE: assign'uniform mat4 M[4];' in instanced rendering.
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="matrixes"></param>
        internal int glUniform(string uniformName, mat2[] matrixes)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix2fv == null) { glUniformMatrix2fv = GL.Instance.GetDelegateFor("glUniformMatrix2fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                var values = new float[matrixes.Length * 4];
                for (int index = 0, i = 0; i < matrixes.Length; i++)
                {
                    mat2 matrix = matrixes[i];
                    values[index++] = matrix.col0.x;
                    values[index++] = matrix.col0.y;
                    values[index++] = matrix.col1.x;
                    values[index++] = matrix.col1.y;
                }
                glUniformMatrix2fv(location, matrixes.Length, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="matrixes"></param>
        internal int glUniform(string uniformName, mat3[] matrixes)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix3fv == null) { glUniformMatrix3fv = GL.Instance.GetDelegateFor("glUniformMatrix3fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                var values = new float[matrixes.Length * 9];
                for (int index = 0, i = 0; i < matrixes.Length; i++)
                {
                    mat3 matrix = matrixes[i];
                    values[index++] = matrix.col0.x;
                    values[index++] = matrix.col0.y;
                    values[index++] = matrix.col0.z;
                    values[index++] = matrix.col1.x;
                    values[index++] = matrix.col1.y;
                    values[index++] = matrix.col1.z;
                    values[index++] = matrix.col2.x;
                    values[index++] = matrix.col2.y;
                    values[index++] = matrix.col2.z;
                }
                glUniformMatrix3fv(location, matrixes.Length, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="matrixes"></param>
        internal int glUniform(string uniformName, mat4[] matrixes)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix4fv == null) { glUniformMatrix4fv = GL.Instance.GetDelegateFor("glUniformMatrix4fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                var values = new float[matrixes.Length * 16];
                for (int index = 0, i = 0; i < matrixes.Length; i++)
                {
                    mat4 matrix = matrixes[i];
                    values[index++] = matrix.col0.x;
                    values[index++] = matrix.col0.y;
                    values[index++] = matrix.col0.z;
                    values[index++] = matrix.col0.w;
                    values[index++] = matrix.col1.x;
                    values[index++] = matrix.col1.y;
                    values[index++] = matrix.col1.z;
                    values[index++] = matrix.col1.w;
                    values[index++] = matrix.col2.x;
                    values[index++] = matrix.col2.y;
                    values[index++] = matrix.col2.z;
                    values[index++] = matrix.col2.w;
                    values[index++] = matrix.col3.x;
                    values[index++] = matrix.col3.y;
                    values[index++] = matrix.col3.z;
                    values[index++] = matrix.col3.w;
                }
                glUniformMatrix4fv(location, matrixes.Length, false, values);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniformMatrix2(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix2fv == null) { glUniformMatrix2fv = GL.Instance.GetDelegateFor("glUniformMatrix2fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                glUniformMatrix2fv(location, m.Length / 4, false, m);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniformMatrix3(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix3fv == null) { glUniformMatrix3fv = GL.Instance.GetDelegateFor("glUniformMatrix3fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                glUniformMatrix3fv(location, m.Length / 9, false, m);
            }
            return location;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        internal int glUniformMatrix4(string uniformName, float[] m)
        {
            int location = GetUniformLocation(uniformName);
            if (location >= 0)
            {
                if (glUniformMatrix4fv == null) { glUniformMatrix4fv = GL.Instance.GetDelegateFor("glUniformMatrix4fv", GLDelegates.typeof_void_int_int_bool_floatN) as GLDelegates.void_int_int_bool_floatN; }

                glUniformMatrix4fv(location, m.Length / 16, false, m);
            }
            return location;
        }
    }
}