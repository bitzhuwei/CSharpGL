using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMGraphics
{
    public static class NormalHelper
    {
        /// <summary>
        /// Calculates normal lines for specified vertex positions and faces.
        /// </summary>
        /// <param name="vertexPositions"></param>
        /// <param name="faces"></param>
        /// <returns></returns>
        public static vec3[] CalculateNormals(this vec3[] vertexPositions, Triangle[] faces)
        {
            if (vertexPositions == null || faces == null) { throw new ArgumentNullException(); }

            var faceNormals = new vec3[faces.Length];
            var normals = new vec3[vertexPositions.Length];
            var counts = new int[vertexPositions.Length];
            for (int i = 0; i < faceNormals.Length; i++)
            {
                int vertexId1 = faces[i].Num1;
                int vertexId2 = faces[i].Num2;
                int vertexId3 = faces[i].Num3;
                vec3 vertex1 = vertexPositions[vertexId1];
                vec3 vertex2 = vertexPositions[vertexId2];
                vec3 vertex3 = vertexPositions[vertexId3];
                vec3 v12 = vertex2 - vertex1;
                vec3 v23 = vertex3 - vertex2;
                vec3 normal = v23.cross(v12).normalize();
                faceNormals[i] = normal;
                normals[vertexId1] += normal;
                normals[vertexId2] += normal;
                normals[vertexId3] += normal;
                counts[vertexId1]++;
                counts[vertexId2]++;
                counts[vertexId3]++;
            }

            for (int i = 0; i < normals.Length; i++)
            {
                if (counts[i] > 0)
                {
                    normals[i] = normals[i] / counts[i];
                }
            }

            return normals;
        }
    }
}
