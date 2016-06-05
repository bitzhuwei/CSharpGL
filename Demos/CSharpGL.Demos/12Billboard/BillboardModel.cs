using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class BillboardModel : IBufferable
    {
        public const string strPosition = "position";
        PropertyBufferPtr positionBuffer;
        static readonly float[] positions = 
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
                    {
                        buffer.Alloc(positions.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
                        }
                        positionBuffer = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBuffer;
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleStrip, 0, 4))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        IndexBufferPtr indexBufferPtr = null;

    }
}