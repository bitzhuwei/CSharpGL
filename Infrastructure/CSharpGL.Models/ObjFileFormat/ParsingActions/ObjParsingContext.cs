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
            this.ObjFile = new ObjFile();
            this.ObjFile.MeshList.Add(new ObjMesh());
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjFile ObjFile { get; private set; }

        internal ObjMesh GetCurrentMesh()
        {
            return this.ObjFile.MeshList[this.ObjFile.MeshList.Count - 1];
        }
    }
}
