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
    public class ObjFile
    {
        private List<ObjMesh> meshList = new List<ObjMesh>();

        /// <summary>
        /// 
        /// </summary>
        public List<ObjMesh> MeshList
        {
            get { return meshList; }
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Position { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Size { get; internal set; }
    }
}
