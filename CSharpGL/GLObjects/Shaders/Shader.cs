using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// A GLSL shader(supported extensions: vs, fs, gs, vsh, fsh, gsh, vshader, fshader, gshader, vert, frag, geom, tesc, tese, comp, glsl).
    /// </summary>

    public unsafe partial class Shader : IDisposable {
        //internal static readonly GLDelegates.uint_uint glCreateShader;
        //internal static readonly GLDelegates.void_uint_int_stringN_intN glShaderSource;
        //internal static readonly GLDelegates.void_uint glCompileShader;
        //internal static readonly GLDelegates.void_uint glDeleteShader;
        //internal static readonly GLDelegates.void_uint_uint_intN glGetShaderiv;
        //internal static readonly GLDelegates.void_uint_int_IntPtr_StringBuilder glGetShaderInfoLog;
        //static Shader() {
        //    glCreateShader = gl.glGetDelegateFor("glCreateShader", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
        //    glShaderSource = gl.glGetDelegateFor("glShaderSource", GLDelegates.typeof_void_uint_int_stringN_intN) as GLDelegates.void_uint_int_stringN_intN; ;
        //    glCompileShader = gl.glGetDelegateFor("glCompileShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
        //    glDeleteShader = gl.glGetDelegateFor("glDeleteShader", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; ;
        //    glGetShaderiv = gl.glGetDelegateFor("glGetShaderiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN; ;
        //    glGetShaderInfoLog = gl.glGetDelegateFor("glGetShaderInfoLog", GLDelegates.typeof_void_uint_int_IntPtr_StringBuilder) as GLDelegates.void_uint_int_IntPtr_StringBuilder; ;

        //}

        /// <summary>
        /// Gets the shader object.
        /// </summary>
        public readonly uint shaderId;
        public readonly Kind kind;
        public readonly string source;

        private Shader(GLuint id, Shader.Kind kind, string source) {
            this.shaderId = id;
            this.kind = kind;
            this.source = source;
        }

        public static unsafe Shader? Create(Shader.Kind kind, string[] sources, out string log) {
            var gl = GL.current; if (gl == null) { log = "openGL not ready"; return null; }

            GLuint shaderId = gl.glCreateShader((GLenum)kind);
            //var sources = stackalloc String[1]; sources[0] = source;
            //var sources = new IntPtr[sourceSegments.Length]; var handles = new GCHandle[sourceSegments.Length];
            //for (int i = 0; i < sourceSegments.Length; i++) {
            //    var handle = GCHandle.Alloc(sourceSegments[i], GCHandleType.Pinned);
            //    sources[i] = handle.AddrOfPinnedObject();
            //    sources[i] = Marshal.StringToHGlobalAnsi(sourceSegments[i]);
            //    handles[i] = handle;
            //}
            //var codes = (from item in sources select Marshal.StringToHGlobalAnsi(item)).ToArray();
            var lengths = (from item in sources select item.Length).ToArray();
            //fixed (IntPtr* pSources = codes) fixed (GLint* pLengths = lengths) {
            //    gl.glShaderSource(shaderId, sources.Length, pSources, pLengths);
            //}
            //for (int i = 0; i < handles.Length; i++) { handles[i].Free(); }
            //for (int i = 0; i < sources.Length; i++) { Marshal.FreeHGlobal(codes[i]); }
            fixed (GLint* pLengths = lengths) {
                gl.glShaderSource(shaderId, sources.Length, sources, pLengths);
            }

            //  Compile the shader object.
            gl.glCompileShader(shaderId);

            //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
            //  going to throw an exception.
            if (GetCompileStatus(shaderId) == false) {
                log = GetInfoLog(shaderId);
                return null;
            }
            else {
                log = "";
                return new Shader(shaderId, kind, string.Concat(sources));
            }

        }

        public static Shader? Create(Shader.Kind kind, string code, out string log) {
            var gl = GL.current; if (gl == null) { log = "openGL not ready"; return null; }

            GLuint shaderId = gl.glCreateShader((GLenum)kind);

            //var handle = GCHandle.Alloc(source, GCHandleType.Pinned);
            //var codes = stackalloc IntPtr[1]; codes[0] = Marshal.StringToHGlobalUni(code);//handle.AddrOfPinnedObject();
            //var arr = new string[] { source };
            //var codes = stackalloc IntPtr[1]; codes[0] = Marshal.StringToHGlobalAnsi(code);
            var lengths = code.Length;
            gl.glShaderSource(shaderId, 1, new string[] { code }, &lengths);
            //gl.glShaderSource(shaderId, 1, codes, &lengths);
            //Marshal.FreeHGlobal(codes[0]);
            //handle.Free();

            //  Compile the shader object.
            gl.glCompileShader(shaderId);

            //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
            //  going to throw an exception.
            if (GetCompileStatus(shaderId) == false) {
                log = GetInfoLog(shaderId);
                return null;
            }
            else {
                log = "";
                return new Shader(shaderId, kind, code);
            }

        }
        //private bool isInitialized = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //public void Initialize() {
        //    if (!this.isInitialized) {
        //        this.DoInitialize();
        //        this.isInitialized = true;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //protected abstract void DoInitialize();

        ///// <summary>
        ///// Create and compile this shader.
        ///// </summary>
        ///// <param name="shaderType"></param>
        ///// <param name="source"></param>
        //protected void Create(uint shaderType, string source) {
        //}

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private static bool GetCompileStatus(GLuint shaderId) {
            var gl = GL.current; if (gl == null) { return false; }
            var parameters = stackalloc int[1];
            gl.glGetShaderiv(shaderId, GL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private static string GetInfoLog(GLuint shaderId) {
            var gl = GL.current; if (gl == null) { return ""; }
            //  Get the info log length.
            var infoLength = stackalloc int[1];
            gl.glGetShaderiv(shaderId, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            gl.glGetShaderInfoLog(shaderId, bufSize, Array.Empty<int>(), il);
            string log = il.ToString();
            return log;
        }

        /// <summary>
        ///
        /// </summary>
        public enum Kind : uint {
            /// <summary>
            ///
            /// </summary>
            vert = GL.GL_VERTEX_SHADER,

            /// <summary>
            ///
            /// </summary>
            geom = GL.GL_GEOMETRY_SHADER,

            /// <summary>
            /// 
            /// </summary>
            tesc = GL.GL_TESS_CONTROL_SHADER,

            /// <summary>
            /// 
            /// </summary>
            tese = GL.GL_TESS_EVALUATION_SHADER,

            /// <summary>
            ///
            /// </summary>
            frag = GL.GL_FRAGMENT_SHADER,

            /// <summary>
            ///
            /// </summary>
            comp = GL.GL_COMPUTE_SHADER,
        }

        public override string ToString() {
            return $"{this.kind}, {this.shaderId}";
        }
    }
}