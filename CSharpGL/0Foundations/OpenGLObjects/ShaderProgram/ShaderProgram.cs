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
        private static OpenGL.glCreateProgram glCreateProgram;
        private static OpenGL.glAttachShader glAttachShader;
        private static OpenGL.glLinkProgram glLinkProgram;
        private static OpenGL.glDetachShader glDetachShader;
        private static OpenGL.glDeleteProgram glDeleteProgram;
        private static OpenGL.glGetAttribLocation glGetAttribLocation;
        private static OpenGL.glUseProgram glUseProgram;
        private static OpenGL.glGetProgramiv glGetProgramiv;
        private static OpenGL.glUniform1ui glUniform1ui;
        private static OpenGL.glUniform2ui glUniform2ui;
        private static OpenGL.glUniform3ui glUniform3ui;
        private static OpenGL.glUniform4ui glUniform4ui;
        private static OpenGL.glUniform1uiv glUniform1uiv;
        private static OpenGL.glUniform2uiv glUniform2uiv;
        private static OpenGL.glUniform3uiv glUniform3uiv;
        private static OpenGL.glUniform4uiv glUniform4uiv;
        private static OpenGL.glUniform1i glUniform1i;
        private static OpenGL.glUniform2i glUniform2i;
        private static OpenGL.glUniform3i glUniform3i;
        private static OpenGL.glUniform4i glUniform4i;
        private static OpenGL.glUniform1iv glUniform1iv;
        private static OpenGL.glUniform2iv glUniform2iv;
        private static OpenGL.glUniform3iv glUniform3iv;
        private static OpenGL.glUniform4iv glUniform4iv;
        private static OpenGL.glUniform1f glUniform1f;
        private static OpenGL.glUniform2f glUniform2f;
        private static OpenGL.glUniform3f glUniform3f;
        private static OpenGL.glUniform4f glUniform4f;
        private static OpenGL.glUniform1fv glUniform1fv;
        private static OpenGL.glUniform2fv glUniform2fv;
        private static OpenGL.glUniform3fv glUniform3fv;
        private static OpenGL.glUniform4fv glUniform4fv;
        private static OpenGL.glUniformMatrix2fv glUniformMatrix2fv;
        private static OpenGL.glUniformMatrix3fv glUniformMatrix3fv;
        private static OpenGL.glUniformMatrix4fv glUniformMatrix4fv;
        private static OpenGL.glGetUniformLocation glGetUniformLocation;
        //    void glGetActiveUniform(GLuint program,
        //GLuint index,
        //GLsizei bufSize,
        //GLsizei* length,
        //GLint* size,
        //GLenum* type,
        //GLchar* name);
        delegate void glGetActiveUniform(uint program, uint index, int bufSize, int[] length, int[] size, int[] type, StringBuilder name);
        private static glGetActiveUniform getActiveUniform;

        delegate void glGetActiveUniformsiv(uint program, int uniformCount, uint[] uniformIndices, uint pname, int[] parameters);
        private static glGetActiveUniformsiv getActiveUniformsiv;

        delegate void glGetActiveUniformName(uint program, uint uniformIndex, int bufSize, int[] length, StringBuilder uniformName);
        private static glGetActiveUniformName getActiveUniformName;

        static ShaderProgram()
        {
            glCreateProgram = OpenGL.GetDelegateFor<OpenGL.glCreateProgram>();
            glAttachShader = OpenGL.GetDelegateFor<OpenGL.glAttachShader>();
            glLinkProgram = OpenGL.GetDelegateFor<OpenGL.glLinkProgram>();
            glDetachShader = OpenGL.GetDelegateFor<OpenGL.glDetachShader>();
            glDeleteProgram = OpenGL.GetDelegateFor<OpenGL.glDeleteProgram>();
            glGetAttribLocation = OpenGL.GetDelegateFor<OpenGL.glGetAttribLocation>();
            glUseProgram = OpenGL.GetDelegateFor<OpenGL.glUseProgram>();
            glGetProgramiv = OpenGL.GetDelegateFor<OpenGL.glGetProgramiv>();
            glGetUniformLocation = OpenGL.GetDelegateFor<OpenGL.glGetUniformLocation>();
            getActiveUniform = OpenGL.GetDelegateFor<glGetActiveUniform>();
            getActiveUniformsiv = OpenGL.GetDelegateFor<glGetActiveUniformsiv>();
            getActiveUniformName = OpenGL.GetDelegateFor<glGetActiveUniformName>();
        }

        /// <summary>
        /// Initialize this shader program object.
        /// </summary>
        /// <param name="shaders"></param>
        public void Initialize(params Shader[] shaders)
        {
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

            // TODO; remove this. This is a test.
            int count = this.GetActivetUniformCount(programId);
            uint[] indexes = new uint[count];
            uint pname = OpenGL.GL_UNIFORM_NAME_LENGTH;
            int[] parameters = new int[count];
            getActiveUniformsiv(programId, count, indexes, pname, parameters);

            //getActiveUniformName(program, 0, 
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
            glGetProgramiv(programId, OpenGL.GL_ACTIVE_UNIFORMS, infoLength);
            return infoLength[0];
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
            glGetProgramiv(programId, OpenGL.GL_LINK_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }

        private string GetInfoLog(uint programId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(programId, OpenGL.GL_INFO_LOG_LENGTH, infoLength);
            int bufSize = infoLength[0];

            //  Get the compile info.
            StringBuilder il = new StringBuilder(bufSize);
            OpenGL.GetDelegateFor<OpenGL.glGetProgramInfoLog>()(programId, bufSize, 0, il);

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