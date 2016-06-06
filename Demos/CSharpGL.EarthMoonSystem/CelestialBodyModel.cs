using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    /// <summary>
    /// 天体（星球）
    /// </summary>
    class CelestialBodyModel 
    {
        internal vec3[] positions;
        internal vec3[] normals;
        internal vec2[] uv;
        internal uint[] indexes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="latitudeParts">用纬线把地球切割为几块。</param>
        /// <param name="longitudeParts">用经线把地球切割为几块。</param>
        /// <param name="colorGenerator"></param>
        /// <returns></returns>
        internal CelestialBodyModel(float radius = 1.0f, int latitudeParts = 10, int longitudeParts = 40)
        {
            if (radius <= 0.0f || latitudeParts < 2 || longitudeParts < 3) { throw new Exception(); }

            int vertexCount = (latitudeParts + 1) * (longitudeParts);
            this.positions = new vec3[vertexCount];
            this.normals = new vec3[vertexCount];
            this.uv = new vec2[vertexCount];

            int indexCount = (latitudeParts) * (2 * (longitudeParts + 1) + 1);
            this.indexes = new uint[indexCount];

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
                    this.positions[index] = position;

                    this.normals[index] = position.normalize();

                    this.uv[index] = new vec2((float)i / (float)latitudeParts, (float)j / (float)longitudeParts);

                    index++;
                }
            }

            // 索引
            index = 0;
            for (int i = 0; i < latitudeParts; i++)
            {
                for (int j = 0; j < (longitudeParts); j++)
                {
                    this.indexes[index++] = (uint)((longitudeParts) * (i + 0) + j);
                    this.indexes[index++] = (uint)((longitudeParts) * (i + 1) + j);
                }
                {
                    this.indexes[index++] = (uint)((longitudeParts) * (i + 0) + 0);
                    this.indexes[index++] = (uint)((longitudeParts) * (i + 1) + 0);
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
