using CSharpGL;
using System;
using System.Collections.Generic;

namespace DrvSimu
{
    internal class PointsModel : IBufferable
    {

        /// <summary>
        /// how many points can this model contains?
        /// </summary>
        private int capacity;

        public PointsModel(int capacity)
        {
            this.capacity = capacity;
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;

        private ZeroIndexBufferPtr indexBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(this.capacity);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.capacity; i++)
                            {
                                array[i] = new vec3(0, 0, 0);
                            }
                        }
                        this.positionBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(this.capacity);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.capacity; i++)
                            {
                                array[i] = new vec3(1, 0, 0);// red color as default.
                            }
                        }
                        this.colorBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.LineStrip, 0, this.capacity))
                {
                    this.indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
                }
            }

            return this.indexBufferPtr;
        }

        public bool UsesZeroIndexBuffer()
        {
            return true;
        }
    }
}