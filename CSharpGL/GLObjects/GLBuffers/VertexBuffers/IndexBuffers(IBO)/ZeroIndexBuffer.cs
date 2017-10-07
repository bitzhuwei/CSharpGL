using System;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    public sealed partial class ZeroIndexBuffer : IndexBuffer
    {
        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <param name="frameCount">How many frames are there?</param>
        internal ZeroIndexBuffer(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1, int frameCount = 1)
            : base(mode, 0, firstVertex, vertexCount, vertexCount * sizeof(uint), primCount, frameCount)
        {
            this.Target = BufferTarget.ZeroIndexArrayBuffer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public override void Draw(ControlMode controlMode)
        {
            uint mode = (uint)this.Mode;

            int primCount = this.PrimCount;
            if (primCount < 1) { throw new Exception("error: primCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (FrameCount < 1) { throw new Exception("error: frameCount is less than 1."); }

            switch (controlMode)
            {
                case ControlMode.ByFrame:
                    int vertexCount = this.VertexCount;
                    if (primCount == 1)
                    {
                        if (frameCount == 1)
                        {
                            GL.Instance.DrawArrays(mode, 0, vertexCount);
                        }
                        else
                        {
                            int vertexCountPerFrame = vertexCount / frameCount;
                            GL.Instance.DrawArrays(mode, this.CurrentFrame * vertexCountPerFrame, vertexCountPerFrame);
                        }
                    }
                    else
                    {
                        if (frameCount == 1)
                        {
                            glDrawArraysInstanced(mode, 0, this.VertexCount, primCount);
                        }
                        else
                        {
                            int vertexCountPerFrame = vertexCount / frameCount;
                            glDrawArraysInstanced(mode, this.CurrentFrame * vertexCountPerFrame, vertexCountPerFrame, primCount);
                        }
                    }
                    break;
                case ControlMode.Random:
                    if (primCount == 1)
                    {
                        GL.Instance.DrawArrays(mode, this.FirstVertex, this.RenderingVertexCount);
                    }
                    else
                    {
                        glDrawArraysInstanced(mode, this.FirstVertex, this.RenderingVertexCount, primCount);
                    }
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid value[{0}]", controlMode));
            }

        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int primCount = this.PrimCount;
            if (primCount < 1) { return string.Format("error: primCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (FrameCount < 1) { return string.Format("error: frameCount is less than 1."); }

            var builder = new System.Text.StringBuilder();

            var mode = this.Mode;
            int vertexCount = this.VertexCount;

            builder.AppendLine("ControlMode.ByFrame:");
            if (primCount == 1)
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawArrays(mode: {0}, first: {1}, count: {2});", mode, 0, vertexCount));
                }
                else
                {
                    int vertexCountPerFrame = vertexCount / frameCount;
                    builder.AppendLine(string.Format("glDrawArrays(mode: {0}, first = currentFrame * vertexCountPerFrame: {1} = {2} * {3}, count = vertexCountPerFrame: {4});", mode, this.CurrentFrame * vertexCountPerFrame, this.CurrentFrame, vertexCountPerFrame, vertexCountPerFrame));
                }
            }
            else
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", mode, 0, vertexCount, primCount));
                }
                else
                {
                    int vertexCountPerFrame = vertexCount / frameCount;
                    builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first = currentFrame * vertexCountPerFrame: {1} = {2} * {3}, count = vertexCountPerFrame: {4}, primCount: {5});", mode, this.CurrentFrame * vertexCountPerFrame, this.CurrentFrame, vertexCountPerFrame, vertexCountPerFrame, primCount));
                }
            }

            builder.AppendLine("ControlMode.Random:");
            if (primCount == 1)
            {
                builder.AppendLine(string.Format("glDrawArrays(mode: {0}, first: {1}, count: {2});", mode, this.FirstVertex, this.RenderingVertexCount));
            }
            else
            {
                builder.AppendLine(string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", mode, this.FirstVertex, this.RenderingVertexCount, this.PrimCount));
            }

            return builder.ToString();
        }
    }
}