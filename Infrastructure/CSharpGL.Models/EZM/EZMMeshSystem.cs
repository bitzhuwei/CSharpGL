using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMMeshSystem
    {
        // <MeshSystem asset_name="dude.fbx" asset_info="null" mesh_system_version="1" mesh_system_asset_version="0">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static EZMMeshSystem Parse(System.Xml.Linq.XElement xElement)
        {
            EZMMeshSystem result = null;
            if (xElement.Name == "MeshSystem")
            {
                result = new EZMMeshSystem();
                {
                    var attr = xElement.Attribute("asset_name");
                    if (attr != null) { result.AssetName = attr.Value; }
                }
                {
                    var attr = xElement.Attribute("asset_info");
                    if (attr != null) { result.AssetInfo = attr.Value; }
                }
                {
                    var attr = xElement.Attribute("mesh_system_version");
                    if (attr != null) { result.Version = attr.Value; }
                }
                {
                    var attr = xElement.Attribute("mesh_system_asset_version");
                    if (attr != null) { result.AssetVersion = attr.Value; }
                }
                {
                    var skeletionRoot = xElement.ElementElement("Skeletons");
                    if (xSkeletions != null)
                    {
                        var xSkeletons = skeletionRoot.Elements("Skeleton");
                        var skeletons = new EZMSkeleton[xSkeletons.Count()];
                        int index = 0;
                        foreach (var xSkeletion in xSkeletons)
                        {
                            skeletons[index++] = EZMSkeleton.Parse(xSkeletion);
                        }
                        result.Skeletions = skeletons;
                    }
                }
                {
                    var animationRoot = xElement.ElementElement("Animations");
                    if (animationRoot != null)
                    {
                        var xAnimations = animationRoot.Elements("Animation");
                        var animations = new EZMAnimation[xAnimations.Count()];
                        int index = 0;
                        foreach (var xAnimation in xAnimations)
                        {
                            animations[index++] = EZMAnimation.Parse(xAnimation);
                        }
                        result.Animations = animations;
                    }
                }
                {
                    var materialsRoot = xElement.ElementElement("Materials");
                    if (materialsRoot != null)
                    {
                        var xMaterials = materialsRoot.Elements("Maaterial");
                        var materials = new EZMMaterial[xMaterials.Count()];
                        int index = 0;
                        foreach (var xMaterial in xMaterials)
                        {
                            materials[index++] = EZMMaterial.Parse(xMaterial);
                        }
                        result.Materials = materials;
                    }
                }
                {
                    var meshesRoot = xElement.ElementElement("Meshes");
                    if (meshesRoot != null)
                    {
                        var xMeshes = meshesRoot.Elements("Mesh");
                        var meshes = new EZMMesh[xMeshes.Count()];
                        int index = 0;
                        foreach (var xMesh in xMeshes)
                        {
                            meshes[index++] = EZMMesh.Parse(xMesh);
                        }
                        result.Meshes = meshes;
                    }
                }
            }

            return result;
        }

        public string AssetName { get; private set; }

        public string AssetInfo { get; private set; }

        public string Version { get; private set; }

        public string AssetVersion { get; private set; }

        public EZMSkeleton[] Skeletions { get; private set; }

        public EZMAnimation[] Animations { get; private set; }

        public EZMMaterial[] Materials { get; private set; }

        public EZMMesh[] Meshes { get; private set; }

    }
}
