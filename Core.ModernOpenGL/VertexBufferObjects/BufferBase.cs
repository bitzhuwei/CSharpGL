using CSharpGL;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    /// <summary>
    /// vertex buffer object的基类。
    /// </summary>
    public abstract class BufferBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usage">usage in BufferData(uint target, int size, IntPtr data, uint usage)</param>
        public BufferBase(UsageType usage)
        {
            this.Usage = usage;
        }

        /// <summary>
        /// buffers[0] in GenBuffers(int n, uint[] buffers)
        /// <para>buffer in BindBuffer(uint target, uint buffer)</para>
        /// </summary>
        public uint BufferID { get; protected set; }

        /// <summary>
        /// target in BindBuffer(uint target, uint buffer)
        /// target in BufferData(uint target, int size, IntPtr data, uint usage)
        /// </summary>
        public abstract BufferTargetType Target { get; }

        /// <summary>
        /// usage in BufferData(uint target, int size, IntPtr data, uint usage)
        /// </summary>
        public UsageType Usage { get; set; }

        public override string ToString()
        {
            return string.Format("BufferID: {0}, Target: {1}, Usage: {2}", BufferID, Target, Usage);
        }

        /// <summary>
        /// 初始化VAO时，此buffer应做些什么？
        /// </summary>
        /// <param name="gl"></param>
        public abstract void LayoutForVAO();

        public virtual void Create(UnmanagedArrayBase values)
        {
            uint[] buffers = new uint[1];
            GL.GenBuffers(1, buffers);
            GL.BindBuffer((uint)this.Target, buffers[0]);
            GL.BufferData((uint)this.Target, values.ByteLength, values.Header, (uint)this.Usage);

            this.BufferID = buffers[0];
        }

        public void Update(UnmanagedArrayBase newValues)
        {
            GL.BindBuffer((uint)this.Target, this.BufferID);
            IntPtr dest = GL.MapBuffer((uint)this.Target, GL.GL_READ_WRITE);
            newValues.CopyTo(dest);
            GL.UnmapBuffer((uint)this.Target);
        }

        public void Update(UnmanagedArrayBase newValues, int startIndex)
        {
            GL.BindBuffer((uint)this.Target, this.BufferID);
            IntPtr dest = GL.MapBufferRange((uint)this.Target, startIndex, newValues.ByteLength, GL.GL_READ_WRITE);
            newValues.CopyTo(dest);
            GL.UnmapBuffer((uint)this.Target);
        }
    }
}
