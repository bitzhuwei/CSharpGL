using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a string.
    /// </summary>
    public class GlyphsModel : IBufferSource
    {
        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer positionBuffer;
        /// <summary>
        /// 
        /// </summary>
        public const string STR = "str";
        private VertexBuffer uvBuffer;

        private IDrawCommand drawCmd;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public GlyphsModel(int capacity)
        {
            this.Capacity = capacity;
        }

        #region IBufferSource 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferName"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = VertexBuffer.Create(typeof(QuadPositionStruct), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == STR)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = VertexBuffer.Create(typeof(QuadSTRStruct), this.Capacity, VBOConfig.Vec3, BufferUsage.DynamicDraw);
                }

                yield return this.uvBuffer;
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
                // note: use IDrawCommand.Draw(ControlMode.Random) to enable this property.
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
}
