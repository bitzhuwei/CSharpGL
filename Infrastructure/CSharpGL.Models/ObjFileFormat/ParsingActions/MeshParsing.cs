using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class MeshParsing : ParsingActionBase
    {
        /// <summary>
        /// Fill in meshes' vertex, normal and face infromation.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjParsingContext context)
        {
            using (var reader = new System.IO.StreamReader(context.ObjFilename))
            {
                ObjMesh mesh = null;
                int vertexIndex = 0, normalIndex = 0, faceIndex = 0, meshIndex = 0;
                string lastLine = string.Empty;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    if (line == null || line == string.Empty)
                    {
                    }
                    else if (line.StartsWith("vn"))
                    {
                        if (mesh.normals == null) { mesh.normals = new vec3[mesh.normalCount]; }
                        mesh.normals[normalIndex++] = ParseVec3(line);
                    }
                    else if (line[0] == 'v') // we assume that a new mesh starts with 'v' property.
                    {
                        if (lastLine[0] == 'v')
                        {
                            mesh.vertexes[vertexIndex++] = ParseVec3(line);
                        }
                        else
                        {
                            if (mesh == null) { mesh = context.ObjFile.MeshList[meshIndex++]; }
                            vertexIndex = 0; normalIndex = 0; faceIndex = 0;
                            mesh.vertexes[vertexIndex++] = ParseVec3(line);
                        }
                    }
                    else if (line[0] == 'f')
                    {
                        if (mesh.faces == null) { mesh.faces = new ObjFace[mesh.faceCount]; }
                        mesh.faces[faceIndex++] = ParseFace(line);
                    }

                    lastLine = line;
                }
            }
        }

        private ObjFace ParseFace(string currentLine)
        {
            string[] parts = currentLine.Split(spaceSlash, StringSplitOptions.RemoveEmptyEntries);
            int vx, vy, vz, nx, ny, nz;
            ParseFace(parts[0], out vx, out nx);
            ParseFace(parts[1], out vy, out ny);
            ParseFace(parts[2], out vz, out nz);

            return new ObjFace() { VertexIndexes = new ivec3(vx, vy, vz), NormalIndexes = new ivec3(nx, ny, nz) };
        }

        private static readonly char[] spaceSlash = new char[] { ' ', '/' };
        /// <summary>
        /// face indexes starts with 1 in *.obj files.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="v"></param>
        /// <param name="n"></param>
        private void ParseFace(string vertex, out int v, out int n)
        {
            if (!vertex.Contains('/'))
            {
                v = int.Parse(vertex) - 1;
                n = v;
            }
            else
            {
                string[] parts = vertex.Split(spaceSlash, StringSplitOptions.RemoveEmptyEntries);
                v = int.Parse(parts[0]) - 1;
                n = int.Parse(parts[parts.Length - 1]) - 1;
            }
        }

        private static readonly char[] space = new char[] { ' ' };
        /// <summary>
        /// v x y z
        /// </summary>
        /// <param name="currentLine"></param>
        /// <returns></returns>
        private vec3 ParseVec3(string currentLine)
        {
            string[] parts = currentLine.Split(space, StringSplitOptions.RemoveEmptyEntries);
            var x = float.Parse(parts[1]);
            var y = float.Parse(parts[2]);
            var z = float.Parse(parts[3]);

            return new vec3(x, y, z);
        }

    }
}
