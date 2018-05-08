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
        /// <param name="buffer"></param>
        public void BindBuffer(uint index, GLBuffer buffer)
        {
            this.Bind();
            glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, buffer.BufferId);
            this.Unbind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        internal void Begin(DrawMode mode)
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
                    glBeginTransformFeedback((uint)DrawMode.Triangles);
                    sucessful = true;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    glBeginTransformFeedback((uint)DrawMode.Triangles);
                    sucessful = true;
                    break;
                case DrawMode.Patches:
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            if (!sucessful)
            {
                throw new Exception(string.Format("{0} not acceptable as input parameter for glBeginTransformFeedback(uint primitiveMode);", mode));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        internal void Draw(DrawMode mode)
        {
            bool sucessful = false;
            switch (mode)
            {
                case DrawMode.Points:
                    glDrawTransformFeedback((uint)DrawMode.Points, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.Lines:
                    glDrawTransformFeedback((uint)DrawMode.Lines, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.LineLoop:
                    glDrawTransformFeedback((uint)DrawMode.Lines, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.LineStrip:
                    glDrawTransformFeedback((uint)DrawMode.Lines, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.Triangles:
                    glDrawTransformFeedback((uint)DrawMode.Triangles, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.TriangleStrip:
                    glDrawTransformFeedback((uint)DrawMode.Triangles, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.TriangleFan:
                    glDrawTransformFeedback((uint)DrawMode.Triangles, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.Quads:
                    break;
                case DrawMode.QuadStrip:
                    break;
                case DrawMode.Polygon:
                    break;
                case DrawMode.LinesAdjacency:
                    glDrawTransformFeedback((uint)DrawMode.Lines, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.LineStripAdjacency:
                    glDrawTransformFeedback((uint)DrawMode.Lines, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.TrianglesAdjacency:
                    glDrawTransformFeedback((uint)DrawMode.Triangles, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    glDrawTransformFeedback((uint)DrawMode.Triangles, this.Id);
                    sucessful = true;
                    break;
                case DrawMode.Patches:
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            if (!sucessful)
            {
                throw new Exception(string.Format("{0} not acceptable as input parameter for glDrawTransformFeedback(id, (uint)primitiveMode);", mode));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void Begin(Mode mode)
        {
            glBeginTransformFeedback((uint)mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void Draw(Mode mode)
        {
            glDrawTransformFeedback((uint)mode, this.Id);
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
        public enum Mode : uint
        {
            /// <summary>
            /// GL_POINTS = 0x0000;
            /// </summary>
            Points = GL.GL_POINTS,

            /// <summary>
            /// GL_LINES = 0x0001;
            /// </summary>
            Lines = GL.GL_LINES,

            /// <summary>
            /// GL_TRIANGLES = 0x0004;
            /// </summary>
            Triangles = GL.GL_TRIANGLES,

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vaos"></param>
        /// <param name="switchList"></param>
        public void Draw(ShaderProgram program, VertexArrayObject[] vaos, GLSwitchList switchList = null)
        {
            // 绑定shader
            program.Bind();
            program.PushUniforms(); // push new uniform values to GPU side.

            if (switchList != null) { switchList.On(); }

            this.Bind();
            foreach (var vao in vaos)
            {
                DrawMode mode = vao.DrawCommand.CurrentMode;
                this.Begin(mode);
                vao.Bind();
                this.Draw(mode);
                vao.Unbind();
                this.End();
            }
            this.Unbind();

            if (switchList != null) { switchList.Off(); }

            // 解绑shader
            program.Unbind();
        }
    }
}
