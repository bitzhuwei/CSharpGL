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

        public ObjParsingContext(string objFilename)
        {
            this.ObjFilename = objFilename;
        }


        public List<ObjMesh> MeshList { get; private set; }
    }
}
