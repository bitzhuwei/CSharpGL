using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFieldFont
{
    public partial class SingleLineModel : IBufferSource
    {
        /// <summary>
        /// 
        /// </summary>
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        /// <summary>
        /// 
        /// </summary>
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;

        private DrawArraysCmd drawCmd;
        private GlyphServer glyphServer;

        public GlyphServer GetGlyphServer()
        {
            return this.glyphServer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="glyphServer"></param>
        public SingleLineModel(int capacity, GlyphServer glyphServer)
        {
            this.Capacity = capacity;
            this.glyphServer = glyphServer;
        }

        #region IBufferSource 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferName"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = VertexBuffer.Create(typeof(GlyphPosition), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = VertexBuffer.Create(typeof(GlyphTexCoord), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                yield return this.texCoordBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                var drawCmd = new DrawArraysCmd(DrawMode.Quads, this.Capacity * 4);
                drawCmd.VertexCount = 0;
                this.drawCmd = drawCmd;
            }

            yield return this.drawCmd;
        }

        #endregion

        /// <summary>
        /// Maximum number of characters.
        /// </summary>
        public int Capacity { get; private set; }
    }

    public struct GlyphPosition
    {
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftTop;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightTop;

        /// <summary>
        /// A quad(u, v) renders in GL_QUADS mode.
        /// (u, v) is texture coordinate of this quad in the glyph map.
        /// </summary>
        /// <param name="leftTop">between [0, 0] and [1, 1].</param>
        /// <param name="leftBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightTop">between [0, 0] and [1, 1].</param>
        public GlyphPosition(vec2 leftTop, vec2 leftBottom, vec2 rightBottom, vec2 rightTop)
        {
            this.leftTop = leftTop; this.rightTop = rightTop;
            this.leftBottom = leftBottom; this.rightBottom = rightBottom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("leftTop:{0}, leftBotttom:{1}, rightBottom:{2}, rightTop:{3}",
                this.leftTop, this.leftBottom, this.rightBottom, this.rightTop);
        }
    }

    public struct GlyphTexCoord
    {
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftTop;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightTop;

        /// <summary>
        /// A quad(u, v) renders in GL_QUADS mode.
        /// (u, v) is texture coordinate of this quad in the glyph map.
        /// </summary>
        /// <param name="leftTop">between [0, 0] and [1, 1].</param>
        /// <param name="leftBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightTop">between [0, 0] and [1, 1].</param>
        public GlyphTexCoord(vec2 leftTop, vec2 leftBottom, vec2 rightBottom, vec2 rightTop)
        {
            this.leftTop = leftTop; this.rightTop = rightTop;
            this.leftBottom = leftBottom; this.rightBottom = rightBottom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("leftTop:{0}, leftBotttom:{1}, rightBottom:{2}, rightTop:{3}",
                this.leftTop, this.leftBottom, this.rightBottom, this.rightTop);
        }
    }
}
