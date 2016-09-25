using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A GLSL shader(supported extensions: vs, fs, gs, vsh, fsh, gsh, vshader, fshader, gshader, vert, frag, geom, tesc, tese, comp, glsl).
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Shader : IDisposable
    {
        private static OpenGL.glCreateShader glCreateShader;
        private static OpenGL.glShaderSource glShaderSource;
        private static OpenGL.glCompileShader glCompileShader;
        private static OpenGL.glDeleteShader glDeleteShader;
        private static OpenGL.glGetShaderiv glGetShaderiv;
        private static OpenGL.glGetShaderInfoLog glGetShaderInfoLog;

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <param name="source"></param>
        public void Create(uint shaderType, string source)
        {
            if (glCreateShader == null)
            {
                glCreateShader = OpenGL.GetDelegateFor<OpenGL.glCreateShader>();
                glShaderSource = OpenGL.GetDelegateFor<OpenGL.glShaderSource>();
                glCompileShader = OpenGL.GetDelegateFor<OpenGL.glCompileShader>();
                glDeleteShader = OpenGL.GetDelegateFor<OpenGL.glDeleteShader>();
                glGetShaderiv = OpenGL.GetDelegateFor<OpenGL.glGetShaderiv>();
                glGetShaderInfoLog = OpenGL.GetDelegateFor<OpenGL.glGetShaderInfoLog>();
            }

            //  Create the OpenGL shader object.
            uint shaderObject = glCreateShader(shaderType);

            //  Set the shader source.
            glShaderSource(shaderObject, 1, new[] { source }, new[] { source.Length });
            //  Compile the shader object.
            glCompileShader(shaderObject);

            //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
            //  going to throw an exception.
            if (GetCompileStatus(shaderObject) == false)
            {
                string log = this.GetInfoLog(shaderObject);
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}", shaderObject, log));
            }

            this.ShaderObject = shaderObject;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool GetCompileStatus(uint shaderObject)
        {
            int[] parameters = new int[] { 0 };
            glGetShaderiv(shaderObject, OpenGL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private string GetInfoLog(uint shaderObject)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetShaderiv(shaderObject, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            glGetShaderInfoLog(shaderObject, bufSize, IntPtr.Zero, il);
            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public uint ShaderObject { get; private set; }
    }
}