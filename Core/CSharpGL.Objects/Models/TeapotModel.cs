using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Models
{
    public class TeapotModel : IModel
    {
        internal List<vec3> positions = new List<vec3>();
        internal List<vec3> normals = new List<vec3>();
        internal List<Tuple<ushort, ushort, ushort>> faces = new List<Tuple<ushort, ushort, ushort>>();

        internal TeapotModel() { }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ObjModelPositionBuffer(varNameInShader))
            {
                buffer.Alloc(positions.Count);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < positions.Count; i++)
                    {
                        array[i] = positions[i];
                    }
                }

                return buffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ObjModelColorBuffer(varNameInShader))
            {
                buffer.Alloc(normals.Count);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < normals.Count; i++)
                    {
                        array[i] = normals[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ObjModelNormalBuffer(varNameInShader))
            {
                buffer.Alloc(normals.Count);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < normals.Count; i++)
                    {
                        array[i] = normals[i];
                    }
                }

                return buffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetIndexes()
        {
            using (var buffer = new ObjModelIndexBuffer())
            {
                buffer.Alloc(faces.Count * 3);
                unsafe
                {
                    uint* array = (uint*)buffer.FirstElement();
                    for (int i = 0; i < faces.Count; i++)
                    {
                        //TODO: 用ushort类型的IndexBuffer就会引发系统错误，为什么？
                        //array[i * 3 + 0] = (ushort)(faces[i].Item1 - 1);
                        //array[i * 3 + 1] = (ushort)(faces[i].Item2 - 1);
                        //array[i * 3 + 2] = (ushort)(faces[i].Item3 - 1);

                        array[i * 3 + 0] = (uint)(faces[i].Item1 - 1);
                        array[i * 3 + 1] = (uint)(faces[i].Item2 - 1);
                        array[i * 3 + 2] = (uint)(faces[i].Item3 - 1);
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public static IModel GetModel(float radius)
        {
            TeapotModel model = TeapotLoader.GetModel();

            for (int i = 0; i < model.positions.Count; i++)
            {
                model.positions[i] *= radius;
            }

            return model;
        }
    }


    class ObjModelPositionBuffer : PropertyBuffer<vec3>
    {
        public ObjModelPositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class ObjModelColorBuffer : PropertyBuffer<vec3>
    {
        public ObjModelColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
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

    class ObjModelIndexBuffer : IndexBuffer<uint>
    {
        public ObjModelIndexBuffer()
            : base(DrawMode.Triangles, IndexElementType.UnsignedInt, BufferUsage.StaticDraw)
        {

        }
    }


}
