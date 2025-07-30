using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;

namespace ComputeShader.HelloComputeShader {
    class SimpleCompute : IBufferSource {
        private static readonly vec3[] vertsData = new vec3[]
        {
            new vec3(-1.0f, -1.0f, 0.5f),
            new vec3(1.0f, -1.0f, 0.5f),
            new vec3(1.0f,  1.0f, 0.5f),
            new vec3(-1.0f,  1.0f, 0.5f),
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer = null;
        private IDrawCommand drawCmd;

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    //var buffer = VertexBuffer.Create(typeof(vec3), vertsData.Length, VBOConfig.Vec3, varNameInShader, GLBuffer.BufferUsage.StaticDraw);
                    //unsafe
                    //{
                    //    var array = (vec3*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    for (int i = 0; i < vertsData.Length; i++)
                    //    {
                    //        array[i] = vertsData[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}

                    //positionBuffer = buffer;
                    this.positionBuffer = vertsData.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (drawCmd == null) {
                drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.TriangleFan, vertsData.Length);
            }

            yield return drawCmd;
        }
    }
}
