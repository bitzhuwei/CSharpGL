using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// </summary>
    internal class SphereModel
    {
        internal vec3[] positions;
        internal vec3[] normals;
        internal vec3[] colors;
        internal uint[] indexes;

        static Random random = new Random();
        static vec3 RandomVec3()
        {
            return new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }

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
        internal SphereModel(float radius = 1.0f, int latitudeParts = 10, int longitudeParts = 40)
        {
            if (radius <= 0.0f || latitudeParts < 2 || longitudeParts < 3) { throw new Exception(); }

            int vertexCount = (latitudeParts + 1) * (longitudeParts + 1);
            this.positions = new vec3[vertexCount];
            this.normals = new vec3[vertexCount];
            this.colors = new vec3[vertexCount];

            int indexCount = (latitudeParts) * (2 * (longitudeParts + 1) + 1);
            this.indexes = new uint[indexCount];

            int index = 0;

            //// 把星球平铺在一个平面上
            //for (int i = 0; i < latitudeParts + 1; i++)
            //{
            //    double theta = (latitudeParts - i * 2) * Math.PI / 2 / latitudeParts;
            //    double y = radius * Math.Sin(theta);
            //    for (int j = 0; j < longitudeParts + 1; j++)
            //    {
            //        double x = radius * (i - latitudeParts / 2);
            //        double z = radius * (j - longitudeParts / 2);

            //        vec3 position = new vec3((float)x, (float)y, (float)z);
            //        this.positions[index] = position;

            //        this.normals[index] = position.normalize();

            //        this.colors[index] = colorGenerator(i, j);

            //        index++;
            //    }
            //}

            for (int i = 0; i < latitudeParts + 1; i++)
            {
                double theta = (latitudeParts - i * 2) * Math.PI / 2 / latitudeParts;
                double y = radius * Math.Sin(theta);
                for (int j = 0; j < longitudeParts + 1; j++)
                {
                    double x = radius * Math.Cos(theta) * Math.Sin(j * Math.PI * 2 / longitudeParts);
                    double z = radius * Math.Cos(theta) * Math.Cos(j * Math.PI * 2 / longitudeParts);

                    vec3 position = new vec3((float)x, (float)y, (float)z);
                    this.positions[index] = position;

                    this.normals[index] = position.normalize();

                    vec3 color = position.normalize();
                    if (color.x < 0) { color.x = -(color.x / 2); }
                    if (color.y < 0) { color.y = -(color.y / 2); }
                    if (color.z < 0) { color.z = -(color.z / 2); }
                    this.colors[index] = color;

                    index++;
                }
            }

            // 索引
            index = 0;
            for (int i = 0; i < latitudeParts; i++)
            {
                for (int j = 0; j < longitudeParts + 1; j++)
                {
                    this.indexes[index++] = (uint)((longitudeParts + 1) * (i + 0) + j);
                    this.indexes[index++] = (uint)((longitudeParts + 1) * (i + 1) + j);
                }
                // use 
                // GL.Enable(GL.GL_PRIMITIVE_RESTART); 
                // GL.PrimitiveRestartIndex(uint.MaxValue); 
                // GL.Disable(GL.GL_PRIMITIVE_RESTART);
                this.indexes[index++] = uint.MaxValue;
            }
        }

    }

}
