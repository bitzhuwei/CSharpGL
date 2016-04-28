using CSharpGL;
using CSharpGL.Models;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ModelAdapters
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class SphereModelConverter : IBufferable
    {

        private SphereModel model;

        public SphereModelConverter(SphereModel model)
        {
            this.model = model;
        }

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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.positions.Length; i++)
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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.colors.Length; i++)
                            {
                                array[i] = model.colors[i];
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
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.normals.Length; i++)
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
                if (model.indexes.Length < byte.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer<byte>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (byte*)buffer.FirstElement();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                indexArray[i] = (byte)model.indexes[i];
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
                else if (model.indexes.Length < ushort.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer<ushort>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (ushort*)buffer.FirstElement();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                indexArray[i] = (ushort)model.indexes[i];
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
                else
                {
                    using (var buffer = new OneIndexBuffer<uint>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (uint*)buffer.FirstElement();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                indexArray[i] = model.indexes[i];
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
            }

            return indexBufferPtr;
        }
        IndexBufferPtr indexBufferPtr = null;
    }

}
