using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 索引buffer。索引指定了<see cref="PropertyBuffer"/>里各个顶点的渲染顺序。
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？</typeparam>
    public class OneIndexBuffer<T> : IndexBuffer<T> where T : struct
    {
        /// <summary>
        /// 用于存储索引的VBO。
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="type">type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        /// <param name="usage"></param>
        public OneIndexBuffer(DrawMode mode, BufferUsage usage)
            : base(mode, usage)
        {
            if (typeof(uint) == typeof(T))
            {
                this.Type = IndexElementType.UnsignedInt;
            }
            else if (typeof(ushort) == typeof(T))
            {
                this.Type = IndexElementType.UnsignedShort;
            }
            else if (typeof(byte) == typeof(T))
            {
                this.Type = IndexElementType.UnsignedByte;
            }
            else
            { throw new ArgumentException(); }
        }

        /// <summary>
        /// 索引数组中有多少个元素。
        /// </summary>
        public int GetElementCount()
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

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// 只能是OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT
        /// </summary>
        public IndexElementType Type { get; private set; }

        //protected override UnmanagedArrayBase CreateElements(int elementCount)
        //{
        //    UnmanagedArrayBase result = null;
        //    switch (this.Type)
        //    {
        //        case IndexElementType.UnsignedByte:
        //            result = new UnmanagedArray<byte>(elementCount);
        //            break;
        //        case IndexElementType.UnsignedShort:
        //            result = new UnmanagedArray<ushort>(elementCount);
        //            break;
        //        case IndexElementType.UnsignedInt:
        //            result = new UnmanagedArray<uint>(elementCount);
        //            break;
        //        default:
        //            throw new NotImplementedException();
        //    }

        //    return result;
        //}

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            this.array = new UnmanagedArray<T>(elementCount);
        }

        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, buffers[0]);
            glBufferData(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, 0);

            OneIndexBufferPtr bufferPtr = new OneIndexBufferPtr(
                 buffers[0], this.Mode, 0, this.GetElementCount(), this.Type, this.Length, this.ByteLength);

            return bufferPtr;
        }
    }

    public enum IndexElementType : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        UnsignedShort = OpenGL.GL_UNSIGNED_SHORT,
        UnsignedInt = OpenGL.GL_UNSIGNED_INT,
    }
}
