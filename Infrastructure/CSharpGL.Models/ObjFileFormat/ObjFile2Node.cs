using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains a single mesh.
    /// </summary>
    public static class ObjFile2Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static ObjFileNode ToNode(this ObjFile file)
        {
            var node = new ObjFileNode();
            node.WorldPosition = file.Position;
            node.ModelSize = file.Size;
            foreach (var item in file.MeshList)
            {
                ObjMeshNode meshNode = ObjMeshNode.Create(item);
                node.Children.Add(meshNode);
            }

            return node;
        }
    }
}
