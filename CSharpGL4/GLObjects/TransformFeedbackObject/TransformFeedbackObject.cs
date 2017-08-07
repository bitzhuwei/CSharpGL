using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// manages transform feedback states.
    /// </summary>
    public partial class TransformFeedbackObject : IDisposable
    {
        private readonly uint[] ids = new uint[1];

        /// <summary>
        /// 
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// manages transform feedback states.
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
            this.Bind();
            glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, bufferId);
            this.Unbind();
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
    }
}
