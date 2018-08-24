using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PrismoidModel : IBufferSource, IObjFormat
    {
        private vec3 modelSize;
        public vec3 ModelSize()
        {
            return this.modelSize;
        }

        public PrismoidModel(float topXLength, float topZLength, float bottomXLength, float bottomZLength, float height)
        {
            float xDiff = (bottomXLength - topXLength) / 2;
            float zDiff = (bottomZLength - topZLength) / 2;
            var positions = new vec3[8];
            positions[0] = new vec3(topXLength + xDiff, height, topZLength + zDiff);
            positions[1] = new vec3(topXLength + xDiff, height, 0);
            positions[2] = new vec3(bottomXLength, 0, bottomZLength);
            positions[3] = new vec3(bottomXLength, 0, 0);
            positions[4] = new vec3(xDiff, height, topZLength + zDiff);
            positions[5] = new vec3(xDiff, height, zDiff);
            positions[6] = new vec3(0, 0, bottomZLength);
            positions[7] = new vec3(0, 0, 0);
            BoundingBox box = positions.Move2Center();
            this.positions = positions;
            this.modelSize = box.MaxPosition - box.MinPosition;
        }

        private vec3[] positions;
        private static readonly uint[] indexes = new uint[]
        {
            0, 2, 1,  1, 2, 3,
            0, 1, 5,  0, 5, 4,
            0, 4, 2,  2, 4, 6,
            7, 6, 4,  7, 4, 5,
            7, 5, 3,  3, 5, 1,
            7, 3, 2,  7, 2, 6,
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;


        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion

        #region IObjFormat 成员

        public vec3[] GetPositions()
        {
            return this.positions;
        }

        public uint[] GetIndexes()
        {
            return indexes;
        }

        #endregion
    }
}
