using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>
    [Editor(typeof(DrawElementsCmdEditor), typeof(UITypeEditor))]
    public class DrawElementsCmd : IDrawCommand
    {
        private IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        public IndexBuffer IndexBufferObject { get { return this.indexBuffer; } }

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="frameCount">How many frames are there?</param>
        public DrawElementsCmd(IndexBuffer indexBuffer, DrawMode mode, int firstVertex = 0, int instanceCount = 1, int frameCount = 1)
        //IndexBufferElementType elementType, int vertexCount, int byteLength, int instanceCount = 1, int frameCount = 1)
        //: base(mode, bufferId, 0, vertexCount, byteLength, instanceCount, frameCount)
        {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.FirstVertex = firstVertex;
            this.RenderingVertexCount = indexBuffer.VertexCount;

            this.InstanceCount = instanceCount;
            this.FrameCount = frameCount;
        }

        ///// <summary>
        ///// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        ///// </summary>
        //public IndexBufferElementType ElementType { get; private set; }

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

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int InstanceCount { get; private set; }

        /// <summary>
        /// How many frames are there?
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int FrameCount { get; set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(ControlMode controlMode)
        {
            int instanceCount = this.InstanceCount;
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }
            int frameCount = this.FrameCount;
            if (frameCount < 1) { throw new Exception("error: frameCount is less than 1."); }

            uint mode = (uint)this.Mode;
            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.VertexCount;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            GLBuffer.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.BufferId);
            switch (controlMode)
            {
                case ControlMode.ByFrame:
                    if (instanceCount == 1)
                    {
                        if (frameCount == 1)
                        {
                            GL.Instance.DrawElements(mode, vertexCount, (uint)elementType, offset);
                        }
                        else
                        {
                            glDrawElementsBaseVertex(mode, vertexCount, (uint)elementType, offset, this.CurrentFrame * vertexCount);
                        }
                    }
                    else
                    {
                        if (frameCount == 1)
                        {
                            glDrawElementsInstanced(mode, vertexCount, (uint)elementType, offset, instanceCount);
                        }
                        else
                        {
                            glDrawElementsInstancedBaseVertex(mode, vertexCount, (uint)elementType, offset, instanceCount, this.CurrentFrame * vertexCount);
                        }
                    }
                    break;
                case ControlMode.Random:
                    if (instanceCount == 1)
                    {
                        if (frameCount == 1)
                        {
                            GL.Instance.DrawElements(mode, this.RenderingVertexCount, (uint)elementType, offset);
                        }
                        else
                        {
                            glDrawElementsBaseVertex(mode, this.RenderingVertexCount, (uint)elementType, offset, this.CurrentFrame * vertexCount);
                        }
                    }
                    else
                    {
                        if (frameCount == 1)
                        {
                            glDrawElementsInstanced(mode, this.RenderingVertexCount, (uint)elementType, offset, instanceCount);
                        }
                        else
                        {
                            glDrawElementsInstancedBaseVertex(mode, this.RenderingVertexCount, (uint)elementType, offset, instanceCount, this.CurrentFrame * vertexCount);
                        }
                    }
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(ControlMode));
            }

            GLBuffer.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
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
            if (frameCount < 1) { return string.Format("error: frameCount is less than 1."); }

            var mode = this.Mode;
            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.VertexCount;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            var builder = new System.Text.StringBuilder();

            builder.AppendLine("ControlMode.ByFrame:");
            if (primCount == 1)
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", mode, vertexCount, elementType, offset));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, baseVertex = currentFrame * vertexCount: {4} = {5} * {6});", mode, vertexCount, elementType, offset, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }
            else
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, vertexCount, elementType, offset, primCount));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4}, baseVertex = currentFrame * vertexCount: {5} = {6} * {7});", mode, vertexCount, elementType, offset, primCount, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }

            builder.AppendLine("ControlMode.Random:");
            if (primCount == 1)
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", mode, this.RenderingVertexCount, elementType, offset));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, baseVertex = currentFrame * vertexCount: {4} = {5} * {6});", mode, this.RenderingVertexCount, elementType, offset, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }
            else
            {
                if (frameCount == 1)
                {
                    builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, this.RenderingVertexCount, elementType, offset, primCount));
                }
                else
                {
                    builder.AppendLine(string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4}, baseVertex = currentFrame * vertexCount: {5} = {6} * {7});", mode, this.RenderingVertexCount, elementType, offset, primCount, this.CurrentFrame * vertexCount, this.CurrentFrame, vertexCount));
                }
            }

            return builder.ToString();
        }

        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsInstanced;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsBaseVertex;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int_int glDrawElementsInstancedBaseVertex;
        static DrawElementsCmd()
        {
            glDrawElementsInstanced = GL.Instance.GetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
            glDrawElementsInstancedBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsInstancedBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int_int) as GLDelegates.void_uint_int_uint_IntPtr_int_int;
        }
    }
}