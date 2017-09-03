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
    public abstract partial class Shader : IDisposable
    {
        internal static readonly GLDelegates.uint_uint glCreateShader;
        internal static readonly GLDelegates.void_uint_int_stringN_intN glShaderSource;
        internal static readonly GLDelegates.void_uint glCompileShader;
        internal static readonly GLDelegates.void_uint glDeleteShader;
        internal static readonly GLDelegates.void_uint_uint_intN glGetShaderiv;
        internal static readonly GLDelegates.void_uint_int_IntPtr_StringBuilder glGetShaderInfoLog;
        static Shader()
        {
            glCreateShader = GL.Instance.GetDelegateFor("glCreateShader", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
            glShaderSource = GL.Instance.GetDelegateFor("glShaderSource", GLDelegates.typeof_void_uint_int_stringN_intN) as GLDelegates.void_uint_int_stringN_intN; ;
            glCompileShader = GL.Instance.GetDelegateFor("glCompileShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
            glDeleteShader = GL.Instance.GetDelegateFor("glDeleteShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
            glGetShaderiv = GL.Instance.GetDelegateFor("glGetShaderiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN; ;
            glGetShaderInfoLog = GL.Instance.GetDelegateFor("glGetShaderInfoLog", GLDelegates.typeof_void_uint_int_IntPtr_StringBuilder) as GLDelegates.void_uint_int_IntPtr_StringBuilder; ;

        }

        private bool isInitialized = false;
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            if (!this.isInitialized)
            {
                this.DoInitialize();
                this.isInitialized = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// Create and compile this shader.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <param name="source"></param>
        protected void Create(uint shaderType, string source)
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
            glGetShaderiv(shaderId, GL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private string GetInfoLog(uint shaderId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetShaderiv(shaderId, GL.GL_INFO_LOG_LENGTH, infoLength);
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
    }
}