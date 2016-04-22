using CSharpGL;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// </summary>
    public class SphereModelAdapter : IBufferable
    {

        private SphereModel model;

        public SphereModelAdapter(SphereModel model)
        {
            this.model = model;
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        public const string strNormal = "normal";

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strColor)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strNormal)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else
            {
                return null;
            }

        }

        public IndexBufferPtr GetIndex()
        {

            using (var indexBuffer = new OneIndexBuffer<uint>(DrawMode.TriangleStrip, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(model.indexes.Length);
                unsafe
                {
                    uint* indexArray = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < model.indexes.Length; i++)
                    {
                        indexArray[i] = model.indexes[i];
                    }
                }

                return indexBuffer.GetBufferPtr() as IndexBufferPtr;
            }
        }
    }

}
