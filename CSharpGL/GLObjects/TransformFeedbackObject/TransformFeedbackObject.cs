using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// manages transform feedback states.
    /// </summary>
    public unsafe partial class TransformFeedbackObject : IDisposable {

        public readonly GLuint id;

        /// <summary>
        /// manages transform feedback states.
        /// </summary>
        public TransformFeedbackObject() {
            var gl = GL.current; if (gl != null) {
                var ids = stackalloc GLuint[1];
                gl.glGenTransformFeedbacks(1, ids);
                this.id = ids[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, this.id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);
        }

        /// <summary>
        /// Bind specified buffer to specified binding point of this transform feedback object.
        /// Then data will be dumped to the specified buffer when this transform feedback object works.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="buffer"></param>
        public void BindBuffer(uint index, GLBuffer buffer) {
            var gl = GL.current; if (gl == null) { return; }
            this.Bind();
            gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, buffer.bufferId);
            this.Unbind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        internal void Begin(DrawMode mode) {
            GL.StopAtError();
            var gl = GL.current; if (gl == null) { return; }
            bool sucessful = false;
            switch (mode) {
            case DrawMode.Points:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Points);
            sucessful = true;
            break;
            case DrawMode.Lines:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Lines);
            sucessful = true;
            break;
            case DrawMode.LineLoop:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Lines);
            sucessful = true;
            break;
            case DrawMode.LineStrip:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Lines);
            sucessful = true;
            break;
            case DrawMode.Triangles:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Triangles);
            sucessful = true;
            break;
            case DrawMode.TriangleStrip:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Triangles);
            sucessful = true;
            break;
            case DrawMode.TriangleFan:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Triangles);
            sucessful = true;
            break;
            case DrawMode.Quads:
            break;
            case DrawMode.QuadStrip:
            break;
            case DrawMode.Polygon:
            break;
            case DrawMode.LinesAdjacency:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Lines);
            sucessful = true;
            break;
            case DrawMode.LineStripAdjacency:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Lines);
            sucessful = true;
            break;
            case DrawMode.TrianglesAdjacency:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Triangles);
            sucessful = true;
            break;
            case DrawMode.TriangleStripAdjacency:
            gl.glBeginTransformFeedback((GLenum)DrawMode.Triangles);
            sucessful = true;
            break;
            case DrawMode.Patches:
            break;
            default:
            throw new NotSupportedException(mode.ToString());
            }

            GL.StopAtError();

            if (!sucessful) {
                throw new Exception(string.Format("{0} not acceptable as input parameter for glBeginTransformFeedback(uint primitiveMode);", mode));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        internal void Draw(DrawMode mode) {
            var gl = GL.current; if (gl == null) { return; }
            bool sucessful = false;
            switch (mode) {
            case DrawMode.Points:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Points, this.id);
            sucessful = true;
            break;
            case DrawMode.Lines:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Lines, this.id);
            sucessful = true;
            break;
            case DrawMode.LineLoop:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Lines, this.id);
            sucessful = true;
            break;
            case DrawMode.LineStrip:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Lines, this.id);
            sucessful = true;
            break;
            case DrawMode.Triangles:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Triangles, this.id);
            sucessful = true;
            break;
            case DrawMode.TriangleStrip:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Triangles, this.id);
            sucessful = true;
            break;
            case DrawMode.TriangleFan:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Triangles, this.id);
            sucessful = true;
            break;
            case DrawMode.Quads:
            break;
            case DrawMode.QuadStrip:
            break;
            case DrawMode.Polygon:
            break;
            case DrawMode.LinesAdjacency:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Lines, this.id);
            sucessful = true;
            break;
            case DrawMode.LineStripAdjacency:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Lines, this.id);
            sucessful = true;
            break;
            case DrawMode.TrianglesAdjacency:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Triangles, this.id);
            sucessful = true;
            break;
            case DrawMode.TriangleStripAdjacency:
            gl.glDrawTransformFeedback((GLenum)DrawMode.Triangles, this.id);
            sucessful = true;
            break;
            case DrawMode.Patches:
            break;
            default:
            throw new NotSupportedException(mode.ToString());
            }

            if (!sucessful) {
                throw new Exception(string.Format("{0} not acceptable as input parameter for glDrawTransformFeedback(id, (uint)primitiveMode);", mode));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void Begin(Mode mode) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBeginTransformFeedback((GLenum)mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void Draw(Mode mode) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glDrawTransformFeedback((GLenum)mode, this.id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void End() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glEndTransformFeedback();
        }

        /// <summary>
        ///
        /// </summary>
        public enum Mode : GLuint {
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
        public void Draw(GLProgram program, VertexArrayObject[] vaos, GLSwitchList? switchList = null) {
            // 绑定shader
            GL.StopAtError();
            program.Bind();
            GL.StopAtError();
            program.PushUniforms(); // push new uniform values to GPU side.
            GL.StopAtError();

            if (switchList != null) { switchList.On(); }
            GL.StopAtError();

            GL.StopAtError();
            this.Bind();
            GL.StopAtError();
            foreach (var vao in vaos) {
                DrawMode mode = vao.DrawCommand.Mode;
                GL.StopAtError();
                this.Begin(mode);
                GL.StopAtError();
                vao.Bind();
                GL.StopAtError();
                this.Draw(mode);
                GL.StopAtError();
                vao.Unbind();
                GL.StopAtError();
                this.End();
                GL.StopAtError();
            }
            GL.StopAtError();
            this.Unbind();
            GL.StopAtError();

            GL.StopAtError();
            if (switchList != null) { switchList.Off(); }
            GL.StopAtError();

            // 解绑shader
            program.Unbind();
            GL.StopAtError();
        }
    }
}
