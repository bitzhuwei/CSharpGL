using System;
namespace CSharpGL.Demos
{
    internal class RaycastModel : IBufferable
    {
        public const string strposition = "position";
        public const string strcolor = "color";
        private VertexAttributeBufferPtr positionBuffer;
        private VertexAttributeBufferPtr colorBuffer;

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

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strposition)
            {
                if (this.positionBuffer == null)
                {
                    int length = boundingBox.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < boundingBox.Length; i++)
                        {
                            array[i] = boundingBox[i] - 0.5f;
                        }
                        bufferPtr.UnmapBuffer();
                    }

                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strcolor)
            {
                if (this.colorBuffer == null)
                {
                    int length = boundingBox.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < boundingBox.Length; i++)
                        {
                            array[i] = boundingBox[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }

                    this.colorBuffer = bufferPtr;
                }
                return this.colorBuffer;
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                int length = indices.Length;
                OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UInt, length);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    for (int i = 0; i < indices.Length; i++)
                    {
                        array[i] = indices[i];
                    }
                    bufferPtr.UnmapBuffer();
                }
                this.indexBufferPtr = bufferPtr;
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}