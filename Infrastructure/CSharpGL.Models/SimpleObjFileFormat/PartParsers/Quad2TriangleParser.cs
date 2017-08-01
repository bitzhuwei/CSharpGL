using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class Quad2TriangleParser : ObjParserBase
    {
        private readonly char[] separator = new char[] { ' ' };
        /// <summary>
        /// Reads mesh's vertex count, normal count and face count.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjVNFContext context)
        {
            int triangleFaceCount = 0;
            ObjVNFMesh mesh = context.Mesh;
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

                if (face is ObjVNFTriangle)
                {
                    triangleFaceCount++;
                }
                else if (face is ObjVNFQuad)
                {
                    triangleFaceCount += 2;
                }
            }

            if (triangleFaceCount != context.faceCount)
            {
                var faces = new ObjVNFTriangle[triangleFaceCount];
                for (int i = 0, j = 0; i < context.faceCount; i++)
                {
                    ObjVNFFace face = mesh.faces[i];
                    if (face is ObjVNFTriangle)
                    {
                        faces[j++] = face as ObjVNFTriangle;
                    }
                    else if (face is ObjVNFQuad)
                    {
                        var quad = face as ObjVNFQuad;
                        faces[j++] = new ObjVNFTriangle(
                            quad.vertexIndexes[0], quad.vertexIndexes[1], quad.vertexIndexes[2],
                            quad.normalIndexes[0], quad.normalIndexes[1], quad.normalIndexes[2]);
                        faces[j++] = new ObjVNFTriangle(
                            quad.vertexIndexes[0], quad.vertexIndexes[2], quad.vertexIndexes[3],
                            quad.normalIndexes[0], quad.normalIndexes[2], quad.normalIndexes[3]);
                    }
                }
                mesh.faces = faces;
                context.faceCount = triangleFaceCount;
            }
        }
    }
}
