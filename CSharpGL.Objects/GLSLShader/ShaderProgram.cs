using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.GLSLShader
{
    public class ShaderProgram
    {
        private readonly Shader vertexShader = new Shader();
        private readonly Shader fragmentShader = new Shader();

        /// <summary>
        /// Creates the shader program.
        /// </summary>
        /// <param name="vertexShaderSource">The vertex shader source.</param>
        /// <param name="fragmentShaderSource">The fragment shader source.</param>
        /// <param name="attributeLocations">The attribute locations. This is an optional array of
        /// uint attribute locations to their names.</param>
        /// <exception cref="ShaderCompilationException"></exception>
        public void Create(string vertexShaderSource, string fragmentShaderSource,
            Dictionary<uint, string> attributeLocations)
        {
            //  Create the shaders.
            vertexShader.Create(GL.GL_VERTEX_SHADER, vertexShaderSource);
            fragmentShader.Create(GL.GL_FRAGMENT_SHADER, fragmentShaderSource);

            //  Create the program, attach the shaders.
            shaderProgramObject = GL.CreateProgram();
            GL.AttachShader(shaderProgramObject, vertexShader.ShaderObject);
            GL.AttachShader(shaderProgramObject, fragmentShader.ShaderObject);

            //  Before we link, bind any vertex attribute locations.
            if (attributeLocations != null)
            {
                foreach (var vertexAttributeLocation in attributeLocations)
                    GL.BindAttribLocation(shaderProgramObject, vertexAttributeLocation.Key, vertexAttributeLocation.Value);
            }

            //  Now we can link the program.
            GL.LinkProgram(shaderProgramObject);

            //  Now that we've compiled and linked the shader, check it's link status. If it's not linked properly, we're
            //  going to throw an exception.
            if (GetLinkStatus() == false)
            {
                throw new ShaderCompilationException(string.Format("Failed to link shader program with ID {0}.", shaderProgramObject), GetInfoLog());
            }
        }

        public void Delete()
        {
            GL.DetachShader(shaderProgramObject, vertexShader.ShaderObject);
            GL.DetachShader(shaderProgramObject, fragmentShader.ShaderObject);
            vertexShader.Delete();
            fragmentShader.Delete();
            GL.DeleteProgram(shaderProgramObject);
            shaderProgramObject = 0;
        }

        public int GetAttributeLocation(string attributeName)
        {
            return GL.GetAttribLocation(shaderProgramObject, attributeName);
        }

        public void BindAttributeLocation(uint location, string attribute)
        {
            GL.BindAttribLocation(shaderProgramObject, location, attribute);
        }

        public void Bind()
        {
            GL.UseProgram(shaderProgramObject);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public bool GetLinkStatus()
        {
            int[] parameters = new int[] { 0 };
            GL.GetProgram(shaderProgramObject, GL.GL_LINK_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            GL.GetProgram(shaderProgramObject, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            GL.GetProgramInfoLog(shaderProgramObject, bufSize, IntPtr.Zero, il);

            return il.ToString();
        }

        public void AssertValid()
        {
            if (vertexShader.GetCompileStatus() == false)
                throw new Exception(vertexShader.GetInfoLog());
            if (fragmentShader.GetCompileStatus() == false)
                throw new Exception(fragmentShader.GetInfoLog());
            if (GetLinkStatus() == false)
                throw new Exception(GetInfoLog());
        }

        public void SetUniform1(string uniformName, int v1)
        {
            GL.Uniform1(GetUniformLocation(uniformName), v1);
        }

        public void SetUniform3(string uniformName, int v1, int v2)
        {
            GL.Uniform2(GetUniformLocation(uniformName), v1, v2);
        }

        public void SetUniform3(string uniformName, int v1, int v2, int v3)
        {
            GL.Uniform3(GetUniformLocation(uniformName), v1, v2, v3);
        }

        public void SetUniform3(string uniformName, int v1, int v2, int v3, int v4)
        {
            GL.Uniform4(GetUniformLocation(uniformName), v1, v2, v3, v4);
        }

        public void SetUniform1(string uniformName, float v1)
        {
            GL.Uniform1(GetUniformLocation(uniformName), v1);
        }

        public void SetUniform3(string uniformName, float v1, float v2)
        {
            GL.Uniform2(GetUniformLocation(uniformName), v1, v2);
        }

        public void SetUniform3(string uniformName, float v1, float v2, float v3)
        {
            GL.Uniform3(GetUniformLocation(uniformName), v1, v2, v3);
        }

        public void SetUniform3(string uniformName, float v1, float v2, float v3, float v4)
        {
            GL.Uniform4(GetUniformLocation(uniformName), v1, v2, v3, v4);
        }

        public void SetUniformMatrix3(string uniformName, float[] m)
        {
            GL.UniformMatrix3(GetUniformLocation(uniformName), 1, false, m);
        }

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
                uniformNamesToLocations[uniformName] = GL.GetUniformLocation(shaderProgramObject, uniformName);
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
        public uint ShaderProgramObject
        {
            get { return shaderProgramObject; }
        }

        private uint shaderProgramObject;

        /// <summary>
        /// A mapping of uniform names to locations. This allows us to very easily specify 
        /// uniform data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> uniformNamesToLocations = new Dictionary<string, int>();
    }
}
