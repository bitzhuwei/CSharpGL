using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c09d00_FullScreenQuad
{
    class FullScreenModel : IBufferSource
    {
        private const int clipSpaceLength = 1;
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(clipSpaceLength, clipSpaceLength, 0),
            new vec3(-clipSpaceLength, clipSpaceLength, 0),
            new vec3(-clipSpaceLength, -clipSpaceLength, 0),
            new vec3(clipSpaceLength, -clipSpaceLength, 0),
        };
        private static readonly vec2[] uvs = new vec2[] 
        {
            new vec2(1, 1),
            new vec2(0, 1),
            new vec2(0, 0),
            new vec2(1, 0),
        };

        private vec3 size;
        public vec3 GetSize()
        {
            return this.size;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strUV == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
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
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

    }
}
