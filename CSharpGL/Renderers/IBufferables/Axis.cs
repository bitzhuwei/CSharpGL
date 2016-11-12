using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// an 3D axis
    /// </summary>
    public class Axis : IBufferable
    {
        private AxisModel model;

        /// <summary>
        /// an 3D axis
        /// </summary>
        /// <param name="partCount"></param>
        /// <param name="radius"></param>
        public Axis(int partCount = 24, float radius = 0.5f)
        {
            if (partCount < 2) { throw new ArgumentException(); }
            this.model = new AxisModel(partCount, radius);
            this.ModelSize = new vec3(radius * 2, radius * 2, radius * 2);
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    int length = this.model.positions.Length;
                    VertexBuffer ptr = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = ptr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer.ToPointer();
                        for (int i = 0; i < length; i++)
                        {
                            array[i] = this.model.positions[i];
                        }
                        ptr.UnmapBuffer();
                    }
                    this.positionBuffer = ptr;
                }
                return positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (colorBuffer == null)
                {
                    int length = this.model.colors.Length;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer.ToPointer();
                        for (int i = 0; i < length; i++)
                        {
                            array[i] = this.model.colors[i];
                        }
                        buffer.UnmapBuffer();
                    }

                    this.colorBuffer = buffer;
                }
                return colorBuffer;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBuffer GetIndexBuffer()
        {
            if (indexBuffer == null)
            {
                OneIndexBuffer buffer = OneIndexBuffer.Create(BufferUsage.StaticDraw, this.model.mode, IndexElementType.UInt, this.model.indexes.Length);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer.ToPointer();
                    for (int i = 0; i < this.model.indexes.Length; i++)
                    {
                        array[i] = this.model.indexes[i];
                    }
                    buffer.UnmapBuffer();
                }

                this.indexBuffer = buffer;
            }

            return indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        private IndexBuffer indexBuffer = null;

        /// <summary>
        ///
        /// </summary>
        public vec3 ModelSize { get; private set; }
    }
}