
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    internal partial class TeapotModel
    {
        internal static vec3[] normals;

        public TeapotModel() { }

        public float[] GetPositions()
        {
            return positionData;
        }

        public vec3[] GetNormals()
        {
            return normals;
        }

        public Face[] GetFaces()
        {
            return faceData;
        }

        static TeapotModel()
        {
            MovePosition2Center();
            GenNormals();
        }

        private static void GenNormals()
        {
            var faceNormals = new vec3[faceData.Length];
            normals = new vec3[positionData.Length / 3];

            for (int i = 0; i < faceData.Length; i++)
            {
                var face = faceData[i];
                vec3 vertex0 = new vec3(
                    positionData[(face.vertexId1 - 1) * 3 + 0],
                    positionData[(face.vertexId1 - 1) * 3 + 1],
                    positionData[(face.vertexId1 - 1) * 3 + 2]);
                vec3 vertex1 = new vec3(
                    positionData[(face.vertexId2 - 1) * 3 + 0],
                    positionData[(face.vertexId2 - 1) * 3 + 1],
                    positionData[(face.vertexId2 - 1) * 3 + 2]);
                vec3 vertex2 = new vec3(
                    positionData[(face.vertexId3 - 1) * 3 + 0],
                    positionData[(face.vertexId3 - 1) * 3 + 1],
                    positionData[(face.vertexId3 - 1) * 3 + 2]);
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v2.cross(v1).normalize();
            }

            for (int i = 0; i < positionData.Length / 3; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < faceData.Length; j++)
                {
                    var face = faceData[j];
                    if (face.vertexId1 - 1 == i || face.vertexId2 - 1 == i || face.vertexId3 - 1 == i)
                    {
                        sum = sum + faceNormals[j];
                        shared++;
                    }
                }
                if (shared > 0)
                {
                    sum = (sum / shared).normalize();
                }
                normals[i] = sum;
            }

        }

        private static void MovePosition2Center()
        {
            vec3 min = new vec3(0 * 3 + 0, 0 * 3 + 1, 0 * 3 + 2);
            vec3 max = min;
            for (int i = 1; i < positionData.Length / 3; i++)
            {
                if (positionData[i * 3 + 0] < min.x) { min.x = positionData[i * 3 + 0]; }
                if (positionData[i * 3 + 1] < min.y) { min.y = positionData[i * 3 + 1]; }
                if (positionData[i * 3 + 2] < min.z) { min.z = positionData[i * 3 + 2]; }
                if (max.x < positionData[i * 3 + 0]) { max.x = positionData[i * 3 + 0]; }
                if (max.y < positionData[i * 3 + 1]) { max.y = positionData[i * 3 + 1]; }
                if (max.z < positionData[i * 3 + 2]) { max.z = positionData[i * 3 + 2]; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positionData.Length / 3; i++)
            {
                positionData[i * 3 + 0] = positionData[i * 3 + 0] - mid.x;
                positionData[i * 3 + 1] = positionData[i * 3 + 1] - mid.y;
                positionData[i * 3 + 2] = positionData[i * 3 + 2] - mid.z;
            }
        }
    }

}
