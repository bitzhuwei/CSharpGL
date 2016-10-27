using CSharpGL;
using System;
using System.Collections.Generic;

namespace FeasibilityTest
{
    internal class PointsModel : IBufferable
    {
        private List<vec3> pointList;

        public PointsModel(List<vec3> pointList)
        {
            this.pointList = pointList;
        }

        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBufferPtr;

        private ZeroIndexBufferPtr indexBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(this.pointList.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.pointList.Count; i++)
                            {
                                array[i] = this.pointList[i];
                            }
                        }
                        this.positionBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.positionBufferPtr;
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
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.pointList.Count))
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