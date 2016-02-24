using CSharpGL.Objects.Models;
using CSharpGL.Objects.VertexBuffers;
using CSharpGL.OBJParser;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ObjViewer
{
    class ObjModelAdpater : IModel
    {
        private ObjModel model;
        public ObjModelAdpater(ObjModel model)
        {
            this.model = model;
        }


        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ObjModelPositionBuffer(varNameInShader))
            {
                buffer.Alloc(model.positionList.Count);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < model.positionList.Count; i++)
                    {
                        array[i] = model.positionList[i];
                    }
                }

                return buffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            if (model.uvList.Count == 0) { return null; }

            using (var buffer = new ObjModelColorBuffer(varNameInShader))
            {
                buffer.Alloc(model.uvList.Count);
                unsafe
                {
                    vec2* array = (vec2*)buffer.FirstElement();
                    for (int i = 0; i < model.uvList.Count; i++)
                    {
                        array[i] = model.uvList[i];
                    }
                }

                return buffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ObjModelNormalBuffer(varNameInShader))
            {
                buffer.Alloc(model.normalList.Count);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < model.normalList.Count; i++)
                    {
                        array[i] = model.normalList[i];
                    }
                }

                return buffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.IndexBufferRendererBase IModel.GetIndexes()
        {
            using (var buffer = new IndexBuffer<uint>(DrawMode.Triangles, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                buffer.Alloc(model.faceList.Count * 3);
                unsafe
                {
                    uint* array = (uint*)buffer.FirstElement();
                    for (int i = 0; i < model.faceList.Count; i++)
                    {
                        array[i * 3 + 0] = (uint)(model.faceList[i].Item1 - 1);
                        array[i * 3 + 1] = (uint)(model.faceList[i].Item2 - 1);
                        array[i * 3 + 2] = (uint)(model.faceList[i].Item3 - 1);
                    }
                }

                return buffer.GetRenderer() as IndexBufferRendererBase;
            }
        }
    }


    class ObjModelPositionBuffer : PropertyBuffer<vec3>
    {
        public ObjModelPositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class ObjModelColorBuffer : PropertyBuffer<vec2>
    {
        public ObjModelColorBuffer(string varNameInShader)
            : base(varNameInShader, 2, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class ObjModelNormalBuffer : PropertyBuffer<vec3>
    {
        public ObjModelNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
