using CSharpGL;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpGL
{
    class PyramidModelAdapter : CSharpGL.Objects.Models.IModel
    {
        private PyramidModel model;

        public PyramidModelAdapter(PyramidModel model)
        {
            this.model = model;
        }

        public CSharpGL.Objects.VertexBuffers.BufferRenderer GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new PositionBuffer(varNameInShader))
            {
                vec3[] positions = this.model.positions;
                buffer.Alloc(positions.Length);
                unsafe
                {
                    vec3* header = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        header[i] = positions[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public CSharpGL.Objects.VertexBuffers.BufferRenderer GetColorBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ColorBuffer(varNameInShader))
            {
                vec3[] colors = this.model.colors;
                buffer.Alloc(colors.Length);
                unsafe
                {
                    vec3* header = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < colors.Length; i++)
                    {
                        header[i] = colors[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public CSharpGL.Objects.VertexBuffers.BufferRenderer GetIndexes()
        {
            using (var buffer = new ZeroIndexBuffer(DrawMode.Triangles, 0, this.model.positions.Length))
            {
                return buffer.GetRenderer();
            }
        }

        public CSharpGL.Objects.VertexBuffers.BufferRenderer GetNormalBufferRenderer(string varNameInShader)
        {
            return null;
        }


        class PositionBuffer : CSharpGL.Objects.VertexBuffers.PropertyBuffer<vec3>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }

        class ColorBuffer : CSharpGL.Objects.VertexBuffers.PropertyBuffer<vec3>
        {
            public ColorBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }

    }
}
