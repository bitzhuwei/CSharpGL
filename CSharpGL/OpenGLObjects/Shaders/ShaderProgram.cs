using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class ShaderProgram
    {

        public ShaderProgram()
        {
            this.ShaderProgramObject = GL.GetDelegateFor<GL.glCreateProgram>()();
        }

        public void Create(params Shader[] shaders)
        {
            if (shaders.Length < 1) { throw new ArgumentException(); }

            uint program = this.ShaderProgramObject;

            foreach (var item in shaders)
            {
                GL.GetDelegateFor<GL.glAttachShader>()(program, item.ShaderObject);
            }

            GL.GetDelegateFor<GL.glLinkProgram>()(program);

            if (this.GetLinkStatus() == false)
            {
                string log = this.GetInfoLog();
                throw new ShaderCompilationException(
                    string.Format("Failed to link shader program with ID {0}.", program),
                    log);
            }

            foreach (var item in shaders)
            {
                if (item.GetCompileStatus() == false)
                {
                    string log = item.GetInfoLog();
                    throw new Exception(log);
                }
            }

            foreach (var item in shaders)
            {
                GL.GetDelegateFor<GL.glDetachShader>()(program, item.ShaderObject);
            }
        }

        public void Delete()
        {
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                GL.GetDelegateFor<GL.glDeleteProgram>()(this.ShaderProgramObject);
            }
            this.ShaderProgramObject = 0;
        }

        public uint GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            if (attributeNamesToLocations.ContainsKey(attributeName) == false)
            {
                int location = GL.GetDelegateFor<GL.glGetAttribLocation>()(ShaderProgramObject, attributeName);
                if (location < 0) { throw new Exception(); }

                attributeNamesToLocations[attributeName] = (uint)location;
            }

            //  Return the attribute location.
            return attributeNamesToLocations[attributeName];
        }

        public void Bind()
        {
            GL.GetDelegateFor<GL.glUseProgram>()(ShaderProgramObject);
        }

        public void Unbind()
        {
            GL.GetDelegateFor<GL.glUseProgram>()(0);
        }

        private bool GetLinkStatus()
        {
            int[] parameters = new int[] { 0 };
            GL.GetDelegateFor<GL.glGetProgramiv>()(ShaderProgramObject, GL.GL_LINK_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            GL.GetDelegateFor<GL.glGetProgramiv>()(ShaderProgramObject, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            GL.GetDelegateFor<GL.glGetProgramInfoLog>()(ShaderProgramObject, bufSize, IntPtr.Zero, il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, int v0)
        {
            GL.GetDelegateFor<GL.glUniform1i>()(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, int v0, int v1)
        {
            GL.GetDelegateFor<GL.glUniform2i>()(GetUniformLocation(uniformName), v0, v1);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetUniform(string uniformName, int v0, int v1, int v2)
        {
            GL.GetDelegateFor<GL.glUniform3i>()(GetUniformLocation(uniformName), v0, v1, v2);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void SetUniform(string uniformName, int v0, int v1, int v2, int v3)
        {
            GL.GetDelegateFor<GL.glUniform4i>()(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, float v0)
        {
            GL.GetDelegateFor<GL.glUniform1f>()(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, float v0, float v1)
        {
            GL.GetDelegateFor<GL.glUniform2f>()(GetUniformLocation(uniformName), v0, v1);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetUniform(string uniformName, float v0, float v1, float v2)
        {
            GL.GetDelegateFor<GL.glUniform3f>()(GetUniformLocation(uniformName), v0, v1, v2);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void SetUniform(string uniformName, float v0, float v1, float v2, float v3)
        {
            GL.GetDelegateFor<GL.glUniform4f>()(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix2(string uniformName, float[] m)
        {
            GL.GetDelegateFor<GL.glUniformMatrix2fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            GL.GetDelegateFor<GL.glUniformMatrix3fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix4(string uniformName, float[] m)
        {
            GL.GetDelegateFor<GL.glUniformMatrix4fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            if (uniformNamesToLocations.ContainsKey(uniformName) == false)
            {
                uniformNamesToLocations[uniformName] = GL.GetDelegateFor<GL.glGetUniformLocation>()(ShaderProgramObject, uniformName);
                //  TODO: if it's not found, we should probably throw an exception.
            }

            //  Return the uniform location.
            return uniformNamesToLocations[uniformName];
        }

        /// <summary>
        /// Gets the shader program object.
        /// </summary>
        /// <value>
        /// The shader program object.
        /// </value>
        public uint ShaderProgramObject { get; protected set; }


        /// <summary>
        /// A mapping of uniform names to locations. This allows us to very easily specify
        /// uniform data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> uniformNamesToLocations = new Dictionary<string, int>();

        /// <summary>
        /// A mapping of attribute names to locations. This allows us to very easily specify
        /// attribute data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, uint> attributeNamesToLocations = new Dictionary<string, uint>();
    }
}
