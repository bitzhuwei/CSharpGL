using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 经典的茶壶模型
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Teapot : IBufferable
    {

        public Teapot()
        {
            this.model = new TeapotModel();
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        public const string strNormal = "normal";
        private TeapotModel model;
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] positions = model.GetPositions();
                        buffer.Alloc(positions.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
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
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.Alloc(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
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
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.Alloc(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
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
                using (var buffer = new OneIndexBuffer<ushort>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    ushort[] faces = model.GetFaces();
                    buffer.Alloc(faces.Length);
                    unsafe
                    {
                        var array = (ushort*)buffer.Header.ToPointer();
                        for (int i = 0; i < faces.Length; i++)
                        {
                            array[i] = (ushort)(faces[i] - 1);
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
