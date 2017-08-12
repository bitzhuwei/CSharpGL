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
        private static readonly GLDelegates.uint_uint glCreateShader;
        private static readonly GLDelegates.void_uint_int_stringN_intN glShaderSource;
        private static readonly GLDelegates.void_uint glCompileShader;
        private static readonly GLDelegates.void_uint glDeleteShader;
        private static readonly GLDelegates.void_uint_uint_intN glGetShaderiv;
        private static readonly GLDelegates.void_uint_int_IntPtr_StringBuilder glGetShaderInfoLog;
        static Shader()
        {
            glCreateShader = OpenGL.GetDelegateFor("glCreateShader", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
            glShaderSource = OpenGL.GetDelegateFor("glShaderSource", GLDelegates.typeof_void_uint_int_stringN_intN) as GLDelegates.void_uint_int_stringN_intN; ;
            glCompileShader = OpenGL.GetDelegateFor("glCompileShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
            glDeleteShader = OpenGL.GetDelegateFor("glDeleteShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
            glGetShaderiv = OpenGL.GetDelegateFor("glGetShaderiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN; ;
            glGetShaderInfoLog = OpenGL.GetDelegateFor("glGetShaderInfoLog", GLDelegates.typeof_void_uint_int_IntPtr_StringBuilder) as GLDelegates.void_uint_int_IntPtr_StringBuilder; ;

        }

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <param name="source"></param>
        public void Create(uint shaderType, string source)
        {
            //  Create the OpenGL shader object.
            uint shaderId = glCreateShader(shaderType);

            //  Set the shader source.
            glShaderSource(shaderId, 1, new[] { source }, new[] { source.Length });
            //  Compile the shader object.
            glCompileShader(shaderId);

            //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
            //  going to throw an exception.
            if (GetCompileStatus(shaderId) == false)
            {
                string log = this.GetInfoLog(shaderId);
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}", shaderId.ToString(), log));
            }

            this.ShaderId = shaderId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool GetCompileStatus(uint shaderId)
        {
            int[] parameters = new int[] { 0 };
            glGetShaderiv(shaderId, OpenGL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private string GetInfoLog(uint shaderId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetShaderiv(shaderId, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            glGetShaderInfoLog(shaderId, bufSize, IntPtr.Zero, il);
            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public uint ShaderId { get; private set; }

        public string SourceCode { get; set; }
    }
}