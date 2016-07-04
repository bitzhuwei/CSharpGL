using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{
    class RaycastModel : IBufferable
    {
        public const string strPosition = "position";
        public const string strBoundingBox = "boundingBox";
        PropertyBufferPtr positionBuffer;
        PropertyBufferPtr colorBuffer;
        // draw the six faces of the boundbox by drawwing triangles
        // draw it contra-clockwise
        // front: 1 5 7 3
        // back:  0 2 6 4
        // left： 0 1 3 2
        // right: 7 5 4 6    
        // up:    2 3 7 6
        // down:  1 0 4 5
        static readonly float[] boundingBox = 
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
        static readonly uint[] indices = 
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

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(boundingBox.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < boundingBox.Length; i++)
                            {
                                array[i] = boundingBox[i] - 0.5f;
                            }
                        }
                        positionBuffer = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBuffer;
            }
            else if (bufferName == strBoundingBox)
            {
                if (colorBuffer == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(boundingBox.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < boundingBox.Length; i++)
                            {
                                array[i] = boundingBox[i];
                            }
                        }
                        colorBuffer = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBuffer;
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
                using (var buffer = new OneIndexBuffer<uint>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Create(indices.Length);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < indices.Length; i++)
                        {
                            array[i] = indices[i];
                        }
                    }

                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        IndexBufferPtr indexBufferPtr = null;

    }
}