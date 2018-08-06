using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HighlightGeometryModel : IBufferSource
    {
        private static readonly vec3[] array = new vec3[4];

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCommand;

        static HighlightGeometryModel()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new vec3(1, 1, 1);
            }
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName) // requiring position buffer.
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.LineLoop, array.Length);
            }

            yield return this.drawCommand;
        }

        #endregion

    }
}
