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

        private static readonly vec3[] normals = new vec3[]
        {
            new vec3(1,-1,-1).normalize(),
            new vec3(1,-1,1).normalize(),
            new vec3(-1,-1,1).normalize(),
            new vec3(-1,-1,-1).normalize(),
            new vec3(1,1,-1).normalize(),
            new vec3(1,1,1).normalize(),
            new vec3(-1,1,1).normalize(),
            new vec3(-1,1,-1).normalize(),
        };

        private static readonly Face[] indexes = new Face[] { new Face(0, 1, 2), new Face(0, 2, 3), new Face(4, 7, 6), new Face(4, 6, 5), new Face(0, 4, 5), new Face(0, 5, 1), new Face(1, 5, 6), new Face(1, 6, 2), new Face(2, 6, 7), new Face(2, 7, 3), new Face(4, 0, 3), new Face(4, 3, 7), };

        private static readonly AdjacentFace[] adjacentIndexes;

        static AdjacentCubeModel()
        {
            adjacentIndexes = FaceHelper.CalculateAdjacentFaces(indexes);
        }

        private vec3[] instancePositions;
        private vec3[] instanceNormals;
        public AdjacentCubeModel() : this(new vec3(2, 2, 2)) { }
        public AdjacentCubeModel(vec3 size)
        {
            size = size / 2;
            {
                var instancePositions = new vec3[positions.Length];
                for (int i = 0; i < positions.Length; i++)
                {
                    instancePositions[i] = positions[i] * size;
                }
                this.instancePositions = instancePositions;
            }
            {
                mat4 matrix = glm.transpose(glm.inverse(glm.scale(mat4.identity(), size)));
                var instanceNormals = new vec3[normals.Length];
                for (int i = 0; i < normals.Length; i++)
                {
                    instanceNormals[i] = new vec3((matrix * new vec4(normals[i], 0))).normalize();
                }
                this.instanceNormals = instanceNormals;
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IDrawCommand command;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.instancePositions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
            else if (strNormal == bufferName)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = this.instanceNormals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
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
