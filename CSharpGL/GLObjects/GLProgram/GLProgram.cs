using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// A shader program object.
    /// </summary>

    public unsafe partial class GLProgram {
        /// <summary>
        /// Gets the shader program object.
        /// </summary>
        public readonly uint programId;

        /// <summary>
        /// A mapping of uniform names to locations. This allows us to very easily specify
        /// uniform data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> uniformNamesToLocations = new Dictionary<string, int>();

        /// <summary>
        /// A mapping of attribute names to locations. This allows us to very easily specify
        /// attribute data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> attributeLocationDict = new Dictionary<string, int>();

        /// <summary>
        /// 
        /// </summary>
        private GLProgram(GLuint programId) {
            this.programId = programId;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum BufferMode : GLuint {
            /// <summary>
            /// 
            /// </summary>
            Separate = GL.GL_SEPARATE_ATTRIBS,

            /// <summary>
            /// 
            /// </summary>
            InterLeaved = GL.GL_INTERLEAVED_ATTRIBS,
        }

        /// <summary>
        /// Initialize this shader program object.
        /// </summary>
        /// <param name="feedbackVaryings"></param>
        /// <param name="mode"></param>
        /// <param name="shaderObjs"></param>
        public static (GLProgram?, string log) Create(string[] feedbackVaryings, BufferMode mode,
            params Shader[] shaderObjs) {
            //if (glTransformFeedbackVaryings == null) {
            //    glTransformFeedbackVaryings = gl.glGetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
            //}
            var gl = GL.current; if (gl == null) { return (null, "openGL not ready"); }
            GLuint programId = gl.glCreateProgram();
            gl.glTransformFeedbackVaryings(programId, feedbackVaryings.Length, feedbackVaryings, (uint)mode);

            var (program, log) = TryCompile(programId, shaderObjs);
            if (program == null) { gl.glDeleteProgram(programId); }
            return (program, log);
        }

        /// <summary>
        /// Initialize this shader program object.
        /// </summary>
        /// <param name="shaderObjs"></param>
        public static (GLProgram?, string log) Create(params Shader[] shaderObjs) {
            var gl = GL.current; if (gl == null) { return (null, "openGL not ready"); }
            GLuint programId = gl.glCreateProgram();

            var (program, log) = TryCompile(programId, shaderObjs);
            if (program == null) { gl.glDeleteProgram(programId); }
            return (program, log);
        }

        private static (GLProgram?, string log) TryCompile(GLuint programId, params Shader[] shaderObjs) {
            var gl = GL.current; if (gl == null) { return (null, "openGL not ready"); }
            //if (shaders.Length < 1) { throw new ArgumentException(); }

            foreach (Shader shaderObj in shaderObjs) {
                gl.glAttachShader(programId, shaderObj.shaderId);
            }

            gl.glLinkProgram(programId);

            var success = GetLinkStatus(programId);
            string log = ""; GLProgram? program = null;
            if (success == false) {
                log = GetInfoLog(programId);
                //throw new Exception(string.Format("Failed to compile shader with ID {0}: {1}", programId, log));
            }
            else { program = new GLProgram(programId); }

            foreach (Shader item in shaderObjs) {
                gl.glDetachShader(programId, item.shaderId);
            }

            // TODO: I'm not ready for this. Some uniform variable types are not supported.
            //UniformVarInShader[] variables = LoadAllUniformsInShader();
            //foreach (var item in variables)
            //{
            //    UniformVariable variable = item.GetUniformVariable(programId);
            //    if (variable != null)
            //    {
            //        this.uniformVariables.Add(variable.VarName, variable);
            //    }
            //}

            return (program, log);
        }
        //private static bool CheckLinkStatus(uint programId, out string log) {
        //	if (GetLinkStatus(programId) == false) {
        //		log = GetInfoLog(programId);
        //		//throw new Exception(string.Format("Failed to compile shader with ID {0}: {1}", programId, log));
        //	}

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public void CheckLinkStatus() {
        //	this.CheckLinkStatus(this.programId);
        //}

        /// <summary>
        /// Query location/index of specified <paramref name="attributeName"/>.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public int GetAttributeLocation(string attributeName) {
            int location;
            if (!attributeLocationDict.TryGetValue(attributeName, out location)) {
                var gl = GL.current; if (gl == null) { return -1; }
                //var ptr = Marshal.StringToHGlobalAnsi(attributeName);
                //location = gl.glGetAttribLocation(this.programId, (byte*)ptr);
                location = gl.glGetAttribLocation(this.programId, attributeName);
                //Marshal.FreeHGlobal(ptr);
                if (location < 0) {
                    Debug.WriteLine(string.Format("Failed to getAttribLocation for [{0}]", attributeName));
                }

                attributeLocationDict[attributeName] = location;
            }

            return location;
        }

        /// <summary>
        /// Use this program.
        /// </summary>
        public void Bind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glUseProgram(this.programId);
        }

        /// <summary>
        /// Stop using this program.
        /// </summary>
        public void Unbind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glUseProgram(0);
        }

        private static bool GetLinkStatus(uint programId) {
            var gl = GL.current; if (gl == null) { return false; }
            var parameters = stackalloc int[1];
            gl.glGetProgramiv(programId, GL.GL_LINK_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        private static string GetInfoLog(uint programId) {
            var gl = GL.current; if (gl == null) { return ""; }

            //  Get the info log length.
            var infoLength = stackalloc int[1];
            gl.glGetProgramiv(programId, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            var il = new StringBuilder(bufSize);
            gl.glGetProgramInfoLog(programId, bufSize, Array.Empty<int>(), il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <returns></returns>
        public int GetUniformLocation(string uniformName) {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            int location;
            if (!uniformNamesToLocations.TryGetValue(uniformName, out location)) {
                var gl = GL.current; if (gl == null) { return -1; }
                location = gl.glGetUniformLocation(this.programId, uniformName);
                if (location < 0) { Debug.WriteLine(string.Format("No uniform found for the name [{0}]", uniformName)); }

                uniformNamesToLocations[uniformName] = location;
            }

            //  Return the uniform location.
            return location;
        }

        /// <summary>
        /// 
        /// </summary>
        public void PushUniforms() {
            foreach (UniformVariable item in this.uniformVariables.Values) {
                if (item.updated) { item.SetUniform(this); }
            }
        }

        public override string ToString() {
            return $"program:{this.programId}";
        }
    }
}