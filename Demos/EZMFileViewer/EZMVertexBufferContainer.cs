using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer
{
    public class EZMVertexBufferContainer
    {
        private EZMMesh ezmMesh;
        public EZMVertexBufferContainer(EZMMesh ezmMesh, EZMAnimation animation)
        {
            this.ezmMesh = ezmMesh;
            this.animation = animation;
        }

        public int BoneCount
        {
            get
            {
                int result = 0;
                EZMSkeleton skeleton = this.ezmMesh.Skeleton;
                if (skeleton != null)
                {
                    EZMBone[] bones = skeleton.Bones;
                    if (bones != null)
                    {
                        result = bones.Length;
                    }
                }
                return result;
            }
        }

        public mat4[] DefaultBoneMatrixes()
        {
            mat4[] result = null;
            EZMSkeleton skeleton = this.ezmMesh.Skeleton;
            if (skeleton != null)
            {
                EZMBone[] bones = skeleton.Bones;
                if (bones != null)
                {
                    result = new mat4[bones.Length];
                    for (int i = 0; i < result.Length; i++)
                    {
                        //result[i] = bones[i].combinedMat * bones[i].inverseCombinedMatrix;
                        //result[i] = bones[i].combinedMat;
                        //result[i] = bones[i].OriginalState.matrix;
                        //result[i] = bones[i].state.matrix;
                        //result[i] = bones[i].inverseCombinedMatrix;
                        result[i] = mat4.identity();
                    }
                }
            }
            return result;
        }

        private bool firstRun = true;
        private DateTime lastTime;
        private double passedTime = 0;
        private int currentFrame = 0;

        public mat4[] GetBoneMatrixes()
        {
            mat4[] result = null;

            EZMAnimation animation = this.animation;
            if (animation == null)
            {
                result = DefaultBoneMatrixes();
            }
            else
            {
                if (this.firstRun)
                {
                    lastTime = DateTime.Now;
                    this.firstRun = false;
                }

                DateTime now = DateTime.Now;
                var deltaTime = now.Subtract(this.lastTime).TotalSeconds;
                float frameDuration = animation.duration / animation.FrameCount;
                if (deltaTime + passedTime > frameDuration)
                {
                    this.currentFrame = (this.currentFrame + 1) % animation.FrameCount;
                    passedTime = deltaTime - frameDuration;
                }
                this.currentFrame = 0;
                this.lastTime = now;

                result = new mat4[animation.AnimTracks.Length];
                foreach (EZMAnimTrack animTrack in animation.AnimTracks)
                {
                    EZMBoneState animState = animTrack.States[this.currentFrame];
                    EZMBone bone = animTrack.Bone;
                    bone.state = animState;
                }
                EZMBone rootBone = this.ezmMesh.Skeleton.OrderedBones[0];
                mat4 inverse = glm.inverse(rootBone.OriginalState.matrix);
                foreach (EZMBone bone in this.ezmMesh.Skeleton.OrderedBones)
                {
                    EZMBone parent = bone.Parent;
                    if (parent == null)
                    {
                        bone.combinedMat = bone.state.matrix;
                    }
                    else
                    {
                        bone.combinedMat = parent.combinedMat * bone.state.matrix;
                    }
                }
                for (int i = 0; i < result.Length; i++)
                {
                    EZMAnimTrack animTrack = animation.AnimTracks[i];
                    EZMBone bone = animTrack.Bone;
                    result[i] = bone.combinedMat * bone.offsetMat;
                }
            }

            return result;
        }

        private VertexBuffer positionBuffer;
        private VertexBuffer normalBuffer;
        private VertexBuffer uvBuffer;
        private VertexBuffer blendWeightsBuffer;
        private VertexBuffer blendIndicesBuffer;
        private EZMAnimation animation;

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == EZMTextureModel.strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.ezmMesh.Vertexbuffer.GetBuffer(bufferName).array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == EZMTextureModel.strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = this.ezmMesh.Vertexbuffer.GetBuffer(bufferName).array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else if (bufferName == EZMTextureModel.strUV)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = this.ezmMesh.Vertexbuffer.GetBuffer(bufferName).array.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.uvBuffer;
            }
            else if (bufferName == EZMTextureModel.strBlendWeights)
            {
                if (this.blendWeightsBuffer == null)
                {
                    this.blendWeightsBuffer = this.ezmMesh.Vertexbuffer.GetBuffer(bufferName).array.GenVertexBuffer(VBOConfig.Vec4, BufferUsage.StaticDraw);
                }

                yield return this.blendWeightsBuffer;
            }
            else if (bufferName == EZMTextureModel.strBlendIndices)
            {
                if (this.blendIndicesBuffer == null)
                {
                    this.blendIndicesBuffer = this.ezmMesh.Vertexbuffer.GetBuffer(bufferName).array.GenVertexBuffer(VBOConfig.IVec4, BufferUsage.StaticDraw);
                }

                yield return this.blendIndicesBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
