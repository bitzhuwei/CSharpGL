using CSharpGL.Objects.Models;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Common
{
    /// <summary>
    /// 用网格描述的地面
    /// </summary>
    public class Ground : IModel
    {
        private unsafe vec3[] positionArray;

        public vec3 lineColor = new vec3(1, 1, 1);

        /// <summary>
        /// 用网格描述的地面
        /// </summary>
        /// <param name="xCount">x正半轴上有多少条线</param>
        /// <param name="zCount">z正半轴上有多少条线</param>
        /// <param name="xInterval">x轴上线之间的间隔</param>
        /// <param name="zInterval">z轴上线之间的间隔</param>
        public Ground(int xCount = 100, int zCount = 100, float xInterval = 1.0f, float zInterval = 1.0f)
        {
            this.positionArray = new vec3[xCount * 4 + zCount * 4];
            int index = 0;
            for (int i = 0; i < xCount; i++)
            {
                this.positionArray[index++] = new vec3(xInterval / 2 + i * xInterval, 0, zInterval / 2 + zCount * zInterval);
                this.positionArray[index++] = new vec3(xInterval / 2 + i * xInterval, 0, -(zInterval / 2 + zCount * zInterval));
            }
            for (int i = 0; i < xCount; i++)
            {
                this.positionArray[index++] = new vec3(-(xInterval / 2 + i * xInterval), 0, zInterval / 2 + zCount * zInterval);
                this.positionArray[index++] = new vec3(-(xInterval / 2 + i * xInterval), 0, -(zInterval / 2 + zCount * zInterval));
            }

            for (int i = 0; i < zCount; i++)
            {
                this.positionArray[index++] = new vec3(xInterval / 2 + xCount * xInterval, 0, zInterval / 2 + i * zInterval);
                this.positionArray[index++] = new vec3(-(xInterval / 2 + xCount * xInterval), 0, zInterval / 2 + i * zInterval);
            }
            for (int i = 0; i < zCount; i++)
            {
                this.positionArray[index++] = new vec3(xInterval / 2 + xCount * xInterval, 0, -(zInterval / 2 + i * zInterval));
                this.positionArray[index++] = new vec3(-(xInterval / 2 + xCount * xInterval), 0, -(zInterval / 2 + i * zInterval));
            }
        }

        VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new PositionBuffer(varNameInShader))
            {
                buffer.Alloc(positionArray.Length);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < positionArray.Length; i++)
                    {
                        array[i] = positionArray[i];
                    }
                }
                return buffer.GetRenderer();
            }
        }

        VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            return null;
        }

        VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            return null;
        }

        VertexBuffers.IndexBufferRendererBase IModel.GetIndexes()
        {
            using (var buffer = new ZeroIndexBuffer(DrawMode.Lines, 0, positionArray.Length))
            {
                return buffer.GetRenderer() as IndexBufferRendererBase;
            }
        }

        class PositionBuffer : PropertyBuffer<vec3>
        {
            public PositionBuffer(string varNameInGLSL)
                : base(varNameInGLSL, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }
    }
}
