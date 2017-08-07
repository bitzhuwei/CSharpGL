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
        /// <returns></returns>
        public bool Begin(DrawMode mode)
        {
            bool sucessful = false;
            switch (mode)
            {
                case DrawMode.Points:
                    glBeginTransformFeedback((uint)DrawMode.Points);
                    sucessful = true;
                    break;
                case DrawMode.Lines:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.LineLoop:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.LineStrip:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.Triangles:
                    glBeginTransformFeedback((uint)DrawMode.Triangles);
                    sucessful = true;
                    break;
                case DrawMode.TriangleStrip:
                    glBeginTransformFeedback((uint)DrawMode.Triangles);
                    sucessful = true;
                    break;
                case DrawMode.TriangleFan:
                    glBeginTransformFeedback((uint)DrawMode.Triangles);
                    sucessful = true;
                    break;
                case DrawMode.Quads:
                    break;
                case DrawMode.QuadStrip:
                    break;
                case DrawMode.Polygon:
                    break;
                case DrawMode.LinesAdjacency:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.LineStripAdjacency:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.TrianglesAdjacency:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    glBeginTransformFeedback((uint)DrawMode.Lines);
                    sucessful = true;
                    break;
                case DrawMode.Patches:
                    break;
                default:
                    break;
            }

            return sucessful;
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
