using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class DrawArraysInstancedCmd : IDrawCommand
    {
        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="frameCount">How many frames are there?</param>
        public DrawArraysInstancedCmd(DrawMode mode, int firstVertex, int vertexCount, int instanceCount, int frameCount = 1)
        {
            this.Mode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.RenderingVertexCount = vertexCount;
            this.InstanceCount = instanceCount;
            this.FrameCount = frameCount;
        }

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        public int VertexCount { get; private set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int InstanceCount { get; private set; }

        /// <summary>
        /// How many frames are there?
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int FrameCount { get; set; }

        /// <summary>
        /// Gets or sets index of current frame.
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int CurrentFrame { get; set; }


        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int RenderingVertexCount { get; set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="indexAccessMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(IndexAccessMode indexAccessMode)
        {
            uint mode = (uint)this.Mode;

            int instanceCount = this.InstanceCount;
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (frameCount < 1) { throw new Exception("error: frameCount is less than 1."); }

            switch (indexAccessMode)
            {
                case IndexAccessMode.ByFrame:
                    int vertexCount = this.VertexCount;
                    if (frameCount == 1)
                    {
                        glDrawArraysInstanced(mode, 0, this.VertexCount, instanceCount);
                    }
                    else
                    {
                        int vertexCountPerFrame = vertexCount / frameCount;
                        glDrawArraysInstanced(mode, this.CurrentFrame * vertexCountPerFrame, vertexCountPerFrame, instanceCount);
                    }
                    break;
                case IndexAccessMode.Random:
                    glDrawArraysInstanced(mode, this.FirstVertex, this.RenderingVertexCount, instanceCount);
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexAccessMode));
            }

        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int primCount = this.InstanceCount;
            if (primCount < 1) { return string.Format("error: primCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (FrameCount < 1) { return string.Format("error: frameCount is less than 1."); }

            var builder = new System.Text.StringBuilder();

            var mode = this.Mode;
            int vertexCount = this.VertexCount;

            builder.AppendLine("ControlMode.ByFrame:");
            if (frameCount == 1)
            {
                builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", mode, 0, vertexCount, primCount));
            }
            else
            {
                int vertexCountPerFrame = vertexCount / frameCount;
                builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first = currentFrame * vertexCountPerFrame: {1} = {2} * {3}, count = vertexCountPerFrame: {4}, primCount: {5});", mode, this.CurrentFrame * vertexCountPerFrame, this.CurrentFrame, vertexCountPerFrame, vertexCountPerFrame, primCount));
            }

            builder.AppendLine("ControlMode.Random:");
            builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", mode, this.FirstVertex, this.RenderingVertexCount, this.InstanceCount));

            return builder.ToString();
        }

        /// <summary>
        /// void glDrawArraysInstanced(GLenum mode​, GLint first​, GLsizei count​, GLsizei primcount​);
        /// <para>mode: Specifies what kind of primitives to render. Symbolic constants GL_POINTS, GL_LINE_STRIP, GL_LINE_LOOP, GL_LINES, GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN, GL_TRIANGLES, GL_LINES_ADJACENCY, GL_LINE_STRIP_ADJACENCY, GL_TRIANGLES_ADJACENCY, GL_TRIANGLE_STRIP_ADJACENCY and GL_PATCHES are accepted.</para>
        /// <para>first: Specifies the starting index in the enabled arrays.</para>
        /// <para>count: Specifies the number of indices to be rendered.</para>
        /// <para>primcount: Specifies the number of instances of the specified range of indices to be rendered.</para>
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_int_int glDrawArraysInstanced;

        static DrawArraysInstancedCmd()
        {
            glDrawArraysInstanced = GL.Instance.GetDelegateFor("glDrawArraysInstanced", GLDelegates.typeof_void_uint_int_int_int) as GLDelegates.void_uint_int_int_int;
        }
    }
}