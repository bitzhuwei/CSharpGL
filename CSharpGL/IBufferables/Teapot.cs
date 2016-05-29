using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 经典的茶壶模型
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Teapot : IBufferable
    {

        public Teapot(float radius = 1.0f)
        {
            this.model = TeapotModel.GetModel(radius);
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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.positions.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.positions.Count; i++)
                            {
                                array[i] = model.positions[i];
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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.normals.Count; i++)
                            {
                                array[i] = model.normals[i];
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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.normals.Count; i++)
                            {
                                array[i] = model.normals[i];
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
                    buffer.Alloc(model.faces.Count * 3);
                    unsafe
                    {
                        var array = (ushort*)buffer.Header.ToPointer();
                        for (int i = 0; i < model.faces.Count; i++)
                        {
                            array[i * 3 + 0] = (ushort)(model.faces[i].Item1 - 1);
                            array[i * 3 + 1] = (ushort)(model.faces[i].Item2 - 1);
                            array[i * 3 + 2] = (ushort)(model.faces[i].Item3 - 1);
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
