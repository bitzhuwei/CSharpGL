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
    /// 一个类似冰激凌形状的模型。偶然得之。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000064.jpg
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000065.jpg
    /// </summary>
    public class IceCreamModel : IModel
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

        private IceCreamModel() { }

        public static IModel GetModel(float radius = 1.0f, int halfLatitudeCount = 10, int longitudeCount = 10)
        {
            IceCreamModel sphere = new IceCreamModel();
            int vertexCount = (halfLatitudeCount * 2 + 1) * (longitudeCount + 1);
            sphere.positions = new vec3[vertexCount];
            sphere.normals = new vec3[vertexCount];
            sphere.colors = new vec3[vertexCount];

            int indexCount = (halfLatitudeCount * 2) * ((longitudeCount + 1) * 2 + 1);
            sphere.indexes = new uint[indexCount];

            int index = 0;

            // 北半球
            for (int i = 0; i < halfLatitudeCount; i++)
            {
                double theta = Math.PI / 2 * (halfLatitudeCount - i);
                double y = radius * Math.Sin(theta);
                for (int j = 0; j < longitudeCount + 1; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 4 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 4 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    sphere.normals[index] = position.normalize();

                    sphere.colors[index] = RandomVec3();

                    index++;
                }
            }

            // 赤道
            {
                double theta = 0;
                double y = 0;
                for (int j = 0; j < longitudeCount + 1; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 4 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 4 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    sphere.normals[index] = position.normalize();

                    sphere.colors[index] = RandomVec3();

                    index++;
                }
            }

            // 南半球
            for (int i = 0; i < halfLatitudeCount; i++)
            {
                double theta = (i + 1) * Math.PI / 2 / halfLatitudeCount;
                double y = -radius * Math.Sin(theta);
                for (int j = 0; j < longitudeCount + 1; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 4 / longitudeCount);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 4 / longitudeCount);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    sphere.normals[index] = position.normalize();

                    sphere.colors[index] = RandomVec3();

                    index++;
                }
            }

            // 索引
            index = 0;
            for (int i = 0; i < halfLatitudeCount * 2; i++)
            {
                for (int j = 0; j < longitudeCount + 1; j++)
                {
                    sphere.indexes[index++] = (uint)((longitudeCount + 1) * i + j);
                    sphere.indexes[index++] = (uint)((longitudeCount + 1) * (i + 1) + j);
                }
                sphere.indexes[index++] = uint.MaxValue;
            }

            return sphere;
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var positionBuffer = new IceCreamModelPositionBuffer(varNameInShader))
            {
                positionBuffer.Alloc(positions.Length);
                unsafe
                {
                    vec3* array = (vec3*)positionBuffer.FirstElement();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        array[i] = positions[i];
                    }
                }

                return positionBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            using (var colorBuffer = new IceCreamModelColorBuffer(varNameInShader))
            {
                colorBuffer.Alloc(colors.Length);
                unsafe
                {
                    vec3* array = (vec3*)colorBuffer.FirstElement();
                    for (int i = 0; i < colors.Length; i++)
                    {
                        array[i] = colors[i];
                    }
                }

                return colorBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            using (var normalBuffer = new IceCreamModelNormalBuffer(varNameInShader))
            {
                normalBuffer.Alloc(normals.Length);
                unsafe
                {
                    vec3* array = (vec3*)normalBuffer.FirstElement();
                    for (int i = 0; i < normals.Length; i++)
                    {
                        array[i] = normals[i];
                    }
                }

                return normalBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.IndexBufferRendererBase IModel.GetIndexes()
        {
            using (var indexBuffer = new IndexBuffer<uint>(DrawMode.TriangleStrip, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(indexes.Length);
                unsafe
                {
                    uint* array = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        array[i] = indexes[i];
                    }
                }

                return indexBuffer.GetRenderer() as IndexBufferRendererBase;
            }
        }

        class IceCreamModelPositionBuffer : PropertyBuffer<vec3>
        {
            public IceCreamModelPositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class IceCreamModelColorBuffer : PropertyBuffer<vec3>
        {
            public IceCreamModelColorBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class IceCreamModelNormalBuffer : PropertyBuffer<vec3>
        {
            public IceCreamModelNormalBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }
    }

 
}
