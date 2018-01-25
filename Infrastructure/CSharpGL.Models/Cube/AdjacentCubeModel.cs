using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AdjacentCubeModel : IBufferSource
    {
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(1,-1,-1),
            new vec3(1,-1,1),
            new vec3(-1,-1,1),
            new vec3(-1,-1,-1),
            new vec3(1,1,-1),
            new vec3(1,1,1),
            new vec3(-1,1,1),
            new vec3(-1,1,-1),
        };
        private static readonly vec3[] colors = new vec3[]
        {
            new vec3(1,0,0),
            new vec3(1,1,1) * 0.5f,
            new vec3(0,0,1),
            new vec3(1,1,1) * 0.5f,
            new vec3(1,1,1) * 0.5f,
            new vec3(1,1,1),
            new vec3(1,1,1) * 0.5f,
            new vec3(0,1,0),
        };

        private static readonly Face[] indexes = new Face[] { new Face(0, 1, 2), new Face(0, 2, 3), new Face(4, 7, 6), new Face(4, 6, 5), new Face(0, 4, 5), new Face(0, 5, 1), new Face(1, 5, 6), new Face(1, 6, 2), new Face(2, 6, 7), new Face(2, 7, 3), new Face(4, 0, 3), new Face(4, 3, 7), };

        private static readonly AdjacentFace[] adjacentIndexes;

        static AdjacentCubeModel()
        {
            adjacentIndexes = FaceHelper.CalculateAdjacentFaces(indexes);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand command;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.command == null)
            {
                //IndexBuffer indexBuffer = indexes.GenIndexBuffer(IndexBufferElementType.UShort, BufferUsage.StaticDraw);
                //this.command = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
                IndexBuffer indexBuffer = adjacentIndexes.GenIndexBuffer(IndexBufferElementType.UShort, BufferUsage.StaticDraw);
                this.command = new DrawElementsCmd(indexBuffer, DrawMode.TrianglesAdjacency);
            }

            yield return this.command;
        }

        #endregion

        public vec3 GetSize()
        {
            return new vec3(2, 2, 2);
        }
    }
}
