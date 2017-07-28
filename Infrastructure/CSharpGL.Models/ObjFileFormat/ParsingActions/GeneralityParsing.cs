using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class GeneralityParsing : ParsingActionBase
    {

        public override void Parse(ObjParsingContext context)
        {
            using (var reader = new System.IO.StreamReader(context.ObjFilename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    if (line == null || line == string.Empty) { continue; }

                    if (line.StartsWith("vn"))
                    {
                        UpdateCurrentMeshNormalCount(reader, context);
                    }
                    else if (line[0] == 'v')
                    {
                        UpdateCurrentMeshVertexCount(reader, context);
                    }
                    else if (line[0] == 'f')
                    {
                        UpdateCurrentMeshFaceCount(reader, context);
                    }
                }
            }

            ObjMesh mesh = context.GetCurrentMesh();
            if (mesh.normalCount > 0 && mesh.normalCount != mesh.vertexCount)
            {
                throw new Exception(string.Format("mesh[{0}]'s normal count[{1}] not equal to vertex count[{2}]!",
                    context.MeshList.IndexOf(mesh), mesh.normalCount, mesh.vertexCount));
            }
        }

        private void UpdateCurrentMeshFaceCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            mesh.faceCount++;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line.StartsWith("vn")) { mesh.normalCount++; break; }
                else if (line[0] == 'v') { mesh.vertexCount++; break; }
                else if (line[0] == 'f') { mesh.faceCount++; }
                else { break; }
            }
        }

        private void UpdateCurrentMeshNormalCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            mesh.normalCount++;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line.StartsWith("vn")) { mesh.normalCount++; }
                else if (line[0] == 'v') { mesh.vertexCount++; break; }
                else if (line[0] == 'f') { mesh.faceCount++; break; }
                else { break; }
            }
        }

        private void UpdateCurrentMeshVertexCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            mesh.vertexCount++;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { break; }

                if (line.StartsWith("vn")) { mesh.normalCount++; break; }
                else if (line[0] == 'v') { mesh.vertexCount++; }
                else if (line[0] == 'f') { mesh.faceCount++; break; }
                else { break; }
            }
        }
    }
}
