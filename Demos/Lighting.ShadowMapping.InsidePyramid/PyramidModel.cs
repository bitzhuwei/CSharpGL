using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid
{
    class PyramidModel : IBufferSource
    {
        public readonly vec3 size = new vec3(2, 1, 2);
        private static readonly vec3[] positions = new vec3[] { new vec3(0, 0, 0), new vec3(1, -1, 1), new vec3(1, -1, -1), new vec3(-1, -1, -1), new vec3(-1, -1, 1), new vec3(0, -1, 0) };

        ///// <summary>
        ///// indexes in GL_LINES
        ///// </summary>
        //private static readonly byte[] indexes = new byte[] { 0, 1, 0, 2, 0, 3, 0, 4, 1, 2, 2, 3, 3, 4, 4, 1, 1, 3, 2, 4, };
        /// <summary>
        /// indexes in GL_TRIANGLES
        /// </summary>
        private static readonly byte[] indexes = new byte[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1, 1, 1, 5, 2, 2, 5, 3, 3, 5, 4, 4, 5, 1 };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand command;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new Exception(string.Format("Not expected buffer name: {0}", bufferName));
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.command == null)
            {
                var indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.command = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.command;
        }

        #endregion
    }
}
