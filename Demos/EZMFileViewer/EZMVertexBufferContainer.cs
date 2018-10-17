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
        public EZMVertexBufferContainer(EZMMesh ezmMesh)
        {
            this.ezmMesh = ezmMesh;
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

        public mat4[] BoneMatrixes
        {
            get
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
                            result[i] = bones[i].AbsBoneMat;
                        }
                    }
                }
                return result;
            }
        }

        private VertexBuffer positionBuffer;
        private VertexBuffer normalBuffer;
        private VertexBuffer uvBuffer;
        private VertexBuffer blendWeightsBuffer;
        private VertexBuffer blendIndicesBuffer;

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == EZMTextureModel.strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.ezmMesh.Vertexbuffer.Buffers[0].array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
