using System;

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
            this.Lengths = new vec3(radius * 2, radius * 2, radius * 2);
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(this.model.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.model.positions.Length; i++)
                            {
                                array[i] = this.model.positions[i];
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(this.model.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.model.colors.Length; i++)
                            {
                                array[i] = this.model.colors[i];
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return colorBufferPtr;
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
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer<uint>(
                     this.model.mode, BufferUsage.StaticDraw))
                {
                    buffer.Create(this.model.indexes.Length);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < this.model.indexes.Length; i++)
                        {
                            array[i] = this.model.indexes[i];
                        }
                    }
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer&lt;T&gt;"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }
    }
}