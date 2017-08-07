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
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class ShaderProgram
    {
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
        public ShaderProgram()
        {
            uint programId = glCreateProgram();
            this.ProgramId = programId;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum BufferMode : uint
        {
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
        /// <param name="shaders"></param>
        public void Initialize(string[] feedbackVaryings, BufferMode mode, params Shader[] shaders)
        {
            if (glTransformFeedbackVaryings == null)
            {
                glTransformFeedbackVaryings = GL.Instance.GetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
            }
            glTransformFeedbackVaryings(this.ProgramId, 1, feedbackVaryings, (uint)mode);

            this.Initialize(shaders);
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
            uint programId = this.ProgramId;

            foreach (Shader item in shaders)
            {
                glAttachShader(programId, item.ShaderId);
            }

            glLinkProgram(programId);

            this.CheckLinkStatus(programId);

            UniformVarInShader[] variables = LoadAllUniformsInShader();
            foreach (var item in variables)
            {
                UniformVariable var = item.GetUniformVariable(programId);
                if (var != null)
                {
                    this.uniformVariables.Add(var.VarName, var);
                }
            }
        }

        private void CheckLinkStatus(uint id)
        {
            if (this.GetLinkStatus(id) == false)
            {
                string log = this.GetInfoLog(id);
                throw new Exception(
                    string.Format("Failed to compile shader with ID {0}: {1}",
                        id.ToString(), log));
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void CheckLinkStatus()
        {
            this.CheckLinkStatus(this.ProgramId);
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