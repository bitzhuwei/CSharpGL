using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public static partial class EZMFile2AiScene
    {
        public static AiScene Parse(this EZMFile ezmFile)
        {
            if (ezmFile == null) { throw new ArgumentNullException(); }

            var aiScene = new AiScene();
            aiScene.Fullname = ezmFile.Fullname;
            // root node.
            {
                EZMSkeleton skeleton = ezmFile.MeshSystem.Skeletons[0];
                EZMBone[] bones = skeleton.Bones;
                aiScene.RootNode = Parse(bones[0]);
                Match(aiScene.RootNode, bones[0]);
            }
            // meshes.
            {
                EZMMesh[] ezmMeshes = ezmFile.MeshSystem.Meshes;
                var aiMeshes = new AiMesh[ezmMeshes.Length];
                for (int i = 0; i < aiMeshes.Length; i++)
                {
                    aiMeshes[i] = Parse(ezmMeshes[i]);
                }
                aiScene.Meshes = aiMeshes;
            }
            // materials.
            {
                EZMMaterial[] ezmMaterials = ezmFile.MeshSystem.Materials;
                var aiMaterials = new AiMaterial[ezmMaterials.Length];
                for (int i = 0; i < aiMaterials.Length; i++)
                {
                    aiMaterials[i] = Parse(ezmMaterials[i]);
                }
                aiScene.Materials = aiMaterials;
            }
            // animations.
            {
                EZMAnimation[] ezmAnimations = ezmFile.MeshSystem.Animations;
                var aiAnimations = new AiAnimation[ezmAnimations.Length];
                for (int i = 0; i < ezmAnimations.Length; i++)
                {
                    aiAnimations[i] = Parse(ezmAnimations[i]);
                }
                aiScene.Animations = aiAnimations;
            }

            return aiScene;
        }

    }
}
