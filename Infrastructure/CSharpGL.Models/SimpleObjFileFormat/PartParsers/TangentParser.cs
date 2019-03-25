using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public class TangentParser : ObjParserBase {
        public override void Parse(ObjVNFContext context) {
            ObjVNFMesh mesh = context.Mesh;
            vec3[] vertexes = mesh.vertexes;// positions
            vec2[] texCoords = mesh.texCoords;
            vec3[] normals = mesh.normals;
            if (vertexes == null || texCoords == null || normals == null) { return; }
            if (vertexes.Length != texCoords.Length || vertexes.Length != normals.Length) { return; }

            ObjVNFFace[] faces = mesh.faces;
            if (faces == null || faces.Length == 0) { return; }
            // if (not triangles) { return; }
            if (faces[0].VertexIndexes().Count() != 3
                || faces[0].TexCoordIndexes().Count() != 3
                || faces[0].NormalIndexes().Count() != 3) { return; }

            var tangents = new vec3[normals.Length];
            for (int i = 0; i < faces.Length; i++) {
                var face = faces[i] as ObjVNFTriangle;
                if (face == null) { return; } // no dealing with quad.
                uint[] vertexIndexes = (from item in face.VertexIndexes() select item).ToArray();
                uint[] texCoordIndexes = (from item in face.TexCoordIndexes() select item).ToArray();
                uint[] normalIndexes = (from item in face.NormalIndexes() select item).ToArray();
                vec3 p0 = vertexes[vertexIndexes[0]];
                vec3 p1 = vertexes[vertexIndexes[1]];
                vec3 p2 = vertexes[vertexIndexes[2]];
                vec2 uv0 = texCoords[texCoordIndexes[0]];
                vec2 uv1 = texCoords[texCoordIndexes[1]];
                vec2 uv2 = texCoords[texCoordIndexes[2]];
                vec3 n0 = normals[normalIndexes[0]];
                vec3 n1 = normals[normalIndexes[1]];
                vec3 n2 = normals[normalIndexes[2]];

                vec3 q0 = p1 - p0, q1 = p2 - p0;
                float u0 = uv0.x, v0 = uv0.y, u1 = uv1.x, v1 = uv1.y, u2 = uv2.x, v2 = uv2.y;
                float coefficient = 1.0f / ((u1 - u0) * (v2 - v0) - (v1 - v0) * (u2 - u0));
                vec3 tangentFace;
                tangentFace.x = (v2 - v0) * q0.x + (v0 - v1) * q1.x;
                tangentFace.y = (v2 - v0) * q0.y + (v0 - v1) * q1.y;
                tangentFace.z = (v2 - v0) * q0.z + (v0 - v1) * q1.z;
                //vec3 binormalFace;
                //binormalFace.x = (u0 - u2) * q0.x + (u1 - u0) * q1.x;
                //binormalFace.y = (u0 - u2) * q0.y + (u1 - u0) * q1.y;
                //binormalFace.z = (u0 - u2) * q0.z + (u1 - u0) * q1.z;
                for (int t = 0; t < vertexIndexes.Length; t++) {
                    vec3 n = normals[normalIndexes[t]].normalize();
                    tangents[vertexIndexes[t]] = tangentFace - tangentFace.dot(n) * n;
                }
            }

            mesh.tangents = tangents;
        }

    }
}
