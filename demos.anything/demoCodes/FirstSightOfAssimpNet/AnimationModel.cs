using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet {
    class AnimationModel : IBufferSource {
        public readonly Assimp.Mesh mesh;
        public readonly AssimpSceneContainer container;

        private uvec4[] boneIDs;
        private vec4[] boneWeights;

        public AnimationModel(Assimp.Mesh mesh, AssimpSceneContainer container) {
            this.mesh = mesh;
            this.container = container;
            InitSkinInfo(mesh, container);
        }

        private void InitSkinInfo(Assimp.Mesh mesh, AssimpSceneContainer container) {
            var boneIDs = new uvec4[mesh.VertexCount];
            var boneWeights = new vec4[mesh.VertexCount];
            AllBoneInfos allBones = container.GetAllBoneInfos();
            Dictionary<string, uint> name2index = allBones.name2index;
            for (int i = 0; i < mesh.BoneCount; i++) {
                Assimp.Bone bone = mesh.Bones[i]; // bones that influence this mesh.
                uint boneIndex = name2index[bone.Name];

                for (int j = 0; j < bone.VertexWeightCount; j++) {
                    Assimp.VertexWeight vertexWeight = bone.VertexWeights[j];
                    uint vertexID = vertexWeight.VertexID;
                    for (int t = 0; t < 4; t++) {
                        if (boneWeights[vertexID][t] == 0.0f) {// fill in x y z w.
                            boneIDs[vertexID][t] = boneIndex;
                            boneWeights[vertexID][t] = vertexWeight.Weight;
                            break;
                        }
                    }
                }
            }
            this.boneIDs = boneIDs;
            this.boneWeights = boneWeights;
        }

        public Texture Texture {
            get {
                int index = this.mesh.MaterialIndex;
                var texture = this.container.TextureProviders[index].BindingTexture;
                return texture;
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        public const string strBoneIDs = "boneIDs";
        private VertexBuffer boneIDsBuffer;
        public const string strWeights = "weights";
        private VertexBuffer weightsBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.mesh.Vertices.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strNormal == bufferName) {
                if (this.normalBuffer == null) {
                    this.normalBuffer = this.mesh.Normals.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else if (strTexCoord == bufferName) {
                if (this.texCoordBuffer == null) {
                    Assimp.Vector3D[] texCoords = this.mesh.GetTextureCoords(0);
                    if (texCoords == null) {
                        texCoords = new Assimp.Vector3D[this.mesh.VertexCount];
                        for (int i = 0; i < texCoords.Length; i++) {
                            texCoords[i] = new Assimp.Vector3D(-1, -1, -1);
                        }
                    }
                    this.texCoordBuffer = texCoords.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else if (strBoneIDs == bufferName) {
                if (this.boneIDsBuffer == null) {
                    this.boneIDsBuffer = this.boneIDs.GenVertexBuffer(VBOConfig.UVec4, GLBuffer.Usage.StaticDraw);
                }

                yield return this.boneIDsBuffer;
            }
            else if (strWeights == bufferName) {
                if (this.weightsBuffer == null) {
                    this.weightsBuffer = this.boneWeights.GenVertexBuffer(VBOConfig.Vec4, GLBuffer.Usage.StaticDraw);
                }

                yield return this.weightsBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                int faceCount = this.mesh.FaceCount;
                var indexes = new uint[faceCount * 3]; // assume this is a triangle face.
                for (int i = 0; i < faceCount; i++) {
                    for (int t = 0; t < 3; t++) {
                        indexes[i * 3 + t] = this.mesh.Faces[i].Indices[t];
                    }
                }
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(IndexBuffer.ElementType.UInt, GLBuffer.Usage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, CSharpGL.DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
