using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class ShaderProgram
    {

        static OpenGL.glCreateProgram glCreateProgram;
        static OpenGL.glAttachShader glAttachShader;
        static OpenGL.glLinkProgram glLinkProgram;
        static OpenGL.glDetachShader glDetachShader;
        static OpenGL.glDeleteProgram glDeleteProgram;
        static OpenGL.glGetAttribLocation glGetAttribLocation;
        static OpenGL.glUseProgram glUseProgram;
        static OpenGL.glGetProgramiv glGetProgramiv;
        static OpenGL.glUniform1ui glUniform1ui;
        static OpenGL.glUniform2ui glUniform2ui;
        static OpenGL.glUniform3ui glUniform3ui;
        static OpenGL.glUniform4ui glUniform4ui;
        static OpenGL.glUniform1i glUniform1i;
        static OpenGL.glUniform2i glUniform2i;
        static OpenGL.glUniform3i glUniform3i;
        static OpenGL.glUniform4i glUniform4i;
        static OpenGL.glUniform1f glUniform1f;
        static OpenGL.glUniform2f glUniform2f;
        static OpenGL.glUniform3f glUniform3f;
        static OpenGL.glUniform4f glUniform4f;
        static OpenGL.glUniformMatrix2fv glUniformMatrix2fv;
        static OpenGL.glUniformMatrix3fv glUniformMatrix3fv;
        static OpenGL.glUniformMatrix4fv glUniformMatrix4fv;
        static OpenGL.glGetUniformLocation glGetUniformLocation;

        public ShaderProgram()
        {
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
                glUniform1ui = OpenGL.GetDelegateFor<OpenGL.glUniform1ui>();
                glUniform2ui = OpenGL.GetDelegateFor<OpenGL.glUniform2ui>();
                glUniform3ui = OpenGL.GetDelegateFor<OpenGL.glUniform3ui>();
                glUniform4ui = OpenGL.GetDelegateFor<OpenGL.glUniform4ui>();
                glUniform1i = OpenGL.GetDelegateFor<OpenGL.glUniform1i>();
                glUniform2i = OpenGL.GetDelegateFor<OpenGL.glUniform2i>();
                glUniform3i = OpenGL.GetDelegateFor<OpenGL.glUniform3i>();
                glUniform4i = OpenGL.GetDelegateFor<OpenGL.glUniform4i>();
                glUniform1f = OpenGL.GetDelegateFor<OpenGL.glUniform1f>();
                glUniform2f = OpenGL.GetDelegateFor<OpenGL.glUniform2f>();
                glUniform3f = OpenGL.GetDelegateFor<OpenGL.glUniform3f>();
                glUniform4f = OpenGL.GetDelegateFor<OpenGL.glUniform4f>();
                glUniformMatrix2fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix2fv>();
                glUniformMatrix3fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix3fv>();
                glUniformMatrix4fv = OpenGL.GetDelegateFor<OpenGL.glUniformMatrix4fv>();
                glGetUniformLocation = OpenGL.GetDelegateFor<OpenGL.glGetUniformLocation>();
            }

            this.ShaderProgramObject = glCreateProgram();
        }

        public void Create(params Shader[] shaders)
        {
            if (shaders.Length < 1) { throw new ArgumentException(); }

            uint program = this.ShaderProgramObject;

            foreach (var item in shaders)
            {
                glAttachShader(program, item.ShaderObject);
            }

            glLinkProgram(program);

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
                glDetachShader(program, item.ShaderObject);
            }
        }

        public void Delete()
        {
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                glDeleteProgram(this.ShaderProgramObject);
            }
            this.ShaderProgramObject = 0;
        }

        public uint GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            if (attributeNamesToLocations.ContainsKey(attributeName) == false)
            {
                int location = glGetAttribLocation(this.ShaderProgramObject, attributeName);
                if (location < 0) { throw new Exception(); }

                attributeNamesToLocations[attributeName] = (uint)location;
            }

            //  Return the attribute location.
            return attributeNamesToLocations[attributeName];
        }

        public void Bind()
        {
            glUseProgram(this.ShaderProgramObject);
        }

        public void Unbind()
        {
            glUseProgram(0);
        }

        private bool GetLinkStatus()
        {
            int[] parameters = new int[] { 0 };
            glGetProgramiv(this.ShaderProgramObject, OpenGL.GL_LINK_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(this.ShaderProgramObject, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            OpenGL.GetDelegateFor<OpenGL.glGetProgramInfoLog>()(this.ShaderProgramObject, bufSize, IntPtr.Zero, il);

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
            glUniform1ui(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, uint v0, uint v1)
        {
            glUniform2ui(GetUniformLocation(uniformName), v0, v1);
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
            glUniform3ui(GetUniformLocation(uniformName), v0, v1, v2);
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
            glUniform4ui(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, int v0)
        {
            glUniform1i(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, int v0, int v1)
        {
            glUniform2i(GetUniformLocation(uniformName), v0, v1);
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
            glUniform3i(GetUniformLocation(uniformName), v0, v1, v2);
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
            glUniform4i(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        public void SetUniform(string uniformName, float v0)
        {
            glUniform1f(GetUniformLocation(uniformName), v0);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, float v0, float v1)
        {
            glUniform2f(GetUniformLocation(uniformName), v0, v1);
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
            glUniform3f(GetUniformLocation(uniformName), v0, v1, v2);
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
            glUniform4f(GetUniformLocation(uniformName), v0, v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix2(string uniformName, float[] m)
        {
            glUniformMatrix2fv(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            glUniformMatrix3fv(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix4(string uniformName, float[] m)
        {
            glUniformMatrix4fv(GetUniformLocation(uniformName), 1, false, m);
        }

        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            if (uniformNamesToLocations.ContainsKey(uniformName) == false)
            {
                int location = glGetUniformLocation(this.ShaderProgramObject, uniformName);
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
