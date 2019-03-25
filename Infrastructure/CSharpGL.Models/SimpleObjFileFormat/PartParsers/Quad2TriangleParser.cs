using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public class Quad2TriangleParser : ObjParserBase {
        private readonly char[] separator = new char[] { ' ' };
        /// <summary>
        /// Reads mesh's vertex count, normal count and face count.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjVNFContext context) {
            int triangleFaceCount = 0;
            ObjVNFMesh mesh = context.Mesh;
            for (int i = 0; i < context.faceCount; i++) {
                ObjVNFFace face = mesh.faces[i];
                uint[] vertexIndexes = face.VertexIndexes();

                if (face is ObjVNFTriangle) {
                    triangleFaceCount++;
                }
                else if (face is ObjVNFQuad) {
                    triangleFaceCount += 2;
                }
            }

            if (triangleFaceCount != context.faceCount) {
                var faces = new ObjVNFTriangle[triangleFaceCount];
                for (int i = 0, j = 0; i < context.faceCount; i++) {
                    ObjVNFFace face = mesh.faces[i];
                    if (face is ObjVNFTriangle) {
                        faces[j++] = face as ObjVNFTriangle;
                    }
                    else if (face is ObjVNFQuad) {
                        var quad = face as ObjVNFQuad;
                        faces[j++] = new ObjVNFTriangle(
                            quad.vertexIndexes[0], quad.vertexIndexes[1], quad.vertexIndexes[2],
                            quad.normalIndexes[0], quad.normalIndexes[1], quad.normalIndexes[2],
                            quad.texCoordIndexes[0], quad.texCoordIndexes[1], quad.texCoordIndexes[2]);
                        faces[j++] = new ObjVNFTriangle(
                            quad.vertexIndexes[0], quad.vertexIndexes[2], quad.vertexIndexes[3],
                            quad.normalIndexes[0], quad.normalIndexes[2], quad.normalIndexes[3],
                            quad.texCoordIndexes[0], quad.texCoordIndexes[2], quad.texCoordIndexes[3]);
                    }
                }
                mesh.faces = faces;
                context.faceCount = triangleFaceCount;
            }
        }
    }
}
