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
                    var skeletionRoot = xElement.Element("Skeletons");
                    if (skeletionRoot != null)
                    {
                        var xSkeletons = skeletionRoot.Elements("Skeleton");
                        var skeletons = new EZMSkeleton[xSkeletons.Count()];
                        int index = 0;
                        foreach (var xSkeleton in xSkeletons)
                        {
                            skeletons[index++] = EZMSkeleton.Parse(xSkeleton);
                        }
                        result.Skeletons = skeletons;
                    }
                }
                {
                    var animationRoot = xElement.Element("Animations");
                    if (animationRoot != null)
                    {
                        var xAnimations = animationRoot.Elements("Animation");
                        var animations = new EZMAnimation[xAnimations.Count()];
                        int index = 0;
                        foreach (var xAnimation in xAnimations)
                        {
                            var animation = EZMAnimation.Parse(xAnimation);
                            foreach (var animTrack in animation.AnimTracks)
                            {
                                string name = animTrack.BoneName;
                                if (name != null)
                                {
                                    foreach (var skeleton in result.Skeletons)
                                    {
                                        EZMBone bone = null;
                                        if (skeleton.nameBoneDict.TryGetValue(name, out bone))
                                        {
                                            animTrack.Bone = bone;
                                            break;
                                        }
                                    }
                                }
                            }
                            animations[index++] = animation;
                        }
                        result.Animations = animations;
                    }
                }
                var nameMaterialDict = new Dictionary<string, EZMMaterial>();
                {
                    var materialsRoot = xElement.Element("Materials");
                    if (materialsRoot != null)
                    {
                        var xMaterials = materialsRoot.Elements("Material");
                        var materials = new EZMMaterial[xMaterials.Count()];
                        int index = 0;
                        foreach (var xMaterial in xMaterials)
                        {
                            var material = EZMMaterial.Parse(xMaterial);
                            nameMaterialDict.Add(material.Name, material);
                            materials[index++] = material;
                        }
                        result.Materials = materials;
                    }
                }
                {
                    var meshesRoot = xElement.Element("Meshes");
                    if (meshesRoot != null)
                    {
                        var xMeshes = meshesRoot.Elements("Mesh");
                        var meshes = new EZMMesh[xMeshes.Count()];
                        int index = 0;
                        foreach (var xMesh in xMeshes)
                        {
                            var mesh = EZMMesh.Parse(xMesh);
                            foreach (var meshSection in mesh.MeshSections)
                            {
                                string name = meshSection.MaterialName;
                                EZMMaterial material = null;
                                if (nameMaterialDict.TryGetValue(name, out material))
                                {
                                    meshSection.Material = material;
                                }
                            }
                            meshes[index++] = mesh;
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

        public EZMSkeleton[] Skeletons { get; private set; }

        public EZMAnimation[] Animations { get; private set; }

        public EZMMaterial[] Materials { get; private set; }

        public EZMMesh[] Meshes { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} skeletions {5} animations {6} materials {7} meshes.", this.AssetName, this.AssetInfo, this.Version, this.AssetVersion, this.Skeletons.Length, this.Animations.Length, this.Materials.Length, this.Meshes.Length);
        }
    }
}
