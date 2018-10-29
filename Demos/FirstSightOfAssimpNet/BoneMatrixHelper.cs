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
        public static mat4[] GetBoneMatrixes(this Assimp.Scene aiScene, float TimeInSeconds, AllBones allBones)
        {
            if (!aiScene.HasAnimations) { return null; }
            double ticksPerSecond = aiScene.Animations[0].TicksPerSecond;
            if (ticksPerSecond == 0) { ticksPerSecond = 25.0; }
            double timeInTicks = TimeInSeconds * ticksPerSecond;
            float animationTime = (float)(timeInTicks % aiScene.Animations[0].DurationInTicks);

            Assimp.Matrix4x4 transform = aiScene.RootNode.Transform;
            transform.Inverse();
            ReadNodeHeirarchy(animationTime, aiScene.RootNode, aiScene.Animations[0], transform.ToMat4(), allBones);

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
                Assimp.Vector3D scaling = CalcInterpolatedScaling(animationTime, nodeAnim);
                mat4 scalingMat = glm.scale(mat, new vec3(scaling.X, scaling.Y, scaling.Z));

                // Interpolate rotation and generate rotation transformation matrix
                Assimp.Quaternion rotation = CalcInterpolatedRotation(animationTime, nodeAnim);
                mat4 rotationMat = new Assimp.Matrix4x4(rotation.GetMatrix()).ToMat4();

                // Interpolate translation and generate translation transformation matrix
                Assimp.Vector3D translation = CalcInterpolatedPosition(animationTime, nodeAnim);
                mat4 translationMat = glm.translate(mat4.identity(), new vec3(translation.X, translation.Y, translation.Z));

                // Combine the above transformations
                nodeTransform = translationMat * rotationMat * scalingMat;
            }

            mat4 globalTransformation = parentTransform * nodeTransform;

            if (allBones.nameIndexDict.ContainsKey(nodeName))
            {
                uint BoneIndex = allBones.nameIndexDict[nodeName];
                allBones.boneInfos[BoneIndex].FinalTransformation = globalTransformation * allBones.boneInfos[BoneIndex].Bone.OffsetMatrix.ToMat4();
            }

            for (int i = 0; i < node.ChildCount; i++)
            {
                ReadNodeHeirarchy(animationTime, node.Children[i], animation, globalTransformation, allBones);
            }
        }

        private static Assimp.Vector3D CalcInterpolatedPosition(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Vector3D result;
            if (nodeAnim.PositionKeyCount == 1)
            {
                result = nodeAnim.PositionKeys[0].Value;
                return result;
            }

            uint index = FindPosition(animationTime, nodeAnim);
            uint nextIndex = (index + 1);
            //assert(NextPositionIndex < nodeAnim->mNumPositionKeys);
            float deltaTime = (float)(nodeAnim.PositionKeys[nextIndex].Time - nodeAnim.PositionKeys[index].Time);
            float factor = (animationTime - (float)nodeAnim.PositionKeys[index].Time) / deltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Vector3D start = nodeAnim.PositionKeys[index].Value;
            Assimp.Vector3D end = nodeAnim.PositionKeys[nextIndex].Value;
            Assimp.Vector3D delta = end - start;
            result = start + factor * delta;
            return result;
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

            return 0;
        }

        private static Assimp.Quaternion CalcInterpolatedRotation(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Quaternion result;
            // we need at least two values to interpolate...
            if (nodeAnim.RotationKeyCount == 1)
            {
                result = nodeAnim.RotationKeys[0].Value;
                return result;
            }

            uint index = FindRotation(animationTime, nodeAnim);
            uint nextIndex = (index + 1);
            //assert(NextRotationIndex < nodeAnim.RotationKeyCount);
            float deltaTime = (float)(nodeAnim.RotationKeys[nextIndex].Time - nodeAnim.RotationKeys[index].Time);
            float factor = (animationTime - (float)nodeAnim.RotationKeys[index].Time) / deltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Quaternion start = nodeAnim.RotationKeys[index].Value;
            Assimp.Quaternion end = nodeAnim.RotationKeys[nextIndex].Value;
            result = Interpolate(start, end, factor);
            result.Normalize();
            return result;
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

        private static Assimp.Quaternion Interpolate(Assimp.Quaternion start, Assimp.Quaternion end, float factor)
        {
            Assimp.Quaternion result;
            // calc cosine theta
            float cosom = start.X * end.X + start.Y * end.Y + start.Z * end.Z + start.W * end.W;

            // adjust signs (if necessary)
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
                sclp = (float)Math.Sin(((1.0f) - factor) * omega) / sinom;
                sclq = (float)Math.Sin(factor * omega) / sinom;
            }
            else
            {
                // Very close, do linear interp (because it's faster)
                sclp = (1.0f) - factor;
                sclq = factor;
            }

            result.X = sclp * start.X + sclq * end.X;
            result.Y = sclp * start.Y + sclq * end.Y;
            result.Z = sclp * start.Z + sclq * end.Z;
            result.W = sclp * start.W + sclq * end.W;

            return result;
        }

        private static Assimp.Vector3D CalcInterpolatedScaling(float animationTime, Assimp.NodeAnimationChannel nodeAnim)
        {
            Assimp.Vector3D result;
            if (nodeAnim.ScalingKeyCount == 1)
            {
                result = nodeAnim.ScalingKeys[0].Value;
                return result;
            }

            uint index = FindScaling(animationTime, nodeAnim);
            uint nextIndex = (index + 1);
            //assert(NextScalingIndex < nodeAnim->mNumScalingKeys);
            float deltaTime = (float)(nodeAnim.ScalingKeys[nextIndex].Time - nodeAnim.ScalingKeys[index].Time);
            float factor = (animationTime - (float)nodeAnim.ScalingKeys[index].Time) / deltaTime;
            //assert(Factor >= 0.0f && Factor <= 1.0f);
            Assimp.Vector3D start = nodeAnim.ScalingKeys[index].Value;
            Assimp.Vector3D end = nodeAnim.ScalingKeys[nextIndex].Value;
            Assimp.Vector3D delta = end - start;
            result = start + factor * delta;
            return result;
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
