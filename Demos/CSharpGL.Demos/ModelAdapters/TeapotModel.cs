using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ModelAdapters
{
    public class TeapotModel : IBufferable
    {
        internal List<vec3> positions = new List<vec3>();
        internal List<vec3> normals = new List<vec3>();
        internal List<Tuple<ushort, ushort, ushort>> faces = new List<Tuple<ushort, ushort, ushort>>();

        internal TeapotModel() { }

        public static IBufferable GetModel(float radius = 1.0f)
        {
            TeapotModel model = TeapotLoader.GetModel();

            if (radius != 1.0f)
            {
                for (int i = 0; i < model.positions.Count; i++)
                {
                    model.positions[i] *= radius;
                }
            }

            return model;
        }

        class PositionBuffer : PropertyBuffer<vec3>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class ColorBuffer : PropertyBuffer<vec3>
        {
            public ColorBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class NormalBuffer : PropertyBuffer<vec3>
        {
            public NormalBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        public const string strNormal = "normal";

        public BufferPointer GetBufferRenderer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                using (var buffer = new PositionBuffer(varNameInShader))
                {
                    buffer.Alloc(positions.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < positions.Count; i++)
                        {
                            array[i] = positions[i];
                        }
                    }

                    return buffer.GetBufferPtr();
                }
            }
            else if (bufferName == strColor)
            {
                using (var buffer = new ColorBuffer(varNameInShader))
                {
                    buffer.Alloc(normals.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < normals.Count; i++)
                        {
                            array[i] = normals[i];
                        }
                    }

                    return buffer.GetBufferPtr();
                }
            }
            else if (bufferName == strNormal)
            {
                using (var buffer = new NormalBuffer(varNameInShader))
                {
                    buffer.Alloc(normals.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < normals.Count; i++)
                        {
                            array[i] = normals[i];
                        }
                    }

                    return buffer.GetBufferPtr();
                }
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndexBufferRenderer()
        {
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Triangles, BufferUsage.StaticDraw))
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

                return buffer.GetBufferPtr() as IndexBufferPointerBase;
            }
        }
    }

}
