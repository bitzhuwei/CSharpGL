using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 一个四面体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_tetrahedron.jpg
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Tetrahedron : IBufferable
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
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();
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
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(TetrahedronModel.position.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.position.Length; i++)
                            {
                                array[i] = TetrahedronModel.position[i];
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
                        buffer.Create(TetrahedronModel.color.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.color.Length; i++)
                            {
                                array[i] = TetrahedronModel.color[i];
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
                        buffer.Create(TetrahedronModel.normal.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.normal.Length; i++)
                            {
                                array[i] = TetrahedronModel.normal[i];
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
                    buffer.Create(TetrahedronModel.index.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.Header.ToPointer();
                        for (int i = 0; i < TetrahedronModel.index.Length; i++)
                        {
                            array[i] = TetrahedronModel.index[i];
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