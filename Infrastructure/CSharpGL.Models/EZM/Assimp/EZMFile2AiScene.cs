using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public static class EZMFile2AiScene
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
            // meshes
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

        private static AiAnimation Parse(EZMAnimation eZMAnimation)
        {
            throw new NotImplementedException();
        }

        private static AiMaterial Parse(EZMMaterial eZMMaterial)
        {
            throw new NotImplementedException();
        }

        private static AiMesh Parse(EZMMesh ezmMesh)
        {
            throw new NotImplementedException();
        }

        private static void Match(AiNode aiNode, EZMBone ezmBone)
        {
            foreach (var childBone in ezmBone.children)
            {
                var childNode = Parse(childBone);
                aiNode.Children.Add(childNode);
                Match(childNode, childBone);
            }
        }

        private static AiNode Parse(EZMBone ezmBone)
        {
            var aiNode = new AiNode();
            aiNode.Name = ezmBone.Name;
            aiNode.Transform = ezmBone.state.matrix;

            return aiNode;
        }
    }
}
