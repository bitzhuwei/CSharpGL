using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Cube.
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_CubeModel.jpg
    /// <para>Uses <see cref="OneIndexBuffer&lt;T&gt;"/></para>
    /// </summary>
    public class Cube : IBufferable
    {

        /// <summary>
        /// 
        /// </summary>
        public const string strPosition = "position";
        /// <summary>
        /// 
        /// </summary>
        public const string strColor = "color";
        /// <summary>
        /// 
        /// </summary>
        public const string strNormal = "normal";

        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr colorBufferPtr;
        private PropertyBufferPtr normalBufferPtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubePosition>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(1);
                        unsafe
                        {
                            var positionArray = (CubeModel.CubePosition*)buffer.Header.ToPointer();
                            positionArray[0] = CubeModel.position;

                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubeColor>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(1);
                        unsafe
                        {
                            var colorArray = (CubeModel.CubeColor*)buffer.Header.ToPointer();
                            colorArray[0] = CubeModel.color;
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubeNormal>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(1);
                        unsafe
                        {
                            var normalArray = (CubeModel.CubeNormal*)buffer.Header.ToPointer();
                            normalArray[0] = CubeModel.normal;
                        }

                        normalBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return normalBufferPtr;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer<byte>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Create(CubeModel.index.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.Header.ToPointer();
                        for (int i = 0; i < CubeModel.index.Length; i++)
                        {
                            array[i] = CubeModel.index[i];
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