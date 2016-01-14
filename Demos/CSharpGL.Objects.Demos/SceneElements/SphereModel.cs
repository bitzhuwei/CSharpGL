using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 一个球体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// </summary>
    public class SphereModel
    {
        public vec3[] positions;
        public vec3[] normals;
        public vec3[] colors;
        public uint[] indexes;

        static Random random = new Random();
        static vec3 RandomVec3()
        {
            return new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }

        public static SphereModel GetSphere(float radius = 1.0f, int halfLatitudeCount = 2, int longitudeCount = 4)
        {
            SphereModel sphere = new SphereModel();
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

                    position.Normalize();
                    sphere.normals[index] = position;

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

                    position.Normalize();
                    sphere.normals[index] = position;

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

                    position.Normalize();
                    sphere.normals[index] = position;

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
    }

}
