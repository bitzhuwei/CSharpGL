using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    public class IndexBuffer : IndexBufferBase
    {
        /// <summary>
        /// 用于存储索引的VBO。
        /// </summary>
        /// <param name="name">此索引VBO的名字。如果有多个时，可用于区分索引。</param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="type">type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        public IndexBuffer(string name, DrawMode mode, IndexElementType type, BufferUsage usage)
            : base(name, mode, usage)
        {
            this.Type = type;
        }

        /// <summary>
        /// 索引数组中有多少个元素。
        /// </summary>
        public int ElementCount
        {
            get
            {
                int result = 0;
                switch (this.Type)
                {
                    case IndexElementType.UnsignedByte:
                        result = base.ByteLength / sizeof(byte);
                        break;
                    case IndexElementType.UnsignedShort:
                        result = base.ByteLength / sizeof(ushort);
                        break;
                    case IndexElementType.UnsignedInt:
                        result = base.ByteLength / sizeof(uint);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return result;
            }
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// 只能是OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT
        /// </summary>
        public IndexElementType Type { get; private set; }

        protected override UnmanagedArrayBase CreateElements(int elementCount)
        {
            UnmanagedArrayBase result = null;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    result = new UnmanagedArray<byte>(elementCount);
                    break;
                case IndexElementType.UnsignedShort:
                    result = new UnmanagedArray<ushort>(elementCount);
                    break;
                case IndexElementType.UnsignedInt:
                    result = new UnmanagedArray<uint>(elementCount);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        protected override BufferRenderer CreateRenderer()
        {
            uint[] buffers = new uint[1];
            GL.GenBuffers(1, buffers);
            GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, buffers[0]);
            GL.BufferData(GL.GL_ELEMENT_ARRAY_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);

            IndexBufferRenderer renderer = new IndexBufferRenderer(
                 buffers[0], this.Mode, this.ElementCount, this.Type);

            return renderer;
        }
    }

    public enum IndexElementType : uint
    {
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        UnsignedShort = GL.GL_UNSIGNED_SHORT,
        UnsignedInt = GL.GL_UNSIGNED_INT,
    }
}
