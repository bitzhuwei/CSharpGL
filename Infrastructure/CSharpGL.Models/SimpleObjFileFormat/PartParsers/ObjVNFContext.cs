using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjVNFContext
    {
        internal int vertexCount;
        internal int normalCount;
        internal int texCoordCount;
        internal int faceCount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public ObjVNFContext(string filename)
        {
            this.ObjFilename = filename;
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjVNFMesh Mesh { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string ObjFilename { get; internal set; }
    }
}
