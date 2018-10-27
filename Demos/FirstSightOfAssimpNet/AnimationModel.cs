using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class AnimationModel : IBufferSource
    {
        public readonly Assimp.Mesh mesh;
        private AssimpSceneContainer container;
        private mat4 m_GlobalInverseTransform;

        private uvec4[] boneIDs;
        private vec4[] boneWeights;

        public AnimationModel(Assimp.Mesh mesh, AssimpSceneContainer container)
        {
            this.mesh = mesh;
            this.container = container;
            Assimp.Matrix4x4 matrix = container.aiScene.RootNode.Transform;
            matrix.Inverse();
            this.m_GlobalInverseTransform = matrix.ToMat4();
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
            get
            {
                int index = this.mesh.MaterialIndex;
                var texture = this.container.textures[index];
                return texture;
            }
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

        public mat4[] GetBoneMatrixes(float TimeInSeconds)
        {
            Assimp.Scene scene = this.container.aiScene;
            if (scene.AnimationCount <= 0) { return null; }
            double ticksPerSecond = scene.Animations[0].TicksPerSecond;
            if (ticksPerSecond == 0) { ticksPerSecond = 25.0; }
            double timeInTicks = TimeInSeconds * ticksPerSecond;
            float animationTime = (float)(timeInTicks % scene.Animations[0].DurationInTicks);

            mat4 identity = mat4.identity();
            ReadNodeHeirarchy(animationTime, scene.RootNode, identity);

            AllBones allBones = this.container.GetAllBones();
            int boneCount = allBones.boneInfos.Length;
            var result = new mat4[boneCount];

            for (int i = 0; i < boneCount; i++)
            {
                result[i] = allBones.boneInfos[i].FinalTransformation;
            }

            return result;
        }

        private void ReadNodeHeirarchy(float animationTime, Assimp.Node node, mat4 parentTransform)
        {
            var allBones = this.container.GetAllBones();
            string nodeName = node.Name;
            Assimp.Scene scene = this.container.aiScene;
            var animation = scene.Animations[0];
            mat4 nodeTransform = node.Transform.ToMat4();
            Assimp.NodeAnimationChannel nodeAnim = FineNodeAnim(animation, nodeName);
            if (nodeAnim != null)
            {
                mat4 mat = mat4.identity();
                // Interpolate scaling and generate scaling transformation matrix
                Assimp.Vector3D Scaling = CalcInterpolatedScaling(animationTime, nodeAnim);
                mat4 ScalingM = glm.scale(mat, new vec3(Scaling.X, Scaling.Y, Scaling.Z));

                // Interpolate rotation and generate rotation transformation matrix
                Assimp.Quaternion RotationQ = CalcInterpolatedRotation(animationTime, nodeAnim);
                mat4 RotationM = new Assimp.Matrix4x4(RotationQ.GetMatrix()).ToMat4();

                // Interpolate translation and generate translation transformation matrix
                Assimp.Vector3D Translation = CalcInterpolatedPosition(animationTime, nodeAnim);
                mat4 TranslationM = glm.translate(mat4.identity(), new vec3(Translation.X, Translation.Y, Translation.Z));

                // Combine the above transformations
                nodeTransform = TranslationM * RotationM * ScalingM;
            }

            //Assimp.Matrix4x4 GlobalTransformation = nodeTransform * parentTransform;
            mat4 GlobalTransformation = parentTransform * nodeTransform;

            if (allBones.nameIndexDict.ContainsKey(nodeName))
            {
                uint BoneIndex = allBones.nameIndexDict[nodeName];
                //allBones.boneInfos[BoneIndex].FinalTransformation = allBones.boneInfos[BoneIndex].Bone.OffsetMatrix * GlobalTransformation * m_GlobalInverseTransform;
                allBones.boneInfos[BoneIndex].FinalTransformation = m_GlobalInverseTransform * GlobalTransformation * allBones.boneInfos[BoneIndex].Bone.OffsetMatrix.ToMat4();
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ReadNodeHeirarchy(animationTime, node.Children[i], GlobalTransformation);
            }
        }

        private Assimp.Vector3D CalcInterpolatedPosition(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Vector3D Out;
            if (nodeAnim.PositionKeyCount == 1)
            {
                Out = nodeAnim.PositionKeys[0].Value;
                return Out;
            }

            uint PositionIndex = FindPosition(animationTime, nodeAnim);
            uint NextPositionIndex = (PositionIndex + 1);
            //assert(NextPositionIndex < nodeAnim->mNumPositionKeys);
            float DeltaTime = (float)(nodeAnim.PositionKeys[NextPositionIndex].Time - nodeAnim.PositionKeys[PositionIndex].Time);
            float Factor = (animationTime - (float)nodeAnim.PositionKeys[PositionIndex].Time) / DeltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Vector3D Start = nodeAnim.PositionKeys[PositionIndex].Value;
            Assimp.Vector3D End = nodeAnim.PositionKeys[NextPositionIndex].Value;
            Assimp.Vector3D Delta = End - Start;
            Out = Start + Factor * Delta;
            return Out;
        }

        private uint FindPosition(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            for (uint i = 0; i < nodeAnim.PositionKeyCount - 1; i++)
            {
                if (animationTime < (float)nodeAnim.PositionKeys[i + 1].Time)
                {
                    return i;
                }
            }

            //assert(0);

            return 0;
        }

        private Assimp.Quaternion CalcInterpolatedRotation(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Quaternion Out;
            // we need at least two values to interpolate...
            if (nodeAnim.RotationKeyCount == 1)
            {
                Out = nodeAnim.RotationKeys[0].Value;
                return Out;
            }

            uint RotationIndex = FindRotation(animationTime, nodeAnim);
            uint NextRotationIndex = (RotationIndex + 1);
            //assert(NextRotationIndex < nodeAnim.RotationKeyCount);
            float DeltaTime = (float)(nodeAnim.RotationKeys[NextRotationIndex].Time - nodeAnim.RotationKeys[RotationIndex].Time);
            float Factor = (animationTime - (float)nodeAnim.RotationKeys[RotationIndex].Time) / DeltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Quaternion StartRotationQ = nodeAnim.RotationKeys[RotationIndex].Value;
            Assimp.Quaternion EndRotationQ = nodeAnim.RotationKeys[NextRotationIndex].Value;
            Out = Interpolate(StartRotationQ, EndRotationQ, Factor);
            Out.Normalize();
            return Out;
        }

        private uint FindRotation(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            //assert(pNodeAnim->mNumRotationKeys > 0);

            for (uint i = 0; i < nodeAnim.RotationKeyCount - 1; i++)
            {
                if (animationTime < (float)nodeAnim.RotationKeys[i + 1].Time)
                {
                    return i;
                }
            }

            //assert(0);

            return 0;
        }

        private Assimp.Quaternion Interpolate(Assimp.Quaternion pStart, Assimp.Quaternion pEnd, float pFactor)
        {
            Assimp.Quaternion pOut;
            // calc cosine theta
            float cosom = pStart.X * pEnd.X + pStart.Y * pEnd.Y + pStart.Z * pEnd.Z + pStart.W * pEnd.W;

            // adjust signs (if necessary)
            Assimp.Quaternion end = pEnd;
            if (cosom < 0.0f)
            {
                cosom = -cosom;
                end.X = -end.X;   // Reverse all signs
                end.Y = -end.Y;
                end.Z = -end.Z;
                end.W = -end.W;
            }

            // Calculate coefficients
            float sclp, sclq;
            if (((1.0f) - cosom) > (0.0001f)) // 0.0001 -> some epsillon
            {
                // Standard case (slerp)
                float omega, sinom;
                omega = (float)Math.Acos(cosom); // extract theta from dot product's cos theta
                sinom = (float)Math.Sin(omega);
                sclp = (float)Math.Sin(((1.0f) - pFactor) * omega) / sinom;
                sclq = (float)Math.Sin(pFactor * omega) / sinom;
            }
            else
            {
                // Very close, do linear interp (because it's faster)
                sclp = (1.0f) - pFactor;
                sclq = pFactor;
            }

            pOut.X = sclp * pStart.X + sclq * end.X;
            pOut.Y = sclp * pStart.Y + sclq * end.Y;
            pOut.Z = sclp * pStart.Z + sclq * end.Z;
            pOut.W = sclp * pStart.W + sclq * end.W;

            return pOut;
        }

        private Assimp.Vector3D CalcInterpolatedScaling(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Vector3D Out;
            if (nodeAnim.ScalingKeyCount == 1)
            {
                Out = nodeAnim.ScalingKeys[0].Value;
                return Out;
            }

            uint ScalingIndex = FindScaling(animationTime, nodeAnim);
            uint NextScalingIndex = (ScalingIndex + 1);
            //assert(NextScalingIndex < nodeAnim->mNumScalingKeys);
            float DeltaTime = (float)(nodeAnim.ScalingKeys[NextScalingIndex].Time - nodeAnim.ScalingKeys[ScalingIndex].Time);
            float Factor = (animationTime - (float)nodeAnim.ScalingKeys[ScalingIndex].Time) / DeltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Vector3D Start = nodeAnim.ScalingKeys[ScalingIndex].Value;
            Assimp.Vector3D End = nodeAnim.ScalingKeys[NextScalingIndex].Value;
            Assimp.Vector3D Delta = End - Start;
            Out = Start + Factor * Delta;
            return Out;
        }

        private uint FindScaling(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            //assert(pNodeAnim->mNumScalingKeys > 0);

            for (uint i = 0; i < nodeAnim.ScalingKeyCount - 1; i++)
            {
                if (animationTime < (float)nodeAnim.ScalingKeys[i + 1].Time)
                {
                    return i;
                }
            }

            //assert(0);

            return 0;
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
            else if (strNormal == bufferName)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = this.mesh.Normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else if (strTexCoord == bufferName)
            {
                if (this.texCoordBuffer == null)
                {
                    Assimp.Vector3D[] texCoords = this.mesh.GetTextureCoords(0);
                    if (texCoords == null)
                    {
                        texCoords = new Assimp.Vector3D[this.mesh.VertexCount];
                        for (int i = 0; i < texCoords.Length; i++)
                        {
                            texCoords[i] = new Assimp.Vector3D(-1, -1, -1);
                        }
                    }
                    this.texCoordBuffer = texCoords.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
