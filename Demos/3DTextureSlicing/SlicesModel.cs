using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace _3DTextureSlicing
{
    class SlicesModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer slicesBuffer;

        private IndexBuffer indexBuffer;

        const int MAX_SLICES = 512;
        private vec3[] vTextureSlices = new vec3[MAX_SLICES * 12];


        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.slicesBuffer == null)
                {
                    this.slicesBuffer = this.vTextureSlices.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicDraw);
                }

                return this.slicesBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Triangles, 0, this.vTextureSlices.Length);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
