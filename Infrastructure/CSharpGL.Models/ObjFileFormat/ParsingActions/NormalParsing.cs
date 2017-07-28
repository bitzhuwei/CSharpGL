using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class NormalParsing : ParsingActionBase
    {
        /// <summary>
        /// prepare normals for all meshes.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjParsingContext context)
        {
            foreach (var mesh in context.ObjFile.MeshList)
            {
                PrepareNormals(mesh);
            }
        }

        private void PrepareNormals(ObjMesh mesh)
        {
            if (mesh.normals == null)
            {
                CalculateNormals(mesh);
            }
            else
            {
                ArrangeNormals(mesh);
            }
        }

        private void ArrangeNormals(ObjMesh mesh)
        {
            var normals = new vec3[mesh.vertexCount];
            var normalCounter = new int[mesh.vertexCount];
            for (int i = 0; i < mesh.faceCount; i++)
            {
                ObjFace face = mesh.faces[i];
                ivec3 vertexIndexes = face.VertexIndexes;
                ivec3 normalIndexes = face.NormalIndexes;
                for (int t = 0; t < 3; t++)
                {
                    if (normalCounter[vertexIndexes[t]] > 0)
                    {
                        if (normals[vertexIndexes[t]] != mesh.normals[normalIndexes[t]])
                        {
                            throw new Exception(string.Format("Different values[{0}][{1}] for the same normal at index[{2}]!",
                                normals[vertexIndexes[t]], mesh.normals[normalIndexes[t]], vertexIndexes[t]));
                        }
                    }
                    else
                    {
                        normals[vertexIndexes[t]] = mesh.normals[normalIndexes[t]];
                    }
                }
            }

            mesh.normals = normals;
        }

        private void CalculateNormals(ObjMesh mesh)
        {
            var faceNormals = new vec3[mesh.faceCount];
            for (int i = 0; i < mesh.faceCount; i++)
            {
                ObjFace face = mesh.faces[i];
                ivec3 vertexIndexes = face.VertexIndexes;
                vec3 v0 = mesh.vertexes[vertexIndexes[0]];
                vec3 v1 = mesh.vertexes[vertexIndexes[1]];
                vec3 v2 = mesh.vertexes[vertexIndexes[2]];
                vec3 vector01 = v0 - v1;
                vec3 vector12 = v1 - v2;
                vec3 normal = vector01.cross(vector12);
                faceNormals[i] = normal.normalize();
            }

            var vertexNormals = new vec3[mesh.vertexCount];
            var normalCounter = new int[mesh.vertexCount];
            for (int i = 0; i < mesh.faceCount; i++)
            {
                ObjFace face = mesh.faces[i];
                ivec3 vertexIndexes = face.VertexIndexes;
                vertexNormals[vertexIndexes[0]] += faceNormals[i];
                vertexNormals[vertexIndexes[1]] += faceNormals[i];
                vertexNormals[vertexIndexes[2]] += faceNormals[i];
                normalCounter[vertexIndexes[0]]++;
                normalCounter[vertexIndexes[1]]++;
                normalCounter[vertexIndexes[2]]++;
            }
            for (int i = 0; i < vertexNormals.Length; i++)
            {
                if (normalCounter[i] != 0)
                {
                    vertexNormals[i] = (vertexNormals[i] / normalCounter[i]).normalize();
                }
            }

            mesh.normals = vertexNormals;
        }

    }
}
