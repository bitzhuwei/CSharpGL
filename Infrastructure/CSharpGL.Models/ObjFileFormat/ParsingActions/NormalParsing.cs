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
            foreach (var mesh in context.MeshList)
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
            throw new NotImplementedException();
        }

        private void CalculateNormals(ObjMesh mesh)
        {
            var faceNormals = new vec3[mesh.faceCount];
            for (int i = 0; i < mesh.faceCount; i++)
            {
                ObjFace face = mesh.faces[i];
                ivec3 vertexIndexes = face.VertexIndexes;
                vec3 v0 = mesh.vertexes[vertexIndexes.x];
                vec3 v1 = mesh.vertexes[vertexIndexes.y];
                vec3 v2 = mesh.vertexes[vertexIndexes.z];
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
                vertexNormals[vertexIndexes.x] += faceNormals[i];
                vertexNormals[vertexIndexes.y] += faceNormals[i];
                vertexNormals[vertexIndexes.z] += faceNormals[i];
                normalCounter[vertexIndexes.x]++;
                normalCounter[vertexIndexes.y]++;
                normalCounter[vertexIndexes.z]++;
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
