using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// manages <see cref="TransformFeedbackBuffer"/>s.
    /// </summary>
    public partial class TransformFeedbackObject : IDisposable
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
            glGenTransformFeedbacks(1, this.ids);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, this.ids[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind()
        {
            glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);
        }

        /// <summary>
        /// Bind specified buffer to specified binding point of this transform feedback object.
        /// Then data will be dumped to the specified buffer when this transform feedback object works.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bufferId"></param>
        public void BindBuffer(uint index, uint bufferId)
        {
            glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, bufferId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void Begin(DrawMode mode)
        {
            glBeginTransformFeedback((uint)mode);
        }

        /// <summary>
        /// 
        /// </summary>
        public void End()
        {
            glEndTransformFeedback();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeNames"></param>
        /// <param name="program"></param>
        /// <param name="bufferMode"></param>
        public void Capture(string[] attributeNames, ShaderProgram program, BufferMode bufferMode)
        {
            this.Bind();
            glTransformFeedbackVaryings(program.ProgramId, attributeNames.Length, attributeNames, (uint)bufferMode);
            ShaderProgram.glLinkProgram(program.ProgramId);
            this.Unbind();
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