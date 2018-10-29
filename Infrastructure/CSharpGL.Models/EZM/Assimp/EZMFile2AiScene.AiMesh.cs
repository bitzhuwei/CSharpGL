using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public static partial class EZMFile2AiScene
    {
        private static unsafe AiMesh Parse(EZMMesh ezmMesh)
        {
            var aiMesh = new AiMesh();
            EZMVertexbuffer vertexbuffer = ezmMesh.Vertexbuffer;
            {
                // positions.
                Passbuffer passbuffer = vertexbuffer.GetBuffer("position");
                GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
                IntPtr address = pin.AddrOfPinnedObject();
                vec3* pointer = (vec3*)address.ToPointer();
                int length = passbuffer.Length();
                var array = new vec3[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = pointer[i];
                }
                aiMesh.Vertexes = array;
            }
            {
                // normals.
                Passbuffer passbuffer = vertexbuffer.GetBuffer("normal");
                GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
                IntPtr address = pin.AddrOfPinnedObject();
                vec3* pointer = (vec3*)address.ToPointer();
                int length = passbuffer.Length();
                var array = new vec3[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = pointer[i];
                }
                aiMesh.Normals = array;
            }
            {
                // normals.
                Passbuffer passbuffer = vertexbuffer.GetBuffer("texcoord1");
                GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
                IntPtr address = pin.AddrOfPinnedObject();
                vec2* pointer = (vec2*)address.ToPointer();
                int length = passbuffer.Length();
                var array = new vec2[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = pointer[i];
                }
                aiMesh.TexCoords = array;
            }
            {
                // bone weights.
                Passbuffer passbuffer = vertexbuffer.GetBuffer("blendweights");
                GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
                IntPtr address = pin.AddrOfPinnedObject();
                vec4* pointer = (vec4*)address.ToPointer();
                int length = passbuffer.Length();
                var array = new vec4[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = pointer[i];
                }
                aiMesh.boneWeights = array;
            }
            {
                // bone indexes.
                Passbuffer passbuffer = vertexbuffer.GetBuffer("blendindices");
                GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
                IntPtr address = pin.AddrOfPinnedObject();
                uvec4* pointer = (uvec4*)address.ToPointer();
                int length = passbuffer.Length();
                var array = new uvec4[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = pointer[i];
                }
                aiMesh.boneIndexes = array;
            }

            //ezmMesh.MeshSections
            return aiMesh;
        }

    }
}
