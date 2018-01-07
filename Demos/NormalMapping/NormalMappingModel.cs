using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    //
    // 0-----------3
    // |           |
    // |           |
    // |           |
    // |           |
    // |           |
    // 1-----------2
    //
    /// <summary>
    /// 
    /// </summary>
    class NormalMappingModel : IBufferSource
    {
        private static readonly vec3[] positionArray = new vec3[] 
        { 
            new vec3(-1, +1, 0), 
            new vec3(-1, -1, 0), 
            new vec3(+1, -1, 0), 
            new vec3(+1, +1, 0) 
        };
        private static readonly vec2[] texCoordArray = new vec2[] 
        { 
            new vec2(0, 1), 
            new vec2(0, 0), 
            new vec2(1, 0), 
            new vec2(1, 1) 
        };
        private static readonly vec3[] normalArray = new vec3[] 
        { 
            new vec3(0, 0, 1), 
            new vec3(0, 0, 1), 
            new vec3(0, 0, 1), 
            new vec3(0, 0, 1)
        };
        private static readonly vec3[] tangentArray = new vec3[] 
        { 
            new vec3(1, 0, 0),
            new vec3(1, 0, 0),
            new vec3(1, 0, 0),
            new vec3(1, 0, 0)
        };
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;
        public const string strTangent = "tangent";
        private VertexBuffer tangentBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positionArray.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = texCoordArray.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = normalArray.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else if (bufferName == strTangent)
            {
                if (this.tangentBuffer == null)
                {
                    this.tangentBuffer = tangentArray.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.tangentBuffer;
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
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, 0, 4);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
