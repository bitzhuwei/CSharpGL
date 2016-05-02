using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 一个立方体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_CubeModel.jpg
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Cube : IBufferable
    {

        public const string strPosition = "position";
        public const string strColor = "color";
        public const string strNormal = "normal";
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubePosition>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(1);
                        unsafe
                        {
                            var positionArray = (CubeModel.CubePosition*)buffer.FirstElement();
                            positionArray[0] = CubeModel.position;

                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == strColor)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubeColor>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(1);
                        unsafe
                        {
                            var colorArray = (CubeModel.CubeColor*)buffer.FirstElement();
                            colorArray[0] = CubeModel.color;
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == strNormal)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<CubeModel.CubeNormal>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(1);
                        unsafe
                        {
                            var normalArray = (CubeModel.CubeNormal*)buffer.FirstElement();
                            normalArray[0] = CubeModel.normal;
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
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
                using (var buffer = new OneIndexBuffer<byte>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Alloc(CubeModel.index.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.FirstElement();
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