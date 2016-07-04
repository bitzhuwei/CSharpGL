using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Sphere : IBufferable
    {

        private SphereModel model;

        /// <summary>
        /// 一个球体的模型。
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="latitudeParts">用纬线把地球切割为几块。</param>
        /// <param name="longitudeParts">用经线把地球切割为几块。</param>
        /// <param name="colorGenerator"></param>
        public Sphere(float radius = 1.0f, int latitudeParts = 10, int longitudeParts = 40)
        {
            this.model = new SphereModel(radius, latitudeParts, longitudeParts);
        }

        public const string strPosition = "position";
        public const string strNormal = "normal";
        public const string strColor = "color";
        public const string strUV = "uv";
        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr normalBufferPtr;
        private PropertyBufferPtr colorBufferPtr;
        private PropertyBufferPtr uvBufferPtr;
        private IndexBufferPtr indexBufferPtr = null;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.positions.Length; i++)
                            {
                                array[i] = model.positions[i];
                            }
                        }
                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
                else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.normals.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.normals.Length; i++)
                            {
                                array[i] = model.normals[i];
                            }
                        }
                        normalBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return normalBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.colors.Length; i++)
                            {
                                array[i] = model.colors[i];
                            }
                        }
                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strUV)
            {
                if (uvBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec2>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.uv.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.uv.Length; i++)
                            {
                                array[i] = model.uv[i];
                            }
                        }
                        uvBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return uvBufferPtr;
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
                if (model.positions.Length < byte.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer<byte>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (byte*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                if (model.indexes[i] == uint.MaxValue)
                                { indexArray[i] = byte.MaxValue; }
                                else
                                { indexArray[i] = (byte)model.indexes[i]; }
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
                else if (model.positions.Length < ushort.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer<ushort>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (ushort*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                if (model.indexes[i] == uint.MaxValue)
                                { indexArray[i] = ushort.MaxValue; }
                                else
                                { indexArray[i] = (ushort)model.indexes[i]; }
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
                else
                {
                    using (var buffer = new OneIndexBuffer<uint>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (uint*)buffer.Header.ToPointer();
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
    }

}
