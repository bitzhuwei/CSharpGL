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
    /// 一个立方体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000061.jpg
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000062.jpg
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class CubeModelAdapter : IBufferable
    {

        private CubeModel model;

        public CubeModelAdapter(CubeModel model)
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
                using (var positionBuffer = new PropertyBuffer<CubeModel.CubePosition>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    positionBuffer.Alloc(1);
                    unsafe
                    {
                        var positionArray = (CubeModel.CubePosition*)positionBuffer.FirstElement();
                        positionArray[0] = this.model.position;

                    }

                    return positionBuffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strColor)
            {
                using (var colorBuffer = new PropertyBuffer<CubeModel.CubeColor>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    colorBuffer.Alloc(1);
                    unsafe
                    {
                        var colorArray = (CubeModel.CubeColor*)colorBuffer.FirstElement();
                        colorArray[0] = this.model.color;
                    }

                    return colorBuffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strNormal)
            {
                using (var normalBuffer = new PropertyBuffer<CubeModel.CubeNormal>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    normalBuffer.Alloc(1);
                    unsafe
                    {
                        var normalArray = (CubeModel.CubeNormal*)normalBuffer.FirstElement();
                        normalArray[0] = this.model.normal;
                    }

                    return normalBuffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndex()
        {
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Triangles, BufferUsage.StaticDraw))
            {
                buffer.Alloc(this.model.index.Length);
                unsafe
                {
                    uint* array = (uint*)buffer.FirstElement();
                    for (int i = 0; i < this.model.index.Length; i++)
                    {
                        array[i] = this.model.index[i];
                    }
                }

                return buffer.GetBufferPtr() as IndexBufferPtr;
            }
        }
    }
}