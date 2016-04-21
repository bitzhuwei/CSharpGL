using CSharpGL;
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
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// </summary>
    public class SphereModel : IBufferable
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="latitudeParts">用纬线把地球切割为几块。</param>
        /// <param name="longitudeParts">用经线把地球切割为几块。</param>
        /// <param name="colorGenerator"></param>
        /// <returns></returns>
        public static IBufferable GetModel(float radius = 1.0f, int latitudeParts = 10, int longitudeParts = 40, Func<int, int, vec3> colorGenerator = null)
        {
            if (radius <= 0.0f || latitudeParts < 1 || longitudeParts < 3) { throw new Exception(); }

            if (colorGenerator == null) { colorGenerator = defaultColorGenerator; }

            SphereModel sphere = new SphereModel();
            int vertexCount = (latitudeParts + 1) * (longitudeParts);
            sphere.positions = new vec3[vertexCount];
            sphere.normals = new vec3[vertexCount];
            sphere.colors = new vec3[vertexCount];

            int indexCount = (latitudeParts) * (2 * (longitudeParts + 1) + 1);
            sphere.indexes = new uint[indexCount];

            int index = 0;

            for (int i = 0; i < latitudeParts + 1; i++)
            {
                double theta = (latitudeParts - i * 2) * Math.PI / 2 / latitudeParts;
                double y = radius * Math.Sin(theta);
                for (int j = 0; j < longitudeParts; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 2 / longitudeParts);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 2 / longitudeParts);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    sphere.positions[index] = position;

                    sphere.normals[index] = position.normalize();

                    sphere.colors[index] = colorGenerator(i, j);

                    index++;
                }
            }

            // 索引
            index = 0;
            for (int i = 0; i < latitudeParts; i++)
            {
                for (int j = 0; j < (longitudeParts); j++)
                {
                    sphere.indexes[index++] = (uint)((longitudeParts) * (i + 0) + j);
                    sphere.indexes[index++] = (uint)((longitudeParts) * (i + 1) + j);
                }
                {
                    sphere.indexes[index++] = (uint)((longitudeParts) * (i + 0) + 0);
                    sphere.indexes[index++] = (uint)((longitudeParts) * (i + 1) + 0);
                }
                // use 
                // GL.Enable(GL.GL_PRIMITIVE_RESTART); 
                // GL.PrimitiveRestartIndex(uint.MaxValue); 
                // GL.Disable(GL.GL_PRIMITIVE_RESTART);
                sphere.indexes[index++] = uint.MaxValue;
            }

            return sphere;
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

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                using (var buffer = new PositionBuffer(varNameInShader))
                {
                    buffer.Alloc(positions.Length);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                    }

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strColor)
            {
                using (var buffer = new ColorBuffer(varNameInShader))
                {
                    buffer.Alloc(colors.Length);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < colors.Length; i++)
                        {
                            array[i] = colors[i];
                        }
                    }

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strNormal)
            {
                using (var buffer = new NormalBuffer(varNameInShader))
                {
                    buffer.Alloc(normals.Length);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < normals.Length; i++)
                        {
                            array[i] = normals[i];
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
                indexBuffer.Alloc(indexes.Length);
                unsafe
                {
                    uint* indexArray = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        indexArray[i] = indexes[i];
                    }
                }

                return indexBuffer.GetBufferPtr() as IndexBufferPtr;
            }
        }
    }

}
