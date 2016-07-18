
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    internal partial class TeapotModel
    {
        internal static float[] normals;

        public TeapotModel() { }

        public float[] GetPositions()
        {
            return positionData;
        }

        public float[] GetNormals()
        {
            return normals;
        }

        public ushort[] GetFaces()
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
            var faceNormals = new vec3[faceData.Length / 3];

            for (int i = 0; i < faceData.Length / 3; i++)
            {
                ushort vertexId1 = faceData[i * 3 + 0];
                ushort vertexId2 = faceData[i * 3 + 1];
                ushort vertexId3 = faceData[i * 3 + 2];
                vec3 vertex0 = new vec3(
                    positionData[(vertexId1 - 1) * 3 + 0],
                    positionData[(vertexId1 - 1) * 3 + 1],
                    positionData[(vertexId1 - 1) * 3 + 2]);
                vec3 vertex1 = new vec3(
                    positionData[(vertexId2 - 1) * 3 + 0],
                    positionData[(vertexId2 - 1) * 3 + 1],
                    positionData[(vertexId2 - 1) * 3 + 2]);
                vec3 vertex2 = new vec3(
                    positionData[(vertexId3 - 1) * 3 + 0],
                    positionData[(vertexId3 - 1) * 3 + 1],
                    positionData[(vertexId3 - 1) * 3 + 2]);
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v2.cross(v1).normalize();
            }

            var normals = new float[positionData.Length];
            for (int i = 0; i < positionData.Length / 3; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < faceData.Length / 3; j++)
                {
                    ushort vertexId1 = faceData[j * 3 + 0];
                    ushort vertexId2 = faceData[j * 3 + 1];
                    ushort vertexId3 = faceData[j * 3 + 2];
                    if (vertexId1 - 1 == i || vertexId2 - 1 == i || vertexId3 - 1 == i)
                    {
                        sum = sum + faceNormals[j];
                        shared++;
                    }
                }

                if (shared > 0)
                {
                    sum = (sum / shared).normalize();
                }

                normals[i * 3 + 0] = sum.x;
                normals[i * 3 + 1] = sum.y;
                normals[i * 3 + 2] = sum.z;
            }

            TeapotModel.normals = normals;
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
