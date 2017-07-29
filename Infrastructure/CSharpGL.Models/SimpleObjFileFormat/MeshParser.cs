using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class MeshParser : ObjParserBase
    {
        private readonly char[] separator = new char[] { ' ' };
        public override void Parse(ObjVNFContext context)
        {
            var objVNF = new ObjVNFMesh();
            var vertexes = new vec3[context.vertexCount];
            var normals = new vec3[context.normalCount];
            var faces = new ObjVNFFace[context.faceCount];
            string filename = context.ObjFilename;
            using (var reader = new System.IO.StreamReader(filename))
            {
                int vertexIndex = 0, normalIndex = 0, faceIndex = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length <= 0) { continue; }

                    if (parts[0] == "v") { vertexes[vertexIndex++] = ParseVec3(parts); }
                    else if (parts[0] == "vn") { normals[normalIndex++] = ParseVec3(parts); }
                    else if (parts[0] == "f") { faces[faceIndex++] = ParseFace(parts); }
                }

                objVNF.vertexes = vertexes;
                objVNF.normals = normals;
                objVNF.faces = faces;

                if (vertexIndex != context.vertexCount)
                { throw new Exception(string.Format("v: [{0}] not equals to [{1}] in MeshParser!", vertexIndex, context.vertexCount)); }
                if (normalIndex != context.normalCount)
                { throw new Exception(string.Format("vn: [{0}] not equals to [{1}] in MeshParser!", normalIndex, context.normalCount)); }
                if (faceIndex != context.faceCount)
                { throw new Exception(string.Format("f: [{0}] not equals to [{1}] in MeshParser!", vertexIndex, context.vertexCount)); }
            }
        }

        private ObjVNFFace ParseFace(string[] parts)
        {
            throw new NotImplementedException();
        }

        private vec3 ParseVec3(string[] parts)
        {
            throw new NotImplementedException();
        }
    }
}
