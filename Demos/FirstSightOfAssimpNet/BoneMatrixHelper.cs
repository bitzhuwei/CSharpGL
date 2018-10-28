using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    public static class BoneMatrixHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aiScene"></param>
        /// <param name="TimeInSeconds"></param>
        /// <returns></returns>
        public static mat4[] GetBoneMatrixes(this Assimp.Scene aiScene, float TimeInSeconds, mat4 globalInverseTransform, AllBones allBones)
        {
            if (aiScene.AnimationCount <= 0) { return null; }
            double ticksPerSecond = aiScene.Animations[0].TicksPerSecond;
            if (ticksPerSecond == 0) { ticksPerSecond = 25.0; }
            double timeInTicks = TimeInSeconds * ticksPerSecond;
            float animationTime = (float)(timeInTicks % aiScene.Animations[0].DurationInTicks);

            ReadNodeHeirarchy(animationTime, aiScene.RootNode, aiScene.Animations[0], globalInverseTransform, allBones);

            int boneCount = allBones.boneInfos.Length;
            var result = new mat4[boneCount];

            for (int i = 0; i < boneCount; i++)
            {
                result[i] = allBones.boneInfos[i].FinalTransformation;
            }

            return result;
        }

        private static void ReadNodeHeirarchy(float animationTime, Assimp.Node node, Assimp.Animation animation, mat4 parentTransform, AllBones allBones)
        {
            string nodeName = node.Name;
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
                allBones.boneInfos[BoneIndex].FinalTransformation = GlobalTransformation * allBones.boneInfos[BoneIndex].Bone.OffsetMatrix.ToMat4();
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ReadNodeHeirarchy(animationTime, node.Children[i], animation, GlobalTransformation, allBones);
            }
        }

        private static Assimp.Vector3D CalcInterpolatedPosition(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static uint FindPosition(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static Assimp.Quaternion CalcInterpolatedRotation(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static uint FindRotation(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static Assimp.Quaternion Interpolate(Assimp.Quaternion pStart, Assimp.Quaternion pEnd, float pFactor)
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

        private static Assimp.Vector3D CalcInterpolatedScaling(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static uint FindScaling(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
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

        private static Assimp.NodeAnimationChannel FineNodeAnim(Assimp.Animation animation, string nodeName)
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
    }
}
