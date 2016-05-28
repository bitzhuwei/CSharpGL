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
            this.ShaderProgramObject = OpenGL.GetDelegateFor<OpenGL.glCreateProgram>()();
        }

        public void Create(params Shader[] shaders)
        {
            if (shaders.Length < 1) { throw new ArgumentException(); }

            uint program = this.ShaderProgramObject;

            foreach (var item in shaders)
            {
                OpenGL.GetDelegateFor<OpenGL.glAttachShader>()(program, item.ShaderObject);
            }

            OpenGL.GetDelegateFor<OpenGL.glLinkProgram>()(program);

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
                OpenGL.GetDelegateFor<OpenGL.glDetachShader>()(program, item.ShaderObject);
            }
        }

        public void Delete()
        {
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                OpenGL.GetDelegateFor<OpenGL.glDeleteProgram>()(this.ShaderProgramObject);
            }
            this.ShaderProgramObject = 0;
        }

        public uint GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            if (attributeNamesToLocations.ContainsKey(attributeName) == false)
            {
                int location = OpenGL.GetDelegateFor<OpenGL.glGetAttribLocation>()(ShaderProgramObject, attributeName);
                if (location < 0) { throw new Exception(); }

                attributeNamesToLocations[attributeName] = (uint)location;
            }

            //  Return the attribute location.
            return attributeNamesToLocations[attributeName];
        }

        public void Bind()
        {
            OpenGL.GetDelegateFor<OpenGL.glUseProgram>()(ShaderProgramObject);
        }

        public void Unbind()
        {
            OpenGL.GetDelegateFor<OpenGL.glUseProgram>()(0);
        }

        private bool GetLinkStatus()
        {
            int[] parameters = new int[] { 0 };
            OpenGL.GetDelegateFor<OpenGL.glGetProgramiv>()(ShaderProgramObject, OpenGL.GL_LINK_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            OpenGL.GetDelegateFor<OpenGL.glGetProgramiv>()(ShaderProgramObject, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            OpenGL.GetDelegateFor<OpenGL.glGetProgramInfoLog>()(ShaderProgramObject, bufSize, IntPtr.Zero, il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, uint v0)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform1ui>()(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, uint v0, uint v1)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform2ui>()(GetUniformLocation(uniformName), v0, v1);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetUniform(string uniformName, uint v0, uint v1, uint v2)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform3ui>()(GetUniformLocation(uniformName), v0, v1, v2);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void SetUniform(string uniformName, uint v0, uint v1, uint v2, uint v3)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform4ui>()(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, int v0)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform1i>()(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, int v0, int v1)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform2i>()(GetUniformLocation(uniformName), v0, v1);
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
            OpenGL.GetDelegateFor<OpenGL.glUniform3i>()(GetUniformLocation(uniformName), v0, v1, v2);
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
            OpenGL.GetDelegateFor<OpenGL.glUniform4i>()(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, float v0)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform1f>()(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, float v0, float v1)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniform2f>()(GetUniformLocation(uniformName), v0, v1);
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
            OpenGL.GetDelegateFor<OpenGL.glUniform3f>()(GetUniformLocation(uniformName), v0, v1, v2);
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
            OpenGL.GetDelegateFor<OpenGL.glUniform4f>()(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix2(string uniformName, float[] m)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniformMatrix2fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniformMatrix3fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix4(string uniformName, float[] m)
        {
            OpenGL.GetDelegateFor<OpenGL.glUniformMatrix4fv>()(GetUniformLocation(uniformName), 1, false, m);
        }

        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            if (uniformNamesToLocations.ContainsKey(uniformName) == false)
            {
                int location = OpenGL.GetDelegateFor<OpenGL.glGetUniformLocation>()(ShaderProgramObject, uniformName);
                if (location < 0)
                { throw new Exception(string.Format("No uniform found for the name [{0}]", uniformName)); }

                uniformNamesToLocations[uniformName] = location;
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
