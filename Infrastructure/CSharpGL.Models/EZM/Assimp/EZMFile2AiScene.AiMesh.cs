using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public static partial class EZMFile2AiScene
    {
        private static unsafe AiMesh[] Parse(EZMMesh ezmMesh)
        {
            EZMVertexbuffer vertexbuffer = ezmMesh.Vertexbuffer;
            vec3[] vertexes = GetPositions(vertexbuffer);
            vec3[] normals = GetNormals(vertexbuffer);
            vec2[] texCoords = GetTexCoords(vertexbuffer);
            vec4[] boneWeights = GetBoneWeights(vertexbuffer);
            uvec4[] boneIndexes = GetBoneIndexes(vertexbuffer);

            EZMMeshSection[] meshSections = ezmMesh.MeshSections;
            var aiMeshes = new AiMesh[meshSections.Length];
            for (int i = 0; i < aiMeshes.Length; i++)
            {
                EZMMeshSection section = meshSections[i];
                var aiMesh = new AiMesh();
                aiMesh.Vertexes = vertexes;
                aiMesh.Normals = normals;
                aiMesh.TexCoords = texCoords;
                aiMesh.boneWeights = boneWeights;
                aiMesh.boneIndexes = boneIndexes;
                aiMesh.indexes = section.Indexbuffer;
                aiMesh.materialName = section.MaterialName;
                aiMeshes[i] = aiMesh;
            }

            return aiMeshes;
        }

        unsafe private static uvec4[] GetBoneIndexes(EZMVertexbuffer vertexbuffer)
        {
            Passbuffer passbuffer = vertexbuffer.GetBuffer("blendindices");
            IntPtr address = passbuffer.Mapbuffer();
            uvec4* pointer = (uvec4*)address.ToPointer();
            int length = passbuffer.Length();
            var boneIndexes = new uvec4[length];
            for (int i = 0; i < length; i++)
            {
                boneIndexes[i] = pointer[i];
            }
            passbuffer.Unmapbuffer();
            return boneIndexes;
        }

        unsafe private static vec4[] GetBoneWeights(EZMVertexbuffer vertexbuffer)
        {
            Passbuffer passbuffer = vertexbuffer.GetBuffer("blendweights");
            IntPtr address = passbuffer.Mapbuffer();
            vec4* pointer = (vec4*)address.ToPointer();
            int length = passbuffer.Length();
            var boneWeights = new vec4[length];
            for (int i = 0; i < length; i++)
            {
                boneWeights[i] = pointer[i];
            }
            passbuffer.Unmapbuffer();
            return boneWeights;
        }

        unsafe private static vec2[] GetTexCoords(EZMVertexbuffer vertexbuffer)
        {
            Passbuffer passbuffer = vertexbuffer.GetBuffer("texcoord1");
            IntPtr address = passbuffer.Mapbuffer();
            vec2* pointer = (vec2*)address.ToPointer();
            int length = passbuffer.Length();
            var texCoords = new vec2[length];
            for (int i = 0; i < length; i++)
            {
                texCoords[i] = pointer[i];
            }
            passbuffer.Unmapbuffer();
            return texCoords;
        }

        unsafe private static vec3[] GetNormals(EZMVertexbuffer vertexbuffer)
        {
            Passbuffer passbuffer = vertexbuffer.GetBuffer("normal");
            IntPtr address = passbuffer.Mapbuffer();
            vec3* pointer = (vec3*)address.ToPointer();
            int length = passbuffer.Length();
            var normals = new vec3[length];
            for (int i = 0; i < length; i++)
            {
                normals[i] = pointer[i];
            }
            passbuffer.Unmapbuffer();
            return normals;
        }

        unsafe private static vec3[] GetPositions(EZMVertexbuffer vertexbuffer)
        {
            Passbuffer passbuffer = vertexbuffer.GetBuffer("position");
            IntPtr address = passbuffer.Mapbuffer();
            vec3* pointer = (vec3*)address.ToPointer();
            int length = passbuffer.Length();
            var vertexes = new vec3[length];
            for (int i = 0; i < length; i++)
            {
                vertexes[i] = pointer[i];
            }
            passbuffer.Unmapbuffer();
            return vertexes;
        }

    }
}
