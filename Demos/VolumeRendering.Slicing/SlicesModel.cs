using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace VolumeRendering.Slicing
{
    class SlicesModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer slicesBuffer;

        private IDrawCommand drawCmd;

        const int MAX_SLICES = 512;
        private vec3[] vTextureSlices = new vec3[MAX_SLICES * 12];


        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.slicesBuffer == null)
                {
                    this.slicesBuffer = this.vTextureSlices.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicDraw);
                }

                yield return this.slicesBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Triangles, this.vTextureSlices.Length);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
