using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// bounding box.
    /// </summary>
    class BoundingBox : IBufferable
    {

        private vec3[] positions = new vec3[] 
        { 
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
            new vec3(1, 1, -1),  new vec3(-1, 1, -1),
            new vec3(1, -1, -1), new vec3(-1, -1, -1),
            new vec3(1, -1, 1),  new vec3(-1, -1, 1),
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
        };

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.QuadStrip, 0, positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

    }
}
