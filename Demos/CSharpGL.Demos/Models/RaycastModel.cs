using System;
namespace CSharpGL.Demos
{
    internal class RaycastModel : IBufferable
    {
        public const string strposition = "position";
        public const string strcolor = "color";
        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;

        // draw the six faces of the boundbox by drawwing triangles
        // draw it contra-clockwise
        // front: 1 5 7 3
        // back:  0 2 6 4
        // left： 0 1 3 2
        // right: 7 5 4 6
        // up:    2 3 7 6
        // down:  1 0 4 5
        private static readonly float[] boundingBox =
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

        private static readonly float[] boundingBoxColor =
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

        private static readonly uint[] indices =
        {
			1,5,7,
			7,3,1,
			0,2,6,
			6,4,0,
			0,1,3,
			3,2,0,
			7,5,4,
			4,6,7,
			2,3,7,
			7,6,2,
			1,0,4,
			4,5,1,
        };

        static RaycastModel()
        {
            for (int i = 0; i < boundingBox.Length; i++)
            {
                boundingBox[i] = boundingBox[i] - 0.5f;
            }
        }
        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strposition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = boundingBox.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBuffer = boundingBox.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else if (bufferName == strcolor)
            {
                if (this.colorBuffer == null)
                {
                    //int length = boundingBox.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.colorBuffer = boundingBoxColor.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.colorBuffer;
            }
            else
            {
                return null;
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (indexBuffer == null)
            {
                //int length = indices.Length;
                //OneIndexBuffer buffer = CSharpGL.Buffer.Create(IndexElementType.UInt, length, DrawMode.Triangles, BufferUsage.StaticDraw);
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
                //this.indexBuffer = buffer;
                this.indexBuffer = indices.GenIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
            }

            return indexBuffer;
        }

        private IndexBuffer indexBuffer = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}