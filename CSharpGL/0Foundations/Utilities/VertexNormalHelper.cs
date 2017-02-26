namespace CSharpGL
{
    /// <summary>
    /// Helper class for generating vertex's normal.
    /// </summary>
    public static class VertexNormalHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static vec3[] GenerateNormalsForQuadMesh(vec3[] positions, uint[] indexes)
        {
            var faceNormals = new vec3[indexes.Length / 4];

            for (int i = 0; i < indexes.Length / 4; i++)
            {
                uint vertexId0 = indexes[i * 4 + 0];
                uint vertexId1 = indexes[i * 4 + 1];
                uint vertexId2 = indexes[i * 4 + 2];
                uint vertexId3 = indexes[i * 4 + 3];
                vec3 vertex0 = positions[vertexId0];
                vec3 vertex1 = positions[vertexId1];
                vec3 vertex2 = positions[vertexId2];
                vec3 vertex3 = positions[vertexId3];
                vec3 normalA, normalB, normalC, normalD;
                {
                    vec3 v1 = vertex0 - vertex2;
                    vec3 v2 = vertex2 - vertex1;
                    normalA = v2.cross(v1).normalize();
                }
                {
                    vec3 v1 = vertex0 - vertex3;
                    vec3 v2 = vertex3 - vertex2;
                    normalB = v2.cross(v1).normalize();
                }
                {
                    vec3 v1 = vertex0 - vertex3;
                    vec3 v2 = vertex3 - vertex1;
                    normalC = v2.cross(v1).normalize();
                }
                {
                    vec3 v1 = vertex1 - vertex3;
                    vec3 v2 = vertex3 - vertex2;
                    normalD = v2.cross(v1).normalize();
                }
                faceNormals[i] = (normalA + normalB + normalC + normalD).normalize();
            }

            var normals = new vec3[positions.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < indexes.Length / 4; j++)
                {
                    uint vertexId0 = indexes[i * 4 + 0];
                    uint vertexId1 = indexes[i * 4 + 1];
                    uint vertexId2 = indexes[i * 4 + 2];
                    uint vertexId3 = indexes[i * 4 + 3];
                    if (vertexId0 == i || vertexId1 == i || vertexId2 == i || vertexId3 == i)
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

            return normals;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static vec3[] GenerateNormalsForTriangleMesh(vec3[] positions, uint[] indexes)
        {
            var vertexNormals = new vec3[positions.Length];
            var counts = new int[positions.Length];

            for (int i = 0; i < indexes.Length / 3; i++)
            {
                uint vertexId0 = indexes[i * 3 + 0];
                uint vertexId1 = indexes[i * 3 + 1];
                uint vertexId2 = indexes[i * 3 + 2];
                vec3 vertex0 = positions[vertexId0];
                vec3 vertex1 = positions[vertexId1];
                vec3 vertex2 = positions[vertexId2];
                vec3 v01 = vertex1 - vertex0;
                vec3 v12 = vertex2 - vertex1;
                vec3 normal = v12.cross(v01).normalize();
                vertexNormals[vertexId0] += normal;
                vertexNormals[vertexId1] += normal;
                vertexNormals[vertexId2] += normal;
                counts[vertexId0]++;
                counts[vertexId1]++;
                counts[vertexId2]++;
            }

            for (int i = 0; i < positions.Length; i++)
            {
                if (counts[i] > 0)
                {
                    vertexNormals[i] = vertexNormals[i] / counts[i];
                }
            }

            return vertexNormals;
        }
    }
}
// TODO: update this algorithm with following codes:
/*
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
*/