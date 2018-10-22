using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class BoneModel : IBufferSource
    {
        private Assimp.Mesh mesh;
        private AssimpSceneContainer container;

        public BoneModel(Assimp.Mesh mesh, AssimpSceneContainer container)
        {
            this.mesh = mesh;
            this.container = container;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        //public const string strNormal = "normal";
        //private VertexBuffer normalBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        public const string strBoneIDs = "boneIDs";
        private VertexBuffer boneIDsBuffer;
        public const string strWeights = "weights";
        private VertexBuffer weightsBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.mesh.Vertices.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strTexCoord == bufferName)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = this.mesh.GetTextureCoords(0).GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                int faceCount = this.mesh.FaceCount;
                var indexes = new uint[faceCount * 3];
                for (int i = 0; i < faceCount; i++)
                {
                    for (int t = 0; t < 3; t++)
                    {
                        indexes[i * 3 + t] = this.mesh.Faces[i].Indices[t];
                    }
                }
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
