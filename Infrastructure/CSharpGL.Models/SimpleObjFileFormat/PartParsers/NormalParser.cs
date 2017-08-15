using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class NormalParser : ObjParserBase
    {
        public override void Parse(ObjVNFContext context)
        {
            var normals = new vec3[context.vertexCount];
            ObjVNFMesh mesh = context.Mesh;
            if (mesh.normals.Length == 0) { mesh.normals = new vec3[context.vertexCount]; }

            for (int i = 0; i < context.faceCount; i++)
            {
                ObjVNFFace face = mesh.faces[i];
                uint[] normalIndexes = (from item in face.NormalIndexes() select item).ToArray();
                uint[] vertexIndexes = (from item in face.VertexIndexes() select item).ToArray();

                if (normalIndexes.Length != vertexIndexes.Length)
                {
                    throw new Exception(string.Format(
                        "normalIndexes.Length [{0}] != vertexIndexes.Length [{0}]!",
                    normalIndexes.Length, vertexIndexes.Length));
                }

                for (int t = 0; t < vertexIndexes.Length; t++)
                {
                    normals[vertexIndexes[t]] = mesh.normals[normalIndexes[t]];
                }
            }

            mesh.normals = normals;
        }
    }
}
