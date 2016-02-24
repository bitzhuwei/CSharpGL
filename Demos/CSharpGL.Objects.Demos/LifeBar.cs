using CSharpGL.Objects.Models;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    public class LifeBar : IModel
    {

        private vec3 color = new vec3(1, 0.1f, 0.1f);

        public vec3 Color
        {
            get { return color; }
            set { color = value; }
        }

        public LifeBar(float length = 0.2f, float width = 0.02f, float height = 4f)
        {
            this.Length = length;
            this.Wdith = width;
            this.Height = height;
        }

        VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new PositionBuffer(varNameInShader))
            {
                buffer.Alloc(1);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    array[0] = new vec3();
                }

                return buffer.GetRenderer();
            }
        }

        VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            throw new NotImplementedException();
        }

        VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            throw new NotImplementedException();
        }

        VertexBuffers.IndexBufferRendererBase IModel.GetIndexes()
        {
            using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, 1))
            {
                return buffer.GetRenderer() as IndexBufferRendererBase;
            }
        }

        class PositionBuffer : PropertyBuffer<vec3>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }


        public float Height { get; set; }

        public float Length { get; set; }

        public float Wdith { get; set; }
    }
}
