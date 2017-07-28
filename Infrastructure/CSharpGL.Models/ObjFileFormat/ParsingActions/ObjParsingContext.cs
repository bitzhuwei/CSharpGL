using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class ObjParsingContext
    {
        /// <summary>
        /// 
        /// </summary>
        public string ObjFilename { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFilename"></param>
        public ObjParsingContext(string objFilename)
        {
            this.ObjFilename = objFilename;
            this.MeshList = new List<ObjMesh>();
            this.MeshList.Add(new ObjMesh());
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ObjMesh> MeshList { get; private set; }

        internal ObjMesh GetCurrentMesh()
        {
            return this.MeshList[this.MeshList.Count - 1];
        }
    }
}
