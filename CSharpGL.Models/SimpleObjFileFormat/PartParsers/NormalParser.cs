﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class NormalParser : ObjParserBase {
        private bool reverseNormal;

        public NormalParser(bool reverseNormal = false) {
            this.reverseNormal = reverseNormal;
        }
        public override void Parse(ObjVNFContext context) {
            vec3[] normals = null;
            ObjVNFMesh mesh = context.Mesh;
            if (mesh.normals.Length == 0) {
                normals = CalculateNormals(context);
            }
            else {
                normals = ArrangeNormals(context);
            }

            mesh.normals = normals;
        }

        private vec3[] ArrangeNormals(ObjVNFContext context) {
            var normals = new vec3[context.vertexCount];
            ObjVNFMesh mesh = context.Mesh;
            for (int i = 0; i < context.faceCount; i++) {
                ObjVNFFace face = mesh.faces[i];
                uint[] normalIndexes = face.NormalIndexes();
                uint[] vertexIndexes = face.VertexIndexes();

                if (normalIndexes.Length != vertexIndexes.Length) {
                    throw new Exception(string.Format(
                        "normalIndexes.Length [{0}] != vertexIndexes.Length [{1}]!",
                    normalIndexes.Length, vertexIndexes.Length));
                }


                for (int t = 0; t < vertexIndexes.Length; t++) {
                    normals[vertexIndexes[t]] =
                        reverseNormal ? -mesh.normals[normalIndexes[t]] : mesh.normals[normalIndexes[t]];
                }
            }

            return normals;
        }


        private vec3[] CalculateNormals(ObjVNFContext context) {
            ObjVNFMesh mesh = context.Mesh;
            var faceNormals = new vec3[context.faceCount];
            for (int i = 0; i < context.faceCount; i++) {
                ObjVNFFace face = mesh.faces[i];
                uint[] vertexIndexes = face.VertexIndexes();
                vec3 v0 = mesh.vertexes[vertexIndexes[0]];
                vec3 v1 = mesh.vertexes[vertexIndexes[1]];
                vec3 v2 = mesh.vertexes[vertexIndexes[2]];

                vec3 normal = (v0 - v1).cross(v0 - v2).normalize();
                faceNormals[i] = normal;
            }

            var normals = new vec3[context.vertexCount];
            var counters = new int[context.vertexCount];
            for (int i = 0; i < context.faceCount; i++) {
                ObjVNFFace face = mesh.faces[i];
                uint[] vertexIndexes = face.VertexIndexes();
                vec3 v0 = mesh.vertexes[vertexIndexes[0]];
                vec3 v1 = mesh.vertexes[vertexIndexes[1]];
                vec3 v2 = mesh.vertexes[vertexIndexes[2]];

                normals[vertexIndexes[0]] += faceNormals[i];
                counters[vertexIndexes[0]]++;
                normals[vertexIndexes[1]] += faceNormals[i];
                counters[vertexIndexes[1]]++;
                normals[vertexIndexes[2]] += faceNormals[i];
                counters[vertexIndexes[2]]++;
            }
            for (int i = 0; i < normals.Length; i++) {
                if (counters[i] > 0) {
                    normals[i] = reverseNormal ? -normals[i].normalize() : normals[i].normalize();
                }
            }

            return normals;
        }
    }
}
