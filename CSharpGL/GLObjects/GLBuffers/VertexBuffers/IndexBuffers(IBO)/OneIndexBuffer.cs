using System;

namespace CSharpGL
{
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>
    public sealed partial class OneIndexBuffer : IndexBuffer
    {
        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="elementType">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        /// <param name="vertexCount">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="frameCount">How many frames are there?</param>
        internal OneIndexBuffer(uint bufferId, DrawMode mode,
            IndexBufferElementType elementType, int vertexCount, int byteLength, int instanceCount = 1, int frameCount = 1)
            : base(mode, bufferId, 0, vertexCount, byteLength, instanceCount, frameCount)
        {
            this.Target = BufferTarget.ElementArrayBuffer;

            this.ElementType = elementType;
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexBufferElementType ElementType { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public override void Draw(ControlMode controlMode)
        {
            int instanceCount = this.InstanceCount;
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (FrameCount < 1) { throw new Exception("error: frameCount is less than 1."); }

            uint mode = (uint)this.Mode;
            int vertexCount = this.VertexCount;
            IntPtr offset = GetOffset(this.ElementType, this.FirstVertex);


            glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, this.BufferId);
            switch (controlMode)
            {
                case ControlMode.ByFrame:
                    if (instanceCount == 1)
                    {
                        if (frameCount == 1)
                        {
                            GL.Instance.DrawElements(mode, vertexCount, (uint)this.ElementType, offset);
                        }
                        else
                        {
                            glDrawElementsBaseVertex(mode, vertexCount, (uint)this.ElementType, offset, this.CurrentFrame * vertexCount);
                        }
                    }
                    else
                    {
                        if (frameCount == 1)
                        {
                            glDrawElementsInstanced(mode, vertexCount, (uint)this.ElementType, offset, instanceCount);
                        }
                        else
                        {
                            glDrawElementsInstancedBaseVertex(mode, vertexCount, (uint)this.ElementType, offset, instanceCount, this.CurrentFrame * vertexCount);
                        }
                    }
                    break;
                case ControlMode.Random:
                    if (instanceCount == 1)
                    {
                        if (frameCount == 1)
                        {
                            GL.Instance.DrawElements(mode, this.RenderingVertexCount, (uint)this.ElementType, offset);
                        }
                        else
                        {
                            glDrawElementsBaseVertex(mode, this.RenderingVertexCount, (uint)this.ElementType, offset, this.CurrentFrame * vertexCount);
                        }
                    }
                    else
                    {
                        if (frameCount == 1)
                        {
                            glDrawElementsInstanced(mode, this.RenderingVertexCount, (uint)this.ElementType, offset, instanceCount);
                        }
                        else
                        {
                            glDrawElementsInstancedBaseVertex(mode, this.RenderingVertexCount, (uint)this.ElementType, offset, instanceCount, this.CurrentFrame * vertexCount);
                        }
                    }
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(ControlMode));
            }

            glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
        }

        private IntPtr GetOffset(IndexBufferElementType elementType, int firstIndex)
        {
            IntPtr offset;
            switch (elementType)
            {
                case IndexBufferElementType.UByte:
                    offset = new IntPtr(firstIndex * sizeof(byte));
                    break;

                case IndexBufferElementType.UShort:
                    offset = new IntPtr(firstIndex * sizeof(ushort));
                    break;

                case IndexBufferElementType.UInt:
                    offset = new IntPtr(firstIndex * sizeof(uint));
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
            }
            return offset;
        }

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

            var mode = this.Mode;
            int vertexCount = this.VertexCount;
            IntPtr offset = GetOffset(this.ElementType, this.FirstVertex);

            var builder = new System.Text.StringBuilder();

            builder.AppendLine("ControlMode.ByFrame:");
            if (primCount == 1)
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", mode, vertexCount, this.ElementType, offset));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, baseVertex = currentFrame * vertexCount: {4} = {5} * {6});", mode, vertexCount, this.ElementType, offset, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }
            else
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, vertexCount, this.ElementType, offset, primCount));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4}, baseVertex = currentFrame * vertexCount: {5} = {6} * {7});", mode, vertexCount, this.ElementType, offset, primCount, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }

            builder.AppendLine("ControlMode.Random:");
            if (primCount == 1)
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", mode, this.RenderingVertexCount, this.ElementType, offset));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, baseVertex = currentFrame * vertexCount: {4} = {5} * {6});", mode, this.RenderingVertexCount, this.ElementType, offset, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }
            else
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, this.RenderingVertexCount, this.ElementType, offset, primCount));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4}, baseVertex = currentFrame * vertexCount: {5} = {6} * {7});", mode, this.RenderingVertexCount, this.ElementType, offset, primCount, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }

            return builder.ToString();
        }
    }
}