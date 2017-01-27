using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMGraphics
{
    /// <summary>
    /// 
    /// </summary>
    public class TestModel : IBufferable
    {
        public TestModel(vec3[] vertexPositions, Triangle[] triangles)
        {
            this.vertexPositions = vertexPositions;
            this.triangles = triangles;
        }
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        private vec3[] vertexPositions;

        public const string strIndex = "index";
        private IndexBuffer indexBuffer = null;
        private Triangle[] triangles;

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.vertexPositions.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                OneIndexBuffer buffer = CSharpGL.Buffer.Create(IndexBufferElementType.UInt, this.triangles.Length * 3, DrawMode.TriangleStrip, BufferUsage.StaticDraw);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    for (int i = 0; i < this.triangles.Length; i++)
                    {
                        array[i * 3 + 0] = (uint)this.triangles[i].Num1;
                        array[i * 3 + 1] = (uint)this.triangles[i].Num2;
                        array[i * 3 + 2] = (uint)this.triangles[i].Num3;
                    }
                    buffer.UnmapBuffer();
                }
                this.indexBuffer = buffer;
            }

            return indexBuffer;
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }
}
