namespace CSharpGL
{
    /// <summary>
    /// Helper class for generating vertex's normal.
    /// </summary>
    public static class VertexNormalHelper
    {
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

        public static vec3[] GenerateNormalsForTriangleMesh(vec3[] positions, uint[] indexes)
        {
            var faceNormals = new vec3[indexes.Length / 3];

            for (int i = 0; i < indexes.Length / 3; i++)
            {
                uint vertexId0 = indexes[i * 3 + 0];
                uint vertexId1 = indexes[i * 3 + 1];
                uint vertexId2 = indexes[i * 3 + 2];
                vec3 vertex0 = positions[vertexId0];
                vec3 vertex1 = positions[vertexId1];
                vec3 vertex2 = positions[vertexId2];
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v2.cross(v1).normalize();
            }

            var normals = new vec3[positions.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < indexes.Length / 3; j++)
                {
                    uint vertexId0 = indexes[j * 3 + 0];
                    uint vertexId1 = indexes[j * 3 + 1];
                    uint vertexId2 = indexes[j * 3 + 2];
                    if (vertexId0 == i || vertexId1 == i || vertexId2 == i)
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
    }
}