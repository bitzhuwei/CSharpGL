using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public class TexCoordParser : ObjParserBase {
        public override void Parse(ObjVNFContext context) {
            ObjVNFMesh mesh = context.Mesh;
            if (mesh.texCoords.Length > 0) {
                vec2[] texCoords = ArrangeTexCoords(context);
                mesh.texCoords = texCoords;
            }
        }

        private vec2[] ArrangeTexCoords(ObjVNFContext context) {
            var texCoords = new vec2[context.vertexCount];
            ObjVNFMesh mesh = context.Mesh;
            for (int i = 0; i < context.faceCount; i++) {
                ObjVNFFace face = mesh.faces[i];
                uint[] texCoordIndexes = face.TexCoordIndexes();
                uint[] vertexIndexes = face.VertexIndexes();

                if (texCoordIndexes.Length != vertexIndexes.Length) {
                    throw new Exception(string.Format(
                        "texCoordIndexes.Length [{0}] != vertexIndexes.Length [{1}]!",
                    texCoordIndexes.Length, vertexIndexes.Length));
                }

                for (int t = 0; t < vertexIndexes.Length; t++) {
                    texCoords[vertexIndexes[t]] = mesh.texCoords[texCoordIndexes[t]];
                }
            }

            return texCoords;
        }

    }
}
