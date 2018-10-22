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
        private Assimp.Matrix4x4 m_GlobalInverseTransform;

        private uvec4[] boneIDs;
        private vec4[] boneWeights;

        public BoneModel(Assimp.Mesh mesh, AssimpSceneContainer container)
        {
            this.mesh = mesh;
            this.container = container;
            this.m_GlobalInverseTransform = container.aiScene.RootNode.Transform;
            this.m_GlobalInverseTransform.Inverse();
            InitBoneInfo(mesh, container);
        }

        private void InitBoneInfo(Assimp.Mesh mesh, AssimpSceneContainer container)
        {
            var boneIDs = new uvec4[mesh.VertexCount];
            var boneWeights = new vec4[mesh.VertexCount];
            List<BoneInfo> bones = new List<BoneInfo>();
            var nameIndexDict = new Dictionary<string, uint>();
            AllBones allBones = container.GetAllBones();
            Dictionary<string, uint> dict = allBones.nameIndexDict;
            for (int i = 0; i < mesh.BoneCount; i++)
            {
                Assimp.Bone bone = mesh.Bones[i];
                uint boneIndex = dict[bone.Name];

                for (int j = 0; j < bone.VertexWeightCount; j++)
                {
                    Assimp.VertexWeight vertexWeight = bone.VertexWeights[j];
                    uint vertexID = vertexWeight.VertexID;
                    for (int t = 0; t < 4; t++)
                    {
                        if (boneWeights[vertexID][t] == 0.0f)
                        {
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

        public Texture Texture
        {
            get { throw new NotImplementedException(); }
        }

        public int BoneCount
        {
            get { return this.container.GetAllBones().boneInfos.Length; }
        }

        public mat4[] DefaultBoneMatrixes()
        {
            throw new NotImplementedException();
            //mat4[] result = null;
            //EZMSkeleton skeleton = this.ezmMesh.Skeleton;
            //if (skeleton != null)
            //{
            //    EZMBone[] bones = skeleton.Bones;
            //    if (bones != null)
            //    {
            //        result = new mat4[bones.Length];
            //        for (int i = 0; i < result.Length; i++)
            //        {
            //            //result[i] = bones[i].combinedMat * bones[i].inverseCombinedMatrix;
            //            //result[i] = bones[i].combinedMat;
            //            //result[i] = bones[i].OriginalState.matrix;
            //            //result[i] = bones[i].state.matrix;
            //            //result[i] = bones[i].inverseCombinedMatrix;
            //            result[i] = mat4.identity();
            //        }
            //    }
            //}
            //return result;
        }

        private bool firstRun = true;
        private DateTime lastTime;
        private double passedTime = 0;
        private int currentFrame = 0;

        public mat4[] GetBoneMatrixes(float TimeInSeconds)
        {
            Assimp.Scene scene = this.container.aiScene;
            double ticksPerSecond = scene.Animations[0].TicksPerSecond;
            if (ticksPerSecond == 0) { ticksPerSecond = 25.0; }
            double timeInTicks = TimeInSeconds * ticksPerSecond;
            float animationTime = (float)(timeInTicks % scene.Animations[0].DurationInTicks);

            Assimp.Matrix4x4 identity = Assimp.Matrix4x4.Identity;
            ReadNodeHeirarchy(animationTime, scene.RootNode, identity);

            var allBones = this.container.GetAllBones();
            int boneCount = allBones.boneInfos.Length;
            var result = new mat4[boneCount];
            for (int i = 0; i < boneCount; i++)
            {
                result[i] = allBones.boneInfos[i].FinalTransformation.ToMat4();
            }

            return result;
        }

        private void ReadNodeHeirarchy(float animationTime, Assimp.Node node, Assimp.Matrix4x4 parentTransform)
        {
            var allBones = this.container.GetAllBones();
            string nodeName = node.Name;
            Assimp.Scene scene = this.container.aiScene;
            var animation = scene.Animations[0];
            Assimp.Matrix4x4 nodeTransform = node.Transform;
            Assimp.NodeAnimationChannel nodeAnim = FineNodeAnim(animation, nodeName);
            if (nodeAnim != null)
            {

            }

            Assimp.Matrix4x4 GlobalTransformation = parentTransform * nodeTransform;

            if (allBones.nameIndexDict.ContainsKey(nodeName))
            {
                uint BoneIndex = allBones.nameIndexDict[nodeName];
                allBones.boneInfos[BoneIndex].FinalTransformation = m_GlobalInverseTransform * GlobalTransformation * allBones.boneInfos[BoneIndex].Bone.OffsetMatrix;
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ReadNodeHeirarchy(animationTime, node.Children[i], GlobalTransformation);
            }
        }

        private Assimp.NodeAnimationChannel FineNodeAnim(Assimp.Animation animation, string nodeName)
        {
            Assimp.NodeAnimationChannel channel = null;
            for (int i = 0; i < animation.NodeAnimationChannelCount; i++)
            {
                var nodeAnim = animation.NodeAnimationChannels[i];
                if (nodeAnim.NodeName == nodeName)
                {
                    channel = nodeAnim;
                    break;
                }
            }

            return channel;
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
            else if (strBoneIDs == bufferName)
            {
                if (this.boneIDsBuffer == null)
                {
                    this.boneIDsBuffer = this.boneIDs.GenVertexBuffer(VBOConfig.UVec4, BufferUsage.StaticDraw);
                }

                yield return this.boneIDsBuffer;
            }
            else if (strWeights == bufferName)
            {
                if (this.weightsBuffer == null)
                {
                    this.weightsBuffer = this.boneWeights.GenVertexBuffer(VBOConfig.Vec4, BufferUsage.StaticDraw);
                }

                yield return this.weightsBuffer;
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
