
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

        public vec3[] GetPositions()
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
            normals = new vec3[positionData.Length];

            for (int i = 0; i < faceData.Length; i++)
            {
                var face = faceData[i];
                vec3 vertex0 = positionData[face.item1 - 1];
                vec3 vertex1 = positionData[face.item2 - 1];
                vec3 vertex2 = positionData[face.item3 - 1];
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v2.cross(v1).normalize();
            }

            for (int i = 0; i < positionData.Length; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < faceData.Length; j++)
                {
                    var face = faceData[j];
                    if (face.item1 - 1 == i || face.item2 - 1 == i || face.item3 - 1 == i)
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
            vec3 min = positionData[0], max = positionData[0];
            for (int i = 1; i < positionData.Length; i++)
            {
                if (positionData[i].x < min.x) { min.x = positionData[i].x; }
                if (positionData[i].y < min.y) { min.y = positionData[i].y; }
                if (positionData[i].z < min.z) { min.z = positionData[i].z; }
                if (max.x < positionData[i].x) { max.x = positionData[i].x; }
                if (max.y < positionData[i].y) { max.y = positionData[i].y; }
                if (max.z < positionData[i].z) { max.z = positionData[i].z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positionData.Length; i++)
            {
                positionData[i] = positionData[i] - mid;
            }
        }
    }

}
