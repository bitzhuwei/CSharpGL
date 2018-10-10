using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMMeshSystem
    {
        // <MeshSystem asset_name="dude.fbx" asset_info="null" mesh_system_version="1" mesh_system_asset_version="0">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        internal static EZMMeshSystem Parse(System.Xml.Linq.XElement xElement)
        {
            EZMMeshSystem result = null;
            if (xElement.Name == "MeshSystem")
            {
                result = new EZMMeshSystem();
                result.AssetName = xElement.Attribute("asset_name").Value;
                result.AssetInfo = xElement.Attribute("asset_info").Value;
                result.Version = xElement.Attribute("mesh_system_version").Value;
                result.AssetVersion = xElement.Attribute("mesh_system_asset_version").Value;
                {
                    var xMaterials = xElement.Element("Materials").Elements("Maaterial");
                    var materials = new EZMMaterial[xMaterials.Count()];
                    int index = 0;
                    foreach (var xMaterial in xMaterials)
                    {
                        materials[index++] = EZMMaterial.Parse(xMaterial);
                    }
                    result.Materials = materials;
                }
                {
                    var xMeshes = xElement.Element("Meshes").Elements("Mesh");
                    var meshes = new EZMMesh[xMeshes.Count()];
                    int index = 0;
                    foreach (var xMesh in xMeshes)
                    {
                        meshes[index++] = EZMMesh.Parse(xMesh);
                    }
                    result.Meshes = meshes;
                }
            }

            return result;
        }

        public string AssetName { get; private set; }

        public string AssetInfo { get; private set; }

        public string Version { get; private set; }

        public string AssetVersion { get; private set; }

        public EZMMaterial[] Materials { get; private set; }

        public EZMMesh[] Meshes { get; private set; }

    }
}
