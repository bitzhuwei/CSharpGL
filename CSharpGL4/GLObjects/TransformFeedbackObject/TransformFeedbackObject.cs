using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// manages <see cref="TransformFeedbackBuffer"/>s.
    /// </summary>
    public partial class TransformFeedbackObject
    {
        private readonly uint[] ids = new uint[1];

        /// <summary>
        /// 
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// manages <see cref="TransformFeedbackBuffer"/>s.
        /// </summary>
        public TransformFeedbackObject()
        {
            glGenTransformFeedbacks(ids.Length, ids);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeNames"></param>
        /// <param name="program"></param>
        /// <param name="bufferMode"></param>
        public void Capture(string[] attributeNames, ShaderProgram program, BufferMode bufferMode)
        {
            glTransformFeedbackVaryings(program.ProgramId, attributeNames.Length, attributeNames, (uint)bufferMode);
            ShaderProgram.glLinkProgram(program.ProgramId);
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

    }
}