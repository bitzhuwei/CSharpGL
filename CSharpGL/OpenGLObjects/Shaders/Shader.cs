using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// This is the base class for all shaders (vertex and fragment). It offers functionality
    /// which is core to all shaders, such as file loading and binding.
    /// </summary>
    public class Shader
    {
        static OpenGL.glCreateShader glCreateShader;
        static OpenGL.glShaderSource glShaderSource;
        static OpenGL.glCompileShader glCompileShader;
        static OpenGL.glDeleteShader glDeleteShader;
        static OpenGL.glGetShaderiv glGetShaderiv;

        internal Shader()
        {
            if (glCreateShader == null)
            {
                glCreateShader = OpenGL.GetDelegateFor<OpenGL.glCreateShader>();
                glShaderSource = OpenGL.GetDelegateFor<OpenGL.glShaderSource>();
                glCompileShader = OpenGL.GetDelegateFor<OpenGL.glCompileShader>();
                glDeleteShader = OpenGL.GetDelegateFor<OpenGL.glDeleteShader>();
                glGetShaderiv = OpenGL.GetDelegateFor<OpenGL.glGetShaderiv>();
            }
        }
        public void Create(uint shaderType, string source)
        {
            //  Create the OpenGL shader object.
            ShaderObject = glCreateShader(shaderType);

            //  Set the shader source.
            glShaderSource(ShaderObject, 1, new[] { source }, new[] { source.Length });
            //  Compile the shader object.
            glCompileShader(ShaderObject);

            //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
            //  going to throw an exception.
            if (GetCompileStatus() == false)
            {
                string log = this.GetInfoLog();
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}", ShaderObject, log));
            }
        }

        public void Delete()
        {
            glDeleteShader(ShaderObject);
            ShaderObject = 0;
        }

        public bool GetCompileStatus()
        {
            int[] parameters = new int[] { 0 };
            glGetShaderiv(ShaderObject, OpenGL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        public string GetInfoLog()
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetShaderiv(ShaderObject, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            OpenGL.GetDelegateFor<OpenGL.glGetShaderInfoLog>()(ShaderObject, bufSize, IntPtr.Zero, il);
            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public uint ShaderObject { get; private set; }
    }
}
