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
        /// <summary>
        /// Gets generality information for all meshes.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjParsingContext context)
        {
            using (var reader = new System.IO.StreamReader(context.ObjFilename))
            {
                ObjMesh mesh = null;
                string lastLine = string.Empty;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    if (line == null || line == string.Empty)
                    {
                    }
                    else if (line.StartsWith("vn"))
                    {
                        mesh.normalCount++;
                    }
                    else if (line[0] == 'v') // we assume that a new mesh starts with 'v' property.
                    {
                        if (lastLine[0] == 'v')
                        {
                            mesh.vertexCount++;
                        }
                        else
                        {
                            if (mesh != null) { context.ObjFile.MeshList.Add(mesh); }
                            mesh = new ObjMesh();
                            mesh.vertexCount++;
                        }
                    }
                    else if (line[0] == 'f')
                    {
                        mesh.faceCount++;
                    }

                    lastLine = line;
                }

                context.ObjFile.MeshList.Add(mesh);
            }

            //ObjMesh mesh = context.GetCurrentMesh();
            //if (mesh.normalCount > 0 && mesh.normalCount != mesh.vertexCount)
            //{
            //    throw new Exception(string.Format("mesh[{0}]'s normal count[{1}] not equal to vertex count[{2}]!",
            //        context.ObjFile.MeshList.IndexOf(mesh), mesh.normalCount, mesh.vertexCount));
            //}
        }

        private void UpdateCurrentMeshFaceCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            mesh.faceCount++;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { continue; }

                if (line.StartsWith("vn"))
                {
                    throw new Exception("The one after 'f' should only be 'v', not 'vn'!");
                }
                else if (line[0] == 'v')
                {
                    var newMesh = new ObjMesh();
                    newMesh.vertexCount++;
                    context.ObjFile.MeshList.Add(newMesh);
                    break;
                }
                else if (line[0] == 'f') { mesh.faceCount++; }
            }
        }

        private void UpdateCurrentMeshNormalCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            mesh.normalCount++;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { continue; }

                if (line.StartsWith("vn")) { mesh.normalCount++; }
                else if (line[0] == 'v') { mesh.vertexCount++; break; }
                else if (line[0] == 'f') { mesh.faceCount++; break; }
            }
        }

        private void UpdateCurrentMeshVertexCount(System.IO.StreamReader reader, ObjParsingContext context)
        {
            ObjMesh mesh = context.GetCurrentMesh();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line == null || line == string.Empty) { continue; }

                if (line.StartsWith("vn")) { mesh.normalCount++; break; }
                else if (line[0] == 'v') { mesh.vertexCount++; }
                else if (line[0] == 'f') { mesh.faceCount++; break; }
            }

            context.ObjFile.MeshList.Add(mesh);
        }
    }
}
