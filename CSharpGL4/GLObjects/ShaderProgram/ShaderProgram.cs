using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A shader program object.
    /// </summary>
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class ShaderProgram
    {
        private static GLDelegates.uint_void glCreateProgram;
        private static GLDelegates.void_uint_uint glAttachShader;
        private static GLDelegates.void_uint glLinkProgram;
        private static GLDelegates.void_uint_uint glDetachShader;
        private static GLDelegates.void_uint glDeleteProgram;
        private static GLDelegates.int_uint_string glGetAttribLocation;
        private static GLDelegates.void_uint glUseProgram;
        private static GLDelegates.void_uint_uint_intN glGetProgramiv;
        private static GLDelegates.void_int_uint glUniform1ui;
        private static GLDelegates.void_int_uint_uint glUniform2ui;
        private static GLDelegates.void_int_uint_uint_uint glUniform3ui;
        private static GLDelegates.void_int_uint_uint_uint_uint glUniform4ui;
        private static GLDelegates.void_int_int_uintN glUniform1uiv;
        private static GLDelegates.void_int_int_uintN glUniform2uiv;
        private static GLDelegates.void_int_int_uintN glUniform3uiv;
        private static GLDelegates.void_int_int_uintN glUniform4uiv;
        private static GLDelegates.void_int_int glUniform1i;
        private static GLDelegates.void_int_int_int glUniform2i;
        private static GLDelegates.void_int_int_int_int glUniform3i;
        private static GLDelegates.void_int_int_int_int_int glUniform4i;
        private static GLDelegates.void_int_int_intN glUniform1iv;
        private static GLDelegates.void_int_int_intN glUniform2iv;
        private static GLDelegates.void_int_int_intN glUniform3iv;
        private static GLDelegates.void_int_int_intN glUniform4iv;
        private static GLDelegates.void_int_float glUniform1f;
        private static GLDelegates.void_int_float_float glUniform2f;
        private static GLDelegates.void_int_float_float_float glUniform3f;
        private static GLDelegates.void_int_float_float_float_float glUniform4f;
        private static GLDelegates.void_int_int_floatN glUniform1fv;
        private static GLDelegates.void_int_int_floatN glUniform2fv;
        private static GLDelegates.void_int_int_floatN glUniform3fv;
        private static GLDelegates.void_int_int_floatN glUniform4fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix2fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix3fv;
        private static GLDelegates.void_int_int_bool_floatN glUniformMatrix4fv;
        private static GLDelegates.int_uint_string glGetUniformLocation;

        static ShaderProgram()
        {
            glCreateProgram = GL.Instance.GetDelegateFor("glCreateProgram", GLDelegates.typeof_uint_void) as GLDelegates.uint_void;
            glAttachShader = GL.Instance.GetDelegateFor("glAttachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glLinkProgram = GL.Instance.GetDelegateFor("glLinkProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDetachShader = GL.Instance.GetDelegateFor("glDetachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteProgram = GL.Instance.GetDelegateFor("glDeleteProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetAttribLocation = GL.Instance.GetDelegateFor("glGetAttribLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
            glUseProgram = GL.Instance.GetDelegateFor("glUseProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetProgramiv = GL.Instance.GetDelegateFor("glGetProgramiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
            glGetUniformLocation = GL.Instance.GetDelegateFor("glGetUniformLocation", GLDelegates.typeof_int_uint_string) as GLDelegates.int_uint_string;
        }

        /// <summary>
        /// Initialize this shader program object.
        /// </summary>
        /// <param name="shaders"></param>
        public void Initialize(params Shader[] shaders)
        {
            foreach (var item in shaders)
            {
                item.Initialize();
            }

            //if (shaders.Length < 1) { throw new ArgumentException(); }

            uint programId = glCreateProgram();

            foreach (Shader item in shaders)
            {
                glAttachShader(programId, item.ShaderId);
            }

            glLinkProgram(programId);

            if (this.GetLinkStatus(programId) == false)
            {
                string log = this.GetInfoLog(programId);
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}",
                        programId.ToString(), log));
            }

            foreach (Shader item in shaders)
            {
                glDetachShader(programId, item.ShaderId);
            }

            this.ProgramId = programId;

            int count = GetActivetUniformCount(programId);

        }

        /// <summary>
        /// Query location/index of specified <paramref name="attributeName"/>.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public int GetAttributeLocation(string attributeName)
        {
            //  If we don't have the attribute name in the dictionary, get it's
            //  location and add it.
            int location;
            if (!attributeNamesToLocations.TryGetValue(attributeName, out location))
            {
                location = glGetAttribLocation(this.ProgramId, attributeName);
                if (location < 0)
                {
                    Debug.WriteLine(string.Format("Failed to getAttribLocation for [{0}]", attributeName));
                }

                attributeNamesToLocations[attributeName] = location;
            }

            //  Return the attribute location.
            return location;
        }

        /// <summary>
        /// Use this program.
        /// </summary>
        public void Bind()
        {
            glUseProgram(this.ProgramId);
        }

        /// <summary>
        /// Stop using this program.
        /// </summary>
        public void Unbind()
        {
            glUseProgram(0);
        }

        private bool GetLinkStatus(uint programId)
        {
            int[] parameters = new int[] { 0 };
            glGetProgramiv(programId, GL.GL_LINK_STATUS, parameters);
            return parameters[0] == GL.GL_TRUE;
        }

        /// <summary>
        /// How many uniform variables are there?
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        private int GetActivetUniformCount(uint programId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(programId, GL.GL_ACTIVE_UNIFORMS, infoLength);
            return infoLength[0];
        }

        private string GetInfoLog(uint programId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(programId, GL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);

            var glGetProgramInfoLog = GL.Instance.GetDelegateFor("glGetProgramInfoLog", GLDelegates.typeof_void_uint_int_IntPtr_StringBuilder) as GLDelegates.void_uint_int_IntPtr_StringBuilder;
            glGetProgramInfoLog(programId, bufSize, IntPtr.Zero, il);

            string log = il.ToString();
            return log;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName"></param>
        /// <returns></returns>
        public int GetUniformLocation(string uniformName)
        {
            //  If we don't have the uniform name in the dictionary, get it's
            //  location and add it.
            int location;
            if (!uniformNamesToLocations.TryGetValue(uniformName, out location))
            {
                location = glGetUniformLocation(this.ProgramId, uniformName);
                if (location < 0)
                { Debug.WriteLine(string.Format("No uniform found for the name [{0}]", uniformName)); }

                uniformNamesToLocations[uniformName] = location;
            }

            //  Return the uniform location.
            return location;
        }

        /// <summary>
        /// Gets the shader program object.
        /// </summary>
        public uint ProgramId { get; protected set; }

        /// <summary>
        /// A mapping of uniform names to locations. This allows us to very easily specify
        /// uniform data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> uniformNamesToLocations = new Dictionary<string, int>();

        /// <summary>
        /// A mapping of attribute names to locations. This allows us to very easily specify
        /// attribute data by name, quickly looking up the location first if needed.
        /// </summary>
        private readonly Dictionary<string, int> attributeNamesToLocations = new Dictionary<string, int>();

        /// <summary>
        /// 
        /// </summary>
        public void PushUniforms()
        {
            foreach (UniformVariable item in this.uniformVariables.Values)
            {
                item.SetUniform(this);
            }
        }
    }
}