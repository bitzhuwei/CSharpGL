using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AdjacentTriangleModel : IBufferSource
    {
        private ObjVNFMesh mesh;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public vec3 GetSize()
        {
            return mesh.Size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        public AdjacentTriangleModel(ObjVNFMesh mesh)
        {
            this.mesh = mesh;
        }

        #region IBufferSource 成员

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IDrawCommand drawCmd;

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = mesh.vertexes.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = mesh.texCoords.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = mesh.normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                ObjVNFMesh mesh = this.mesh;
                ushort[] values = new ushort[3];
                var index = 0;
                var array = new Face[mesh.faces.Length];
                foreach (var face in mesh.faces)
                {
                    int i = 0;
                    foreach (var vertexIndex in face.VertexIndexes())
                    {
                        if (vertexIndex > ushort.MaxValue)
                        {
                            throw new Exception(string.Format("Not support model size greater than {0} vertexes!", ushort.MaxValue));
                        }

                        values[i++] = (ushort)vertexIndex;
                    }
                    array[index++] = new Face(values[0], values[1], values[2]);
                    i = 0;
                }
                AdjacentFace[] adjacentFaces = array.CalculateAdjacentFaces();
                IndexBuffer buffer = adjacentFaces.GenIndexBuffer(IndexBufferElementType.UShort, BufferUsage.StaticDraw);

                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TrianglesAdjacency);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
