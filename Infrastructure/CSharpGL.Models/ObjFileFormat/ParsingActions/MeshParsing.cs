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
                string line = reader.ReadLine().Trim();
                int meshIndex = -1;
                while (true)
                {
                    if (line == null || line == string.Empty) { continue; }

                    if (line.StartsWith("vn"))
                    {
                        line = FillCurrentMeshNormals(reader, line, meshIndex, context);
                    }
                    else if (line[0] == 'v')
                    {
                        meshIndex++;
                        line = FillCurrentMeshVertexes(reader, line, meshIndex, context);
                    }
                    else if (line[0] == 'f')
                    {
                        line = FillCurrentMeshFaces(reader, line, meshIndex, context);
                    }
                    else
                    {
                        if (reader.EndOfStream) { break; }
                        else { line = reader.ReadLine().Trim(); }
                    }
                }
            }
        }

        private string FillCurrentMeshFaces(System.IO.StreamReader reader, string currentLine, int meshIndex, ObjParsingContext context)
        {
            ObjMesh mesh = context.MeshList[meshIndex];
            ObjFace[] faces;
            if (mesh.faces == null)
            {
                faces = new ObjFace[mesh.faceCount];
                mesh.faces = faces;
            }
            else
            {
                faces = mesh.faces;
            }
            faces[0] = ParseFace(currentLine);
            int index = 1;

            string line = string.Empty;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line[0] == 'f') { faces[index++] = ParseFace(line); }
                else { break; }
            }

            return line;
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

        private string FillCurrentMeshNormals(System.IO.StreamReader reader, string currentLine, int meshIndex, ObjParsingContext context)
        {
            ObjMesh mesh = context.MeshList[meshIndex];
            vec3[] normals;
            if (mesh.normals == null)
            {
                normals = new vec3[mesh.vertexCount];
                mesh.normals = normals;
            }
            else
            {
                normals = mesh.normals;
            }
            normals[0] = ParseVec3(currentLine);
            int index = 1;

            string line = string.Empty;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line.StartsWith("vn")) { normals[index++] = ParseVec3(line); }
                else { break; }
            }

            return line;
        }

        private string FillCurrentMeshVertexes(System.IO.StreamReader reader, string currentLine, int meshIndex, ObjParsingContext context)
        {
            ObjMesh mesh = context.MeshList[meshIndex];
            vec3[] vertexes;
            if (mesh.vertexes == null)
            {
                vertexes = new vec3[mesh.vertexCount];
                mesh.vertexes = vertexes;
            }
            else
            {
                vertexes = mesh.vertexes;
            }
            vertexes[0] = ParseVec3(currentLine);
            int index = 1;

            string line = string.Empty;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line.StartsWith("vn")) { break; }
                else if (line[0] == 'v') { vertexes[index++] = ParseVec3(line); }
                else { break; }
            }

            return line;
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
