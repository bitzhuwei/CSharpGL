using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class MeshParser : ObjParserBase
    {
        private readonly char[] separator = new char[] { ' ' };
        /// <summary>
        /// Reads mesh's vertexes, normals and faces.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjVNFContext context)
        {
            var objVNF = new ObjVNFMesh();
            var vertexes = new vec3[context.vertexCount];
            var normals = new vec3[context.normalCount];
            var texCoords = new vec2[context.texCoordCount];
            var faces = new ObjVNFFace[context.faceCount];
            string filename = context.ObjFilename;
            int vertexIndex = 0, normalIndex = 0, texCoordIndex = 0, faceIndex = 0;
            using (var reader = new System.IO.StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length <= 0) { continue; }

                    if (parts[0] == "v") { vertexes[vertexIndex++] = ParseVec3(parts); }
                    else if (parts[0] == "vn") { normals[normalIndex++] = ParseVec3(parts); }
                    else if (parts[0] == "vt") { texCoords[texCoordIndex++] = ParseVec2(parts); }
                    else if (parts[0] == "f") { faces[faceIndex++] = ParseFace(parts); }
                }
            }

            objVNF.vertexes = vertexes;
            objVNF.normals = normals;
            objVNF.texCoords = texCoords;
            objVNF.faces = faces;

            context.Mesh = objVNF;

            if (vertexIndex != context.vertexCount)
            { throw new Exception(string.Format("v: [{0}] not equals to [{1}] in MeshParser!", vertexIndex, context.vertexCount)); }
            if (normalIndex != context.normalCount)
            { throw new Exception(string.Format("vn: [{0}] not equals to [{1}] in MeshParser!", normalIndex, context.normalCount)); }
            if (texCoordIndex != context.texCoordCount)
            { throw new Exception(string.Format("vt: [{0}] not equals to [{1}] in MeshParser!", texCoordIndex, context.texCoordCount)); }
            if (faceIndex != context.faceCount)
            { throw new Exception(string.Format("f: [{0}] not equals to [{1}] in MeshParser!", vertexIndex, context.vertexCount)); }
            if (faceIndex > 0)
            {
                Type type = faces[0].GetType();
                for (int i = 1; i < faceIndex; i++)
                {
                    if (faces[i].GetType() != type)
                    {
                        throw new Exception(string.Format("Different face types [{0}] vs [{1}]!", type, faces[i].GetType()));
                    }
                }
            }
        }

        private ObjVNFFace ParseFace(string[] parts)
        {
            ObjVNFFace result = null;
            if (parts.Length == 4)// f 1 2 3
            {
                uint v0, v1, v2, n0, n1, n2, t0, t1, t2;
                ParseFaceUnit(parts[1], out v0, out n0, out t0);
                ParseFaceUnit(parts[2], out v1, out n1, out t1);
                ParseFaceUnit(parts[3], out v2, out n2, out t2);
                // index in obj files starts with 1.
                result = new ObjVNFTriangle(v0 - 1, v1 - 1, v2 - 1, n0 - 1, n1 - 1, n2 - 1, t0 - 1, t1 - 1, t2 - 1);
            }
            else if (parts.Length == 5)// f 1 2 3 4
            {
                uint v0, v1, v2, v3, n0, n1, n2, n3, t0, t1, t2, t3;
                ParseFaceUnit(parts[1], out v0, out n0, out t0);
                ParseFaceUnit(parts[2], out v1, out n1, out t1);
                ParseFaceUnit(parts[3], out v2, out n2, out t2);
                ParseFaceUnit(parts[4], out v3, out n3, out t3);

                // index in obj files starts with 1.
                result = new ObjVNFQuad(v0 - 1, v1 - 1, v2 - 1, v3 - 1, n0 - 1, n1 - 1, n2 - 1, n3 - 1, t0 - 1, t1 - 1, t2 - 1, t3 - 1);
            }
            else
            {
                throw new Exception(string.Format("unexpected line parts[{0}]", parts.Length));
            }

            return result;
        }

        private readonly char[] separator2 = new char[] { '/' };
        /// <summary>
        /// 1/2/3
        /// 1//3
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="vertexIndex"></param>
        /// <param name="normalIndex"></param>
        private void ParseFaceUnit(string unit, out uint vertexIndex, out uint normalIndex, out uint texCoordIndex)
        {
            string[] parts = unit.Split(separator2, StringSplitOptions.None);
            if (parts.Length == 1)
            {
                vertexIndex = uint.Parse(parts[0]);
                texCoordIndex = 0;
                normalIndex = 0;
            }
            else if (parts.Length == 2)
            {
                vertexIndex = uint.Parse(parts[0]);
                texCoordIndex = uint.Parse(parts[1]);
                normalIndex = 0;
            }
            else if (parts.Length == 3)
            {
                vertexIndex = uint.Parse(parts[0]);
                texCoordIndex = uint.Parse(parts[2]);
                normalIndex = uint.Parse(parts[1]);
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// v 1 2 3
        /// vn 1 2 3
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        private vec3 ParseVec3(string[] parts)
        {
            var x = float.Parse(parts[1]);
            var y = float.Parse(parts[2]);
            var z = float.Parse(parts[3]);

            return new vec3(x, y, z);
        }

        /// <summary>
        /// vt 1 2
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        private vec2 ParseVec2(string[] parts)
        {
            var x = float.Parse(parts[1]);
            var y = float.Parse(parts[2]);

            return new vec2(x, y);
        }
    }
}
