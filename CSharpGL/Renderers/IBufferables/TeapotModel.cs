namespace CSharpGL
{
    internal partial class TeapotModel
    {
        internal static vec3[] normals;

        public TeapotModel()
        {
        }

        public vec3[] GetPositions()
        {
            var result = new vec3[positionData.Length];
            positionData.CopyTo(result, 0);
            return result;
        }

        public vec3[] GetNormals()
        {
            var result = new vec3[normals.Length];
            normals.CopyTo(result, 0);
            return result;
        }

        public Face[] GetFaces()
        {
            var result = new Face[faceData.Length];
            faceData.CopyTo(result, 0);
            return result;
        }

        static TeapotModel()
        {
            MovePosition2Center();
            GenNormals();
        }

        private static void GenNormals()
        {
            var faceNormals = new vec3[faceData.Length];
            for (int i = 0; i < faceData.Length; i++)
            {
                ushort vertexId1 = faceData[i].vertexId1;
                ushort vertexId2 = faceData[i].vertexId2;
                ushort vertexId3 = faceData[i].vertexId3;
                vec3 vertex0 = positionData[vertexId1 - 1];
                vec3 vertex1 = positionData[vertexId2 - 1];
                vec3 vertex2 = positionData[vertexId3 - 1];
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v2.cross(v1).normalize();
            }

            var normals = new vec3[positionData.Length];
            for (int i = 0; i < positionData.Length; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < faceData.Length; j++)
                {
                    ushort vertexId1 = faceData[j].vertexId1;
                    ushort vertexId2 = faceData[j].vertexId2;
                    ushort vertexId3 = faceData[j].vertexId3;
                    if (vertexId1 - 1 == i || vertexId2 - 1 == i || vertexId3 - 1 == i)
                    {
                        sum = sum + faceNormals[j];
                        shared++;
                    }
                }

                if (shared > 0)
                {
                    normals[i] = (sum / shared).normalize();
                }
            }

            TeapotModel.normals = normals;
        }

        private static void MovePosition2Center()
        {
            vec3 min = positionData[0];
            vec3 max = min;
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