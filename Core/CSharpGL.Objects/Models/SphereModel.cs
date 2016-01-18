using CSharpGL;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Models
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// </summary>
    public class SphereModel : IModel
    {
        vec3[] positions;
        vec3[] normals;
        vec3[] colors;
        uint[] indexes;

        static Random random = new Random();
        static vec3 RandomVec3()
        {
            return new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }

        private SphereModel() { }

        static readonly Func<int, int, vec3> defaultColorGenerator = new Func<int, int, vec3>(DefaultColorGenerator);

        private static vec3 DefaultColorGenerator(int latitude, int longitude)
        {
            return RandomVec3();
        }

        public static IModel GetModel(float radius = 1.0f, int halfLatitudeCount = 10, int longitudeCount = 40, Func<int, int, vec3> colorGenerator = null)
        {
            if (radius <= 0.0f || halfLatitudeCount < 1 || longitudeCount < 2) { throw new Exception(); }

            if (colorGenerator == null) { colorGenerator = defaultColorGenerator; }

            SphereModel sphere = new SphereModel();
            int vertexCount = (halfLatitudeCount * 2 + 1) * (longitudeCount);
            sphere.positions = new vec3[vertexCount];
            sphere.normals = new vec3[vertexCount];
            sphere.colors = new vec3[vertexCount];

            int indexCount = (halfLatitudeCount * 2) * ((longitudeCount + 1) * 2 + 1);
            sphere.indexes = new uint[indexCount];

            int index = 0;

            // 北半球
            for (int i = 0; i < halfLatitudeCount; i++)
            {
                double theta = (halfLatitudeCount - i) * Math.PI / 2 / halfLatitudeCount;
                double y = radius * Math.Sin(theta);
                for (int j = 0; j < longitudeCount; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 2 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 2 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    position.Normalize();
                    sphere.normals[index] = position;

                    sphere.colors[index] = colorGenerator(i, j);

                    index++;
                }
            }

            // 赤道
            {
                double theta = 0;
                double y = 0;
                for (int j = 0; j < longitudeCount; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 2 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 2 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    position.Normalize();
                    sphere.normals[index] = position;

                    sphere.colors[index] = colorGenerator(-1, j);

                    index++;
                }
            }

            // 南半球
            for (int i = 0; i < halfLatitudeCount; i++)
            {
                double theta = (i + 1) * Math.PI / 2 / halfLatitudeCount;
                double y = -radius * Math.Sin(theta);
                for (int j = 0; j < longitudeCount; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 2 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 2 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    position.Normalize();
                    sphere.normals[index] = position;

                    sphere.colors[index] = colorGenerator(i, j);

                    index++;
                }
            }

            // 索引
            index = 0;
            for (int i = 0; i < halfLatitudeCount * 2; i++)
            {
                for (int j = 0; j < (longitudeCount); j++)
                {
                    sphere.indexes[index++] = (uint)((longitudeCount) * (i + 0) + j);
                    sphere.indexes[index++] = (uint)((longitudeCount) * (i + 1) + j);
                }
                {
                    sphere.indexes[index++] = (uint)((longitudeCount) * (i + 0) + 0);
                    sphere.indexes[index++] = (uint)((longitudeCount) * (i + 1) + 0);
                }
                sphere.indexes[index++] = uint.MaxValue;
            }

            return sphere;
        }


        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new SphereModelPositionBuffer(varNameInShader))
            {
                buffer.Alloc(positions.Length);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        array[i] = positions[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            using (var buffer = new SphereModelColorBuffer(varNameInShader))
            {
                buffer.Alloc(colors.Length);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < colors.Length; i++)
                    {
                        array[i] = colors[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            using (var buffer = new SphereModelNormalBuffer(varNameInShader))
            {
                buffer.Alloc(normals.Length);
                unsafe
                {
                    vec3* array = (vec3*)buffer.FirstElement();
                    for (int i = 0; i < normals.Length; i++)
                    {
                        array[i] = normals[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetIndexes()
        {
            using (var indexBuffer = new IndexBuffer<uint>(DrawMode.QuadStrip, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(indexes.Length);
                unsafe
                {
                    uint* indexArray = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        indexArray[i] = indexes[i];
                    }
                }

                return indexBuffer.GetRenderer();
            }
        }
    }

    class SphereModelPositionBuffer : PropertyBuffer<vec3>
    {
        public SphereModelPositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereModelColorBuffer : PropertyBuffer<vec3>
    {
        public SphereModelColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereModelNormalBuffer : PropertyBuffer<vec3>
    {
        public SphereModelNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
