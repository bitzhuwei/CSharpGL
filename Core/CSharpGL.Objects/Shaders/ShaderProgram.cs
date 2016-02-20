using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Shaders
{
    public class ShaderProgram
    {
        private readonly Shader vertexShader = new Shader();
        private readonly Shader fragmentShader = new Shader();
        private Shader geometryShader;// = new Shader();

        /// <summary>
        /// Creates the shader program.
        /// </summary>
        /// <param name="vertexShaderSource">The vertex shader source.</param>
        /// <param name="fragmentShaderSource">The fragment shader source.</param>
        /// <param name="attributeLocations">The attribute locations. This is an optional array of
        /// uint attribute locations to their names.</param>
        /// <exception cref="ShaderCompilationException"></exception>
        public void Create(string vertexShaderSource, string fragmentShaderSource, string geometryShaderSource = null,
            Dictionary<uint, string> attributeLocations = null)
        {
            //  Create the shaders.
            vertexShader.Create(GL.GL_VERTEX_SHADER, vertexShaderSource);
            if (geometryShaderSource != null)
            {
                geometryShader = new Shader();
                geometryShader.Create(GL.GL_GEOMETRY_SHADER, geometryShaderSource);
            }
            fragmentShader.Create(GL.GL_FRAGMENT_SHADER, fragmentShaderSource);

            //  Create the program, attach the shaders.
            ShaderProgramObject = GL.CreateProgram();
            GL.AttachShader(ShaderProgramObject, vertexShader.ShaderObject);
            if (geometryShaderSource != null)
            { GL.AttachShader(ShaderProgramObject, geometryShader.ShaderObject); }
            GL.AttachShader(ShaderProgramObject, fragmentShader.ShaderObject);

            //  Before we link, bind any vertex attribute locations.
            if (attributeLocations != null)
            {
                foreach (var vertexAttributeLocation in attributeLocations)
                    GL.BindAttribLocation(ShaderProgramObject, vertexAttributeLocation.Key, vertexAttributeLocation.Value);
            }

            //  Now we can link the program.
            GL.LinkProgram(ShaderProgramObject);

            //  Now that we've compiled and linked the shader, check it's link status. If it's not linked properly, we're
            //  going to throw an exception.
            if (GetLinkStatus() == false)
            {
                string log = this.GetInfoLog();
                throw new ShaderCompilationException(
                    string.Format("Failed to link shader program with ID {0}.", ShaderProgramObject),
                    log);
            }
            if (vertexShader.GetCompileStatus() == false)
            {
                string log = vertexShader.GetInfoLog();
                throw new Exception(log);
            }
            if (geometryShader != null && geometryShader.GetCompileStatus() == false)
            {
                string log = geometryShader.GetInfoLog();
                throw new Exception(log);
            }
            if (fragmentShader.GetCompileStatus() == false)
            {
                string log = fragmentShader.GetInfoLog();
                throw new Exception(log);
            }

            GL.DetachShader(ShaderProgramObject, vertexShader.ShaderObject);
            if (geometryShader != null)
            { GL.DetachShader(ShaderProgramObject, geometryShader.ShaderObject); }
            GL.DetachShader(ShaderProgramObject, fragmentShader.ShaderObject);
            vertexShader.Delete();
            fragmentShader.Delete();
        }

        public void Delete()
        {
            //GL.DetachShader(ShaderProgramObject, vertexShader.ShaderObject);
            //GL.DetachShader(ShaderProgramObject, fragmentShader.ShaderObject);
            //vertexShader.Delete();
            //fragmentShader.Delete();
            GL.DeleteProgram(ShaderProgramObject);
            ShaderProgramObject = 0;
        }

        public uint GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            if (attributeNamesToLocations.ContainsKey(attributeName) == false)
            {
                int location = GL.GetAttribLocation(ShaderProgramObject, attributeName);
                if (location < 0) { throw new Exception(); }

                attributeNamesToLocations[attributeName] = (uint)location;
            }

            //  Return the attribute location.
            return attributeNamesToLocations[attributeName];
        }

        public void BindAttributeLocation(uint location, string attribute)
        {
            GL.BindAttribLocation(ShaderProgramObject, location, attribute);
        }

        public void Bind()
        {
            GL.UseProgram(ShaderProgramObject);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public bool GetLinkStatus()
        {
            int[] parameters = new int[] { 0 };
            GL.GetProgram(ShaderProgramObject, GL.GL_LINK_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            GL.GetProgram(ShaderProgramObject, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            GL.GetProgramInfoLog(ShaderProgramObject, bufSize, IntPtr.Zero, il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, int v1)
        {
            GL.Uniform1(GetUniformLocation(uniformName), v1);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetUniform(string uniformName, int v1, int v2)
        {
            GL.Uniform2(GetUniformLocation(uniformName), v1, v2);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void SetUniform(string uniformName, int v1, int v2, int v3)
        {
            GL.Uniform3(GetUniformLocation(uniformName), v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        public void SetUniform(string uniformName, int v1, int v2, int v3, int v4)
        {
            GL.Uniform4(GetUniformLocation(uniformName), v1, v2, v3, v4);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        public void SetUniform(string uniformName, float v1)
        {
            GL.Uniform1(GetUniformLocation(uniformName), v1);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetUniform(string uniformName, float v1, float v2)
        {
            GL.Uniform2(GetUniformLocation(uniformName), v1, v2);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void SetUniform(string uniformName, float v1, float v2, float v3)
        {
            GL.Uniform3(GetUniformLocation(uniformName), v1, v2, v3);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        public void SetUniform(string uniformName, float v1, float v2, float v3, float v4)
        {
            GL.Uniform4(GetUniformLocation(uniformName), v1, v2, v3, v4);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix2(string uniformName, float[] m)
        {
            GL.UniformMatrix2(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            GL.UniformMatrix3(GetUniformLocation(uniformName), 1, false, m);
        }

        /// <summary>
        /// 请注意你的数据类型最终将转换为int还是float
        /// </summary>
        /// <param name="uniformName"></param>
        /// <param name="m"></param>
        public void SetUniformMatrix4(string uniformName, float[] m)
        {
            GL.UniformMatrix4(GetUniformLocation(uniformName), 1, false, m);
        }

        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            if (uniformNamesToLocations.ContainsKey(uniformName) == false)
            {
                uniformNamesToLocations[uniformName] = GL.GetUniformLocation(ShaderProgramObject, uniformName);
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
