using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class TangentParser : ObjParserBase
    {
        // https://www.cnblogs.com/bitzhuwei/p/opengl-Computing-Tangent-Space-Basis-Vectors.html
        public override void Parse(ObjVNFContext context)
        {
            ObjVNFMesh mesh = context.Mesh;
            vec3[] vertexes = mesh.vertexes;// positions
            vec2[] texCoords = mesh.texCoords;
            vec3[] normals = mesh.normals;
            if (vertexes == null || texCoords == null || normals == null) { return; }
            if (vertexes.Length != texCoords.Length || vertexes.Length != normals.Length) { return; }

            ObjVNFFace[] faces = mesh.faces;
            if (faces == null || faces.Length == 0) { return; }
            // if (not triangles) { return; }
            if (faces[0].VertexIndexes().Count() != 3) { return; }

            var tangents = new vec3[normals.Length];
            var biTangents = new vec3[normals.Length];
            for (int i = 0; i < faces.Length; i++)
            {
                var face = faces[i] as ObjVNFTriangle;
                if (face == null) { return; } // no dealing with quad.

                uint[] vertexIndexes = face.VertexIndexes();
                uint i0 = vertexIndexes[0];
                uint i1 = vertexIndexes[1];
                uint i2 = vertexIndexes[2];
                vec3 p0 = vertexes[i0];
                vec3 p1 = vertexes[i1];
                vec3 p2 = vertexes[i2];
                vec2 uv0 = texCoords[i0];
                vec2 uv1 = texCoords[i1];
                vec2 uv2 = texCoords[i2];

                float x1 = p1.x - p0.x;
                float y1 = p1.y - p0.y;
                float z1 = p1.z - p0.z;
                float x2 = p2.x - p0.x;
                float y2 = p2.y - p0.y;
                float z2 = p2.z - p0.z;

                float s1 = uv1.x - uv0.x;
                float t1 = uv1.y - uv0.y;
                float s2 = uv2.x - uv0.x;
                float t2 = uv2.y - uv0.y;

                float r = 1.0F / (s1 * t2 - s2 * t1);
                var sdir = new vec3((t2 * x1 - t1 * x2) * r, (t2 * y1 - t1 * y2) * r,
                        (t2 * z1 - t1 * z2) * r);
                var tdir = new vec3((s1 * x2 - s2 * x1) * r, (s1 * y2 - s2 * y1) * r,
                        (s1 * z2 - s2 * z1) * r);

                //tangents[i0] += sdir;
                tangents[i0] = (float)i / (float)(i + 1) * tangents[i0] + sdir / (float)(i + 1);
                //tangents[i1] += sdir;
                tangents[i1] = (float)i / (float)(i + 1) * tangents[i1] + sdir / (float)(i + 1);
                //tangents[i2] += sdir;
                tangents[i2] = (float)i / (float)(i + 1) * tangents[i2] + sdir / (float)(i + 1);

                //biTangents[i0] += tdir;
                biTangents[i0] = (float)i / (float)(i + 1) * biTangents[i0] + sdir / (float)(i + 1);
                //biTangents[i1] += tdir;
                biTangents[i1] = (float)i / (float)(i + 1) * biTangents[i1] + sdir / (float)(i + 1);
                //biTangents[i2] += tdir;
                biTangents[i2] = (float)i / (float)(i + 1) * biTangents[i2] + sdir / (float)(i + 1);
            }

            var finalTangents = new vec4[normals.Length];
            for (long a = 0; a < normals.Length; a++)
            {
                vec3 n = normals[a];
                vec3 t = tangents[a];

                // Calculate handedness
                float w = (n.cross(t).dot(biTangents[a]) < 0.0F) ? -1.0F : 1.0F;

                // Gram-Schmidt orthogonalize
                finalTangents[a] = new vec4((t - n * n.dot(t)).normalize(), w);
            }

            mesh.tangents = finalTangents;
        }

    }
}
