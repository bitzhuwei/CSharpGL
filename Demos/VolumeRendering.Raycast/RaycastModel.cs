using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolumeRendering.Raycast
{
    /// <summary>
    /// model for raycast rendering.
    /// </summary>
    internal class BoundingBoxModel : IBufferSource
    {
        public const string strPosition = "position";
        public const string strColor = "color";
        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd = null;


        // draw the six faces of the boundbox by drawing quads
        // draw it contra-clockwise
        // front: 1 5 7 3
        // back:  0 2 6 4
        // left： 0 1 3 2
        // right: 7 5 4 6
        // up:    2 3 7 6
        // down:  1 0 4 5
        private static readonly float[] positions =
        {
			0.0f, 0.0f, 0.0f,
			0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f,
			0.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 0.0f,
			1.0f, 0.0f, 1.0f,
			1.0f, 1.0f, 0.0f,
			1.0f, 1.0f, 1.0f,
        };

        private static readonly float[] colors =
        {
			0.0f, 0.0f, 0.0f,
			0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f,
			0.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 0.0f,
			1.0f, 0.0f, 1.0f,
			1.0f, 1.0f, 0.0f,
			1.0f, 1.0f, 1.0f,
        };

        private static readonly uint[] indexes =
        { 
            1, 5, 7, 3, // front
            0, 2, 6, 4, // back
            0, 1, 3, 2, // left
            7, 5, 4, 6, // right
            2, 3, 7, 6, // up
            1, 0, 4, 5, // down
        };

        static BoundingBoxModel()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = positions[i] - 0.5f;
            }
        }
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = boundingBox.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < boundingBox.Length; i++)
                    //    {
                    //        array[i] = boundingBox[i] - 0.5f;
                    //    }
                    //    buffer.UnmapBuffer();
                    //}

                    //this.positionBuffer = buffer;
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }
                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    //int length = boundingBox.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < boundingBox.Length; i++)
                    //    {
                    //        array[i] = boundingBox[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}

                    //this.colorBuffer = buffer;
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
            if (drawCmd == null)
            {
                //int length = indices.Length;
                //IndexBuffer buffer = CSharpGL.Buffer.Create(IndexElementType.UInt, length, BufferUsage.StaticDraw);
                //unsafe
                //{
                //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                //    var array = (uint*)pointer;
                //    for (int i = 0; i < indices.Length; i++)
                //    {
                //        array[i] = indices[i];
                //    }
                //    buffer.UnmapBuffer();
                //}
                IndexBuffer buffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.Quads);
            }

            yield return drawCmd;
        }

    }
}
